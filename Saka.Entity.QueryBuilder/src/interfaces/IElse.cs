namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IElse<T>
    {
        QueryBuilder<T> Else(Expression<Func<T,object>> expression);
        QueryBuilder<T> Else(object expression);
        QueryBuilder<T> Else();
    }
}