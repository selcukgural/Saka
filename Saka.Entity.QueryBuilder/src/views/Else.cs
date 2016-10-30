namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Else
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> expression)
        {
            return string.Concat(Constants.Sql.Else,
                ExpressionHelper.GetExpressionPropertyName(expression).SetSqlValueWithQuoteOrWithoutQuote(), " ");
        }

        internal static string WithObject(object expression)
        {
            return string.Concat(Constants.Sql.Else, expression.SetSqlValueWithQuoteOrWithoutQuote(), " ");
        }

        internal static string JustElse()
        {
            return Constants.Sql.Else;
        }
    }
}