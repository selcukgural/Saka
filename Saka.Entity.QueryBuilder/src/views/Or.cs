namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Or
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition, bool parenthesis)
        {
            var value = ExpressionHelper.ConditionBuilder(condition, Constants.Sql.Or);
            return !parenthesis ? value : string.Concat(value.Insert(Constants.Sql.Or.Length, "("), ")", " ");
        }

        internal static string WithString(string condition, bool parenthesis)
        {
            return !parenthesis
                ? string.Concat(Constants.Sql.Or, condition," ")
                : string.Concat(Constants.Sql.Or,"(", condition, ")", " ");
        }

        internal static string JustOr()
        {
            return Constants.Sql.Or;
        }
    }
}