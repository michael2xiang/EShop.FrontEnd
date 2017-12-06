using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Interfaces;
using System.Web.Mvc;
using EShop.FrontEnd.Controllers.ViewModels.ProductCatalog;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Core.CookieStorage;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public class HomeController : ProductCatelogBaseController
    {
        private readonly IProductCatalogService _productCatelogService;
        public HomeController(
            ICookieStorageService cookieStorageService,
            IProductCatalogService productCatelogService) : base(cookieStorageService,productCatelogService)
        {
            _productCatelogService = productCatelogService;
        }
        //TODO
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();
            homePageView.BasketSummary = base.GetBasketSummaryView();

            GetFeatureProductsResponse response = _productCatelogService.GetFeatureProducts();
            homePageView.Products = response.Products;

            return View(homePageView);
        }
    }
}
