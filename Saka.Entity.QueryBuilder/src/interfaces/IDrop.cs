namespace Saka.Entity.QueryBuilder
{
    internal interface IDrop<T>
    {
        QueryBuilder<T> Drop();
    }
}