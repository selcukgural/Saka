using System.Collections.Generic;

namespace Saka.Entity.QueryBuilder
{
    internal interface IIn<T>
    {
        QueryBuilder<T> In<K>(IEnumerable<K> values);
        QueryBuilder<T> In<K>(params K [] values);
        QueryBuilder<T> In();
    }
}