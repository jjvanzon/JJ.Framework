using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingFuncCacheAndConstantHashCode : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression) => Result = GetValueFromExpressionOfFunc(expression);

        private static T GetValueFromExpressionOfFunc<T>(Expression<Func<T>> expression)
        {
            switch (expression.Body)
            {
                case MemberExpression memberExpression:
                    return GetValueFromMemberExpression(expression, memberExpression);

                case UnaryExpression unaryExpression:
                    return GetValueFromUnaryExpression(expression, unaryExpression);
            }

            throw new ArgumentException($"Value cannot be obtained from {expression.Body.GetType().Name}.");
        }

        private static T GetValueFromUnaryExpression<T>(Expression<Func<T>> expression, UnaryExpression unaryExpression)
        {
            switch (unaryExpression.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    if (unaryExpression.Operand is MemberExpression memberExpression)
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

            object cacheKey = GetMemberExpressionKey(memberExpression);

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

        private static readonly string _guid = Guid.NewGuid().ToString();

        private static object GetMemberExpressionKey(MemberExpression memberExpression)
        {
            object constant = GetOuterMostConstant(memberExpression);
            return memberExpression + _guid + constant.GetHashCode();
        }

        private static object GetOuterMostConstant(Expression expression)
        {
            switch (expression)
            {
                case ConstantExpression constantExpression: return constantExpression.Value;
                case MemberExpression memberExpression: return GetOuterMostConstant(memberExpression.Expression);
            }

            throw new Exception("OuterMostConstant could not be retrieved from expression.");
        }
    }
}