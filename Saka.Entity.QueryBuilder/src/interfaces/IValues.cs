namespace Saka.Entity.QueryBuilder
{
    using System.Collections.Generic;
    internal interface IValues<T>
    {
        QueryBuilder<T> Values(IEnumerable<object> columns);
        QueryBuilder<T> Values(params object[] columns);
    }
}