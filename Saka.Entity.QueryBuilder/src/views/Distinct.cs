namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal static class Distinct
    {
        internal static string WithExpression<T>(params Expression<Func<T,object>>[] columns)
        {
            var _columns = ExpressionHelper.GetExpressionPropertyNames(columns);
            return _columns.Append(Constants.Sql.Distinct);
        }

        internal static string WithIEnumerable(IEnumerable<string> columns)
        {
            return columns.Append(Constants.Sql.Distinct);
        }

        internal static string WithParams(params string[] columns)
        {
            return WithIEnumerable(columns);
        }

        internal static string JustDistinct()
        {
            return Constants.Sql.Distinct;
        }

    }
}