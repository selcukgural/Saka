namespace Saka.Entity.QueryBuilder
{
    using System.Collections.Generic;
    internal interface IFormat<T>
    {
        QueryBuilder<T> Format(IEnumerable<string> format, bool comma);
        QueryBuilder<T> Format(string [] format, bool comma);
        QueryBuilder<T> Format(bool comma);
    }
}