namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal static  class Top
    {
        internal static string WithExpression<T>(int top, bool percent, params Expression<Func<T,object>>[] columns)
        {
            var _columns = ExpressionHelper.GetExpressionPropertyNames(columns).Select(e => e.AddSqlBrackets()).ToList();
            return string.Concat(Constants.Sql.Top,top," ",percent ? Constants.Sql.Percent : "", _columns.Aggregate((c,n)=> c+","+n)," ");
        }

        internal static string WihtIEnumerable(int top, bool percent, IEnumerable<string> columns)
        {
            var _columns = columns.Select(e => e.AddSqlBrackets()).ToList();
            return string.Concat(Constants.Sql.Top, top, " ", percent ? Constants.Sql.Percent : "", _columns.Aggregate((c, n) => c + "," + n), " ");
        }

        internal static string WihtParams(int top, bool percent, params string[] columns)
        {
            return WihtIEnumerable(top, percent, columns);
        }

        internal static string JustTop()
        {
            return Constants.Sql.Top;
        }
    }
}