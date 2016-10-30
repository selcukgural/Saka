namespace Saka.Entity.QueryBuilder
{
    public interface IUnion<T>
    {
        QueryBuilder<T> Union(bool all);
    }
}