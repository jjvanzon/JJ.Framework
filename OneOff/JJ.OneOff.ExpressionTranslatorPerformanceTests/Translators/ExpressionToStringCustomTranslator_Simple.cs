using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringCustomTranslator_Simple : IExpressionToStringTranslator
    {
        private StringBuilder StringBuilder = new StringBuilder();

        public string Result
        {
            get
            {
                return StringBuilder.ToString().Substring(1); // Take off the last period.
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

        private void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var memberExpression = (MemberExpression)node;
                        VisitMember(memberExpression);
                        return;
                    }

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
                switch (node.Expression.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        {
                            var node2 = (MemberExpression)node.Expression;
                            VisitMember(node2);
                            break;
                        }

                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        {
                            var unaryExpression = (UnaryExpression)node.Expression;
                            if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                            {
                                var memberExpression = (MemberExpression)unaryExpression.Operand;
                                VisitMember(memberExpression);
                            }
                            return;
                        }
                }
            }

            // Then process 'child' node.
            StringBuilder.Append(".");
            StringBuilder.Append(node.Member.Name);
        }
    }
}