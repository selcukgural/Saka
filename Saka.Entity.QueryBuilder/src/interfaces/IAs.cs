namespace Saka.Entity.QueryBuilder
{
    internal interface IAs<T>
    {
        QueryBuilder<T> As(string alias);
        QueryBuilder<T> As();
    }
}