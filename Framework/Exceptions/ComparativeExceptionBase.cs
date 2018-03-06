using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

// ReSharper disable VirtualMemberCallInConstructor

namespace JJ.Framework.Exceptions
{
	public abstract class ComparativeExceptionBase : Exception
	{
		protected abstract string MessageTemplateWithAAndB { get; }
		protected abstract string MessageTemplateWithAValueAndNoBValue { get; }
		protected abstract string MessageTemplateWithNoAValueAndWithBValue { get; }
		protected abstract string MessageTemplateWithTwoValuesAndTwoNames { get; }

		/// <param name="a">Can be both the name or the value of the object.</param>
		/// <param name="b">Can be both the name or the value of the object.</param>
		public ComparativeExceptionBase(object a, object b) =>
			Message = string.Format(MessageTemplateWithAAndB, a, b);

		public ComparativeExceptionBase(Expression<Func<object>> expressionA, Expression<Func<object>> expressionB)
		{
			string textA = ExpressionHelper.GetText(expressionA);
			string textB = ExpressionHelper.GetText(expressionB);
			object a = ExpressionHelper.GetValue(expressionA);
			object b = ExpressionHelper.GetValue(expressionB);

			Message = FormatMessage(textA, a, textB, b);
		}

		/// <param name="b">Can be both the name or the value of the object.</param>
		public ComparativeExceptionBase(Expression<Func<object>> expressionA, object b)
		{
			string textA = ExpressionHelper.GetText(expressionA);
			object a = ExpressionHelper.GetValue(expressionA);

			Message = FormatMessage(textA, a, b, null);
		}

		/// <param name="a">Can be both the name or the value of the object.</param>
		public ComparativeExceptionBase(object a, Expression<Func<object>> expressionB)
		{
			string textB = ExpressionHelper.GetText(expressionB);
			object b = ExpressionHelper.GetValue(expressionB);

			Message = FormatMessage(a, null, textB, b);
		}

		private string FormatMessage(object textA, object a, object textB, object b)
		{
			bool mustShowValueA = a != null && ReflectionHelper.IsSimpleType(a);
			bool mustShowValueB = b != null && ReflectionHelper.IsSimpleType(b);

			if (mustShowValueA && mustShowValueB)
			{
				return string.Format(MessageTemplateWithTwoValuesAndTwoNames, textA, a, textB, b);
			}

			if (mustShowValueA)
			{
				return string.Format(MessageTemplateWithAValueAndNoBValue, textA, a, textB);
			}

			if (mustShowValueB)
			{
				return string.Format(MessageTemplateWithNoAValueAndWithBValue, textA, textB, b);
			}

			return string.Format(MessageTemplateWithAAndB, textA, textB);
		}

		public override string Message { get; }

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			Expression<Func<object>> expressionA,
			Expression<Func<object>> expressionB,
			bool showValueA = false,
			bool showValueB = false) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			Expression<Func<object>> expressionA,
			object b,
			bool showValueA = false) => throw new NotImplementedException();

		[Obsolete("Remove the showValueA or showValueB parameters. They will be deteremined automatically.", true)]
		public ComparativeExceptionBase(
			object a,
			Expression<Func<object>> expressionB,
			bool showValueB = false) => throw new NotImplementedException();
	}
}