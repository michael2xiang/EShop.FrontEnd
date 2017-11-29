using System;
using System.Collections.Generic;
using System.IO;
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
            string str = "{\"CategoryId\":\"1\",\"Index\":1,\"SortBy\":\"2\",\"RefinementGroups\":[]}";

            //using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(str)))
            using (var streamrd = new StreamReader(controllerContext.HttpContext.Request.InputStream))
            {
                //TODO:获取不了请求的json，所以报错
                string json = streamrd.ReadToEnd();
                using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
                {
                    var serializer = new DataContractJsonSerializer(bindingContext.ModelType);
                    //var b = serializer.ReadObject(ms);
                    //return b;
                    //var inputStream = controllerContext.HttpContext.Request.InputStream;

                    var obj = serializer.ReadObject(ms);
                    return obj;
                }

            }




    }
    }
}
