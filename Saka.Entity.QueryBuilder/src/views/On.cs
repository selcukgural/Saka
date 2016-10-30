using System;
using System.Linq.Expressions;

namespace Saka.Entity.QueryBuilder
{
    internal static class On
    {
        internal static string WithExpression<T, K>(Expression<Func<T,object>> TCondition,
            Expression<Func<K, object>> KCondition)
        {
            var tcondition = ExpressionHelper.GetExpressionPropertyName(TCondition);
            var kcondition = ExpressionHelper.GetExpressionPropertyName(KCondition);

            var tType = typeof (T).Name;
            var kType = typeof (K).Name;

            return string.Concat(Constants.Sql.On, tType, ".", tcondition, " = ", kType, ".", kcondition, " ");
        }

        internal static string WihtString(string condition, string condition2)
        {
            return string.Concat(Constants.Sql.On, condition," = ", condition2, " ");
        }

        internal static string JustOn()
        {
            return Constants.Sql.On;
        }
    }
}