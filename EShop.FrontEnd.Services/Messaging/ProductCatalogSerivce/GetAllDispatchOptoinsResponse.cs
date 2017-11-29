using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce
{
    public class GetAllDispatchOptoinsResponse
    {
        public IEnumerable<DeliveryOptionView> DeliveryOptions { get; set; }
    }
}
