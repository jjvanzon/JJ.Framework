﻿using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JJ.Framework.Reflection.Legacy
{
    internal class ExpressionToValueTranslator
    {
        private IList<object> _list;
        private Stack<object> _stack;

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public IList<object> GetValues(Expression expression)
        {
            GetValue(expression);

            return _list;
        }

        #if !NET9_0_OR_GREATER
        [NoTrim(ExpressionsWithArrays)]
        #endif
        public object GetValue(Expression expression)
        {
            _list = new List<object>();
            _stack = new Stack<object>();
            Visit(expression);
            return _stack.Peek();
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
                    _stack.Push(constantExpression.Value);
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

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", node.NodeType));
        }

        protected virtual void VisitConstant(UnaryExpression unaryExpression)
        {
            var constantExpression = (ConstantExpression)unaryExpression.Operand;
            _stack.Push(constantExpression.Value);
        }

        protected virtual void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            MemberTypes_PlatformSafe memberType = node.Member.MemberType_PlatformSafe();
            switch (memberType)
            {
                case MemberTypes_PlatformSafe.Field:
                    VisitField(node);
                    return;

                case MemberTypes_PlatformSafe.Property:
                    VisitProperty(node);
                    return;

                default:
                    throw new NotSupportedException(String.Format("Member types other than FieldInfo and PropertyInfo are not supported. Member type = {0}", node.Member.GetType().Name)); // ncrunch: no coverage
            }
        }

        protected virtual void VisitField(MemberExpression node)
        {
            var field = (FieldInfo)node.Member;
            object obj = null;
            if (!field.IsStatic)
            {
                obj = _stack.Pop();
            }
            object value = field.GetValue(obj);
            _stack.Push(value);

            _list.Add(value);
        }

        protected virtual void VisitProperty(MemberExpression node)
        {
            var property = (PropertyInfo)node.Member;
            object obj = null;
            MethodInfo getterOrSetter = property.GetGetMethod() ?? property.GetSetMethod();
            if (!getterOrSetter.IsStatic)
            {
                obj = _stack.Pop();
            }
            object value = property.GetValue(obj, null);
            _stack.Push(value);

            _list.Add(value);
        }

        protected virtual void VisitMethodCall(MethodCallExpression node)
        {
            if (!node.Method.IsStatic)
            {
                Visit(node.Object);
            }
            else
            {
                _stack.Push(null);
            }

            for (int i = 0; i < node.Arguments.Count; i++)
            {
                Visit(node.Arguments[i]);
            }
            object[] arguments = new object[node.Arguments.Count];
            for (int i = node.Arguments.Count - 1; i >= 0; i--)
            {
                arguments[i] = _stack.Pop();
            }

            object obj = _stack.Pop();
            object value = node.Method.Invoke(obj, arguments);
            _stack.Push(value);

            _list.Add(value);
        }

        protected virtual void VisitConvert(UnaryExpression node)
        {
            switch (node.Operand.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)node.Operand;
                    VisitMember(memberExpression);
                    break;

                case ExpressionType.Call:
                    Visit(node.Operand);
                    break;

                case ExpressionType.ArrayIndex:
                    var binaryExpression = (BinaryExpression)node.Operand;
                    VisitArrayIndex(binaryExpression);
                    break;

                case ExpressionType.Constant:
                    // TODO: Looks wrong. Should this not be node.Operand?
                    VisitConstant(node);
                    break;

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    var convertExpression2 = (UnaryExpression)node.Operand;
                    VisitConvert(convertExpression2);
                    break;

                default:
                    throw new ArgumentException(String.Format("Value cannot be obtained from NodeType {0}.", node.Operand.NodeType));
            }

            Type type = node.Type;
            if (type.IsNullableType())
            {
                type = Nullable.GetUnderlyingType(type);
            }
            object obj = _stack.Pop();
            if (obj is IConvertible)
            {
                obj = Convert.ChangeType(obj, type);
            }
            _stack.Push(obj);
        }

        protected virtual void VisitArrayLength(UnaryExpression node)
        {
            if (node.Operand.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = (MemberExpression)node.Operand;
                VisitMember(memberExpression);
                Array array = (Array)_stack.Pop();
                _stack.Push(array.Length);
                return;
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from NodeType {0}.", node.Operand.NodeType));
        }

        protected virtual void VisitArrayIndex(BinaryExpression node)
        {
            // An ArrayIndex expression is items[i], not just [i],
            // so the full access to the array element.
            // so the result must be the array element.

            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);
            var array = (Array)_stack.Pop();

            int index;
            switch (node.Right.NodeType)
            {
                case ExpressionType.Constant:
                {
                    var constantExpression = (ConstantExpression)node.Right;
                    index = (int)constantExpression.Value;
                    break;
                }

                case ExpressionType.MemberAccess:
                    var memberExpression2 = (MemberExpression)node.Right;
                    VisitMember(memberExpression2);
                    index = (int)_stack.Pop();
                    break;

                default:
                    throw new Exception(String.Format("ArrayIndex right side of NodeType '{0}' is not supported.", node.Right.NodeType));
            }

            object arrayElement = array.GetValue(index);
            _stack.Push(arrayElement);
        }

        [Suppress("Trimmer", "IL3050", Justification = ExpressionsWithArrays)]
        protected virtual void VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count; i++)
            {
                Visit(node.Expressions[i]);
            }

            //Array array = (Array)Activator.CreateInstance(node.Type, node.Expressions.Count);
            // Alternative works for Trimmable libs.
            #if NET9_0_OR_GREATER
                Array array = Array.CreateInstanceFromArrayType(node.Type, node.Expressions.Count);
            #else
                #pragma warning disable IL3050 // Requires unreferenced code: Already enforced higher up the stack.
                Array array = Array.CreateInstance(node.Type.GetElementType()!, node.Expressions.Count);
                #pragma warning restore IL3050
            #endif

            for (int i = node.Expressions.Count - 1; i >= 0; i--)
            {
                object item = _stack.Pop();
                array.SetValue(item, i);
            }

            _stack.Push(array);
        }
    }
}
