using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.CookieStorage
{
    public interface ICookieStorageService
    {
        void Save(string key, string value, DateTime expires);
        string Retrieve(string key);
    }
}
