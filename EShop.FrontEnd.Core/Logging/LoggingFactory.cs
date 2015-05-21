
namespace EShop.FrontEnd.Core.Logging
{
    public class LoggingFactory
    {
        private static ILogger _logger;
        public static void InitLogginFactory(ILogger logger)
        {
            _logger = logger;
        }
        public static ILogger GetLogger()
        {
            return _logger;
        }
    }
}
