namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    internal interface IOn<T>
    {
        QueryBuilder<T> On<K>(Expression<Func<T,object>> TCondition, Expression<Func<K, object>> KCondition)
            where K : class;
        QueryBuilder<T> On(string condition, string condition2);
        QueryBuilder<T> On();

    }
}