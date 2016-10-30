namespace Saka.Entity.QueryBuilder
{
    internal interface ITransaction<T>
    {
        QueryBuilder<T> Transaction();
    }
}