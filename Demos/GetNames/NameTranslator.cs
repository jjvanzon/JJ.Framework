using System;
using System.Linq.Expressions;
using System.Text;

namespace JJ.Demos.GetNames
{
    public class NameTranslator
    {
        private readonly StringBuilder _sb = new StringBuilder();

        public string Result
            => _sb
               .ToString()
               .CutLeft(".")
               .Replace("(.", "(")
               .Replace("[.", "[");

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

                case ExpressionType.Parameter:
                    // Ignore.
                    return;
            }

            throw new ArgumentException($"Name cannot be obtained from {node.GetType().Name}.");
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

                case ExpressionType.Call:
                {
                    Visit(node.Operand);
                    return;
                }

                case ExpressionType.ArrayIndex:
                {
                    var binaryExpression = (BinaryExpression)node.Operand;
                    VisitArrayIndex(binaryExpression);
                    break;
                }

                default:
                {
                    throw new ArgumentException($"Name cannot be obtained from NodeType {node.Operand.NodeType}.");
                }
            }
        }

        private void VisitConstant(ConstantExpression node)
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

        private void VisitMember(MemberExpression node)
        {
            // First process 'parent' node.
            if (node.Expression != null)
            {
                Visit(node.Expression);
            }

            // Then process 'child' node.
            _sb.Append(".");
            _sb.Append(node.Member.Name);
        }

        private void VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.IsStatic)
            {
                throw new ArgumentException($"Name cannot be obtained from NodeType {node.NodeType} if it is static.");
            }

            Visit(node.Object);

            if (ReflectionHelper.IsIndexerMethod(node.Method))
            {
                _sb.Append("[");
                for (var i = 0; i < node.Arguments.Count - 1; i++)
                {
                    Visit(node.Arguments[i]);
                    _sb.Append(", ");
                }

                Visit(node.Arguments[node.Arguments.Count - 1]);
                _sb.Append("]");

                return;
            }

            throw new ArgumentException($"Name cannot be obtained from NodeType {node.NodeType} if it is not an indexer.");
        }

        private void VisitArrayIndex(BinaryExpression node)
        {
            var memberExpression = (MemberExpression)node.Left;
            VisitMember(memberExpression);

            _sb.Append("[");

            var constantExpression = (ConstantExpression)node.Right;
            var index = (int)constantExpression.Value;
            _sb.Append(index);

            _sb.Append("]");
        }
    }
}