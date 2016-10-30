namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Data;
    using System.Linq.Expressions;
    internal static class Add
    {

        internal static string WihtExpression<K,T>(Expression<Func<T,object>> column, SqlDbType sqlDbType, K KLength, bool canBeNull)
        {
            var _column = ExpressionHelper.GetExpressionPropertyName(column).AddSqlBrackets();
            var lenght = convertDotToCommaIfSqlDbTypeDecimal(sqlDbType, KLength);
            return string.Concat(Constants.Sql.Add, _column, " ",sqlDbType, "(", lenght, ") ", canBeNull ? Constants.Sql.Null : Constants.Sql.NotNull);
        }

        internal static string WihtExpression<T>(Expression<Func<T,object>> column, SqlDbType sqlDbType, bool canBeNull)
        {
            var _column = ExpressionHelper.GetExpressionPropertyName(column).AddSqlBrackets();
            return string.Concat(Constants.Sql.Add, _column," ",sqlDbType," ", canBeNull ? Constants.Sql.Null : Constants.Sql.NotNull);
        }

        internal static string WithParameters<K>(string columnName, SqlDbType sqlDbType,K KLength,bool canBeNull)
        {
            var lenght = convertDotToCommaIfSqlDbTypeDecimal(sqlDbType, KLength);
            return string.Concat(Constants.Sql.Add, columnName.AddSqlBrackets() ," ",sqlDbType, "(", lenght, ") ", canBeNull ? Constants.Sql.Null : Constants.Sql.NotNull);
        }

        internal static string WithParameters(string columnName, SqlDbType sqlDbType,bool canBeNull)
        {
            return string.Concat(Constants.Sql.Add, columnName.AddSqlBrackets(), " ", sqlDbType," ",
                canBeNull ? Constants.Sql.Null : Constants.Sql.NotNull);
        }

        internal static string JustAdd()
        {
            return Constants.Sql.Add;
        }

        private static string convertDotToCommaIfSqlDbTypeDecimal<K>(SqlDbType sqlDbType,K KLength)
        {
            switch (sqlDbType)
            {
                case SqlDbType.Decimal:
                    return KLength.ToString().Replace(".", ",");
                default:
                    return KLength.ToString();
            }
        }
    }
}