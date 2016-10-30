namespace Saka.Entity.QueryBuilder
{
    internal interface IPrint<T>
    {
        QueryBuilder<T> Print(string value);
        QueryBuilder<T> Print();
    }
}