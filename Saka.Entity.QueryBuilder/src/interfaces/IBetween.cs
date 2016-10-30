namespace Saka.Entity.QueryBuilder
{
    internal interface IBetween<T>
    {
        QueryBuilder<T> Between(object value1, object value2);
        QueryBuilder<T> Between();
    }
}