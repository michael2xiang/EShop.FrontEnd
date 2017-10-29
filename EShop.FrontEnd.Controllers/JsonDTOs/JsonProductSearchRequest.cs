using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
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
    public class JsonProductSearchRequest
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public int[] ColorIds { get; set; }
        [DataMember]
        public int[] SizeIds { get; set; }
        [DataMember]
        public int[] BrandIds { get; set; }
        [DataMember]
        public ProductsSortBy SortBy { get; set; }
        [DataMember]
        public IEnumerable<JsonRefinementGroup> RefinementGroups { get; set; }
        [DataMember]
        public int Index { get; set; }

    }
}
