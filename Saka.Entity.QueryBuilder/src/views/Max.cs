namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Max
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column,bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Max, column, comma);
        }

        internal static string WithString(string column,bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Max, column, comma);
        }

        internal static string JustMax(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Max);
        }
    }
}
