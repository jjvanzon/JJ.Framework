using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using JJ.Framework.Exceptions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueTranslator_UsingMemberInfos : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Result = GetValue(expression);
        }

        private T GetValue<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new NullException(() => expression);
            }

            return (T)GetValueFromExpressionOfFunc(expression);
        }

        private object GetValueFromExpressionOfFunc<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return GetValueFromMemberExpression(memberExpression);
            }

            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                return GetValueFromUnaryExpression(unaryExpression);
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", expression.Body.GetType().Name));
        }

        private object GetValueFromUnaryExpression(UnaryExpression unaryExpression)
        {
            MemberExpression memberExpression = null;

            switch (unaryExpression.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetValueFromMemberExpression(memberExpression);
                    }
                    break;

                case ExpressionType.ArrayLength:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        Array array = (Array)GetValueFromMemberExpression(memberExpression);
                        return array.Length;
                    }
                    break;
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", unaryExpression.Operand.GetType().Name));
        }

        private object GetValueFromMemberExpression(MemberExpression memberExpression)
        {
            var members = new List<MemberInfo>();

            object constant = GetOuterMostConstantAndAddMembers(memberExpression, members);

            object value = constant;

            foreach (MemberInfo member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Field:
                        var field = (FieldInfo)member;
                        value = field.GetValue(value);
                        break;

                    case MemberTypes.Property:
                        var property = (PropertyInfo)member;
                        value = property.GetValue(value, null);
                        break;

                    case MemberTypes.Method:
                        throw new NotSupportedException("Retrieving values from expressions with method calls in it, is not supported.");
                }
            }

            return value;
        }

        private object GetOuterMostConstantAndAddMembers(Expression expression, List<MemberInfo> members)
        {
            var constantExpression = expression as ConstantExpression;
            if (constantExpression != null)
            {
                return constantExpression.Value;
            }

            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                members.Insert(0, memberExpression.Member);
                return GetOuterMostConstantAndAddMembers(memberExpression.Expression, members);
            }

            throw new Exception("OuterMostConstantExpression could not be retrieved.");
        }
    }
}
