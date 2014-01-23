using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Reflection;

namespace JJ.Framework.Reflection
{
    public static class ExpressionHelper
    {
        // GetName

        public static string GetName<T>(Expression<Func<T>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName(Expression<Action> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName(LambdaExpression expression)
        {
            MemberInfo member = GetMember(expression);
            return member.Name;
        }

        // GetMember

        public static MemberInfo GetMember<T>(Expression<Func<T>> expression)
        {
            return GetMember((LambdaExpression)expression);
        }

        public static MemberInfo GetMember(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            switch (expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression.Body;
                    return memberExpression.Member;

                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expression.Body;
                    return methodCallExpression.Method;

                default:
                    throw new NotSupportedException(String.Format("Member cannot be retrieved from NodeType {0}.", expression.Body.NodeType));
            }
        }

        // GetValue

        // TODO: You might be able to make a 'fast' variation for GetValue, for simple expressions.

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, propert access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static object GetValue(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var translator = new ExpressionToValueTranslator();
            translator.Visit(expression);
            return translator.Result;
        }

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, propert access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static object GetValue(LambdaExpression expression)
        {
            return GetValue(expression.Body);
        }

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, propert access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static T GetValue<T>(Expression<Func<T>> expression)
        {
            return (T)GetValue((LambdaExpression)expression);
        }

        // GetText

        /// <param name="showIndexerValues"> If you set this to true, an expression like MyArray[i] will translate to e.g. "MyArray[2]", instead of "MyArray[i]". </param>
        public static string GetText(Expression expression, bool showIndexerValues = false)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var translator = new ExpressionToTextTranslator();
            translator.ShowIndexerValues = showIndexerValues;
            translator.Visit(expression);
            return translator.Result;
        }

        /// <param name="showIndexerValues"> If you set this to true, an expression like MyArray[i] will translate to e.g. "MyArray[2]", instead of "MyArray[i]". </param>
        public static string GetText(LambdaExpression expression, bool showIndexerValues = false)
        {
            return GetText(expression.Body, showIndexerValues);
        }

        /// <param name="showIndexerValues"> If you set this to true, an expression like MyArray[i] will translate to e.g. "MyArray[2]", instead of "MyArray[i]". </param>
        public static string GetText<T>(Expression<Func<T>> expression, bool showIndexerValues = false)
        {
            return GetText((LambdaExpression)expression, showIndexerValues);
        }
    }
}
