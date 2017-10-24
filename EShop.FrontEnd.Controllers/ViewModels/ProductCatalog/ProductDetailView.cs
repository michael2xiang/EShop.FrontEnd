using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Controllers.ViewModels.ProductCatalog
{
    public class ProductDetailView:BaseProductCatalogPageView
    {
        public ProductView Product { get; set; }
    }
}
