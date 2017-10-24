using EShop.FrontEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Model.Categories;
using EShop.FrontEnd.Services.Mapping;
using EShop.FrontEnd.Core.Querying;

namespace EShop.FrontEnd.Services.Implementations
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductTitleRepository _productTitleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public ProductCatalogService(IProductTitleRepository productTitleRepository,
            IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productTitleRepository = productTitleRepository;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            IEnumerable<Category> categories = _categoryRepository.FindAll();
            response.Categories = categories.ConvertToCategoryViews();
            return response;
        }

        public GetFeatureProductsResponse GetFeatureProducts()
        {
            GetFeatureProductsResponse response = new GetFeatureProductsResponse();
            Query productQuery = new Query();
            productQuery.OrderByClause = new OrderByClause() {
                    Dese = true,
                    PropertyName= PropertyNameHelper.ResolvePorpertyName<ProductTitle>(pt=>pt.Price)
            };
            response.Products = _productTitleRepository.FindBy(productQuery,0,6).ConverToProductviews();
            return response;
        }

        public GetProductResponse GetProduct(GetProductRequest requset)
        {
            GetProductResponse response = new GetProductResponse();
            ProductTitle productTitle = _productTitleRepository.FindBy(requset.ProductId);
            response.Product = productTitle.ConvertToProductDetailView();
            return response;
        }

        public GetProductsByCategoryResponse GetProductByCategory(GetProductsByCategoryRequest request)
        {
            GetProductsByCategoryResponse response = new GetProductsByCategoryResponse();
            Query productQuery = ProductSearchRequestQueryGenerator.CreateQueryFor(request);
            IEnumerable<Product> productsMatchingRefinement = GetAllProductsMatchingQueryAndSort(request, productQuery);
            response = productsMatchingRefinement.CreaterProductSearchResultFrom(request);
            response.SelectedCategoryName = _categoryRepository.FindBy(request.CategoryId).Name;
            return response;
        }

        private IEnumerable<Product> GetAllProductsMatchingQueryAndSort(GetProductsByCategoryRequest request, Query productQuery)
        {
            IEnumerable<Product> productsMatchingRefinement = _productRepository.FindBy(productQuery);
            switch (request.SortBy)
            {
                case ProductsSortBy.PriceLowToHight:
                    productsMatchingRefinement = productsMatchingRefinement.OrderBy(p => p.Price);
                    break;
                case ProductsSortBy.PriceHightToLow:
                    productsMatchingRefinement = productsMatchingRefinement.OrderByDescending(p => p.Price);
                    break;
            }
            return productsMatchingRefinement;
        }
    }
}
