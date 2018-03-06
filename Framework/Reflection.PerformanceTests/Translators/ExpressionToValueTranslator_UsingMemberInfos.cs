using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using JJ.Framework.Exceptions;
using JJ.Framework.Exceptions.Basic;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	public class ExpressionToValueTranslator_UsingMemberInfos : IExpressionToValueTranslator
	{
		public object Result { get; private set; }

		public void Visit<T>(Expression<Func<T>> expression)
		{
			Result = GetValue(expression);
		}

		private T GetValue<T>(Expression<Func<T>> expression)
		{
			if (expression == null)
			{
				throw new NullException(() => expression);
			}

			return (T)GetValueFromExpressionOfFunc(expression);
		}

		private object GetValueFromExpressionOfFunc<T>(Expression<Func<T>> expression)
		{
			if (expression.Body is MemberExpression memberExpression)
			{
				return GetValueFromMemberExpression(memberExpression);
			}

			if (expression.Body is UnaryExpression unaryExpression)
			{
				return GetValueFromUnaryExpression(unaryExpression);
			}

			throw new ArgumentException($"Value cannot be obtained from {expression.Body.GetType().Name}.");
		}

		private object GetValueFromUnaryExpression(UnaryExpression unaryExpression)
		{
			MemberExpression memberExpression = null;

			switch (unaryExpression.NodeType)
			{
				case ExpressionType.Convert:
				case ExpressionType.ConvertChecked:
					memberExpression = unaryExpression.Operand as MemberExpression;
					if (memberExpression != null)
					{
						return GetValueFromMemberExpression(memberExpression);
					}
					break;

				case ExpressionType.ArrayLength:
					memberExpression = unaryExpression.Operand as MemberExpression;
					if (memberExpression != null)
					{
						Array array = (Array)GetValueFromMemberExpression(memberExpression);
						return array.Length;
					}
					break;
			}

			throw new ArgumentException($"Value cannot be obtained from {unaryExpression.Operand.GetType().Name}.");
		}

		private object GetValueFromMemberExpression(MemberExpression memberExpression)
		{
			var members = new List<MemberInfo>();

			object constant = GetOuterMostConstantAndAddMembers(memberExpression, members);

			object value = constant;

			foreach (MemberInfo member in members)
			{
				switch (member.MemberType)
				{
					case MemberTypes.Field:
						var field = (FieldInfo)member;
						value = field.GetValue(value);
						break;

					case MemberTypes.Property:
						var property = (PropertyInfo)member;
						value = property.GetValue(value, null);
						break;

					case MemberTypes.Method:
						throw new NotSupportedException("Retrieving values from expressions with method calls in it, is not supported.");
				}
			}

			return value;
		}

		private object GetOuterMostConstantAndAddMembers(Expression expression, List<MemberInfo> members)
		{
			if (expression is ConstantExpression constantExpression)
			{
				return constantExpression.Value;
			}

			if (expression is MemberExpression memberExpression)
			{
				members.Insert(0, memberExpression.Member);
				return GetOuterMostConstantAndAddMembers(memberExpression.Expression, members);
			}

			throw new Exception("OuterMostConstantExpression could not be retrieved.");
		}
	}
}
