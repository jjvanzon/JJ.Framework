using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions
{
	public abstract class ComparativeExceptionWithExpressionBase : Exception
	{
		protected abstract string MessageTemplateWithAAndB { get; }
		protected abstract string MessageTemplateWithAValueAndNoBValue { get; }
		protected abstract string MessageTemplateWithNoAValueAndWithBValue { get; }
		protected abstract string MessageTemplateWithTwoValuesAndTwoNames { get; }

		public ComparativeExceptionWithExpressionBase(Expression<Func<object>> expressionA, object b) =>
			Message = string.Format(MessageTemplateWithAAndB, ExpressionHelper.GetText(expressionA), b);

		public ComparativeExceptionWithExpressionBase(object a, object b) =>
			Message = string.Format(MessageTemplateWithAAndB, a, b);

		public ComparativeExceptionWithExpressionBase(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false)
		{
			if (showValueA && showValueB)
			{
				Message = string.Format(
					MessageTemplateWithTwoValuesAndTwoNames,
					ExpressionHelper.GetText(expressionA),
					ExpressionHelper.GetValue(expressionA),
					ExpressionHelper.GetText(expressionB),
					ExpressionHelper.GetValue(expressionB));
			}
			else if (showValueA)
			{
				Message = string.Format(
					MessageTemplateWithAValueAndNoBValue,
					ExpressionHelper.GetText(expressionA),
					ExpressionHelper.GetValue(expressionA),
					ExpressionHelper.GetText(expressionB));
			}
			else if (showValueB)
			{
				Message = string.Format(
					MessageTemplateWithNoAValueAndWithBValue,
					ExpressionHelper.GetText(expressionA),
					ExpressionHelper.GetText(expressionB),
					ExpressionHelper.GetValue(expressionB));
			}
			else
			{
				Message = string.Format(
					MessageTemplateWithAAndB,
					ExpressionHelper.GetText(expressionA),
					ExpressionHelper.GetText(expressionB));
			}
		}

		public ComparativeExceptionWithExpressionBase(Expression<Func<object>> expressionA, object b, bool showValueA = false)
		{
			if (showValueA)
			{
				Message = string.Format(
					MessageTemplateWithAValueAndNoBValue,
					ExpressionHelper.GetText(expressionA),
					ExpressionHelper.GetValue(expressionA),
					b);
			}
			else
			{
				Message = string.Format(
					MessageTemplateWithAAndB,
					ExpressionHelper.GetText(expressionA),
					b);
			}
		}

		public ComparativeExceptionWithExpressionBase(object a, Expression<Func<object>> expressionB, bool showValueB = false)
		{
			if (showValueB)
			{
				Message = string.Format(
					MessageTemplateWithNoAValueAndWithBValue,
					a,
					ExpressionHelper.GetText(expressionB),
					ExpressionHelper.GetValue(expressionB));
			}
			else
			{
				Message = string.Format(
					MessageTemplateWithAAndB,
					a,
					ExpressionHelper.GetText(expressionB));
			}
		}

		public override string Message { get; }
	}
}