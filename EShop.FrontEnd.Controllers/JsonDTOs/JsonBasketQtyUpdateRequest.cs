using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;

namespace EShop.FrontEnd.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketItemUpdateRequest
    {
        [DataMember]
        public JsonBasketItemUpdateDataRequest[] Items { get; set; }


    }
}
