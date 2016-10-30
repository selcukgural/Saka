namespace Saka.Entity.QueryBuilder
{
    public interface INow<T>
    {
        QueryBuilder<T> Now(bool comma);
    }
}