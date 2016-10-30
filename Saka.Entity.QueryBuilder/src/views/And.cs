namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class And
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition, bool parenthesis)
        {
            var value = string.Concat(ExpressionHelper.ConditionBuilder(condition, Constants.Sql.And)," ");
            return !parenthesis ? value : string.Concat(value.Insert(Constants.Sql.And.Length, "("), ")", " ");
        }

        internal static string WithString(string condition, bool parenthesis)
        {
            return !parenthesis
                ? string.Concat(Constants.Sql.And, condition)
                : string.Concat("(", condition, ")", " ");
        }

        internal static string JustAnd()
        {
            return Constants.Sql.And;
        }
    }
}