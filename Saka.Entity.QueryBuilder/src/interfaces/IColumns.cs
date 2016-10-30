namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal interface IColumns<T>
    {
        QueryBuilder<T> Columns(params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> Columns(IEnumerable<string> columns);
        QueryBuilder<T> Columns(params string[] columns);
    }
}