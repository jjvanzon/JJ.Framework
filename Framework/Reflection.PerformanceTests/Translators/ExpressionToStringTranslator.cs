using System;
using System.Text;
using System.Linq.Expressions;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator : ExpressionVisitor, IExpressionToStringTranslator
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public string Result => _sb.ToString()
                                   .TrimStart(".")
                                   .Replace("(.", "(")
                                   .Replace("[.", "[");

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

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.ArrayLength:
                    var unaryExpression = (UnaryExpression)node;
                    VisitUnary(unaryExpression);
                    return node;

                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)node;
                    VisitMethodCall(methodCallExpression);
                    return node;

                case ExpressionType.Constant:
                    var constantExpression = (ConstantExpression)node;
                    VisitConstant(constantExpression);
                    return node;

                case ExpressionType.ArrayIndex:
                    var binaryExpression = (BinaryExpression)node;
                    VisitBinary(binaryExpression);
                    return node;

                case ExpressionType.NewArrayInit:
                    var newArrayExpression = (NewArrayExpression)node;
                    VisitNewArray(newArrayExpression);
                    return node;

                default:
                    throw new ArgumentException($"Name cannot be obtained from {node.NodeType}.");
            }
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsPrimitive)
            {
                _sb.Append(node.Value);
            }
            else if (node.Type == typeof(string))
            {
                _sb.Append(@"""");

                _sb.Append((string)node.Value);

                _sb.Append(@"""");
            }

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            if (node.Member.IsStatic())
            {
                _sb.Append(node.Member.DeclaringType.Name);
            }

            _sb.Append(".");
            _sb.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic)
            {
                _sb.Append(node.Method.DeclaringType.Name);
            }
            else
            {
                Visit(node.Object);
            }

            if (node.Method.IsIndexer())
            {
                _sb.Append("[");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    _sb.Append(", ");
                }
                Visit(node.Arguments[node.Arguments.Count - 1]);
                _sb.Append("]");
            }
            else
            {
                _sb.Append(".");
                _sb.Append(node.Method.Name);
                _sb.Append("(");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    _sb.Append(", ");
                }
                Visit(node.Arguments[node.Arguments.Count - 1]);
                _sb.Append(")");
            }

            return node;
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    Visit(node.Operand);
                    return node;

                case ExpressionType.ArrayLength:
                    VisitArrayLength(node);
                    return node;

                default:
                    throw new ArgumentException($"Name cannot be obtained from NodeType '{node.NodeType}'.");
            }
        }

        private void VisitArrayLength(UnaryExpression node)
        {
            Visit(node.Operand);
            _sb.Append(".");
            _sb.Append("Length");
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    VisitArrayIndex(node);
                    return node;

                default:
                    throw new ArgumentException($"Name cannot be obtained from NodeType '{node.NodeType}'.");
            }
        }

        private void VisitArrayIndex(BinaryExpression node)
        {
            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);

            _sb.Append("[");

            var constantExpression = (ConstantExpression)node.Right;
            int index = (int)constantExpression.Value;
            _sb.Append(index);

            _sb.Append("]");
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count - 1; i++)
            {
                Visit(node.Expressions[i]);
                _sb.Append(", ");
            }
            Visit(node.Expressions[node.Expressions.Count - 1]);

            return node;
        }
    }
}