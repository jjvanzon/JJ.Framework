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
    }
}
