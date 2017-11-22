using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	public class ExpressionToValueTranslator : ExpressionVisitor, IExpressionToValueTranslator
	{
		private readonly Stack<object> _stack = new Stack<object>();

		public object Result => _stack.Peek();

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

				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
				case ExpressionType.ArrayLength:
					var unaryExpression = (UnaryExpression)node;
					VisitUnary(unaryExpression);
					return node;

				case ExpressionType.Call:
					var methodCallExpression = (MethodCallExpression)node;
					VisitMethodCall(methodCallExpression);
					return node;

				case ExpressionType.Constant:
					var constantExpression = (ConstantExpression)node;
					_stack.Push(constantExpression.Value);
					return node;

				case ExpressionType.ArrayIndex:
					var binaryExpression = (BinaryExpression)node;
					VisitArrayIndex(binaryExpression);
					return node;

				case ExpressionType.NewArrayInit:
					var newArrayExpression = (NewArrayExpression)node;
					VisitNewArray(newArrayExpression);
					return node;

				default:
					throw new ArgumentException($"Value cannot be obtained from {node.NodeType}.");
			}
		}

		protected override Expression VisitConstant(ConstantExpression node)
		{
			_stack.Push(node.Value);
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
					VisitField(node);
					break;

				case MemberTypes.Property:
					VisitProperty(node);
					break;

				default:
					throw new NotSupportedException($"MemberTypes ofther than Field and Property are not supported. MemberType = {node.Member.MemberType}");
			}

			return node;
		}

		private void VisitField(MemberExpression node)
		{
			var field = (FieldInfo)node.Member;
			object obj = null;
			if (!field.IsStatic)
			{
				obj = _stack.Pop();
			}
			object value = field.GetValue(obj);
			_stack.Push(value);
		}

		private void VisitProperty(MemberExpression node)
		{
			var property = (PropertyInfo)node.Member;
			object obj = null;
			MethodInfo getterOrSetter = property.GetGetMethod() ?? property.GetSetMethod();
			if (!getterOrSetter.IsStatic)
			{
				obj = _stack.Pop();
			}
			object value = property.GetValue(obj, null);
			_stack.Push(value);
		}

		protected override Expression VisitMethodCall(MethodCallExpression node)
		{
			if (!node.Method.IsStatic)
			{
				Visit(node.Object);
			}
			else
			{
				_stack.Push(null);
			}

			for (int i = 0; i < node.Arguments.Count; i++)
			{
				Visit(node.Arguments[i]);
			}
			var arguments = new object[node.Arguments.Count];
			for (int i = 0; i < node.Arguments.Count; i++) 
			{
				arguments[i] = _stack.Pop();
			}

			object obj = _stack.Pop();
			object value = node.Method.Invoke(obj, arguments);
			_stack.Push(value);

			return node;
		}

		protected override Expression VisitUnary(UnaryExpression node)
		{
			switch (node.NodeType)
			{
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					VisitConvert(node);
					return node;

				case ExpressionType.ArrayLength:
					VisitArrayLength(node);
					return node;

				default:
					throw new ArgumentException($"Value cannot be obtained from NodeType {node.NodeType}.");
			}
		}

		private void VisitConvert(UnaryExpression node)
		{
			Visit(node.Operand);

			object obj = _stack.Pop();
			if (obj is IConvertible)
			{
				obj = Convert.ChangeType(obj, node.Type);
			}
			_stack.Push(obj);
		}

		private void VisitArrayLength(UnaryExpression node)
		{
			Visit(node.Operand);
			Array array = (Array)_stack.Pop();
			_stack.Push(array.Length);
		}

		protected override Expression VisitBinary(BinaryExpression node)
		{
			switch (node.NodeType)
			{
				case ExpressionType.ArrayIndex:
					VisitArrayIndex(node);
					return node;

				default:
					throw new ArgumentException($"Value cannot be obtained from NodeType {node.NodeType}.");
			}
		}

		private void VisitArrayIndex(BinaryExpression node)
		{
			var memberExpression = (MemberExpression)node.Left;
			VisitMember(memberExpression);
			var array = (Array)_stack.Pop();

			var constantExpression = (ConstantExpression)node.Right;
			int index = (int)constantExpression.Value;
			_stack.Push(array.GetValue(index));
		}

		protected override Expression VisitNewArray(NewArrayExpression node)
		{
			for (int i = 0; i < node.Expressions.Count; i++)
			{
				Visit(node.Expressions[i]);
			}
			Array array = (Array)Activator.CreateInstance(node.Type, node.Expressions.Count);
			for (int i = node.Expressions.Count - 1; i >= 0; i--)
			{
				object item = _stack.Pop();
				array.SetValue(item, i);
			}
			_stack.Push(array);

			return node;
		}
	}
}
