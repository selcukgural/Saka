namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class If
    {
        internal static string WihtExpression<T>(Expression<Func<T,object>> condition)
        {
            return FunctionHelper.BuildFunctionWithExpression(Constants.Sql.If, condition, false, false);
        }

        internal static string WithString(string condition)
        {
            return string.Concat(Constants.Sql.If, condition," ");
        }

        internal static string JustIf()
        {
            return Constants.Sql.If;
        }
    }
}