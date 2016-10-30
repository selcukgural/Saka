namespace Saka.Entity.QueryBuilder
{
    using System;
    using Exceptions;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;
   
    public sealed class QueryBuilder<T> : IQueryBuilder<T>, IDisposable
    {
        public string Query { get; private set; }
        public string TableName { get; private set; }
        public QueryBuilder()
        {
            TableName = typeof (T).Name;
        }

        #region SELECT
        public QueryBuilder<T> Select(params Expression<Func<T,object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");
            this.Query += QueryBuilder.Select.WithExpression(columns);
            return this;
        }

        public QueryBuilder<T> Select(IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            this.Query+=QueryBuilder.Select.WithIEnumerable(columns);
            return this;
        }

        public QueryBuilder<T> Select(params string[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            this.Query += QueryBuilder.Select.WithParams(columns);
            return this;
        }

        public QueryBuilder<T> Select()
        {
            this.Query += QueryBuilder.Select.WithoutColumns();
            return this;
        }

        public QueryBuilder<T> SelectAllProperties()
        {
            this.Query += QueryBuilder.Select.WithAllProperties<T>();
            return this;
        }

        public QueryBuilder<T> SelectAllWithStar()
        {
            this.Query += QueryBuilder.Select.WithAllStar();
            return this;
        }
        #endregion

        #region WHERE
        public QueryBuilder<T> Where(Expression<Func<T,object>> condition, bool parenthesis = false)
        {
            this.Query += QueryBuilder.Where.WithExpression(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> Where(string condition, bool parenthesis = false)
        {
            if(string.IsNullOrEmpty(condition)) throw new ArgumentNullException(nameof(condition));

            this.Query += QueryBuilder.Where.WithString(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> Where()
        {
            this.Query += QueryBuilder.Where.JustWhere();
            return this;
        }
        #endregion

        #region MAX
        public QueryBuilder<T> Max(Expression<Func<T,object>> column,bool comma = false)
        {
            Query += QueryBuilder.Max.WithExpression(column,comma);
            return this;
        }

        public QueryBuilder<T> Max(string column,bool comma = false)
        {
            if(string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.Max.WithString(column,comma);
            return this;
        }

        public QueryBuilder<T> Max(bool comma = false)
        {
            Query += QueryBuilder.Max.JustMax(comma);
            return this;
        }

        #endregion

        #region MIN
        public QueryBuilder<T> Min(Expression<Func<T,object>> column, bool comma = false)
        {
            Query += QueryBuilder.Min.WithExpression(column, comma);
            return this;
        }

        public QueryBuilder<T> Min(string column, bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.Min.WithString(column, comma);
            return this;
        }

        public QueryBuilder<T> Min(bool comma = false)
        {
            Query += QueryBuilder.Min.JustMin(comma);
            return this;
        }

        #endregion

        #region AVG
        public QueryBuilder<T> Avg(Expression<Func<T,object>> column, bool comma = false)
        {
            Query += QueryBuilder.Avg.WithExpression(column, comma);
            return this;
        }

        public QueryBuilder<T> Avg(string column, bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.Avg.WithString(column, comma);
            return this;
        }

        public QueryBuilder<T> Avg(bool comma = false)
        {
            Query += QueryBuilder.Avg.JustAvg(comma);
            return this;
        }


        #endregion

        #region COUNT
        public QueryBuilder<T> Count(Expression<Func<T,object>> column, bool comma = false)
        {
            Query += QueryBuilder.Count.WithExpression(column,comma);
            return this;
        }

        public QueryBuilder<T> Count(string column,bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.Count.WithString(column,comma);
            return this;
        }

        public QueryBuilder<T> Count(bool isStar = false,bool comma = false)
        {
            Query += QueryBuilder.Count.WihtStar(isStar,comma);
            return this;
        }
        #endregion

        #region SUM
        public QueryBuilder<T> Sum(Expression<Func<T,object>> column, bool comma = false)
        {
            Query += QueryBuilder.Sum.WithExpression(column, comma);
            return this;
        }

        public QueryBuilder<T> Sum(string column, bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.Sum.WithString(column, comma);
            return this;
        }

        public QueryBuilder<T> Sum(bool comma = false)
        {
            Query += QueryBuilder.Sum.JustSum(comma);
            return this;
        }
        #endregion

        #region BASE
        public string EndQuery()
        {
            return Query += ";";
        }

        public void Clear()
        {
            Query = string.Empty;
        }

        public QueryBuilder<T> FreeText(string value)
        {
            Query += value;
            return this;
        }
        public override string ToString()
        {
            return Query;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            Query = string.Empty;
            TableName = string.Empty;
        }
        #endregion

        #region Is
        public QueryBuilder<T> Is()
        {
            Query += QueryBuilder.Is.JustIs();
            return this;
        }
        #endregion

        #region Null
        public QueryBuilder<T> Null()
        {
            Query += QueryBuilder.Null.JustNull();
            return this;
        } 
        #endregion

        #region FORMAT
        public QueryBuilder<T> Format(IEnumerable<string> format, bool comma = false)
        {
            Query += QueryBuilder.Format.FormatWithEnumerable(format, comma);
            return this;
        }

        public QueryBuilder<T> Format(string[] format, bool comma = false)
        {
            Query += QueryBuilder.Format.FormatWithArray(format, comma);
            return this;
        }

        public QueryBuilder<T> Format(bool comma = false)
        {
            Query += QueryBuilder.Format.JustFormat(comma);
            return this;
        }

        #endregion

        #region GROUP BY
        public QueryBuilder<T> GroupBy(params Expression<Func<T,object>>[] columns)
        {
            Query += QueryBuilder.GroupBy.WithParamsExpression(columns);
            return this;
        }

        public QueryBuilder<T> GroupBy(Expression<Func<T,object>> column)
        {
            Query += QueryBuilder.GroupBy.WithExpression(column);
            return this;
        }

        public QueryBuilder<T> GroupBy(IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.GroupBy.WithIEnumerableString(columns);
            return this;
        }

        public QueryBuilder<T> GroupBy(string value)
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentNullException(nameof(value));

            Query += QueryBuilder.GroupBy.WihtString(value);
            return this;
        }

        public QueryBuilder<T> GroupBy()
        {
            Query += QueryBuilder.GroupBy.JustGroupBy();
            return this;
        }

        #endregion

        #region AND
        public QueryBuilder<T> And(Expression<Func<T,object>> condition, bool parenthesis = false)
        {
            this.Query += QueryBuilder.And.WithExpression(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> And(string condition, bool parenthesis = false)
        {
            if(string.IsNullOrEmpty(condition)) throw new ArgumentNullException(nameof(condition));
            this.Query += QueryBuilder.And.WithString(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> And()
        {
            this.Query += QueryBuilder.And.JustAnd();
            return this;
        }
        #endregion

        #region AS
        public QueryBuilder<T> As(string alias)
        {
            if(string.IsNullOrEmpty(alias)) throw new ArgumentNullException(nameof(alias));
            this.Query += QueryBuilder.As.WithString(alias);
            return this;
        }

        public QueryBuilder<T> As()
        {
            this.Query += QueryBuilder.As.JustAs();
            return this;
        }

        #endregion

        #region HAVING
        public QueryBuilder<T> Having()
        {
            this.Query += QueryBuilder.Having.JustHaving();
            return this;
        }
        #endregion

        #region UPPER
        public QueryBuilder<T> Upper(Expression<Func<T,object>> condition,bool comma = false)
        {
            this.Query += QueryBuilder.Upper.WithExpression(condition,comma);
            return this;
        }

        public QueryBuilder<T> Upper(string column,bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));
            this.Query += QueryBuilder.Upper.WithString(column,comma);
            return this;
        }

        public QueryBuilder<T> Upper(bool comma = false)
        {
            this.Query += QueryBuilder.Upper.JustUpper(comma);
            return this;
        }

        #endregion

        #region LOWER
        public QueryBuilder<T> Lower(Expression<Func<T,object>> condition,bool comma = false)
        {
            this.Query += QueryBuilder.Lower.WithExpression(condition,comma);
            return this;
        }

        public QueryBuilder<T> Lower(string column,bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));
            this.Query += QueryBuilder.Lower.WithString(column,comma);
            return this;
        }

        public QueryBuilder<T> Lower(bool comma = false)
        {
            this.Query += QueryBuilder.Lower.JustLower(comma);
            return this;
        }

        #endregion

        #region SUBSTRING
        public QueryBuilder<T> SubString(Expression<Func<T,object>> column, int startIndex, int length,bool comma = false)
        {
            this.Query += QueryBuilder.SubString.WithExpression(column, startIndex, length,comma);
            return this;
        }

        public QueryBuilder<T> SubString(string column, int startIndex, int length,bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));
            this.Query += QueryBuilder.SubString.WithString(column, startIndex, length,comma);
            return this;
        }

        public QueryBuilder<T> SubString(bool comma = false)
        {
            this.Query += QueryBuilder.SubString.JustSubString(comma);
            return this;
        }

        #endregion

        #region LEN
        public QueryBuilder<T> Len(Expression<Func<T,object>> column,bool comma = false)
        {
            this.Query += QueryBuilder.Len.WithExpression(column,comma);
            return this;
        }

        public QueryBuilder<T> Len(string column, bool comma = false)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));
            this.Query += QueryBuilder.Len.WithString(column,comma);
            return this;
        }

        public QueryBuilder<T> Len(bool comma = false)
        {
            this.Query += QueryBuilder.Len.JustLen(comma);
            return this;
        }

        #endregion

        #region NOW
        public QueryBuilder<T> Now(bool comma)
        {
            Query += QueryBuilder.Now.JustNow(comma);
            return this;
        }
        #endregion

        #region DISTINCT
        public QueryBuilder<T> Distinct(params Expression<Func<T,object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Distinct.WithExpression(columns);
            return this;
        }

        public QueryBuilder<T> Distinct(IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Distinct.WithIEnumerable(columns);
            return this;
        }

        public QueryBuilder<T> Distinct(params string[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Distinct.WithParams(columns);
            return this;
        }

        public QueryBuilder<T> Distinct()
        {
            Query += QueryBuilder.Distinct.JustDistinct();
            return this;
        }

        #endregion

        #region FROM
        public QueryBuilder<T> From(bool justFrom = false)
        {
            if (justFrom) Query += QueryBuilder.From.JustFrom();
            else Query += QueryBuilder.From.WithTableName(TableName); 

            return this;
        }

        public QueryBuilder<T> From(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.From.WithTableName(tableName);
            return this;
        }
        #endregion

        #region OR
        public QueryBuilder<T> Or(Expression<Func<T,object>> condition, bool parenthesis = false)
        {
            this.Query += QueryBuilder.Or.WithExpression(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> Or(string condition, bool parenthesis = false)
        {
            if (string.IsNullOrEmpty(condition)) throw new ArgumentNullException(nameof(condition));
            this.Query += QueryBuilder.Or.WithString(condition, parenthesis);
            return this;
        }

        public QueryBuilder<T> Or()
        {
            this.Query += QueryBuilder.Or.JustOr();
            return this;
        }
        #endregion

        #region ORDER BY

        public QueryBuilder<T> OrderBy(Expression<Func<T,object>> column, bool asc = true)
        {
            Query += QueryBuilder.OrderBy.WithExpression(column, asc);
            return this;
        }

        public QueryBuilder<T> OrderBy(string column, bool asc = true)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));

            Query += QueryBuilder.OrderBy.WithString(column, asc);
            return this;
        }

        public QueryBuilder<T> OrderBy()
        {
            Query += QueryBuilder.OrderBy.JustOrderBy();
            return this;
        }
        #endregion

        #region TOP
        public QueryBuilder<T> Top(int top, bool percent = false, params Expression<Func<T,object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Top.WithExpression(top, percent, columns);
            return this;
        }

        public QueryBuilder<T> Top(int top, bool percent, IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Top.WihtIEnumerable(top, percent, columns);
            return this;
        }

        public QueryBuilder<T> Top(int top, bool percent = false, params string[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Top.WihtParams(top, percent, columns);
            return this;
        }

        public QueryBuilder<T> Top()
        {
            Query += QueryBuilder.Top.JustTop();
            return this;
        }
        #endregion

        #region INSERT
        public QueryBuilder<T> Insert()
        {
            Query += QueryBuilder.Insert.JustInsert();
            return this;
        }
        #endregion

        #region INTO
        public QueryBuilder<T> Into(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.Into.WithString(tableName);
            return this;
        }

        public QueryBuilder<T> Into(bool genericTypeNameIsTableName = false)
        {
            Query += QueryBuilder.Into.JustInto(genericTypeNameIsTableName, TableName);
            return this;
        }
        #endregion

        #region COLUMNS
        public QueryBuilder<T> Columns(params Expression<Func<T,object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Columns.WithExpression(columns);
            return this;
        }

        public QueryBuilder<T> Columns(IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Columns.WithIEnumerable(columns);
            return this;
        }

        public QueryBuilder<T> Columns(params string[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Columns.WithIEnumerable(columns);
            return this;
        }
        #endregion

        #region VALUES
        public QueryBuilder<T> Values(IEnumerable<object> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Values.WithIEnumerable(columns);
            return this;
        }

        public QueryBuilder<T> Values(params object[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Values.WithParams(columns);
            return this;
        }
        #endregion

        #region UPDATE
        public QueryBuilder<T> Update(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.Update.WihtString(tableName);
            return this;
        }

        public QueryBuilder<T> Update(bool genericTypeNameIsTableName = false)
        {
            Query += QueryBuilder.Update.JustUpdate(genericTypeNameIsTableName, TableName);
            return this;
        }
        #endregion

        #region SET
        public QueryBuilder<T> Set(params Expression<Func<T,object>>[] columnsAndValues)
        {
            if (columnsAndValues == null || !columnsAndValues.Any()) throw new ArgumentNullException(nameof(columnsAndValues));
            Query += QueryBuilder.Set.WithExpression(columnsAndValues);
            return this;
        }

        public QueryBuilder<T> Set(IDictionary<string, object> columnsAndValues)
        {
            if (columnsAndValues == null || !columnsAndValues.Keys.Any() || !columnsAndValues.Values.Any()) throw new ArgumentNullException(nameof(columnsAndValues));
            Query += QueryBuilder.Set.WihtIDictionary(columnsAndValues);
            return this;
        }

        public QueryBuilder<T> Set(IEnumerable<string> columns, IEnumerable<object> values)
        {
            if (columns == null || !columns.Any()) throw new ArgumentNullException(nameof(columns));
            if (values == null || !values.Any()) throw new ArgumentNullException(nameof(values));

            Query += QueryBuilder.Set.WihtEnumerable(columns, values);
            return this;
        }

        public QueryBuilder<T> Set(string column, object value)
        {
            if (string.IsNullOrEmpty(column)) throw new ArgumentNullException(nameof(column));
            Query += QueryBuilder.Set.WithSingle(column, value);
            return this;
        }

        public QueryBuilder<T> Set()
        {
            Query += QueryBuilder.Set.JustSet();
            return this;
        }
        #endregion

        #region DELETE
        public QueryBuilder<T> Delete()
        {
            Query += QueryBuilder.Delete.JustDelete();
            return this;
        }
        #endregion

        #region LIKE
        public QueryBuilder<T> Like(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentNullException(nameof(pattern));
            Query += QueryBuilder.Like.WihtString(pattern);
            return this;
        }

        public QueryBuilder<T> Like()
        {
            Query += QueryBuilder.Like.JustLike();
            return this;
        }
        #endregion

        #region BETWEEN
        public QueryBuilder<T> Between(object value1, object value2)
        {
            Query += QueryBuilder.Between.WihtObjects(value1, value2);
            return this;
        }

        public QueryBuilder<T> Between()
        {
            Query += QueryBuilder.Between.JustBetween();
            return this;
        }
        #endregion

        #region NOT
        public QueryBuilder<T> Not()
        {
            Query += QueryBuilder.Not.JustNot();
            return this;
        }
        #endregion

        #region UNION
        public QueryBuilder<T> Union(bool all = false)
        {
            Query += QueryBuilder.Union.JustUnion(all);
            return this;
        }
        #endregion

        #region DROP
        public QueryBuilder<T> Drop()
        {
            Query += QueryBuilder.Drop.JustDrop();
            return this;
        }
        #endregion

        #region TABLE
        public QueryBuilder<T> Table(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.Table.WithString(tableName);
            return this;
        }

        public QueryBuilder<T> Table(bool genericTypeNameIsTableName = false)
        {
            Query += QueryBuilder.Table.JustTable(genericTypeNameIsTableName, TableName);
            return this;
        }
        #endregion

        #region DATABASE
        public QueryBuilder<T> Database(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.Database.WithString(tableName);
            return this;
        }

        public QueryBuilder<T> Database(bool genericTypeNameIsTableName = false)
        {
            Query += QueryBuilder.Database.JustDatabase(genericTypeNameIsTableName, TableName);
            return this;
        }
        #endregion

        #region TRUNCATE
        public QueryBuilder<T> Truncate()
        {
            Query += QueryBuilder.Truncate.JustTruncate();
            return this;
        }
        #endregion
        
        #region ALTER
        public QueryBuilder<T> Alter()
        {
            Query += QueryBuilder.Alter.JustAlter();
            return this;
        }
        #endregion

        #region ADD

        public QueryBuilder<T> Add<K>(Expression<Func<T,object>> column, SqlDbType sqlDbType, K KLength, bool canBeNull)
        {
            Query += QueryBuilder.Add.WihtExpression(column, sqlDbType, KLength, canBeNull);
            return this;
        }

        public QueryBuilder<T> Add<K>(string columnName, SqlDbType sqlDbType, K KLenght, bool canBeNull)
        {
            Query += QueryBuilder.Add.WithParameters<K>(columnName, sqlDbType, KLenght, canBeNull);
            return this;
        }

        public QueryBuilder<T> Add(Expression<Func<T,object>> column, SqlDbType sqlDbType, bool canBeNull)
        {
            Query += QueryBuilder.Add.WihtExpression(column, sqlDbType, canBeNull);
            return this;
        }

        public QueryBuilder<T> Add(string columnName, SqlDbType sqlDbType, bool canBeNull)
        {
            Query += QueryBuilder.Add.WithParameters(columnName, sqlDbType, canBeNull);
            return this;
        }

        public QueryBuilder<T> Add()
        {
            Query += QueryBuilder.Add.JustAdd();
            return this;
        }
        #endregion

        #region COLUMN
        public QueryBuilder<T> Column(Expression<Func<T,object>> column)
        {
            if (column == null) throw new ArgumentNullException(nameof(column));
            Query += QueryBuilder.Column.WithExpression(column);
            return this;
        }

        public QueryBuilder<T> Column(string columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException(nameof(columnName));
            Query += QueryBuilder.Column.WithString(columnName);
            return this;
        }

        public QueryBuilder<T> Column()
        {
            Query += QueryBuilder.Column.JustColumn();
            return this;
        }
        #endregion

        #region BEGIN
        public QueryBuilder<T> Begin()
        {
            Query += QueryBuilder.Begin.JustBegin();
            return this;
        }
        #endregion

        #region END
        public QueryBuilder<T> End()
        {
            Query += QueryBuilder.End.JustEnd();
            return this;
        }
        #endregion

        #region CASE
        public QueryBuilder<T> Case(Expression<Func<T,object>> expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Query += QueryBuilder.Case.WithExpression(expression);
            return this;
        }

        public QueryBuilder<T> Case(string expression)
        {
            if (string.IsNullOrEmpty(expression)) throw new ArgumentNullException(nameof(expression));
            Query += QueryBuilder.Case.WithString(expression);
            return this;
        }

        public QueryBuilder<T> Case()
        {
            Query += QueryBuilder.Case.JutCase();
            return this;
        }
        #endregion

        #region WHEN
        public QueryBuilder<T> When(Expression<Func<T,object>> condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));
            Query += QueryBuilder.When.WithExpression(condition);
            return this;
        }

        public QueryBuilder<T> When(string condition)
        {
            if (string.IsNullOrEmpty(condition)) throw new ArgumentNullException(nameof(condition));
            Query += QueryBuilder.When.WithString(condition);
            return this;
        }

        public QueryBuilder<T> When()
        {
            Query += QueryBuilder.When.JustWhen();
            return this;
        }
        #endregion

        #region THEN
        public QueryBuilder<T> Then(Expression<Func<T,object>> expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Query += QueryBuilder.Then.WithExpression(expression);
            return this;
        }

        public QueryBuilder<T> Then(object expression)
        {
            Query += QueryBuilder.Then.WithObject(expression);
            return this;
        }

        public QueryBuilder<T> Then()
        {
            Query += QueryBuilder.Then.JustThen();
            return this;
        }
        #endregion

        #region ELSE
        public QueryBuilder<T> Else(Expression<Func<T,object>> expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));
            Query += QueryBuilder.Else.WithExpression(expression);
            return this;
        }

        public QueryBuilder<T> Else(object expression)
        {
            Query += QueryBuilder.Else.WithObject(expression);
            return this;
        }

        public QueryBuilder<T> Else()
        {
            Query += QueryBuilder.Else.JustElse();
            return this;
        }
        #endregion

        #region GO
        public QueryBuilder<T> Go()
        {
            Query += QueryBuilder.Go.JustGo();
            return this;
        }
        #endregion

        #region TRANSACTION
        public QueryBuilder<T> Transaction()
        {
            Query += QueryBuilder.Transaction.JustTransaction();
            return this;
        }
        #endregion

        #region ROLLBACK
        public QueryBuilder<T> RollBack()
        {
            Query += QueryBuilder.RollBack.JustRollBack();
            return this;
        }
        #endregion

        #region OUTPUT
        public QueryBuilder<T> Output()
        {
            Query += QueryBuilder.Output.JustOutput();
            return this;
        }
        #endregion

        #region INSERTED

        public QueryBuilder<T> Inserted(params Expression<Func<T,object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Inserted.WithExpression(columns);
            return this;
        }

        public QueryBuilder<T> Inserted(IEnumerable<string> columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Inserted.WithIEnumerable(columns);
            return this;
        }

        public QueryBuilder<T> Inserted(params string[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            Query += QueryBuilder.Inserted.WithParams(columns);
            return this;
        }

        public QueryBuilder<T> Inserted()
        {
            Query += QueryBuilder.Inserted.JustInserted();
            return this;
        }
        #endregion

        #region DECLARE
        public QueryBuilder<T> Declare(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            Query += QueryBuilder.Declare.WithString(name);
            return this;
        }

        public QueryBuilder<T> Declare()
        {
            Query += QueryBuilder.Declare.JustDeclare();
            return this;
        }
        #endregion

        #region RETURN
        public QueryBuilder<T> Return(int value)
        {
            Query += QueryBuilder.Return.WithInteger(value);
            return this;
        }

        public QueryBuilder<T> Return()
        {
            Query += QueryBuilder.Return.JustReturn();
            return this;
        }
        #endregion

        #region USE
        public QueryBuilder<T> Use(string databaseName)
        {
            if (string.IsNullOrEmpty(databaseName)) throw new ArgumentNullException(nameof(databaseName));

            Query += QueryBuilder.Use.WihtString(databaseName);
            return this;
        }

        public QueryBuilder<T> Use()
        {
            Query += QueryBuilder.Use.JustUse();
            return this;
        }
        #endregion

        #region PRINT
        public QueryBuilder<T> Print(string value)
        {
            Query += QueryBuilder.Print.WihtString(value);
            return this;
        }

        public QueryBuilder<T> Print()
        {
            Query += QueryBuilder.Print.JustPrint();
            return this;
        }
        #endregion

        #region IF
        public QueryBuilder<T> If(Expression<Func<T,object>> condition)
        {
            if (condition == null) throw new ArgumentNullException(nameof(condition));

            Query += QueryBuilder.If.WihtExpression(condition);
            return this;
        }

        public QueryBuilder<T> If(string condition)
        {
            if (string.IsNullOrEmpty(condition)) throw new ArgumentNullException(nameof(condition));

            Query += QueryBuilder.If.WithString(condition);
            return this;
        }

        public QueryBuilder<T> If()
        {
            Query += QueryBuilder.If.JustIf();
            return this;
        }
        #endregion

        #region JOIN
        public QueryBuilder<T> Join<K>() where K : class 
        {
            Query += QueryBuilder.Join.WithGenericType<K>();
            return this;
        }

        public QueryBuilder<T> Join(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.Join.WithString(tableName);
            return this;
        }

        public QueryBuilder<T> Join()
        {
            Query += QueryBuilder.Join.JustJoin();
            return this;
        }
        #endregion

        #region ON
        public QueryBuilder<T> On<K>(Expression<Func<T,object>> TCondition, Expression<Func<K, object>> KCondition) where K : class
        {
            Query += QueryBuilder.On.WithExpression(TCondition, KCondition);
            return this;
        }

        public QueryBuilder<T> On(string condition, string condition2)
        {
            Query += QueryBuilder.On.WihtString(condition, condition2);
            return this;
        }

        public QueryBuilder<T> On()
        {
            Query += QueryBuilder.On.JustOn();
            return this;
        }


        #endregion

        #region LEFT JOIN
        public QueryBuilder<T> LeftJoin<K>() where K : class
        {
            Query += QueryBuilder.LeftJoin.WithGenericType<K>();
            return this;
        }

        public QueryBuilder<T> LeftJoin(string tableName)
        {
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentNullException(nameof(tableName));
            Query += QueryBuilder.LeftJoin.WithString(tableName);
            return this;
        }

        public QueryBuilder<T> LeftJoin()
        {
            Query += QueryBuilder.LeftJoin.JustLeftJoin();
            return this;
        }
        #endregion

        #region IN
        public QueryBuilder<T> In<K>(IEnumerable<K> values)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (!values.Any()) throw new ArgumentEmptyException("values");

            Query += QueryBuilder.In.WihtEnumerable(values);
            return this;
        }

        public QueryBuilder<T> In<K>(params K[] values)
        {
            In<K>(values.ToList());
            return this;
        }

        public QueryBuilder<T> In()
        {
            Query += QueryBuilder.In.JustIn();
            return this;
        }
        #endregion

        #region ASC
        public QueryBuilder<T> Asc()
        {
            Query += QueryBuilder.Asc.JustAsc();
            return this;
        }

        #endregion

        #region DESC
        public QueryBuilder<T> Desc()
        {
            Query += QueryBuilder.Desc.JustDesc();
            return this;
        } 
        #endregion
    }
}