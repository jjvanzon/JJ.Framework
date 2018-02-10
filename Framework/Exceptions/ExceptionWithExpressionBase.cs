using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	/// <summary> TODO: Make other exceptions derive from this base type too. </summary>
	public abstract class ExceptionWithExpressionBase : Exception
	{
		private readonly string _message;

		/// <summary> E.g. "{0} is null.". </summary>
		protected abstract string MessageFormat { get; }

		public override string Message => _message;

		public ExceptionWithExpressionBase(Expression<Func<object>> expression)
			: this(ExpressionHelper.GetText(expression))
		{ }

		public ExceptionWithExpressionBase(string name)
		{
			_message = string.Format(MessageFormat, name);
		}
	}
}
