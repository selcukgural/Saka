namespace Saka.Entity.QueryBuilder
{
    internal static class As
    {
        internal static string WithString(string alias)
        {
            return string.Concat(Constants.Sql.As, alias.AddSqlBrackets()," ");
        }
        internal static string JustAs()
        {
            return Constants.Sql.As;
        }
    }
}
