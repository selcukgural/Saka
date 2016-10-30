namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal static class Columns
    {

        internal static string WithParams(params string[] columns)
        {
            return WithIEnumerable(columns);
        }

        internal static string WithIEnumerable(IEnumerable<string> columns)
        {
            var _columns = columns.Select(e => e.AddSqlBrackets()).Aggregate((c, n) => c + "," + n);
            return string.Concat("(", _columns, ")", " ");
        }

        internal static string WithExpression<T>(params Expression<Func<T,object>>[] columns)
        {
            var _columns =
                ExpressionHelper.GetExpressionPropertyNames(columns)
                .Select(e => e.AddSqlBrackets())
                .Aggregate((c, n) => c + "," + n);
            return string.Concat("(", _columns, ")", " ");
        }
    }
}