using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Interfaces
{
    public interface IBasketService
    {

        GetBastetResponse GetBasket(GetBasketRequest basketRequest);
        CreateBasketResponse CreateBasket(CreateBasketRequest basketRequest);
        ModifyBasketResponse ModifyBasket(ModifyBasketRequest request);
        GetAllDispatchOptoinsResponse GetAllDispatchOptions();
    }
}
