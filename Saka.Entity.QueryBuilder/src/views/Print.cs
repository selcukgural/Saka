namespace Saka.Entity.QueryBuilder
{
    internal static class Print
    {
        internal static string WihtString(string value)
        {
            return string.Concat(Constants.Sql.Print, "'", value, "'", " ");
        }

        internal static string JustPrint()
        {
            return Constants.Sql.Print;
        }
    }
}