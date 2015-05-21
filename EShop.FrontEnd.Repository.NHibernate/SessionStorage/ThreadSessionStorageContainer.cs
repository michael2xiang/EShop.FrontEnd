using NHibernate;
using System.Collections;
using System.Threading;

namespace EShop.FrontEnd.Repository.NHibernate.SessionStorage
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable _nhSession = new Hashtable();
        public ISession GetCurrentSession()
        {
            ISession nhsession = null;
            if (_nhSession.Contains(GetThreadName()))
                nhsession = (ISession)_nhSession[GetThreadName()];

            return nhsession;
        }

        public void Store(ISession session)
        {
            if (_nhSession.Contains(GetThreadName()))
                _nhSession[GetThreadName()] = session;
            else
                _nhSession.Add(GetThreadName(), session);
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
