using AutoMapper;
using EShop.FrontEnd.Model.Shipping;
using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Mapping
{
    public static class DeliveryOptionMapper
    {
        public static IEnumerable<DeliveryOptionView> ConvertToDeliveryOptionViews
            (this IEnumerable<DeliveryOption> deliveryOptions)
        {
            return Mapper.Map<IEnumerable<DeliveryOption>, IEnumerable<DeliveryOptionView>>(deliveryOptions);
        }
    }
}
