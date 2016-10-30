namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;

    internal interface ILen<T>
    {
        QueryBuilder<T> Len(Expression<Func<T,object>> column, bool comma);
        QueryBuilder<T> Len(string column,bool comma);
        QueryBuilder<T> Len(bool comma);
    }
}