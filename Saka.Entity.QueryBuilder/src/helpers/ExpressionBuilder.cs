namespace Saka.Entity.QueryBuilder
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    internal class ExpressionBuilder
    {
        internal static string Operand_Not(UnaryExpression unaryExpression)
        {
            var leftValue = string.Empty;
            object rightValue = null;

            var methodCheck = ((UnaryExpression) unaryExpression.Operand).Operand as MethodCallExpression;
            if (methodCheck != null)
            {
                var valueCheck = methodCheck.Arguments.FirstOrDefault() as ConstantExpression;
                if (valueCheck != null)
                {
                    rightValue = valueCheck.Value;
                }
                var leftCheck = methodCheck.Object as MemberExpression;
                if (leftCheck != null)
                {
                    leftValue = leftCheck.Member.Name;
                }
            }
            return string.Concat(leftValue.AddSqlBrackets(),ExpressionHelper.GetOperand(unaryExpression.Operand.NodeType),rightValue.SetSqlValueWithQuoteOrWithoutQuote());
        }

        internal static string Operand_MemberAccess(MemberExpression memberExpression)
        {
            return memberExpression.Member.Name.AddSqlBrackets();
        }

        internal static string Operand_Call(UnaryExpression unaryExpression)
        {
            var leftValue = string.Empty;
            object rightValue = null;
            var methodCheck = ((MethodCallExpression)unaryExpression.Operand).Object as MemberExpression;
            if (methodCheck != null) leftValue = methodCheck.Member.Name;
            var methodConstCheck = ((MethodCallExpression)unaryExpression.Operand).Arguments.FirstOrDefault() as ConstantExpression;
            if (methodConstCheck != null) rightValue = methodConstCheck.Value;
            var methodName = ((MethodCallExpression)unaryExpression.Operand).Method.Name;
            return string.Concat(leftValue.AddSqlBrackets(), ExpressionHelper.GetOperandByMethodName(methodName), rightValue.SetSqlValueWithQuoteOrWithoutQuote(), " ");
        }

        internal static char Member_Is_Char(UnaryExpression unaryExpression)
        {
            object rightValue = null;
            var charCheck = ((BinaryExpression)unaryExpression.Operand).Right as ConstantExpression;
            if (charCheck != null) { rightValue = charCheck.Value; }
            return Convert.ToChar(rightValue);
        }
    }
}
