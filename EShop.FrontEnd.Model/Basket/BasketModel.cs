using EShop.FrontEnd.Core.Domain;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Model.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Basket
{
    public class BasketModel : EntityBase<Guid>, IAggregateRoot
    {
        private IList<BasketItem> _items;
        private IDeliveryOption _deliveryOption;
        public BasketModel()
        {
            _items = new List<BasketItem>();
            _deliveryOption = new NullDeliveryOption();
        }
        public Guid Id { get; set; }
        public int NumberOfItems { get { return _items.Sum(i => i.Qty); } }
        public decimal BasketTotal { get { return ItemsTotal + DeliveryCost(); } }
        public decimal ItemsTotal { get { return _items.Sum(i => i.Qty * i.Product.Price); } }

        public void Add(Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                GetItemFor(product).IncreaseItemQtyBy(1);
            }
            else {
                _items.Add(BasketItemFactory.CreateItemFor(product, this));
            }
        }

        private bool BasketContainsAnItemFor(Product product)
        {
            return _items.Any(i => i.Contain(product));
        }

        private BasketItem GetItemFor(Product product)
        {
            return _items.Where(i => i.Contain(product)).FirstOrDefault();
        }

        public void Remove(Product product)
        {
            if (BasketContainsAnItemFor(product))
            {
                _items.Remove(GetItemFor(product));
            }
        }

        public void ChangeQtyOfProduct(int qty, Product product)
        {
            if(BasketContainsAnItemFor(product))
            {
                GetItemFor(product).ChangeItemQtyTo(qty);
            }
        }
        public int NumbetOfItemsInBasket()
        {
            return _items.Sum(i => i.Qty);
        }
        public IEnumerable<BasketItem> Items()
        {
            return _items;
        }
        public decimal DeliveryCost()
        {
            return DeliveryOption.GetDeliveryChargeForBasketTotalOf(ItemsTotal);
        }
        public IDeliveryOption DeliveryOption
        {
            get { return _deliveryOption; }
        }

        public void SetDeliveryOption(IDeliveryOption deliveryOption)
        {
            _deliveryOption = deliveryOption;
        }

        protected override void Validate()
        {
            if (DeliveryOption == null)
                base.addBrokenRule(BasketBusinessRules.DeliveryOptionRequied);

            foreach (BasketItem item in this.Items())
            {
                if (item.GetBrokenRules().Count() > 0)
                    base.addBrokenRule(BasketBusinessRules.ItemInvalid);
            }

        }
    }
}
