// Date: 2013-02

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JJ.Demos.GetNames
{
    public class NameTranslator_Old
    {
        private List<string> _result = new List<string>();

        public IEnumerable<string> Result   
        {
            get { return _result.ToArray(); }
        }

        public void Visit<T>(Expression<Func<T>> expression)
        {
            Visit((LambdaExpression)expression);
        }

        public void Visit(LambdaExpression expression)
        {
            Visit(expression.Body);
        }

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

            throw new NotSupportedException(string.Format("Name cannot be obtained from {0}.", node.GetType().Name));
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
                        throw new NotSupportedException(string.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
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