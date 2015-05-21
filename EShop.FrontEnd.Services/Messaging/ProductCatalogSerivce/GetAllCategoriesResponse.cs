using System.Collections.Generic;
using EShop.FrontEnd.Services.ViewModels;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class GetAllCategoriesResponse
    {
        public IEnumerable<CategoryView> Categories { get; set; }
    }
}
