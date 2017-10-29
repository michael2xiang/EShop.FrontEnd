using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Interfaces;
using System.Web.Mvc;
using EShop.FrontEnd.Controllers.ViewModels.ProductCatalog;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public class HomeController : ProductCatelogBaseController
    {
        private readonly IProductCatalogService _productCatelogService;
        public HomeController(IProductCatalogService productCatelogService) : base(productCatelogService)
        {
            _productCatelogService = productCatelogService;
        }
        //TODO
        public ActionResult Index()
        {
            HomePageView homePageView = new HomePageView();
            homePageView.Categories = base.GetCategories();

            GetFeatureProductsResponse response = _productCatelogService.GetFeatureProducts();
            homePageView.Products = response.Products;

            return View(homePageView);
        }
    }
}
