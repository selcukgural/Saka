namespace Saka.Entity.QueryBuilder
{
    internal interface ITable<T>
    {
        QueryBuilder<T> Table(string tableName);
        QueryBuilder<T> Table(bool genericTypeNameIsTableName);
    }
}