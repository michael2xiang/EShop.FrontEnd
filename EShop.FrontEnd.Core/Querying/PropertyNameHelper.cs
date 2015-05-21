﻿using System;
using System.Linq.Expressions;

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
