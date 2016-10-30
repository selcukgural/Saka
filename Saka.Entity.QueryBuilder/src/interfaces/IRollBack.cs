namespace Saka.Entity.QueryBuilder
{
    internal interface IRollBack<T>
    {
        QueryBuilder<T> RollBack();
    }
}