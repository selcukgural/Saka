namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface ISum<T>
    {
        QueryBuilder<T> Sum(Expression<Func<T,object>> column, bool comma);
        QueryBuilder<T> Sum(string column, bool comma);
        QueryBuilder<T> Sum(bool comma);
    }
}