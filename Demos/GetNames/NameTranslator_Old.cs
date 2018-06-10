// Date: 2013-02

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace JJ.Demos.GetNames
{
    public class NameTranslator_Old
    {
        private readonly List<string> _result = new List<string>();

        public IEnumerable<string> Result => _result.ToArray();

        public void Visit<T>(Expression<Func<T>> expression) => Visit((LambdaExpression)expression);

        public void Visit(LambdaExpression expression) => Visit(expression.Body);

        private void Visit(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.MemberAccess:
                {
                    var memberExpression = (MemberExpression)node;
                    VisitMember(memberExpression);
                    return;
                }

                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                {
                    var unaryExpression = (UnaryExpression)node;
                    VisitConvert(unaryExpression);
                    return;
                }
            }

            throw new NotSupportedException($"Name cannot be obtained from {node.GetType().Name}.");
        }

        private void VisitConvert(UnaryExpression node)
        {
            switch (node.Operand.NodeType)
            {
                case ExpressionType.MemberAccess:
                {
                    var memberExpression = (MemberExpression)node.Operand;
                    VisitMember(memberExpression);
                    return;
                }

                default:
                {
                    throw new NotSupportedException($"Name cannot be obtained from NodeType {node.Operand.NodeType}.");
                }
            }
        }

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            _result.Add(node.Member.Name);
        }
    }
}