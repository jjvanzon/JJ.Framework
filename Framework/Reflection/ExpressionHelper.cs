﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.Framework.Reflection
{
    public static class ExpressionHelper
    {
        // GetName

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member name is returned.
        /// </summary>
        public static string GetName<T>(Expression<Func<T>> expression) => GetName((LambdaExpression)expression);

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member name is returned.
        /// </summary>
        public static string GetName(Expression<Action> expression) => GetName((LambdaExpression)expression);

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member is returned.
        /// </summary>
        public static string GetName(LambdaExpression expression) => GetMember(expression).Name;

        // GetMember

        /// <summary>
        /// Gets the MemberInfo from the expression.
        /// If the expression contains more than one member access,
        /// the last member is returned.
        /// </summary>
        public static MemberInfo GetMember<T>(Expression<Func<T>> expression) => GetMember((LambdaExpression)expression);

        /// <summary>
        /// Gets the MemberInfo from the expression.
        /// If the expression contains more than one member access,
        /// the last member is returned.
        /// </summary>
        public static MemberInfo GetMember(LambdaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            switch (expression.Body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression.Body;
                    return memberExpression.Member;

                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expression.Body;
                    return methodCallExpression.Method;

                default:
                    throw new NotSupportedException($"Member cannot be retrieved from NodeType {expression.Body.NodeType}.");
            }
        }

        // GetValue

        // TODO: You might be able to make a 'fast' variation for GetValue, for simple expressions.

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, property access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static T GetValue<T>(Expression<Func<T>> expression) => (T)GetValue((LambdaExpression)expression);

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, property access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static object GetValue(LambdaExpression expression) => GetValue(expression?.Body);

        /// <summary>
        /// Gets a value from an expression.
        /// Supports field access, property access, method calls with parameters,
        /// indexers, array lengths, conversion expressions, params (variable amount of arguments),
        /// and both static and instance member access.
        /// </summary>
        public static object GetValue(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var translator = new ExpressionToValueTranslator();
            object result = translator.GetValue(expression);
            return result;
        }

        // GetValues

        public static IList<object> GetValues<T>(Expression<Func<T>> expression) => GetValues((LambdaExpression)expression);

        public static IList<object> GetValues(LambdaExpression expression) => GetValues(expression?.Body);

        public static IList<object> GetValues(Expression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            var translator = new ExpressionToValueTranslator();
            IList<object> result = translator.GetValues(expression);
            return result;
        }

        // GetText

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText<T>(Expression<Func<T>> expression, bool showIndexerValues = false) => GetText((LambdaExpression)expression, showIndexerValues);

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText(LambdaExpression expression, bool showIndexerValues = false) => GetText(expression?.Body, showIndexerValues);

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText(Expression expression, bool showIndexerValues = false)
        {
            var translator = new ExpressionToTextTranslator
            {
                ShowIndexerValues = showIndexerValues
            };

            string result = translator.Execute(expression);
            return result;
        }

        // GetMethodCallInfo

        /// <summary>
        /// For instance:
        ///
        ///     ExpressionHelper.GetMethodCallInfo(() => MyMethod(3));
        ///
        /// Will return:
        ///
        ///     MethodCallInfo
        ///     {
        ///         Name = "MyMethod",
        ///         Parameters = 
        ///         {
        ///             ParameterType = typeof(int),
        ///             Name = "myParameter",
        ///             Value = 3
        ///         }
        ///     };
        /// </summary>
        public static MethodCallInfo GetMethodCallInfo(LambdaExpression expression)
        {
            if (expression == null) throw new ArgumentNullException(nameof(expression));

            switch (expression.Body.NodeType)
            {
                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expression.Body;
                    var methodCallInfo = new MethodCallInfo(methodCallExpression.Method.Name);

                    IList<ParameterInfo> parameters = methodCallExpression.Method.GetParameters();

                    for (var i = 0; i < parameters.Count; i++)
                    {
                        ParameterInfo parameter = parameters[i];
                        Expression argumentExpression = methodCallExpression.Arguments[i];

                        object value = GetValue(argumentExpression);

                        var methodCallParameterInfo = new MethodCallParameterInfo(parameter.ParameterType, parameter.Name, value);
                        methodCallInfo.Parameters.Add(methodCallParameterInfo);
                    }

                    return methodCallInfo;

                default:
                    throw new NotSupportedException($"MethodCallInfo cannot be retrieved from NodeType {expression.Body.NodeType}.");
            }
        }
    }
}
