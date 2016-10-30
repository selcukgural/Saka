namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;
    
    internal interface ISelect<T>
    {
        QueryBuilder<T> Select(params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> Select(IEnumerable<string> columns);
        QueryBuilder<T> Select(params string [] columns);
        QueryBuilder<T> SelectAllProperties();
        QueryBuilder<T> SelectAllWithStar();
        QueryBuilder<T> Select();

    }
}