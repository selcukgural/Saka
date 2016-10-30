namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Case
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> expression)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.Case, expression, false, false);
        }

        internal static string WithString(string expression)
        {
            return FunctionHelper.BuildFunctionWithString(Constants.Sql.Case, expression, false,false);
        }

        internal static string JutCase()
        {
            return Constants.Sql.Case;
        }
    }
}