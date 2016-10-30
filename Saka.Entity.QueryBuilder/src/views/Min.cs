namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Min
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Min, column, comma);
        }

        internal static string WithString(string column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Min, column, comma);
        }

        internal static string JustMin(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Min);
        }
    }
}
