using System;
using System.Linq.Expressions;

namespace Saka.Entity.QueryBuilder
{
    using System.Data;
    internal interface IAdd<T>
    {
        QueryBuilder<T> Add<K>(Expression<Func<T,object>> column , SqlDbType sqlDbType, K KLength, bool canBeNull);
        QueryBuilder<T> Add<K>(string columnName, SqlDbType sqlDbType, K KLength, bool canBeNull);
        QueryBuilder<T> Add(Expression<Func<T,object>> column, SqlDbType sqlDbType, bool canBeNull);
        QueryBuilder<T> Add(string columnName, SqlDbType sqlDbType, bool canBeNull);
        QueryBuilder<T> Add();
    }
}