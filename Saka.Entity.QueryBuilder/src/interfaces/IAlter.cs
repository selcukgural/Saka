namespace Saka.Entity.QueryBuilder
{
    internal interface IAlter<T>
    {
        QueryBuilder<T> Alter();
    }
}