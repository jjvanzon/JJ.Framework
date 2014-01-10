using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToStringTranslator_UsingMemberInfos : IExpressionToStringTranslator
    {
        public string Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Result = GetStringFromExpressionOfT(expression);
        }

        private string GetStringFromExpressionOfT<T>(Expression<Func<T>> expression)
        {
            return GetStringFromLambdaExpression(expression);
        }

        private string GetStringFromLambdaExpression(LambdaExpression lambdaExpression)
        {
            var memberExpression = lambdaExpression.Body as MemberExpression;
            if (memberExpression != null)
            {
                return GetStringFromMemberExpression(memberExpression);
            }

            var unaryExpression = lambdaExpression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                return GetStringFromUnaryExpression(unaryExpression);
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", lambdaExpression.Body.GetType().Name));
        }

        private string GetStringFromUnaryExpression(UnaryExpression unaryExpression)
        {
            MemberExpression memberExpression = null;

            switch (unaryExpression.NodeType)
            {
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetStringFromMemberExpression(memberExpression);
                    }
                    break;

                case ExpressionType.ArrayLength:
                    memberExpression = unaryExpression.Operand as MemberExpression;
                    if (memberExpression != null)
                    {
                        return GetStringFromMemberExpression(memberExpression) + ".Length";
                    }
                    break;
            }

            throw new ArgumentException(String.Format("Name cannot be obtained from {0}.", unaryExpression.Operand.GetType().Name));
        }

        private string GetStringFromMemberExpression(MemberExpression memberExpression)
        {
            string name = memberExpression.Member.Name;

            var parentMemberExpression = memberExpression.Expression as MemberExpression;

            if (parentMemberExpression != null)
            {
                string qualifier = GetStringFromMemberExpression(parentMemberExpression);
                return qualifier + "." + name;
            }
            else
            {
                return name;
            }
        }
    }
}
