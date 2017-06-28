using System;
using System.Text;
using System.Linq.Expressions;
using JJ.Framework.Common;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator_Simple : ExpressionVisitor, IExpressionToStringTranslator
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public string Result => _sb.ToString().TrimStart(".");

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }

        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)node;
                    VisitMember(memberExpression);
                    return node;

                case ExpressionType.ArrayLength:
                    var unaryExpression = (UnaryExpression)node;
                    VisitUnary(unaryExpression);
                    return node;

                case ExpressionType.Constant:
                    var constantExpression = (ConstantExpression)node;
                    VisitConstant(constantExpression);
                    return node;

                default:
                    throw new ArgumentException($"Name cannot be obtained from {node.NodeType}.");
            }
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            _sb.Append(".");
            _sb.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ArrayLength:
                    Visit(node.Operand);
                    _sb.Append(".");
                    _sb.Append("Length");
                    return node;

                default:
                    throw new ArgumentException($"Name cannot be obtained from node with NodeType '{node.NodeType}'.");
            }
        }
    }
}