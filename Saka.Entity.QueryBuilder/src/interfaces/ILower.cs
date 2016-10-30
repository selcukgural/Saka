namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface ILower<T>
    {
        QueryBuilder<T> Lower(Expression<Func<T,object>> condition,bool comma);
        QueryBuilder<T> Lower(string column,bool comma);
        QueryBuilder<T> Lower(bool comma);
    }
}