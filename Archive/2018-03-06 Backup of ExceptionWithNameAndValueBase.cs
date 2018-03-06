//using System;
//using System.Linq.Expressions;

//namespace JJ.Framework.Exceptions
//{
//	/// <summary>
//	/// An exception type to which you can pass a lambda expression to identify the object the error applies to,
//	/// which is then incorporated in the exception message as well as the value if applicable.
//	/// </summary>
//	public abstract class ExceptionWithNameAndValueBase : Exception
//	{
//		/// <summary>The passed lambda expression's text is incorporated in the exception message as well as the value if applicable.</summary>
//		/// <param name="expression">Pass e.g. () => myParam.MyProperty</param>
//		public ExceptionWithNameAndValueBase(string messageTemplate, Expression<Func<object>> expression)
//		{
//			string text = ExceptionHelper.GetTextWithValue(expression);
//			Message = string.Format(messageTemplate, text);
//		}

//		/// <param name="name">Pass e.g. nameof(myParam)</param>
//		public ExceptionWithNameAndValueBase(string messageTemplate, string name) => Message = string.Format(messageTemplate, name);

//		public override string Message { get; }
//	}
//}