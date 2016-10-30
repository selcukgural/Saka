namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IIf<T>
    {
        QueryBuilder<T> If(Expression<Func<T,object>> condition);
        QueryBuilder<T> If(string condition);
        QueryBuilder<T> If();
    }
}