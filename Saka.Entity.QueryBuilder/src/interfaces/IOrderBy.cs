namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IOrderBy<T>
    {
         QueryBuilder<T>OrderBy(Expression<Func<T,object>> column,bool asc); 
         QueryBuilder<T>OrderBy(string column,bool asc); 
         QueryBuilder<T>OrderBy(); 
    }
}