namespace Saka.Entity.QueryBuilder
{
    internal interface IHaving<T>
    {
        QueryBuilder<T> Having();
    }
}