using System;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	public class ExpressionToValueTranslator_Simple : ExpressionVisitor, IExpressionToValueTranslator
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

		public override Expression Visit(Expression node)
		{
			switch (node.NodeType)
			{
				case ExpressionType.MemberAccess:
					var memberExpression = (MemberExpression)node;
					VisitMember(memberExpression);
					return node;

				case ExpressionType.ArrayLength:
					var unaryExpression = (UnaryExpression)node;
					VisitUnary(unaryExpression);
					return node;

				case ExpressionType.Constant:
					var constantExpression = (ConstantExpression)node;
					VisitConstant(constantExpression);
					return node;

				default:
					throw new ArgumentException($"Value cannot be obtained from {node.NodeType}.");
			}
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			Result = node.Value;
			return node;
		}

		protected override Expression VisitMember(MemberExpression node)
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
					throw new NotSupportedException($"MemberTypes ofther than Field and Property are not supported. MemberType = {node.Member.MemberType}");
			}

			return node;
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			switch (node.NodeType)
			{
				case ExpressionType.ArrayLength:
					Visit(node.Operand);
					Array array = (Array)Result;
					Result = array.Length;
					return node;

				default:
					throw new ArgumentException($"Value cannot be obtained from node with NodeType {node.NodeType}.");
			}
		}
	}
}
