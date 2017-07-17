using System;
using System.Text;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection
{
    internal class ExpressionToTextTranslator
    {
        private readonly StringBuilder _sb = new StringBuilder();

        /// <summary> 
        /// If you set this to true, an expression like MyArray[i] will translate to e.g. 
        /// "MyArray[2]" instead of "MyArray[i]". </summary>
        public bool ShowIndexerValues { get; set; }

        public string Execute(Expression expression)
        {
            Visit(expression);

            string result = _sb.ToString()
                               .TrimStart('.')
                               .Replace("(.", "(")
                               .Replace("[.", "[");
            return result;
        }

        protected virtual void Visit(Expression node)
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

                case ExpressionType.ArrayLength:
                    {
                        var unaryExpression = (UnaryExpression)node;
                        VisitArrayLength(unaryExpression);
                        return;
                    }

                case ExpressionType.Call:
                    {
                        var methodCallExpression = (MethodCallExpression)node;
                        VisitMethodCall(methodCallExpression);
                        return;
                    }

                case ExpressionType.Constant:
                    {
                        var constantExpression = (ConstantExpression)node;
                        VisitConstant(constantExpression);
                        return;
                    }

                case ExpressionType.ArrayIndex:
                    {
                        var binaryExpression = (BinaryExpression)node;
                        VisitArrayIndex(binaryExpression);
                        return;
                    }

                case ExpressionType.NewArrayInit:
                    {
                        var newArrayExpression = (NewArrayExpression)node;
                        VisitNewArray(newArrayExpression);
                        return;
                    }

                default:
                    throw new ArgumentException($"Name cannot be obtained from Node with NodeType {node.NodeType}.");
            }
        }

        protected virtual void VisitConvert(UnaryExpression node) => Visit(node.Operand);

        protected virtual void VisitConstant(ConstantExpression node)
        {
            if (node.Type.IsPrimitive)
            {
                _sb.Append(node.Value);
            }
            else if (node.Type == typeof(string))
            {
                _sb.Append(@"""");

                _sb.Append((string)node.Value);

                _sb.Append(@"""");
            }

            // Otherwise: ignore.
        }

        protected virtual void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            if (node.Member.IsStatic())
            {
                _sb.Append(node.Member.DeclaringType.Name);
            }

            // Then process 'child' node.
            _sb.Append(".");
            _sb.Append(node.Member.Name);
        }

        protected virtual void VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic)
            {
                _sb.Append(node.Method.DeclaringType.Name);
            }
            else
            {
                Visit(node.Object);
            }

            if (node.Method.IsIndexer())
            {
                _sb.Append("[");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    VisitIndexerValue(node.Arguments[i]);
                    _sb.Append(", ");
                }
                if (node.Arguments.Count != 0)
                {
                    Expression lastArgumentExpression = node.Arguments[node.Arguments.Count - 1];
                    VisitIndexerValue(lastArgumentExpression);
                }
                _sb.Append("]");
            }
            else
            {
                _sb.Append(".");
                _sb.Append(node.Method.Name);
                _sb.Append("(");
                for (int i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    _sb.Append(", ");
                }
                if (node.Arguments.Count != 0)
                {
                    Expression lastArgumentExpression = node.Arguments[node.Arguments.Count - 1];
                    Visit(lastArgumentExpression);
                }
                _sb.Append(")");
            }
        }

        protected virtual void VisitArrayLength(UnaryExpression node)
        {
            Visit(node.Operand);

            _sb.Append(".");
            _sb.Append("Length");
        }

        protected virtual void VisitArrayIndex(BinaryExpression node)
        {
            Visit(node.Left);

            _sb.Append("[");

            VisitIndexerValue(node.Right);

            _sb.Append("]");
        }

        /// <summary>
        /// Normally indexers are shown as the expression that they are, e.g. [i].
        /// If ShowIndexerValues is set to true, indexers are translated to their value, e.g. [2].
        /// To translate to their value, the work is delegated to ExpressionToValueTranslator.
        /// </summary>
        protected virtual void VisitIndexerValue(Expression node)
        {
            if (ShowIndexerValues)
            {
                object value = ExpressionHelper.GetValue(node);
                _sb.Append(value);
            }
            else
            {
                Visit(node);
            }
        }

        protected virtual void VisitNewArray(NewArrayExpression node)
        {
            for (int i = 0; i < node.Expressions.Count - 1; i++)
            {
                Visit(node.Expressions[i]);
                _sb.Append(", ");
            }
            Visit(node.Expressions[node.Expressions.Count - 1]);
        }
    }
}
