namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal class Avg
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Avg, column, comma);
        }

        internal static string WithString(string column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Avg, column, comma);
        }

        internal static string JustAvg(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Avg);
        }
    }
}