using EShop.FrontEnd.Repository.NHibernate.SessionStorage;
using NHibernate;
using NHibernate.Cfg;

namespace EShop.FrontEnd.Repository.NHibernate
{
    public class SessionFactory
    {
        private static ISessionFactory _sessionFactory;
        private static void Init()
        {
            Configuration config = new Configuration();
            config.AddAssembly("EShop.FrontEnd.Repository.NHibernate");

            log4net.Config.XmlConfigurator.Configure();

            config.Configure();
            _sessionFactory = config.BuildSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            if (_sessionFactory == null)
                Init();
            return _sessionFactory;
        }

        private static ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static ISession GetCurrentSession()
        {
            ISessionStorageContainer sessionStorageContainer = SessionStorageFactory.GetStorageContainer();
            ISession currentSession = sessionStorageContainer.GetCurrentSession();
            if (currentSession == null)
            {
                currentSession = GetNewSession();
                sessionStorageContainer.Store(currentSession);
            }
            return currentSession;
        }
    }
}
