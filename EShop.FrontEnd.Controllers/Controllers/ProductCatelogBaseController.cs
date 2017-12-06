using EShop.FrontEnd.Core.CookieStorage;
using EShop.FrontEnd.Services.Interfaces;
using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.FrontEnd.Controllers.Controllers
{

    public class ProductCatelogBaseController : BaseController
    {
        private readonly IProductCatalogService _productCatelogService;
        public ProductCatelogBaseController(
            ICookieStorageService cookieStorageService,
            IProductCatalogService productCatelogService):base(cookieStorageService)
        {
            _productCatelogService = productCatelogService;
        }

        public IEnumerable<CategoryView> GetCategories()
        {
            var response = _productCatelogService.GetAllCategories();
            return response.Categories;
        }
    }
}
