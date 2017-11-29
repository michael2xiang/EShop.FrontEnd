using AutoMapper;
using EShop.FrontEnd.Model.Basket;
using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Mapping
{
    public static class BasketMapper
    {
        public static BasketView ConvertToBasketView(this BasketModel basket)
        {
            return Mapper.Map<BasketModel, BasketView>(basket);
        }
    }
}
