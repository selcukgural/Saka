namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Text;
    using System.Linq.Expressions;

    internal static class Count
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Count, column,comma);
        }

        internal static string WithString(string column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Count, column, comma);
        }

        internal static string WihtStar(bool isStar, bool comma)
        {
            var builder = new StringBuilder();
            if (comma) builder.Append(",");
            builder.Append(Constants.Sql.Count);

            if (!isStar) return builder.ToString();

            builder.Append("(").Append("*").Append(")").Append(" ");
            return builder.ToString();
        }
    }
}