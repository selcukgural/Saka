namespace Saka.Entity.QueryBuilder
{
    internal static class Database
    {
        internal static string WithString(string tableName)
        {
            return string.Concat(Constants.Sql.Database, tableName, " ");
        }

        internal static string JustDatabase(bool genericTypeNameIsTableName, string tableName)
        {
            return genericTypeNameIsTableName ? string.Concat(Constants.Sql.Database, tableName, " ") : Constants.Sql.Database;
        }
    }
}