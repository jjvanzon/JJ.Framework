using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingFuncCache : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            switch (expression.Body)
            {
                case MemberExpression memberExpression:
                    Result = GetValueFromMemberExpression(expression, memberExpression);
                    break;

                case UnaryExpression unaryExpression:
                    Result = GetValueFromUnaryExpression(expression, unaryExpression);
                    break;
            }

            throw new ArgumentException($"Value cannot be obtained from {expression.Body.GetType().Name}.");
        }

        private static T GetValueFromUnaryExpression<T>(Expression<Func<T>> expression, UnaryExpression unaryExpression)
        {
            MemberExpression memberExpression;

            switch (unaryExpression.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetValueFromMemberExpression(expression, memberExpression);
                    }

                    break;

                case ExpressionType.ArrayLength:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetValueFromMemberExpression(expression, memberExpression);
                    }

                    break;

                case ExpressionType.MemberAccess:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetValueFromMemberExpression(expression, memberExpression);
                    }

                    break;
            }

            throw new ArgumentException($"Value cannot be obtained from {unaryExpression.Operand.GetType().Name}.");
        }

        private static readonly object _funcCacheLock = new object();

        private static T GetValueFromMemberExpression<T>(
            Expression<Func<T>> expression,
            MemberExpression memberExpression)
        {
            Func<T> function;

            object cacheKey = memberExpression.ToString();

            lock (_funcCacheLock)
            {
                if (FuncCache<T>.ContainsKey(cacheKey))
                {
                    function = FuncCache<T>.GetItem(cacheKey);
                }
                else
                {
                    function = expression.Compile();
                    FuncCache<T>.SetItem(cacheKey, function);
                }
            }

            T value = function();
            return value;
        }
    }
}