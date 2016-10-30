namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface ICase<T>
    {
        QueryBuilder<T> Case(Expression<Func<T,object>> expression);
        QueryBuilder<T> Case(string expression);
        QueryBuilder<T> Case();
    }
}