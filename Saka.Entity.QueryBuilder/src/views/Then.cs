namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal class Then
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> expression)
        {
            return string.Concat(Constants.Sql.Then,
                ExpressionHelper.GetExpressionPropertyName(expression).SetSqlValueWithQuoteOrWithoutQuote()," ");
        }

        internal static string WithObject(object expression)
        {
            return string.Concat(Constants.Sql.Then, expression.SetSqlValueWithQuoteOrWithoutQuote()," ");
        }

        internal static string JustThen()
        {
            return Constants.Sql.Then;
        }

    }
}