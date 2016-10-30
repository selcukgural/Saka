namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IUpper<T>
    {
        QueryBuilder<T> Upper(Expression<Func<T,object>> condition,bool comma);
        QueryBuilder<T> Upper(string column,bool comma);
        QueryBuilder<T> Upper(bool comma);
    }
}