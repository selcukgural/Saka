namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Len
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column, bool comma)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Len, column, comma);
        }

        internal static string WithString(string column,bool comma)
        {
          return FunctionHelper.BuildFunctionWithString(Constants.Sql.Len, column, comma);
        }

        internal static string JustLen(bool comma)
        {
            return string.Concat(comma ? "," : "",Constants.Sql.Len);
        }
    }
}