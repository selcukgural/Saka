namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IThen<T>
    {
        QueryBuilder<T> Then(Expression<Func<T,object>> expression);
        QueryBuilder<T> Then(object expression);
        QueryBuilder<T> Then();
    }
}