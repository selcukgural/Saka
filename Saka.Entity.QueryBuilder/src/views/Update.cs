namespace Saka.Entity.QueryBuilder
{
    internal static class Update
    {
        internal static string WihtString(string tableName)
        {
            return string.Concat(Constants.Sql.Update, tableName.AddSqlBrackets(), " ");
        }

        internal static string JustUpdate(bool genericTypeNameIsTableName,string tableName)
        {
            return genericTypeNameIsTableName
                ? string.Concat(Constants.Sql.Update, tableName.AddSqlBrackets(), " ")
                : Constants.Sql.Update;
        }
    }
}