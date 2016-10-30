namespace Saka.Entity.QueryBuilder
{
    internal interface IInsert<T>
    {
        QueryBuilder<T> Insert();
    }
}