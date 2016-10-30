namespace Saka.Entity.QueryBuilder
{
    internal interface IDelete<T>
    {
        QueryBuilder<T> Delete();
    }
}