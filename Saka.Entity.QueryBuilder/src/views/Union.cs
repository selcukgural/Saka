namespace Saka.Entity.QueryBuilder
{
    internal static class Union
    {
        internal static string JustUnion(bool all)
        {
            return all ? Constants.Sql.UnionAll : Constants.Sql.Union;
        }
    }
}