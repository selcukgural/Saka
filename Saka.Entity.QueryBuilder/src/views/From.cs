namespace Saka.Entity.QueryBuilder
{
    internal static class From
    {
        internal static string WithTableName(string tableName)
        {
            return string.Concat(Constants.Sql.From, tableName," ");
        }
        internal static string JustFrom()
        {
            return Constants.Sql.From;
        }
    }
}