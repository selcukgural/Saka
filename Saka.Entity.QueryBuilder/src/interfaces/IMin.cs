namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IMin<T>
    {
        QueryBuilder<T> Min(Expression<Func<T,object>> column, bool comma);
        QueryBuilder<T> Min(string column, bool comma);
        QueryBuilder<T> Min(bool comma);
    }
}