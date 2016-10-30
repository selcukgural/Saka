namespace Saka.Entity.QueryBuilder
{
    internal interface IDesc<T>
    {
        QueryBuilder<T> Desc();
    }
}