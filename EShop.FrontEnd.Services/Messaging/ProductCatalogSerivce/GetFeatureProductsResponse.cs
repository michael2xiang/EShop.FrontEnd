using System.Collections.Generic;
using EShop.FrontEnd.Services.ViewModels;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class GetFeatureProductsResponse
    {
        public IEnumerable<ProductSummaryView> Products { get; set; }
    }
}
