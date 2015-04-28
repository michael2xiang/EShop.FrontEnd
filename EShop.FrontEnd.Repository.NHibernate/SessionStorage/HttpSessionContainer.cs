using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using System.Web;

namespace EShop.FrontEnd.Repository.NHibernate.SessionStorage
{
    public class HttpSessionContainer : ISessionStorageContainer
    {
        private string _sessionKey = "NHibernate";
        public ISession GetCurrentSession()
        {
            ISession nhsession = null;
            if (HttpContext.Current.Items.Contains(_sessionKey))
                nhsession = (ISession)HttpContext.Current.Items[_sessionKey];

            return nhsession;
        }

        public void Store(ISession session)
        {
            if (HttpContext.Current.Items.Contains(_sessionKey))
                HttpContext.Current.Items[_sessionKey] = session;
            else
                HttpContext.Current.Items.Add(_sessionKey, session);
        }
    }
}
