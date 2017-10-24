using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Interfaces;
using System.Web.Mvc;
using EShop.FrontEnd.Controllers.ViewModels.ProductCatalog;

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

            return View(homePageView);
        }
    }
}
