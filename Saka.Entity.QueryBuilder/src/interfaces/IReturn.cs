namespace Saka.Entity.QueryBuilder
{
    internal interface IReturn<T>
    {
        QueryBuilder<T> Return(int value);
        QueryBuilder<T> Return();

    }
}