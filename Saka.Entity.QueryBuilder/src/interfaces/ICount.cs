namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface ICount<T>
    {
        QueryBuilder<T> Count(Expression<Func<T,object>> column,bool comma);
        QueryBuilder<T> Count(string column, bool comma);
        QueryBuilder<T> Count(bool isStar, bool comma);
    }
}