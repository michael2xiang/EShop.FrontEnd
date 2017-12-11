using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Core.CookieStorage;
using EShop.FrontEnd.Services.Interfaces;
using System.Web.Mvc;
using EShop.FrontEnd.Controllers.ViewModels.ProductCatalog;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Controllers.ViewModels;
using EShop.FrontEnd.Services.Implementations;

namespace EShop.FrontEnd.Controllers.Controllers
{
    public class BasketController : ProductCatelogBaseController
    {
        private readonly IBasketService _basketServcie;
        private readonly ICookieStorageService _cookieStorageService;

        public BasketController(IBasketService basketService, ICookieStorageService cookieStorageService, IProductCatalogService productCatelogService) : base(cookieStorageService, productCatelogService)
        {
            _basketServcie = basketService;
            _cookieStorageService = cookieStorageService;
        }

        public ActionResult Detail()
        {
            BasketDetailView basketView = new BasketDetailView();
            Guid basketId = base.GetBasketId();

            GetBasketRequest basketRequest = new GetBasketRequest() {
                BasketId = basketId
            };
            var basketResponse = _basketServcie.GetBasket(basketRequest);
            GetAllDispatchOptoinsResponse dispathOpiontsResponse =
                _basketServcie.GetAllDispatchOptions();

            basketView.Basket = basketResponse.Basket;
            basketView.Categories = base.GetCategories();
            basketView.DeliveryOptions = dispathOpiontsResponse.DeliveryOptions;
            basketView.BasketSummary = base.GetBasketSummaryView();

            return View("View", basketView);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult RemoveItem(int productId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.ItemsToRemove.Add(productId);
            request.BasketId = base.GetBasketId();

            ModifyBasketResponse response = _basketServcie.ModifyBasket(request);

            SaveBasketSummaryToCookie(response.Basket.NumberOfItems, response.Basket.BasketTotal);

            BasketDetailView basketDetailView = new BasketDetailView();
            basketDetailView.BasketSummary = new ViewModels.BasketSummaryView
            {
                BasketTotal = response.Basket.BasketTotal,
                NumberOfItems = response.Basket.NumberOfItems
            };
            basketDetailView.Basket = response.Basket;
            basketDetailView.DeliveryOptions = _basketServcie.GetAllDispatchOptions().DeliveryOptions;

            return Json(basketDetailView);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UpdateShipping(int shippingServiceId)
        {
            ModifyBasketRequest request = new ModifyBasketRequest();
            request.SetShippingServiceIdTo = shippingServiceId;
            request.BasketId = base.GetBasketId();

            BasketDetailView basketDetailView = new BasketDetailView();

            ModifyBasketResponse response = _basketServcie.ModifyBasket(request);
            SaveBasketSummaryToCookie(response.Basket.NumberOfItems, response.Basket.BasketTotal);
            basketDetailView.Basket = response.Basket;
            basketDetailView.BasketSummary = new ViewModels.BasketSummaryView {
                BasketTotal = response.Basket.BasketTotal,
                NumberOfItems = response.Basket.NumberOfItems
            };
            basketDetailView.DeliveryOptions = _basketServcie.GetAllDispatchOptions().DeliveryOptions;
            return Json(basketDetailView);
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public JsonResult UpdateItems(JsonBasketQtyUpdateRequest jsonBasketQtyUpdateRequest)
        //{
        //    ModifyBasketRequest request = new ModifyBasketRequest();
        //    request.BasketId = base.GetBasketId();
        //    request.ItemsToUpdate = jsonBasketQtyUpdateRequest.con

        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult AddtoBasket(int productId)
        {
            BasketSummaryView basketSummaryView = new BasketSummaryView();
            Guid basketId = base.GetBasketId();
            bool createNewBasket = basketId == Guid.Empty;
            if (createNewBasket == false)
            {
                ModifyBasketRequest modifyBasketRequest = new ModifyBasketRequest();
                modifyBasketRequest.ProductsToAdd.Add(productId);
                modifyBasketRequest.BasketId = basketId;
                try
                {
                    ModifyBasketResponse response = _basketServcie.ModifyBasket(modifyBasketRequest);
                    basketSummaryView = response.Basket.ConvertToSummary();
                    SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems, basketSummaryView.BasketTotal);
                }
                catch (BasketDoesNotExistException ex)
                {
                    createNewBasket = true;
                }
            }

            if (createNewBasket)
            {
                CreateBasketRequest createBasketRequest = new CreateBasketRequest();
                createBasketRequest.ProductsToAdd.Add(productId);

                CreateBasketResponse response = _basketServcie.CreateBasket(createBasketRequest);

                SaveBasketIdToCookie(response.Basket.Id);
                basketSummaryView = response.Basket.ConvertToSummary();
                SaveBasketSummaryToCookie(basketSummaryView.NumberOfItems, basketSummaryView.BasketTotal);
            }
            return Json(basketSummaryView);
        }

        private void SaveBasketIdToCookie(Guid id)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketId.ToString(), 
                id.ToString(), DateTime.Now.AddDays(1));
        }

        private void SaveBasketSummaryToCookie(int numberOfItems, string basketTotal)
        {
            _cookieStorageService.Save(CookieDataKeys.BasketItems.ToString(), 
                numberOfItems.ToString(), DateTime.Now.AddDays(1));
            _cookieStorageService.Save(CookieDataKeys.BasketTotal.ToString(),
                basketTotal.ToString(), DateTime.Now.AddDays(1));
        }
    }
}
