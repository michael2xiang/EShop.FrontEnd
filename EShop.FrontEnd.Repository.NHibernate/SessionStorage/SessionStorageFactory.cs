using System.Web;

namespace EShop.FrontEnd.Repository.NHibernate.SessionStorage
{
    public static class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    _nhSessionContainer = new ThreadSessionStorageContainer();
                }
                else
                {
                    _nhSessionContainer = new HttpSessionContainer();
                }
            }
            return _nhSessionContainer;
        }

    }
}
