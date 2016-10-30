namespace Saka.Entity.QueryBuilder
{
    internal static class Like
    {
        internal static string WihtString(string pattern)
        {
            return string.Concat(Constants.Sql.Like, pattern.AddSingleQuote()," ");
        }
        internal static string JustLike()
        {
            return Constants.Sql.Like;
        }
    }
}