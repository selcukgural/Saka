namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IWhen<T>
    {
        QueryBuilder<T> When(Expression<Func<T,object>> condition);
        QueryBuilder<T> When(string condition);
        QueryBuilder<T> When();
    }
}