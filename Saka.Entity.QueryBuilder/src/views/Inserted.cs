namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Text;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal static class Inserted
    {
        internal static string WithParams(params string[] columns)
        {
            return WithIEnumerable(columns);
        }

        internal static string WithIEnumerable(IEnumerable<string> columns)
        {
            return SetInsertedColumns(columns);
        }

        internal static string WithExpression<T>(params Expression<Func<T,object>>[] columns)
        {
            var _columns = ExpressionHelper.GetExpressionPropertyNames(columns);
            return SetInsertedColumns(_columns);
        }

        internal static string JustInserted()
        {
            return Constants.Sql.Inserted;
        }

        private static string SetInsertedColumns(IEnumerable<string> columns)
        {
            var builder = new StringBuilder();
            foreach (var column in columns)
            {
                builder.Append(string.Concat(Constants.Sql.Inserted, ".", column, ","));
            }
            return builder.Append(" ").ToString().Remove(builder.Length - 2, 1);
        }  

    }
}