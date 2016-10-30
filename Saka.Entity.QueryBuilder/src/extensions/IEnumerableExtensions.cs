
namespace Saka.Entity.QueryBuilder
{
    using System.Text;
    using System.Collections.Generic;
    internal static class IEnumerableExtensions
    {
        internal static string Append<T>(this IEnumerable<T> values, string funcName, bool withBrackets = true)
        {
            var builder = new StringBuilder();
            builder.Append(funcName);
            foreach (var value in values)
            {
                builder.AppendFormat(withBrackets ? "[{0}]," : "{0},", value);
            }
            return builder.ToString().Trim(',').Insert(builder.ToString().Length - 1, " ");
        } 
    }
}