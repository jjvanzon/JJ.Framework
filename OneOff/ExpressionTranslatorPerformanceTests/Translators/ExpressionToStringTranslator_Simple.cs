using System;
using System.Text;
using System.Linq.Expressions;
using JJ.Framework.Common;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator_Simple : ExpressionVisitor, IExpressionToStringTranslator
    {
        private StringBuilder sb = new StringBuilder();

        public string Result
        {
            get { return sb.ToString().CutLeft("."); }
        }

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
                    throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", node.NodeType));
            }
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            sb.Append(".");
            sb.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ArrayLength:
                    Visit(node.Operand);
                    sb.Append(".");
                    sb.Append("Length");
                    return node;

                default:
                    throw new ArgumentException(String.Format("Name cannot be obtained from node with NodeType '{0}'.", node.NodeType));
            }
        }
    }
}