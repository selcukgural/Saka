namespace Saka.Entity.QueryBuilder
{
    internal static class Into
    {
        internal static string WithString(string tableName)
        {
            return string.Concat(Constants.Sql.Into, tableName," ");
        }

        internal static string JustInto(bool genericTypeNameIsTableName, string tableName)
        {
            return genericTypeNameIsTableName ? string.Concat(Constants.Sql.Into, tableName," ") : Constants.Sql.Into;
        }
    }
}