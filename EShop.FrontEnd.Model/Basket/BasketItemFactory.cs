using EShop.FrontEnd.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Basket
{
    public static class BasketItemFactory
    {
        public static BasketItem CreateItemFor(Product product, BasketModel basket)
        {
            return new BasketItem(product, basket, 1);
        } 
    }
}
