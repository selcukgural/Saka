namespace Saka.Entity.QueryBuilder
{
    internal interface IQueryBuilder<T> : ISelect<T>, IWhere<T>, IMax<T>,IAvg<T>, IMin<T>,ICount<T>,ISum<T>, IFormat<T>, IGroupBy<T>, IAnd<T>, IAs<T>,IHaving<T>,IUpper<T>, ILower<T>,ISubstring<T>,ILen<T>,INow<T>, IDistinct<T>,IFrom<T>,IOr<T>,IOrderBy<T>,ITop<T>,IInsert<T>,IInto<T>,IColumns<T>,IValues<T>,IUpdate<T>,ISet<T>,IDelete<T>,ILike<T>, IBetween<T>,INot<T>,IUnion<T>,IDrop<T>,ITable<T>,IDatabase<T>,ITruncate<T>,IAlter<T>,IAdd<T>,IColumn<T>,IBegin<T>,IEnd<T>,ICase<T>,IWhen<T>,IThen<T>,IElse<T>,IGo<T>,ITransaction<T>,IRollBack<T>,IOutput<T>,IInserted<T>,IDeclare<T>,IReturn<T>,IUse<T>,IPrint<T>,IIf<T>,IJoin<T>,IOn<T>,ILeftJoin<T>, IIn<T>,IAsc<T>,IDesc<T>
    {
        string EndQuery();
        void Clear();
    }
}