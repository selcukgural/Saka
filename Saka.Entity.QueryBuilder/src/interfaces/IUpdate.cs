namespace Saka.Entity.QueryBuilder
{
    internal interface IUpdate<T>
    {
        QueryBuilder<T> Update(string tableName);
        QueryBuilder<T> Update(bool genericTypeNameIsTableName);
    }
}