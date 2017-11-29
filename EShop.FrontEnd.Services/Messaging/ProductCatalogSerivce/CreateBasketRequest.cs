using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class CreateBasketRequest
    {
        public CreateBasketRequest()
        {
            ProductsToAdd = new List<int>();
        }
        public IList<int> ProductsToAdd { get; set; }
    }
}
