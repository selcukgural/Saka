namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;

    internal static class Upper
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition,bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Upper, condition, comma);
        }

        internal static string WithString(string column,bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Upper, column, comma);
        }

        internal static string JustUpper(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Upper);
        }
    }
}