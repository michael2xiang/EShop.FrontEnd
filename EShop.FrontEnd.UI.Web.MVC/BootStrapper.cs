using EShop.FrontEnd.Model.Categories;
using EShop.FrontEnd.Core.Logging;
using EShop.FrontEnd.Core.UnitOfWork;
using EShop.FrontEnd.Core.Configuration;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Services.Implementations;
using EShop.FrontEnd.Services.Interfaces;
using StructureMap;
using StructureMap.Configuration.DSL;
using EShop.FrontEnd.Core.Email;
using StructureMap.Configuration;
using System.ComponentModel.DataAnnotations;

namespace EShop.FrontEnd.UI.Web.MVC
{
    public static class BootStrapper
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<ICategoryRepository>().Use<Repository.NHibernate.
                    Repositories.CategoryRepository>();
                x.For<IProductTitleRepository>().Use<Repository.NHibernate.Repositories.ProductTitleRepository>();
                x.For<IProductRepository>().Use<Repository.NHibernate.
                  Repositories.ProductRepository>();
                x.For<IUnitOfWork>().Use<Repository.NHibernate.NHUnitOfWork>();
                x.For<IProductCatalogService>().Use<ProductCatalogService>();
                x.For<IApplicationSettings>().Use<WebConfigApplicationSettings>();
                x.For<ILogger>().Use<Log4NetAdapter>();
                x.For<IEmailService>().Use<TextLoggingEmailService>();
            });
        }

    }
}