using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingFuncCacheAndConstantHashCode : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Result = GetValueFromExpressionOfFunc(expression);
        }

        private static T GetValueFromExpressionOfFunc<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return GetValueFromMemberExpression(expression, memberExpression);
            }

            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                return GetValueFromUnaryExpression(expression, unaryExpression);
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
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", unaryExpression.Operand.GetType().Name));
        }

        private static object FuncCacheLock = new object();

        private static T GetValueFromMemberExpression<T>(Expression<Func<T>> expression, MemberExpression memberExpression)
        {
            Func<T> function;

            object cacheKey = GetMemberExpressionKey(memberExpression);

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

        private static string guid = Guid.NewGuid().ToString();

        private static object GetMemberExpressionKey(MemberExpression memberExpression)
        {
            object constant = GetOuterMostConstant(memberExpression);
            return memberExpression.ToString() + guid + constant.GetHashCode();
        }

        private static object GetOuterMostConstant(Expression expression)
        {
            var constantExpression = expression as ConstantExpression;
            if (constantExpression != null)
            {
                return constantExpression.Value;
            }

            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                return GetOuterMostConstant(memberExpression.Expression);
            }

            throw new Exception("OuterMostConstantExpression could not be retrieved.");
        }
    }
}
