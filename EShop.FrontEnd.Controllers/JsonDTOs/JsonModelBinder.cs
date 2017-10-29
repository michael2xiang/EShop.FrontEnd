using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EShop.FrontEnd.Controllers.JsonDTOs
{
    public class JsonModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext == null)
            {
                throw new ArgumentException("controllerContext");
            }
            if (bindingContext == null)
            {
                throw new ArgumentException("bindingContext");
            }

            var serializer = new DataContractJsonSerializer(bindingContext.ModelType);

            return serializer.ReadObject(controllerContext.HttpContext.Request.InputStream);
        }
    }
}
