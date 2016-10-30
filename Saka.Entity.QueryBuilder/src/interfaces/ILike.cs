namespace Saka.Entity.QueryBuilder
{
    internal interface ILike<T>
    {
        QueryBuilder<T> Like(string pattern);
        QueryBuilder<T> Like();
    }
}