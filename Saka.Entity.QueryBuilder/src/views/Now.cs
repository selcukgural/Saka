namespace Saka.Entity.QueryBuilder
{
    internal static class Now
    {
        internal static string JustNow(bool comma)
        {
            return string.Concat(comma ? "," : "", Constants.Sql.Now);
        }
    }
}