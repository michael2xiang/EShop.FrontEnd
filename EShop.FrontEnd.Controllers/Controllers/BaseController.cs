using EShop.FrontEnd.Controllers.ViewModels;
using EShop.FrontEnd.Core.CookieStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public class BaseController :Controller
    {
        private readonly ICookieStorageService _cookieStorageService;
        public BaseController(ICookieStorageService cookieStorageService)
        {
            _cookieStorageService = cookieStorageService;
        }

        public BasketSummaryView GetBasketSummaryView()
        {
            string basketTotal = "";
            int numberOfItems = 0;
            if (!string.IsNullOrEmpty(_cookieStorageService
                .Retrieve(CookieDataKeys.BasketTotal.ToString())))
            {
                basketTotal = _cookieStorageService.Retrieve(CookieDataKeys.BasketTotal.ToString());
            }
            if (!string.IsNullOrEmpty(_cookieStorageService
              .Retrieve(CookieDataKeys.BasketItems.ToString())))
            {
                numberOfItems = int.Parse(_cookieStorageService.Retrieve(CookieDataKeys.BasketItems.ToString()));
            }

            return new BasketSummaryView
            {
                BasketTotal = basketTotal,
                NumberOfItems = numberOfItems
            };
        }
        public Guid GetBasketId()
        {
            string tmpBasketId = _cookieStorageService.Retrieve(CookieDataKeys.BasketId.ToString());
            Guid basketId = Guid.Empty;
            if (!string.IsNullOrEmpty(tmpBasketId))
            {
                basketId = new Guid(tmpBasketId);
            }
            return basketId;
        }
    }
}
