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
        public static T GetValue<T>(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var translator = new ExpressionToValueTranslator();
            translator.Visit(expression);
            return (T)translator.Result;
        }

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, propert access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static T GetValue<T>(Expression<Func<T>> expression)
        {
            return GetValue<T>((LambdaExpression)expression);
        }

        // GetString

        public static string GetString<T>(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var translator = new ExpressionToStringTranslator();
            translator.Visit(expression);
            return translator.Result;
        }

        public static string GetString<T>(Expression<Func<T>> expression)
        {
            return GetString<T>((LambdaExpression)expression);
        }

    }
}
