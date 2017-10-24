using StructureMap;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace EShop.FrontEnd.Controllers
{
    public class IoCControllerFactory:DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
