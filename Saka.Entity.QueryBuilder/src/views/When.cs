namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class When
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.When, condition, false, false);
        }

        internal static string WithString(string condition)
        {
            return string.Concat(Constants.Sql.When, condition, " ");
        }

        internal static string JustWhen()
        {
            return Constants.Sql.When;
        }
    }
}