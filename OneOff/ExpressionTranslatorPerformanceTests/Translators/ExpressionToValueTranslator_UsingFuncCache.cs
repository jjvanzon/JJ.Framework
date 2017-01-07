using System;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingFuncCache : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                Result = GetValueFromMemberExpression(expression, memberExpression);
            }

            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                Result = GetValueFromUnaryExpression(expression, unaryExpression);
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", expression.Body.GetType().Name));
        }

        private static T GetValueFromUnaryExpression<T>(Expression<Func<T>> expression, UnaryExpression unaryExpression)
        {
            MemberExpression memberExpression = null;

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

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", unaryExpression.Operand.GetType().Name));
        }

        private static object FuncCacheLock = new object();

        private static T GetValueFromMemberExpression<T>(Expression<Func<T>> expression, MemberExpression memberExpression)
        {
            Func<T> function;

            object cacheKey = memberExpression.ToString();

            lock (FuncCacheLock)
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
