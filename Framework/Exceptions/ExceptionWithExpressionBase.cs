using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	/// <summary> TODO: Make other exceptions derive from this base type too. </summary>
	public abstract class ExceptionWithExpressionBase : Exception
	{
		/// <summary> E.g. "{0} is null.". </summary>
		protected abstract string MessageFormat { get; }

		public override string Message { get; }

		public ExceptionWithExpressionBase(Expression<Func<object>> expression)
			: this(ExpressionHelper.GetText(expression))
		{ }

		public ExceptionWithExpressionBase(string name)
		{
			Message = string.Format(MessageFormat, name);
		}
	}
}
