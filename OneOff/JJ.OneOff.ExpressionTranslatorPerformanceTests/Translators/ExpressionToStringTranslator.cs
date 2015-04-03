using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator : ExpressionVisitor, IExpressionToStringTranslator
    {
        private StringBuilder sb = new StringBuilder();

        public string Result
        {
            get
            {
                return sb
                    .ToString()
                    .CutLeft(".")
                    .Replace("(.", "(")
                    .Replace("[.", "[");
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
                    throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", node.NodeType));
            }
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsPrimitive)
            {
                sb.Append(node.Value.ToString());
            }
            else if (node.Type == typeof(string))
            {
                sb.Append(@"""");

                sb.Append((string)node.Value);

                sb.Append(@"""");
            }

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            if (ReflectionHelper.IsStatic(node.Member))
            {
                sb.Append(node.Member.DeclaringType.Name);
            }

            sb.Append(".");
            sb.Append(node.Member.Name);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic)
            {
                sb.Append(node.Method.DeclaringType.Name);
            }
            else
            {
                Visit(node.Object);
            }

            if (ReflectionHelper.IsIndexerMethod(node.Method))
            {
                sb.Append("[");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    sb.Append(", ");
                }
                Visit(node.Arguments[node.Arguments.Count - 1]);
                sb.Append("]");
            }
            else
            {
                sb.Append(".");
                sb.Append(node.Method.Name);
                sb.Append("(");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    sb.Append(", ");
                }
                Visit(node.Arguments[node.Arguments.Count - 1]);
                sb.Append(")");
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
                    throw new ArgumentException(String.Format("Name cannot be obtained from NodeType '{0}'.", node.NodeType));
            }
        }

        private void VisitArrayLength(UnaryExpression node)
        {
            Visit(node.Operand);
            sb.Append(".");
            sb.Append("Length");
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    VisitArrayIndex(node);
                    return node;

                default:
                    throw new ArgumentException(String.Format("Name cannot be obtained from NodeType '{0}'.", node.NodeType));
            }
        }

        private void VisitArrayIndex(BinaryExpression node)
        {
            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);

            sb.Append("[");

            var constantExpression = (ConstantExpression)node.Right;
            int index = (int)constantExpression.Value;
            sb.Append(index);

            sb.Append("]");
        }

        protected override Expression VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count - 1; i++)
            {
                Visit(node.Expressions[i]);
                sb.Append(", ");
            }
            Visit(node.Expressions[node.Expressions.Count - 1]);

            return node;
        }
    }
}