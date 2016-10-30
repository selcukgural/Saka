namespace Saka.Entity.QueryBuilder
{
    internal interface INot<T>
    {
        QueryBuilder<T> Not();
    }
}