namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal interface ISet<T>
    {
        QueryBuilder<T> Set(params Expression<Func<T,object>>[] columnsAndValues);
        QueryBuilder<T> Set(IDictionary<string, object> columnsAndValues);
        QueryBuilder<T> Set(IEnumerable<string> columns, IEnumerable<object> values);
        QueryBuilder<T> Set(string column, object value);
        QueryBuilder<T> Set();
    }
}