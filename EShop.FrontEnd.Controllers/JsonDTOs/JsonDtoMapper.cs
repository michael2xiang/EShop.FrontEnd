using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Controllers.JsonDTOs
{
    public static class JsonDtoMapper
    {
        public static IList<ProductQtyUpdateRequest>
            ConvertToBasketItemUpdateRequests(this JsonBasketItemUpdateRequest request)
        {
            return request.Items.ConvertToBasketItemUpdateRequests();
        }

        public static IList<ProductQtyUpdateRequest> ConvertToBasketItemUpdateRequests
            (this JsonBasketItemUpdateDataRequest[] requests)
        {
            int i = 0;
            IList<ProductQtyUpdateRequest> itemRequests = new List<ProductQtyUpdateRequest>();
            for (i = 0; i < requests.Length; i++)
            {
                itemRequests.Add(requests[i].ConvertToBasketItemUpdateRequest());
            }
            return itemRequests;
        }
        public static ProductQtyUpdateRequest ConvertToBasketItemUpdateRequest(
            this JsonBasketItemUpdateDataRequest request)
        {
            return new ProductQtyUpdateRequest
            {
                ProductId = request.ProductId,
                NewQty = request.Qty
            };
        }
    }
}
