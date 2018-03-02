using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;

namespace JJ.Framework.Exceptions
{
	/// <summary>
	/// The difference between IsNotTypeException and UnexpectedTypeException
	/// is that UnexpectedTypeException only mentions what type it is not,
	/// not what type is expected.
	/// Example of produced error messages: "Nala is not of type Dog.", 
	/// "Cat Nala is not of type Dog."
	/// </summary>
	public class IsNotTypeException : Exception
	{
		public IsNotTypeException(Expression<Func<object>> expression, Type expectedType)
			: this(expression, ExceptionHelper.TryFormatShortTypeName(expectedType)) { }

		public IsNotTypeException(Expression<Func<object>> expression, string expectedTypeName)
		{
			string name = ExpressionHelper.GetText(expression);
			object value = ExpressionHelper.GetValue(expression);

			Type concreteType = value?.GetType();
			string concreteTypeName = ExceptionHelper.TryFormatShortTypeName(concreteType);

			Message = $"{concreteTypeName} {name} is not of type {expectedTypeName}.";
		}

		public override string Message { get; }
	}
}