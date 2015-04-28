using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(decimal price)
        {
            return string.Format("￥{0}", price);
        }
    }
}
