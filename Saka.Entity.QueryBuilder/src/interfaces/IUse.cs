namespace Saka.Entity.QueryBuilder
{
    internal interface IUse<T>
    {
        QueryBuilder<T> Use(string databaseName);
        QueryBuilder<T> Use();
    }
}