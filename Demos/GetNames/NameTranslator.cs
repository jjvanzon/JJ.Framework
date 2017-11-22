using System;
using System.Text;
using System.Linq.Expressions;

namespace JJ.Demos.GetNames
{
	public class NameTranslator
	{
		private StringBuilder sb = new StringBuilder();

		public string Result
		{
			get
			{
				return sb
					.ToString()
					.CutLeft(".")
					.Replace("(.", "(")
					.Replace("[.", "[");
			}
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

			throw new ArgumentException(string.Format("Name cannot be obtained from {0}.", node.GetType().Name));
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
						throw new ArgumentException(string.Format("Name cannot be obtained from NodeType {0}.", node.Operand.NodeType));
					}
			}
		}

		private void VisitConstant(ConstantExpression node)
		{
			if (node.Type.IsPrimitive)
			{
				sb.Append(node.Value.ToString());
			}
			else if (node.Type == typeof(string))
			{
				sb.Append(@"""");

				sb.Append((string)node.Value);

				sb.Append(@"""");
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
			sb.Append(".");
			sb.Append(node.Member.Name);
		}

		private void VisitMethodCall(MethodCallExpression node)
		{
			if (node.Method.IsStatic)
			{
				throw new ArgumentException(string.Format("Name cannot be obtained from NodeType {0} if it is static.", node.NodeType));
			}

			Visit(node.Object);

			if (ReflectionHelper.IsIndexerMethod(node.Method))
			{
				sb.Append("[");
				for (int i = 0; i < node.Arguments.Count - 1; i++)
				{
					Visit(node.Arguments[i]);
					sb.Append(", ");
				}
				Visit(node.Arguments[node.Arguments.Count - 1]);
				sb.Append("]");

				return;
			}

			throw new ArgumentException(string.Format("Name cannot be obtained from NodeType {0} if it is not an indexer.", node.NodeType));
		}

		private void VisitArrayIndex(BinaryExpression node)
		{
			var memberExpression = (MemberExpression)node.Left;
			VisitMember(memberExpression);

			sb.Append("[");

			var constantExpression = (ConstantExpression)node.Right;
			int index = (int)constantExpression.Value;
			sb.Append(index);

			sb.Append("]");
		}
	}
}