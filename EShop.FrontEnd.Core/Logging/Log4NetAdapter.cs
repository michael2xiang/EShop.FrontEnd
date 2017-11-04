using EShop.FrontEnd.Core.Configuration;
using log4net;
using log4net.Config;
using System.Web;

namespace EShop.FrontEnd.Core.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _log;

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(HttpContext.Current.Server.MapPath("~") + "Config\\log4net.config"));
            _log = LogManager.GetLogger(ApplicationSettingsFactory.GetApplicationSettings().LoggerName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }
}
