namespace Saka.Entity.QueryBuilder
{
    internal static class Constants
    {
        internal static class Sql
        {
            internal const string Is = "IS ";
            internal const string Where = "WHERE ";
            internal const string Select = "SELECT ";
            internal const string SelectWithStar = "SELECT * ";
            internal const string Null = "NULL ";
            internal const string Max = "MAX ";
            internal const string Min = "MIN ";
            internal const string Avg = "AVG ";
            internal const string Count = "COUNT ";
            internal const string Sum = "SUM ";
            internal const string Format = "FORMAT ";
            internal const string GroupBy = "GROUP BY ";
            internal const string And = "AND ";
            internal const string Or = "OR ";
            internal const string As = "AS ";
            internal const string Having = "HAVING ";
            internal const string Upper = "UPPER ";
            internal const string Lower = "LOWER ";
            internal const string SubString = "SUBSTRING ";
            internal const string Len = "LEN ";
            internal const string Now = "NOW() ";
            internal const string Distinct = "DISTINCT ";
            internal const string From = "FROM ";
            internal const string IsNull = "IS NULL ";
            internal const string IsNotNull = "IS NOT NULL ";
            internal const string OrderBy = "ORDER BY ";
            internal const string Asc = "ASC ";
            internal const string Desc = "DESC ";
            internal const string Top = "TOP ";
            internal const string Percent = "PERCENT ";
            internal const string Insert = "INSERT ";
            internal const string Into = "INTO ";
            internal const string Values = "VALUES ";
            internal const string Update = "UPDATE ";
            internal const string Set = "SET ";
            internal const string Delete = "DELETE ";
            internal const string Like = "LIKE ";
            internal const string Between = "BETWEEN ";
            internal const string Not = "NOT ";
            internal const string Union = "UNION ";
            internal const string UnionAll = "UNION ALL ";
            internal const string Drop = "DROP ";
            internal const string Table = "TABLE ";
            internal const string Database = "DATABASE ";
            internal const string Truncate = "TRUNCATE ";
            internal const string Alter = "ALTER ";
            internal const string Add = "ADD ";
            internal const string NotNull = "NOT NULL ";
            internal const string Column = "COLUMN ";
            internal const string Begin = "BEGIN ";
            internal const string End = "END ";
            internal const string Case = "CASE ";
            internal const string When = "WHEN ";
            internal const string If = "IF ";
            internal const string Else = "ELSE ";
            internal const string Then = "THEN ";
            internal const string Go = "GO ";
            internal const string Transaction = "TRANSACTION ";
            internal const string RollBack = "ROLLBACK ";
            internal const string Output = "OUTPUT ";
            internal const string Inserted = "INSERTED";
            internal const string Declare = "DECLARE ";
            internal const string Return = "RETURN ";
            internal const string Use = "USE ";
            internal const string Print = "PRINT ";
            internal const string Join = "JOIN ";
            internal const string On = "ON ";
            internal const string LeftJoin = "LEFT JOIN ";
            internal const string In = "IN ";
            
        }
        internal static class NodeType
        {
            internal const string Equal = "Equal";
            internal const string GreaterThan = "GreaterThan";
            internal const string LessThan = "LessThan";
            internal const string LessThanOrEqual = "LessThanOrEqual";
            internal const string GreaterThanOrEqual = "GreaterThanOrEqual";
            internal const string NotEqual = "NotEqual";
        }

        internal static class MethodName
        {
            internal new const string Equals = "Equals";
        }

        internal static class Signs
        {
            internal const string OpenParenthesis = "(";
            internal const string CloseParenthesis = ")";
            internal const string Comma = ",";
            internal const string Star = "*";
        }
    }
}
