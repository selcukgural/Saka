namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal static class Select
    {
        internal static string WithAllStar()
        {
            return WithStarOrEmpty(true);
        }

        internal static string WithAllProperties<T>()
        {
            var properties = typeof (T).GetProperties().ToList();
            return WithIEnumerable(properties.Select(e => e.Name));
        }

        internal static string WithoutColumns()
        {
            return WithStarOrEmpty();
        }

        internal static string WithStarOrEmpty(bool withStar = false)
        {
            return withStar ? Constants.Sql.SelectWithStar : Constants.Sql.Select;
        }

        internal static string WithParams(params string[] columns)
        {
            return WithIEnumerable(columns);
        }

        internal static string WithIEnumerable(IEnumerable<string> columns)
        {
            return columns.Append(Constants.Sql.Select);
        }

        internal static string WithExpression<T>(params Expression<Func<T,object>>[] columns)
        {
            var properties = ExpressionHelper.GetExpressionPropertyNames(columns);
            return properties.Append(Constants.Sql.Select);
        }
    }
}
