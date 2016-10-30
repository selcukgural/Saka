namespace Saka.Entity.QueryBuilder
{
    internal static class LeftJoin
    {
        internal static string WithGenericType<K>()
        {
            var genericTypeName = typeof(K).Name;
            return string.Concat(Constants.Sql.LeftJoin, genericTypeName, " ");
        }

        internal static string WithString(string tableName)
        {
            return string.Concat(Constants.Sql.LeftJoin, tableName, " ");
        }

        internal static string JustLeftJoin()
        {
            return Constants.Sql.LeftJoin;
        }
    }
}