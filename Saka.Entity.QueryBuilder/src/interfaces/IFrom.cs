namespace Saka.Entity.QueryBuilder
{
    public interface IFrom<T>
    {
        QueryBuilder<T> From(bool justForm);
        QueryBuilder<T> From(string tableName);
    }
}