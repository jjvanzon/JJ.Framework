using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Common;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection
{
    internal class ExpressionToStringTranslator 
    {
        // Not using the ExpressionVisitor base class performs better.

        /// <summary> If you set this to true, an expression like MyArray[i] will translate to e.g. "MyArray[2]", instead of "MyArray[i]". </summary>
        public bool ShowIndexerValues { get; set; }

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

        public void Visit(Expression node)
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
                        VisitConvert(unaryExpression);
                        return;
                    }

                case ExpressionType.ArrayLength:
                    {
                        var unaryExpression = (UnaryExpression)node;
                        VisitArrayLength(unaryExpression);
                        return;
                    }

                case ExpressionType.Call:
                    {
                        var methodCallExpression = (MethodCallExpression)node;
                        VisitMethodCall(methodCallExpression);
                        return;
                    }

                case ExpressionType.Constant:
                    {
                        var constantExpression = (ConstantExpression)node;
                        VisitConstant(constantExpression);
                        return;
                    }

                case ExpressionType.ArrayIndex:
                    {
                        var binaryExpression = (BinaryExpression)node;
                        VisitArrayIndex(binaryExpression);
                        return;
                    }

                case ExpressionType.NewArrayInit:
                    {
                        var newArrayExpression = (NewArrayExpression)node;
                        VisitNewArray(newArrayExpression);
                        return;
                    }
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", node.NodeType));
        }

        private void VisitConvert(UnaryExpression node)
        {
            switch (node.Operand.NodeType)
            {
                case ExpressionType.MemberAccess:
                    {
                        var memberExpression = (MemberExpression)node.Operand;
                        VisitMember(memberExpression);
                        return;
                    }

                case ExpressionType.Call:
                    {
                        Visit(node.Operand);
                        return;
                    }

                case ExpressionType.ArrayIndex:
                    {
                        var binaryExpression = (BinaryExpression)node.Operand;
                        VisitArrayIndex(binaryExpression);
                        break;
                    }

                case ExpressionType.Constant:
                    {
                        var constantExpression = (ConstantExpression)node.Operand;
                        VisitConstant(constantExpression);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException(String.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
                    }
            }
        }

        private void VisitConstant(ConstantExpression node)
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

            // Otherwise: ignore.
        }

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            if (ReflectionHelper.IsStatic(node.Member))
            {
                sb.Append(node.Member.DeclaringType.Name);
            }

            // Then process 'child' node.
            sb.Append(".");
            sb.Append(node.Member.Name);
        }

        private void VisitMethodCall(MethodCallExpression node)
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
                    VisitIndexerValue(node.Arguments[i]);
                    sb.Append(", ");
                }

                VisitIndexerValue(node.Arguments[node.Arguments.Count - 1]);
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
        }

        private void VisitArrayLength(UnaryExpression node)
        {
            if (node.Operand.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)node.Operand;
                VisitMember(memberExpression);

                sb.Append(".");
                sb.Append("Length");
                return;
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        }

        private void VisitArrayIndex(BinaryExpression node)
        {
            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);

            sb.Append("[");

            switch (node.Right.NodeType)
            {
                case ExpressionType.Constant:
                    var constantExpression = (ConstantExpression)node.Right;
                    int index = (int)constantExpression.Value;
                    sb.Append(index);
                    break;

                case ExpressionType.MemberAccess:
                    var memberExpression2 = (MemberExpression)node.Right;
                    VisitIndexerValue(memberExpression2);
                    break;
            }

            sb.Append("]");
        }

        /// <summary>
        /// Normally indexers are shown as the expression that they are, e.g. [i].
        /// If ShowIndexerValues is set to true, indexers are translated to their value, e.g. [2].
        /// To translate to their value, the work is delegated to ExpressionToValueTranslator.
        /// </summary>
        private void VisitIndexerValue(Expression node)
        {
            if (ShowIndexerValues)
            {
                object value = ExpressionHelper.GetValue(node);
                sb.Append(value);
            }
            else
            {
                Visit(node);
            }
        }

        private void VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count - 1; i++)
            {
                Visit(node.Expressions[i]);
                sb.Append(", ");
            }
            Visit(node.Expressions[node.Expressions.Count - 1]);
        }
    }
}
