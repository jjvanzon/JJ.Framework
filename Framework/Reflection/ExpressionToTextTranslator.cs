﻿using System;
using System.Text;
using JJ.Framework.Common;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection
{
    internal class ExpressionToTextTranslator
    {
        private StringBuilder _sb = new StringBuilder();

        /// <summary> 
        /// If you set this to true, an expression like MyArray[i] will translate to e.g. 
        /// "MyArray[2]" instead of "MyArray[i]". </summary>
        public bool ShowIndexerValues { get; set; }

        public string Execute(Expression expression)
        {
            Visit(expression);

            string result = _sb.ToString()
                               .CutLeft(".")
                               .Replace("(.", "(")
                               .Replace("[.", "[");
            return result;
        }

        protected virtual void Visit(Expression node)
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

        protected virtual void VisitConvert(UnaryExpression node)
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

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    {
                        var convertExpression2 = (UnaryExpression)node.Operand;
                        VisitConvert(convertExpression2);
                        break;
                    }

                case ExpressionType.ArrayLength:
                    {
                        var unaryExpression = (UnaryExpression)node.Operand;
                        VisitArrayLength(unaryExpression);
                        return;
                    }

                default:
                    {
                        throw new ArgumentException(String.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
                    }
            }
        }

        protected virtual void VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsPrimitive)
            {
                _sb.Append(node.Value.ToString());
            }
            else if (node.Type == typeof(string))
            {
                _sb.Append(@"""");

                _sb.Append((string)node.Value);

                _sb.Append(@"""");
            }

            // Otherwise: ignore.
        }

        protected virtual void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            if (ReflectionHelper.IsStatic(node.Member))
            {
                _sb.Append(node.Member.DeclaringType.Name);
            }

            // Then process 'child' node.
            _sb.Append(".");
            _sb.Append(node.Member.Name);
        }

        protected virtual void VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic)
            {
                _sb.Append(node.Method.DeclaringType.Name);
            }
            else
            {
                Visit(node.Object);
            }

            if (ReflectionHelper.IsIndexerMethod(node.Method))
            {
                _sb.Append("[");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    VisitIndexerValue(node.Arguments[i]);
                    _sb.Append(", ");
                }
                if (node.Arguments.Count != 0)
                {
                    VisitIndexerValue(node.Arguments[node.Arguments.Count - 1]);
                }
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
                if (node.Arguments.Count != 0)
                {
                    Visit(node.Arguments[node.Arguments.Count - 1]);
                }
                _sb.Append(")");
            }
        }

        protected virtual void VisitArrayLength(UnaryExpression node)
        {
            if (node.Operand.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)node.Operand;
                VisitMember(memberExpression);

                _sb.Append(".");
                _sb.Append("Length");
                return;
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        }

        protected virtual void VisitArrayIndex(BinaryExpression node)
        {
            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);

            _sb.Append("[");

            switch (node.Right.NodeType)
            {
                case ExpressionType.Constant:
                    var constantExpression = (ConstantExpression)node.Right;
                    int index = (int)constantExpression.Value;
                    _sb.Append(index);
                    break;

                case ExpressionType.MemberAccess:
                    var memberExpression2 = (MemberExpression)node.Right;
                    VisitIndexerValue(memberExpression2);
                    break;
            }

            _sb.Append("]");
        }

        /// <summary>
        /// Normally indexers are shown as the expression that they are, e.g. [i].
        /// If ShowIndexerValues is set to true, indexers are translated to their value, e.g. [2].
        /// To translate to their value, the work is delegated to ExpressionToValueTranslator.
        /// </summary>
        protected virtual void VisitIndexerValue(Expression node)
        {
            if (ShowIndexerValues)
            {
                object value = ExpressionHelper.GetValue(node);
                _sb.Append(value);
            }
            else
            {
                Visit(node);
            }
        }

        protected virtual void VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count - 1; i++)
            {
                Visit(node.Expressions[i]);
                _sb.Append(", ");
            }
            Visit(node.Expressions[node.Expressions.Count - 1]);
        }
    }
}
