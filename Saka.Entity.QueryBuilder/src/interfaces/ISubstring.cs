namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface ISubstring<T>
    {
        QueryBuilder<T> SubString(Expression<Func<T,object>> column, int startIndex, int length,bool comma);
        QueryBuilder<T> SubString(string column, int startIndex, int length,bool comma);
        QueryBuilder<T> SubString(bool comma);
    }
}