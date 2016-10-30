namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal interface IDistinct<T>
    {
        QueryBuilder<T> Distinct(params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> Distinct(IEnumerable<string> columns);
        QueryBuilder<T> Distinct(params string[] columns);
        QueryBuilder<T> Distinct();
    }
}