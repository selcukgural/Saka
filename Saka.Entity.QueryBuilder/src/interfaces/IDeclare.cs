namespace Saka.Entity.QueryBuilder
{
    internal interface IDeclare<T>
    {
        QueryBuilder<T> Declare(string name);
        QueryBuilder<T> Declare();
    }
}