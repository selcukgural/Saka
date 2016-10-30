namespace Saka.Entity.QueryBuilder
{
    internal static class ObjectExtensions
    {
        internal static object SetSqlValueWithQuoteOrWithoutQuote(this object value)
        {
            if(value == null) return Constants.Sql.Null;
            var systemType = value.GetType().FullName;
            if (systemType.Equals("System.String") || systemType.Equals("System.DateTime") || systemType.Equals("System.Char") || systemType.Equals("System.Boolean")) return "'" + value + "'";
            return value;
        }
    }
}
