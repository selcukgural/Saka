namespace Saka.Entity.QueryBuilder
{
    using System.Linq;
    using System.Collections.Generic;
    internal static  class In
    {
        internal static string WihtEnumerable<K>(IEnumerable<K> values)
        {
            return justINTime(values);
        }

        internal static string WihtParams<K>(params K[] values)
        {
            return justINTime(values);
        }

        internal static string JustIn()
        {
            return Constants.Sql.In;
        }
        private static string justINTime<K>(IEnumerable<K> values)
        {
            return string.Concat(Constants.Sql.In,"(",values.Select(e => e.SetSqlValueWithQuoteOrWithoutQuote())
                    .Aggregate((c, n) => c + "," + n).ToString()
                    .Trim(','),") ");
        }
    }
}