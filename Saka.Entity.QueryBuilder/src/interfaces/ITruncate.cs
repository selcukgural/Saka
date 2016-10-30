namespace Saka.Entity.QueryBuilder
{
    internal interface ITruncate<T>
    {
        QueryBuilder<T> Truncate();
    }
}