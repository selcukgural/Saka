namespace Saka.Entity.QueryBuilder
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    internal class Format
    {
        internal static string FormatWithEnumerable(IEnumerable<string> format, bool comma)
        {
            var builder = new StringBuilder();
            if (comma) builder.Append(",").Append(Constants.Sql.Format);
            else builder.Append(Constants.Sql.Format);
            builder.Append("(").Append(format.Aggregate((c, n) => c + "," + n)).Append(") ");

            return builder.ToString();
        }

        internal static string FormatWithArray(string[] format, bool comma)
        {
            return FormatWithEnumerable(format, comma);
        }

        internal static string JustFormat(bool comma)
        {
            return string.Concat(comma ? ",":"",Constants.Sql.Format);
        }
    }
}