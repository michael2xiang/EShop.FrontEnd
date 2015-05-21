
namespace EShop.FrontEnd.Core.Configuration
{
   public  class ApplicationSettingsFactory
    {
       private static IApplicationSettings _applicationSettings;

       public static void InitApplicationSettingsFactory(IApplicationSettings applicationSettings)
       {
           _applicationSettings = applicationSettings;
       }

       public static IApplicationSettings GetApplicationSettings()
       {
           return _applicationSettings;
       }
    }
}
