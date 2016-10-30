namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal interface ITop<T>
    {
        QueryBuilder<T> Top(int top, bool percent, params Expression<Func<T,object>>[] columns);
        QueryBuilder<T> Top(int top, bool percent,IEnumerable<string> columns);
        QueryBuilder<T> Top(int top, bool percent,params  string [] columns);
        QueryBuilder<T> Top();
    }
}