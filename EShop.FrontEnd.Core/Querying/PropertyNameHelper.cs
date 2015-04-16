using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Querying
{
    public static class PropertyNameHelper
    {
        public static string ResolvePorpertyName<T>(Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr != null)
            {
                var u = expression.Body as UnaryExpression;
                expr = u.Operand as MemberExpression;
            }
            return expr.ToString().Substring(expr.ToString().IndexOf(".") + 1);
        }
    }
}
