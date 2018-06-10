using System;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
	public class ExpressionToValueCustomTranslator_Simple : IExpressionToValueTranslator
	{
		public object Result { get; private set; }

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

						var array = (Array)Result;
						Result = array.Length;
						return;
					}
					break;
				}
			}

			throw new ArgumentException($"Value cannot be obtained from {node.NodeType}.");
		}

		private void VisitMember(MemberExpression node)
		{
			// First process 'parent' node.
			if (node.Expression != null)
			{
				switch (node.Expression.NodeType)
				{
					case ExpressionType.Constant:
						{
							var constantExpression = (ConstantExpression)node.Expression;
							Result = constantExpression.Value;
							break;
						}

					case ExpressionType.MemberAccess:
					{
						var node2 = (MemberExpression)node.Expression;
						VisitMember(node2);
						break;
					}

					case ExpressionType.Convert:
					case ExpressionType.ConvertChecked:
					{
						var unaryExpression = (UnaryExpression)node.Expression;
						if (unaryExpression.Operand.NodeType == ExpressionType.MemberAccess)
						{
							var memberExpression = (MemberExpression)unaryExpression.Operand;
							VisitMember(memberExpression);
						}
						return;
					}
				}
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
		}
	}
}