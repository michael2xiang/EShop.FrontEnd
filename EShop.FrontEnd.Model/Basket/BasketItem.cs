using EShop.FrontEnd.Core.Domain;
using EShop.FrontEnd.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Basket
{
    public class BasketItem : EntityBase<int>
    {
        private int _qty;
        private Product _product;
        private BasketModel _basket;

        public BasketItem(Product product, BasketModel basket, int qty)
        {
            _product = product;
            _basket = basket;
            _qty = qty;
        }

        public decimal LineTotal()
        {
            return _product.Price * _qty;
        }
        public int Qty { get { return _qty; } }
        public Product Product { get { return _product; } }
        public BasketModel Basket { get { return _basket; } }
        public bool Contain(Product product)
        {
            return product == _product;
        }
        public void IncreaseItemQtyBy(int qty)
        {
            _qty += qty;
        }
        public void ChangeItemQtyTo(int qty)
        {
            _qty = qty;
        }

        protected override void Validate()
        {
            if (_qty < 0)
                base.addBrokenRule(BasketItemBusinessRules.QtyInvalid);

            if (Product == null)
                base.addBrokenRule(BasketItemBusinessRules.ProductRequired);

            if (Basket == null)
                base.addBrokenRule(BasketItemBusinessRules.BasketRequired);

        }
    }
}
