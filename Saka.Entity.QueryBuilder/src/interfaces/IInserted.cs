namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    internal interface IInserted<T>
    {
        QueryBuilder<T> Inserted(params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> Inserted(IEnumerable<string> columns);
        QueryBuilder<T> Inserted(params string[] columns);
        QueryBuilder<T> Inserted();
    }
}