namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IColumn<T>
    {
        QueryBuilder<T> Column(Expression<Func<T,object>> column);
        QueryBuilder<T> Column(string columnName);
        QueryBuilder<T> Column();
    }
}