namespace Saka.Entity.QueryBuilder
{
    using System.Linq;
    using System.Collections.Generic;
    internal static class Values
    {
        internal static string WithParams(params object[] columns)
        {
            return WithIEnumerable(columns);
        }

        internal static string WithIEnumerable(IEnumerable<object> columns)
        {
            var _columns = columns.Select(e => e.SetSqlValueWithQuoteOrWithoutQuote()).Aggregate((c, n) => c + "," + n);
            return string.Concat(Constants.Sql.Values,"(", _columns, ")", " ");
        }
    }
}