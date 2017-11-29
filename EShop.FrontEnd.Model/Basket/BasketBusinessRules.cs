using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Basket
{
    public class BasketBusinessRules
    {
        public static readonly BusinessRule DeliveryOptionRequied =
            new BusinessRule("DeliveryOption", "a basket must have a valid delivery option");
        public static readonly BusinessRule ItemInvalid =
            new BusinessRule("Item", "a basket cannot have any invalid items");
    }
}
