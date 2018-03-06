using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions.TypeChecking
{
	/// <summary>
	/// The difference between IsNotTypeException and UnexpectedTypeException
	/// is that UnexpectedTypeException only mentions what type it is not,
	/// not what type is expected.
	/// Example of produced error message: "Animal has an unexpected type: Cat."
	/// </summary>
	public class UnexpectedTypeException : Exception
	{
		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
		public UnexpectedTypeException(Expression<Func<object>> expression)
		{
			string name = ExpressionHelper.GetText(expression);

			object value = ExpressionHelper.GetValue(expression);

			Type concreteType = value?.GetType();
			string concreteTypeName = ExceptionHelper.TryFormatShortTypeName(concreteType);

			Message = $"{name} has an unexpected type: {concreteTypeName}.";
		}

		public override string Message { get; }
	}
}

