namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal static class Set
    {
        internal static string WithExpression<T>(params Expression<Func<T,object>>[] columnsAndValues)
        {
            var condition = columnsAndValues.Select(cvw => ExpressionHelper.ConditionBuilder(cvw)).ToList().Aggregate((c,n)=> c+","+n);
            return string.Concat(Constants.Sql.Set, "(", condition, ")", " ");
        }

        internal static string WihtEnumerable(IEnumerable<string> columns, IEnumerable<object> values)
        {
            return string.Concat(Constants.Sql.Set, "(", MergeList(columns, values), ")", " ");
        }

        internal static string WihtIDictionary(IDictionary<string, object> columnsAndValues)
        {
            return string.Concat(Constants.Sql.Set, "(", MergeList(columnsAndValues.Keys, columnsAndValues.Values), ")", " ");
        }

        internal static string WithSingle(string column, object value)
        {
            return string.Concat(Constants.Sql.Set, "(", column.AddSqlBrackets(), " = ", value.SetSqlValueWithQuoteOrWithoutQuote(),")", " ");
        }

        internal static string JustSet()
        {
            return Constants.Sql.Set;
        }

        private static string MergeList(IEnumerable<string> columns, IEnumerable<object> values)
        {
            var _columns = columns.Select(e => e.AddSqlBrackets()).ToList();
            var _values = values.Select(e => e.SetSqlValueWithQuoteOrWithoutQuote()).ToList();
            var builder = new StringBuilder();
            for (var i = 0; i < _columns.Count; i++)
            {
                builder.Append(_columns[i] + " = " + _values[i]).Append(",");
            }
            return builder.ToString().Remove(builder.Length - 1);
        }
    }
}