using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.FrontEnd.Controllers.JsonDTOs
{
    [DataContract]
    [ModelBinder(typeof(JsonModelBinder))]
    public class JsonBasketItemUpdateDataRequest
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Qty { get; set; }
    }
}
