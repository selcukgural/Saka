namespace Saka.Entity.QueryBuilder
{
    internal interface IInto<T>
    {
        QueryBuilder<T> Into(string tableName);
        QueryBuilder<T> Into(bool genericTypeNameIsTableName);
    }
}