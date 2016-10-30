namespace Saka.Entity.QueryBuilder
{
    using System;
    using Exceptions;
    using System.Text;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    internal static class ExpressionHelper
    {
        public static IEnumerable<string> GetExpressionPropertyNames<T>(params Expression<Func<T, object>>[] columns)
        {
            if (columns == null) throw new ArgumentNullException(nameof(columns));
            if (!columns.Any()) throw new ArgumentEmptyException("columns");

            return columns.Select(column => (column.Body as MemberExpression)?.Member.Name ?? (((UnaryExpression)column.Body).Operand as MemberExpression).Member.Name);
        }

        public static string GetExpressionPropertyName<T>(Expression<Func<T, object>> column)
        {
            if (column == null) throw new ArgumentNullException("columns");

            return (column.Body as MemberExpression)?.Member.Name ?? (((UnaryExpression) column.Body).Operand as MemberExpression).Member.Name;
        }

        public static string ConditionBuilder<T>(Expression<Func<T, object>> condition,string keyword = "")
        {
            var stringBuilder = new StringBuilder();
            if(!string.IsNullOrEmpty(keyword)) stringBuilder.Append(keyword);

            var memberExpression = condition.Body as MemberExpression;
            if (memberExpression != null) stringBuilder.Append(getMemberExpressionResult(memberExpression));
            var unaryExpression = condition.Body as UnaryExpression;
            if (unaryExpression != null) stringBuilder.Append(getUnaryExperrsionResult(unaryExpression));

            return stringBuilder.ToString();
        }

        private static string getUnaryExperrsionResult(UnaryExpression unaryExpression)
        {
            var operand = unaryExpression.Operand.NodeType;
            var leftValue = string.Empty;
            object rightValue = null;
            switch (operand)
            {
                case ExpressionType.Equal:
                case ExpressionType.NotEqual:
                case ExpressionType.LessThan:
                case ExpressionType.GreaterThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.GreaterThanOrEqual:
                    var memberExpression = ((BinaryExpression)unaryExpression.Operand).Left as MemberExpression;
                    if (memberExpression != null)
                    {
                        var memberCheck = ((BinaryExpression) unaryExpression.Operand).Left as MemberExpression;
                        if(memberCheck != null) leftValue = memberCheck.Member.Name;
                    }
                    else
                    {
                        var unaryCheck = ((BinaryExpression) unaryExpression.Operand).Left as UnaryExpression;
                        var member = unaryCheck?.Operand as MemberExpression;
                        if (member != null)
                        {
                            leftValue = member.Member.Name;
                            if(member.Type == typeof(char))
                            {
                                rightValue = ExpressionBuilder.Member_Is_Char(unaryExpression);
                                return string.Concat(leftValue.AddSqlBrackets(),GetOperand(operand),rightValue.SetSqlValueWithQuoteOrWithoutQuote()," ");
                            }
                        }
                    }
                    var constCheck = ((BinaryExpression) unaryExpression.Operand).Right as ConstantExpression;
                    if (constCheck != null) { rightValue = constCheck.Value;}
                    if (rightValue == null && (operand == ExpressionType.Equal || operand == ExpressionType.NotEqual))
                    {
                        var nullOrNotNull = operand == ExpressionType.Equal
                            ? Constants.Sql.IsNull
                            : Constants.Sql.IsNotNull;
                        return string.Concat(leftValue.AddSqlBrackets(), " ", nullOrNotNull, " ");
                    }
                    return string.Concat(leftValue.AddSqlBrackets(), GetOperand(operand), rightValue.SetSqlValueWithQuoteOrWithoutQuote(), " ");
                    case ExpressionType.Not:
                    return ExpressionBuilder.Operand_Not(unaryExpression);
                case ExpressionType.Call:
                    return ExpressionBuilder.Operand_Call(unaryExpression);
                case ExpressionType.MemberAccess:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    return ExpressionBuilder.Operand_MemberAccess(memberExpression);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string getMemberExpressionResult(MemberExpression memberExpression)
        {
            return memberExpression.Member.Name.AddSqlBrackets();
        }

        public static string GetOperand(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return " = ";
                case ExpressionType.LessThan:
                    return " < ";
                case ExpressionType.Not:
                case ExpressionType.NotEqual:
                    return " <> ";
                case ExpressionType.GreaterThan:
                    return " > ";
                case ExpressionType.LessThanOrEqual:
                    return " <= ";
                case ExpressionType.GreaterThanOrEqual:
                    return " >= ";
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GetOperandByMethodName(string methodName)
        {
            if(string.IsNullOrEmpty(methodName)) throw new ArgumentNullException(nameof(methodName));
            switch (methodName)
            {
                case Constants.MethodName.Equals:
                    return " = ";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
