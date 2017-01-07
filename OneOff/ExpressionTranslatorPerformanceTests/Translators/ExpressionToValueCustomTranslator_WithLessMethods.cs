using System;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
    public class ExpressionToValueCustomTranslator_WithLessMethods : IExpressionToValueTranslator
    {
        public object Result { get; private set; }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }

        public void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Lambda:
                {
                    var lambdaExpression = (LambdaExpression)node;
                    Visit(lambdaExpression.Body);
                    return;
                }

                case ExpressionType.MemberAccess:
                {
                    var memberExpression = (MemberExpression)node;
                    VisitMember(memberExpression);
                    return;
                }

                case ExpressionType.Constant:
                {
                    var constantExpression = (ConstantExpression)node;
                    Result = constantExpression.Value;
                    return;
                }

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                {
                    var unaryExpression = (UnaryExpression)node;
                    if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                    {
                        var memberExpression = (MemberExpression)unaryExpression.Operand;
                        VisitMember(memberExpression);
                        return;
                    }
                    break;
                }

                case ExpressionType.ArrayLength:
                {
                    var unaryExpression = (UnaryExpression)node;
                    if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
                    {
                        var memberExpression = (MemberExpression)unaryExpression.Operand;
                        VisitMember(memberExpression);

                        Array array = (Array)Result;
                        Result = array.Length;
                        return;
                    }
                    break;
                }
            }

            throw new ArgumentException(String.Format("Value cannot be obtained from {0}.", node.NodeType));
        }

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            switch (node.Member.MemberType)
            {
                case MemberTypes.Field:
                    var field = (FieldInfo)node.Member;
                    Result = field.GetValue(Result);
                    break;

                case MemberTypes.Property:
                    var property = (PropertyInfo)node.Member;
                    Result = property.GetValue(Result, null);
                    break;

                default:
                    throw new NotSupportedException(String.Format("MemberTypes ofther than Field and Property are not supported. MemberType = {0}", node.Member.MemberType)); 
            }
        }
    }
}