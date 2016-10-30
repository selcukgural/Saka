namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class Where
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> condition, bool parenthesis)
        {
            var value = string.Concat(ExpressionHelper.ConditionBuilder(condition, Constants.Sql.Where)," ");
            return !parenthesis ? value : string.Concat(value.Insert(Constants.Sql.Where.Length,"("), ")"," ");
        }

        internal static string WithString(string condition, bool parenthesis)
        {
            return !parenthesis
                ? string.Concat(Constants.Sql.Where, condition)
                : string.Concat("(", condition, ")", " ");
        }

        internal static string JustWhere()
        {
            return Constants.Sql.Where;
        }
    }
}
