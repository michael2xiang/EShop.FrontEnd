using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Basket
{
    public class BasketItemBusinessRules
    {
        public static readonly BusinessRule BasketRequired =
            new BusinessRule("Basket", "a basket item must be related to a bastet");
        public static readonly BusinessRule ProductRequired =
            new BusinessRule("Product", "a basket item must be realate to a product");
        public static readonly BusinessRule QtyInvalid = new BusinessRule("Qty",
            "the quantity of a basket item cannot be negative");
    }
}
