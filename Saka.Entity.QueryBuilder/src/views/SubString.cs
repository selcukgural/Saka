namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class SubString
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column,int startIndex, int length,bool comma)
        {
            var expression = ExpressionHelper.ConditionBuilder(column, Constants.Sql.SubString);
            return string.Concat(comma ? "," : "", expression.Insert(Constants.Sql.SubString.Length, "("),",", startIndex,",",length, ")"," ");
        }

        internal static string WithString(string column,int startIndex,int length,bool comma)
        {
            return string.Concat(comma ? "," : "", Constants.Sql.SubString,"(", column.AddSqlBrackets(), ",",startIndex, ",", length, ")", " ");
        }

        internal static string JustSubString(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.SubString);
        }
    }
}