namespace Saka.Entity.QueryBuilder
{
    internal interface IJoin<T>
    {
        QueryBuilder<T> Join<K>() where K : class;
        QueryBuilder<T> Join(string tableName);
        QueryBuilder<T> Join();
    }
}