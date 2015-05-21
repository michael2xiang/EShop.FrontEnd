using System.Web;

namespace EShop.FrontEnd.Core.Helpers
{
    public static class UrlHelper
    {
        public static string Resolve(string url)
        {
            HttpRequest requset = HttpContext.Current.Request;
            return string.Format("{0}://{1}{2}{3}", requset.Url.Scheme,
                requset.ServerVariables["HTTP_HOST"],
                (requset.ApplicationPath.Equals("/")) ? string.Empty : requset.ApplicationPath, url
                );
        }
    }
}
