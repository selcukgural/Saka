namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IAnd<T>
    {
        QueryBuilder<T> And(Expression<Func<T,object>> condition, bool parenthesis);
        QueryBuilder<T> And(string condition, bool parenthesis);
        QueryBuilder<T> And();
    }
}