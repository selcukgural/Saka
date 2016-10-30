namespace Saka.Entity.QueryBuilder
{
    internal static class Return
    {
        internal static string WithInteger(int value)
        {
            return string.Concat(Constants.Sql.Return, value," ");
        }

        internal static string JustReturn()
        {
            return Constants.Sql.Return;
        }
    }
}