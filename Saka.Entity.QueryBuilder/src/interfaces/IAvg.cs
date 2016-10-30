namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IAvg<T>
    {
        QueryBuilder<T> Avg(Expression<Func<T,object>> column, bool comma);
        QueryBuilder<T> Avg(string column, bool comma);
        QueryBuilder<T> Avg(bool comma);
    }
}
