using EShop.FrontEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using EShop.FrontEnd.Model.Basket;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Model.Shipping;
using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Services.ViewModels;
using EShop.FrontEnd.Services.Mapping;

namespace EShop.FrontEnd.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDeliveryOptionRepository _deliveryOptionRepository;
        private readonly IUnitOfWork _uow;
        public BasketService(IBasketRepository basketRepository, IProductRepository productRepository
            , IDeliveryOptionRepository deliveryOptionRepository, IUnitOfWork uow)
        {
            _basketRepository = basketRepository;
            _productRepository = productRepository;
            _deliveryOptionRepository = deliveryOptionRepository;
            _uow = uow;
        }


        public CreateBasketResponse CreateBasket(CreateBasketRequest basketRequest)
        {
            CreateBasketResponse response = new CreateBasketResponse();
            BasketModel basket = new BasketModel();
            basket.SetDeliveryOption(GetCheapestDeliveryOption());
            AddProductsToBasket(basketRequest.ProductsToAdd, basket);
            ThrowExceptoinIfBasketIsInValid(basket);
            _basketRepository.Save(basket);
            _uow.Commit();
            response.Basket = basket.ConvertToBasketView();
            return response;
        }

        private void ThrowExceptoinIfBasketIsInValid(BasketModel basket)
        {
            if (basket.GetBrokenRules().Count() > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("there were problems saving the basket:");
                foreach (var item in basket.GetBrokenRules())
                {
                    sb.AppendLine(item.Rule);
                }
                throw new ApplicationException(sb.ToString());
            }
        }

        private void AddProductsToBasket(IList<int> productsToAdd, BasketModel basket)
        {
            Product product;
            if (productsToAdd.Count() > 0)
            {
                foreach (var id in productsToAdd)
                {
                    product = _productRepository.FindBy(id);
                    basket.Add(product);
                }
            }
        }

        private DeliveryOption GetCheapestDeliveryOption()
        {
            return _deliveryOptionRepository.FindAll().OrderBy(d => d.Cost).FirstOrDefault();
        }

        public GetAllDispatchOptoinsResponse GetAllDispatchOptions()
        {
            GetAllDispatchOptoinsResponse response = new GetAllDispatchOptoinsResponse();
            response.DeliveryOptions = _deliveryOptionRepository.FindAll()
                .OrderBy(d => d.Cost).ConvertToDeliveryOptionViews();
            return response;
        }

        public GetBastetResponse GetBasket(GetBasketRequest basketRequest)
        {
            GetBastetResponse response = new GetBastetResponse();
            BasketModel basket = _basketRepository.FindBy(basketRequest.BasketId);
            BasketView basketView;
            if (basket != null)
                basketView = basket.ConvertToBasketView();
            else
                basketView = new BasketView();

            response.Basket = basketView;
            return response;
        }

        public ModifyBasketResponse ModifyBasket(ModifyBasketRequest request)
        {
            ModifyBasketResponse response = new ModifyBasketResponse();
            BasketModel basket = _basketRepository.FindBy(request.BasketId);
            if (basket == null)
                throw new BasketDoesNotExistException();

            AddProductsToBasket(request.ProductsToAdd, basket);
            UpdateLineQtys(request.ItemsToUpdate, basket);
            RemoveItemsFromBasket(request.ItemsToRemove, basket);

            if (request.SetShippingServiceIdTo != 0)
            {
                DeliveryOption deliveryOption = _deliveryOptionRepository.
                    FindBy(request.SetShippingServiceIdTo);
                basket.SetDeliveryOption(deliveryOption);
            }
            ThrowExceptoinIfBasketIsInValid(basket);
            _basketRepository.Save(basket);
            _uow.Commit();
            response.Basket = basket.ConvertToBasketView();
            return response;
        }

        private void RemoveItemsFromBasket(IList<int> itemsToRemove, BasketModel basket)
        {
            foreach (var item in itemsToRemove)
            {
                Product product = _productRepository.FindBy(item);
                if (product != null)
                    basket.Remove(product);
            }
        }

        private void UpdateLineQtys(IList<ProductQtyUpdateRequest> itemsToUpdate, BasketModel basket)
        {
            foreach (var item in itemsToUpdate)
            {
                Product product = _productRepository.FindBy(item.ProductId);
                if (product != null)
                    basket.ChangeQtyOfProduct(item.NewQty, product);
            }
        }
    }
}
