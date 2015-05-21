
namespace EShop.FrontEnd.Core.Helpers
{
    public static class PriceHelper
    {
        public static string FormatMoney(this decimal price)
        {
            return string.Format("￥{0}", price);
        }
    }
}
