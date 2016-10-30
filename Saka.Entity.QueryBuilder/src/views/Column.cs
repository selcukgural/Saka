using System;
using System.Linq.Expressions;

namespace Saka.Entity.QueryBuilder
{
    internal static class Column
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column)
        {
            return string.Concat(Constants.Sql.Column, ExpressionHelper.GetExpressionPropertyName(column).AddSqlBrackets()," ");
        }
        internal static string WithString(string columnName)
        {
            return string.Concat(Constants.Sql.Column, columnName.AddSqlBrackets(), " ");
        }

        internal static string JustColumn()
        {
            return Constants.Sql.Column;
        }
    }
}