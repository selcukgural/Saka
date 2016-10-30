namespace Saka.Entity.QueryBuilder
{
    internal static class Use
    {
        internal static string WihtString(string databaseName)
        {
            return string.Concat(Constants.Sql.Use, databaseName.AddSqlBrackets(), " ");
        }

        internal static string JustUse()
        {
            return Constants.Sql.Use;
        }
    }
}