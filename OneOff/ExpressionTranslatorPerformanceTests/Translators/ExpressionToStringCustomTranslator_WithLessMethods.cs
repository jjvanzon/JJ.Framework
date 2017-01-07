using System;
using System.Text;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringCustomTranslator_WithLessMethods : IExpressionToStringTranslator
    {
        private StringBuilder StringBuilder = new StringBuilder();

        public string Result
        {
            get
            {
                return StringBuilder.ToString().Substring(1);
            }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }
 
        public void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Lambda:
                    {
                        var lambdaExpression = (LambdaExpression)node;
                        Visit(lambdaExpression.Body);
                        return;
                    }

                case ExpressionType.MemberAccess:
                    {
                        var memberExpression = (MemberExpression)node;
                        VisitMember(memberExpression);
                        return;
                    }

                case ExpressionType.Constant:
                    // Ignore.
                    return;

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    {
                        var unaryExpression = (UnaryExpression)node;
                        if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                        {
                            var memberExpression = (MemberExpression)unaryExpression.Operand;
                            VisitMember(memberExpression);
                            return;
                        }
                        break;
                    }

                case ExpressionType.ArrayLength:
                    {
                        var unaryExpression = (UnaryExpression)node;
                        if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                        {
                            var memberExpression = (MemberExpression)unaryExpression.Operand;
                            VisitMember(memberExpression);

                            StringBuilder.Append(".");
                            StringBuilder.Append("Length");
                            return;
                        }
                        break;
                    }
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", node.NodeType));
        }

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            StringBuilder.Append(".");
            StringBuilder.Append(node.Member.Name);
        }
    }
}