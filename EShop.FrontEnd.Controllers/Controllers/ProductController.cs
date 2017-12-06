using EShop.FrontEnd.Controllers.JsonDTOs;
using EShop.FrontEnd.Controllers.ViewModels.ProductCatalog;
using EShop.FrontEnd.Core.Configuration;
using EShop.FrontEnd.Core.CookieStorage;
using EShop.FrontEnd.Services.Interfaces;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public class ProductController :ProductCatelogBaseController
    {
        private readonly IProductCatalogService _prodcutService;

        public ProductController(
            ICookieStorageService cookieStorageService,
            IProductCatalogService productService)
            :base(cookieStorageService, productService)
        {
            _prodcutService = productService;
        }

        public ActionResult GetProductsByCategory(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest =
                GenerateInitialProductSearchRequestFrom(categoryId);
            GetProductsByCategoryResponse response =
                _prodcutService.GetProductByCategory(productSearchRequest);
            ProductSearchResultView productSearchResultView =
                GetProductSearchResultViewFrom(response);
            return View("ProductSearchResults", productSearchResultView);
        }

        private GetProductsByCategoryRequest GenerateInitialProductSearchRequestFrom(int categoryId)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();
            productSearchRequest.NumberOfResultsPerPage = 
                int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.CategoryId = categoryId;
            productSearchRequest.Index = 1;
            productSearchRequest.SortBy = ProductsSortBy.PriceHightToLow;
            return productSearchRequest;
        }

        private ProductSearchResultView GetProductSearchResultViewFrom(GetProductsByCategoryResponse response)
        {
            ProductSearchResultView productSearchResultView =
                new ProductSearchResultView();
            productSearchResultView.BasketSummary = base.GetBasketSummaryView();
            productSearchResultView.Categories = base.GetCategories();
            productSearchResultView.CurrentPage = response.CurrentPage;
            productSearchResultView.NumberOfTitlesFound = response.NumberOfTitlesFound;
            productSearchResultView.Products = response.products;
            productSearchResultView.RefinementGroups = response.RefinementGroups;
            productSearchResultView.SelectedCategoryName = response.SelectedCategoryName;
            productSearchResultView.TotalNumberOfPages = response.TotalNumberOfPages;
            return productSearchResultView;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProductsByAjax(JsonProductSearchRequest request)
        {
            GetProductsByCategoryRequest productSearchRequeset = GeneratProductSearchRequestFrom(request);
            GetProductsByCategoryResponse response = _prodcutService.GetProductByCategory(productSearchRequeset);
            ProductSearchResultView productSearchResultView = GetProductSearchResultViewFrom(response);
            return Json(productSearchResultView);

        }

        private GetProductsByCategoryRequest GeneratProductSearchRequestFrom(JsonProductSearchRequest request)
        {
            GetProductsByCategoryRequest productSearchRequest = new GetProductsByCategoryRequest();

            productSearchRequest.NumberOfResultsPerPage =
                int.Parse(ApplicationSettingsFactory.GetApplicationSettings().NumberOfResultsPerPage);
            productSearchRequest.Index = request.Index;
            productSearchRequest.CategoryId = request.CategoryId;
            productSearchRequest.SortBy = request.SortBy;

            List<RefinementGroup> refinementGroups = new List<RefinementGroup>();
            RefinementGroup refinementGroup;
            foreach (var jsonRefinementGroup in request.RefinementGroups)
            {
                switch ((RefinementGroupings)jsonRefinementGroup.GroupId)
                {
                    case RefinementGroupings.brand:
                        productSearchRequest.BrandIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.color:
                        productSearchRequest.ColorIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    case RefinementGroupings.size:
                        productSearchRequest.SizeIds = jsonRefinementGroup.SelectedRefinements;
                        break;
                    default:
                        break;
                }
            }
            return productSearchRequest;
        }

        public ActionResult Detail(int id)
        {
            ProductDetailView productDetailView = new ProductDetailView();
            GetProductRequest request = new GetProductRequest() { ProductId = id };
            GetProductResponse response = _prodcutService.GetProduct(request);
            ProductView productView = response.Product;
            productDetailView.Product = productView;
            productDetailView.Categories = base.GetCategories();
            productDetailView.BasketSummary = base.GetBasketSummaryView();
            return View(productDetailView);
        }
    }
}
