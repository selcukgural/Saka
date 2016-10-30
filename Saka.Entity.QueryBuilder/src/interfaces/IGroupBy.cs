namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal interface IGroupBy<T>
    {
        QueryBuilder<T> GroupBy(params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> GroupBy(Expression<Func<T,object>> column);
        QueryBuilder<T> GroupBy(IEnumerable<string> columns);
        QueryBuilder<T> GroupBy(string value);
        QueryBuilder<T> GroupBy();
    }
}