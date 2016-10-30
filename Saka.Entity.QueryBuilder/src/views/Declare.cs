namespace Saka.Entity.QueryBuilder
{
    internal static class Declare
    {
        internal static string WithString(string name)
        {
            return string.Concat(Constants.Sql.Declare, "@", name, " ");
        }

        internal static string JustDeclare()
        {
            return Constants.Sql.Declare;
        }
    }
}