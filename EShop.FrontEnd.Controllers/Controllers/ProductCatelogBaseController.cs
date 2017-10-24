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

    public class ProductCatelogBaseController : Controller
    {
        private readonly IProductCatalogService _productCatelogService;
        public ProductCatelogBaseController(IProductCatalogService productCatelogService)
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
