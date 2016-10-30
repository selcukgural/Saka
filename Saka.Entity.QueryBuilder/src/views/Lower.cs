namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Lower
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition,bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Lower, condition, comma);
        }

        internal static string WithString(string column,bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Lower, column, comma);
        }

        internal static string JustLower(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Lower);
        }
    }
}