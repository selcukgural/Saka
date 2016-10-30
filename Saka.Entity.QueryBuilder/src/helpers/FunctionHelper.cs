namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;

    internal static class FunctionHelper
    {
        internal static string BuildFunctionWithExpression<T>(string funcName, Expression<Func<T,object>> column,bool comma,bool parenthesis = true)
        {
            return string.Concat(comma ? "," : "", funcName,parenthesis ? "(":"", ExpressionHelper.ConditionBuilder(column).Trim(' '),parenthesis ?")":""," ");
        }

        internal static string BuildFunctionWithString(string funcName, string column, bool comma, bool parenthesis = true)
        {
            return string.Concat(comma ? "," : "", funcName, parenthesis ? "(" : "",column.AddSqlBrackets(), parenthesis ? ")" : "", " ");
        }
    }
}