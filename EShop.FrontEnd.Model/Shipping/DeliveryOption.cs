using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Shipping
{
    public class DeliveryOption : EntityBase<int>,IAggregateRoot, IDeliveryOption
    {
        private readonly decimal _freeDeliveryThreshold;
        private readonly decimal _cost;
        private readonly ShippingService _shippingService;

        public DeliveryOption(decimal freeDeliveryThreshold, decimal cost, ShippingService shippingService)
        {
            _freeDeliveryThreshold = freeDeliveryThreshold;
            _cost = cost;
            _shippingService = shippingService;
        }

        public decimal Cost
        {
            get
            {
                return _cost;
            }
        }

        public decimal FreeDeliveryThreshold
        {
            get
            {
                return _freeDeliveryThreshold;
            }
        }


        public ShippingService ShippingService
        {
            get
            {
                return _shippingService;
            }
        }

        public decimal GetDeliveryChargeForBasketTotalOf(decimal total)
        {
            if (total > FreeDeliveryThreshold)
                return 0;
            return Cost;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
