namespace Saka.Entity.QueryBuilder
{
    internal interface ILeftJoin<T>
    {
        QueryBuilder<T> LeftJoin<K>() where K : class;
        QueryBuilder<T> LeftJoin(string tableName);
        QueryBuilder<T> LeftJoin();
    }
}