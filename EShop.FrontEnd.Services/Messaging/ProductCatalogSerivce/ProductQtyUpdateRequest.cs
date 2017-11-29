using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class ProductQtyUpdateRequest
    {
        public int ProductId { get; set; }
        public int NewQty { get; set; }
    }
}
