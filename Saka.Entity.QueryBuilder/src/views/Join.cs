namespace Saka.Entity.QueryBuilder
{
    internal static class Join
    {
        internal static string WithGenericType<K>()
        {
            var genericTypeName = typeof (K).Name;
            return string.Concat(Constants.Sql.Join, genericTypeName, " ");
        }

        internal static string WithString(string tableName)
        {
            return string.Concat(Constants.Sql.Join, tableName, " ");
        }

        internal static string JustJoin()
        {
            return Constants.Sql.Join;
        }
    }
}