using EShop.FrontEnd.Controllers;
using EShop.FrontEnd.Core.Configuration;
using EShop.FrontEnd.Core.Email;
using EShop.FrontEnd.Core.Logging;
using EShop.FrontEnd.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EShop.FrontEnd.UI.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}",new {favion=@"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            // Use LocalDB for Entity Framework by default
            Database.DefaultConnectionFactory = new SqlConnectionFactory(@"Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BootStrapper.ConfigureDependencies();
            AutoMapperBootStrapper.ConfigureAutoMapper();
            ApplicationSettingsFactory.InitApplicationSettingsFactory(
                ObjectFactory.GetInstance<IApplicationSettings>()
                );
            LoggingFactory.InitLogginFactory(ObjectFactory.GetInstance<ILogger>());
            EmailServiceFactory.InitEmailService(ObjectFactory.GetInstance<IEmailService>());
            ControllerBuilder.Current.SetControllerFactory(new IoCControllerFactory());
            LoggingFactory.GetLogger().Log("application started");
        }
    }
}