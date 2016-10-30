namespace Saka.Entity.QueryBuilder
{
    internal static class StringExtensions
    {
        internal static string AddSingleQuote(this string value)
        {
            return "'" + value + "'";
        }

        internal static string AddSqlBrackets(this string value)
        {
            return "[" + value + "]";
        }
        internal static string AddSqlParenthesis(this string value)
        {
            return "(" + value + ")";
        }
    }
}
