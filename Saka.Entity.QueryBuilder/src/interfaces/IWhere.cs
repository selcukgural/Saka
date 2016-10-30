namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IWhere<T>
    {
        QueryBuilder<T> Where(Expression<Func<T,object>> condition, bool parenthesis);
        QueryBuilder<T> Where(string condition,bool parenthesis);
        QueryBuilder<T> Where();
    }
}
