using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class ModifyBasketRequest
    {
        public ModifyBasketRequest()
        {
            ItemsToRemove = new List<int>();
            ItemsToUpdate = new List<ProductQtyUpdateRequest>();
            ProductsToAdd = new List<int>();
        }
        public Guid BasketId { get; set; }
        public IList<int> ItemsToRemove { get; set; }
        public IList<ProductQtyUpdateRequest> ItemsToUpdate { get; set; }
        public int SetShippingServiceIdTo { get; set; }
        public IList<int> ProductsToAdd { get; set; }
    }
    

}
