namespace Saka.Entity.QueryBuilder
{
    internal interface IOutput<T>
    {
        QueryBuilder<T> Output();
    }
}