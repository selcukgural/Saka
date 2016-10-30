namespace Saka.Entity.QueryBuilder
{
    internal static class Table
    {
        internal static string WithString(string tableName)
        {
            return string.Concat(Constants.Sql.Table, tableName, " ");
        }

        internal static string JustTable(bool genericTypeNameIsTableName, string tableName)
        {
            return genericTypeNameIsTableName ? string.Concat(Constants.Sql.Table, tableName, " ") : Constants.Sql.Table;
        }
    }
}