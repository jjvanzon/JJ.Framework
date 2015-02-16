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

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member name is returned.
        /// </summary>
        public static string GetName<T>(Expression<Func<T>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member name is returned.
        /// </summary>
        public static string GetName(Expression<Action> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        /// <summary>
        /// Gets the member name from the expression.
        /// If the expression contains more than one member,
        /// the last member is returned.
        /// </summary>
        public static string GetName(LambdaExpression expression)
        {
            MemberInfo member = GetMember(expression);
            return member.Name;
        }

        // GetMember

        /// <summary>
        /// Gets the MemberInfo from the expression.
        /// If the expression contains more than one member access,
        /// the last member is returned.
        /// </summary>
        public static MemberInfo GetMember<T>(Expression<Func<T>> expression)
        {
            return GetMember((LambdaExpression)expression);
        }

        /// <summary>
        /// Gets the MemberInfo from the expression.
        /// If the expression contains more than one member access,
        /// the last member is returned.
        /// </summary>
        public static MemberInfo GetMember(LambdaExpression expression)
        {
            if (expression == null) throw new NullException(() => expression);

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
        public static T GetValue<T>(Expression<Func<T>> expression)
        {
            return (T)GetValue((LambdaExpression)expression);
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
        public static object GetValue(Expression expression)
        {
            if (expression == null) throw new NullException(() => expression);

            var translator = new ExpressionToValueTranslator();
            object result = translator.GetValue(expression);
            return result;
        }

        // GetValues

        public static IList<object> GetValues<T>(Expression<Func<T>> expression)
        {
            return GetValues((LambdaExpression)expression);
        }

        public static IList<object> GetValues(LambdaExpression expression)
        {
            return GetValues(expression.Body);
        }

        public static IList<object> GetValues(Expression expression)
        {
            if (expression == null) throw new NullException(() => expression);

            var translator = new ExpressionToValueTranslator();
            IList<object> result = translator.GetValues(expression);
            return result;
        }

        // GetText

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText<T>(Expression<Func<T>> expression, bool showIndexerValues = false)
        {
            return GetText((LambdaExpression)expression, showIndexerValues);
        }

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText(LambdaExpression expression, bool showIndexerValues = false)
        {
            return GetText(expression.Body, showIndexerValues);
        }

        /// <param name="showIndexerValues">
        /// If you set this to true, an expression like MyArray[i] will translate to e.g.
        /// "MyArray[2]" instead of "MyArray[i]".
        /// </param>
        public static string GetText(Expression expression, bool showIndexerValues = false)
        {
            if (expression == null) throw new NullException(() => expression);

            var translator = new ExpressionToTextTranslator();
            translator.ShowIndexerValues = showIndexerValues;
            string result = translator.Execute(expression);
            return result;
        }

        // GetMethodCallInfo

        public static MethodCallInfo GetMethodCallInfo(LambdaExpression expression)
        {
            if (expression == null) throw new NullException(() => expression);

            switch (expression.Body.NodeType)
            {
                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expression.Body;
                    var methodCallInfo = new MethodCallInfo(methodCallExpression.Method.Name);

                    IList<ParameterInfo> parameters = methodCallExpression.Method.GetParameters();

                    for (int i = 0; i < parameters.Count; i++)
                    {
                        ParameterInfo parameter = parameters[i];
                        Expression argumentExpression = methodCallExpression.Arguments[i];

                        object value = ExpressionHelper.GetValue(argumentExpression);

                        var methodCallParameterInfo = new MethodCallParameterInfo(parameter.Name, value);
                        methodCallInfo.Parameters.Add(methodCallParameterInfo);
                    }

                    return methodCallInfo;

                default:
                    throw new NotSupportedException(String.Format("MethodCallInfo cannot be retrieved from NodeType {0}.", expression.Body.NodeType));
            }
        }
    }
}
