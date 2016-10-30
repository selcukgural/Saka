namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IOr<T>
    {
        QueryBuilder<T> Or(Expression<Func<T,object>> condition, bool parenthesis);
        QueryBuilder<T> Or(string condition, bool parenthesis);
        QueryBuilder<T> Or();
    }
}