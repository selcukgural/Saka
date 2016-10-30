namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IMax<T>
    {
        QueryBuilder<T> Max(Expression<Func<T,object>> column, bool comma);
        QueryBuilder<T> Max(string column, bool comma);
        QueryBuilder<T> Max(bool comma);
    }
}