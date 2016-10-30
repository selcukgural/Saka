namespace Saka.Entity.QueryBuilder
{
    internal static class Between
    {
        internal static string WihtObjects(object value1, object value2)
        {
            return string.Concat(Constants.Sql.Between, value1.SetSqlValueWithQuoteOrWithoutQuote(), " AND ",
                value2.SetSqlValueWithQuoteOrWithoutQuote(), " ");
        }

        internal static string JustBetween()
        {
            return Constants.Sql.Between;
        }
    }
}