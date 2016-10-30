namespace Saka.Entity.QueryBuilder
{
    internal interface IDatabase<T>
    {
        QueryBuilder<T> Database(string tableName);
        QueryBuilder<T> Database(bool genericTypeNameIsTableName);
    }
}