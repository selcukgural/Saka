namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal static class OrderBy
    {
        internal static string WithExpression<T>(Expression<Func<T,object>> column,bool asc)
        {
            var condition = FunctionHelper.BuildFunctionWithExpression(Constants.Sql.OrderBy, column, false,false);
            return string.Concat(condition,asc ? Constants.Sql.Asc : Constants.Sql.Desc);
        }

        internal static string WithString(string column, bool asc)
        {
            return string.Concat(Constants.Sql.OrderBy, column, " ", asc ? Constants.Sql.Asc : Constants.Sql.Desc);
        }

        internal static string JustOrderBy()
        {
            return Constants.Sql.OrderBy;
        }
    }
}