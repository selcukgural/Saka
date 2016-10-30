namespace Saka.Entity.QueryBuilder
{
    internal interface IBegin<T>
    {
        QueryBuilder<T> Begin();
    }
}