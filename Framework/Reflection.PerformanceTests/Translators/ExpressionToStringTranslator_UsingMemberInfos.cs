using System;
using System.Linq.Expressions;

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
            if (lambdaExpression.Body is MemberExpression memberExpression)
            {
                return GetStringFromMemberExpression(memberExpression);
            }

            if (lambdaExpression.Body is UnaryExpression unaryExpression)
            {
                return GetStringFromUnaryExpression(unaryExpression);
            }

            throw new ArgumentException($"Name cannot be obtained from {lambdaExpression.Body.GetType().Name}.");
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

            throw new ArgumentException($"Name cannot be obtained from {unaryExpression.Operand.GetType().Name}.");
        }

        private string GetStringFromMemberExpression(MemberExpression memberExpression)
        {
            string name = memberExpression.Member.Name;

            if (memberExpression.Expression is MemberExpression parentMemberExpression)
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
