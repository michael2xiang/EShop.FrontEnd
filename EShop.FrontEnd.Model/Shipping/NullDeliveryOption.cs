using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Shipping
{
    public class NullDeliveryOption : IDeliveryOption
    {
        public decimal Cost
        {
            get
            {
                return 0;
            }
        }

        public decimal FreeDeliveryThreshold
        {
            get
            {
                return 0;
            }
        }

        public int Id
        {
            get;set;
        }

        public ShippingService ShippingService
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            return 0;
        }
    }
}
