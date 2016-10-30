namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal class GroupBy
    {
        internal static string WithParamsExpression<T>(params Expression<Func<T,object>>[] columns)
        {
            var expression = ExpressionHelper.GetExpressionPropertyNames(columns).Select(e => e.AddSqlBrackets()).Aggregate((c, n) => c + "," + n);
            return string.Concat(Constants.Sql.GroupBy, expression," ");
        }

        internal static string WithExpression<T>(Expression<Func<T,object>> column)
        {
            var expression = ExpressionHelper.GetExpressionPropertyName(column);
            return string.Concat(Constants.Sql.GroupBy, expression.AddSqlBrackets(), " ");
        }

        internal static string WithIEnumerableString(IEnumerable<string> columns)
        {
            var expression = columns.Select(e => e.AddSqlBrackets()).Aggregate((c, n) => c + "," + n);
            return string.Concat(Constants.Sql.GroupBy, expression," ");
        }

        internal static string WihtString(string value)
        {
            return string.Concat(Constants.Sql.GroupBy, value," ");
        }

        internal static string JustGroupBy()
        {
            return Constants.Sql.GroupBy;
        }
    }
}