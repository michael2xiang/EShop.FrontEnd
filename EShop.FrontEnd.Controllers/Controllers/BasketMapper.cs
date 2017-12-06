using EShop.FrontEnd.Controllers.ViewModels;
using EShop.FrontEnd.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public static class BasketMapper
    {
        public static BasketSummaryView ConvertToSummary(this BasketView basket)
        {
            return new BasketSummaryView
            {
                BasketTotal = basket.BasketTotal,
                NumberOfItems =basket.NumberOfItems
            };
        }
    }
}
