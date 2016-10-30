namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Sum
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Sum, column, comma);
        }
        internal static string WithString(string column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Sum, column, comma);
        }
        internal static string JustSum(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Sum);
        }
    }
}