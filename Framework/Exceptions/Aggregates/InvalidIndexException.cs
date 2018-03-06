using System;
using System.Linq.Expressions;
using JJ.Framework.Reflection;
using JJ.Framework.Text;

namespace JJ.Framework.Exceptions.Aggregates
{
	/// <summary>An exception with a message like "index of 1 is an invalid index for list with count 0."</summary>
	public class InvalidIndexException : Exception
	{
		/// <summary> Example: "outletViewModel.Keys.OutletListIndex of 1 is an invalid index for op.Outlets with count 0." </summary>
		private const string MESSAGE_TEMPLATE = "{0} is an invalid index for {1} with count {2}.";

		/// <summary>Produces an exception with a message like "index of 1 is an invalid index for list with count 0."</summary>
		/// <param name="listIndexExpression">For instance: () =&gt; index</param>
		/// <param name="countExpression">For instance: () =&gt; list.Count</param>
		public InvalidIndexException(Expression<Func<object>> listIndexExpression, Expression<Func<object>> countExpression)
			: base(string.Format(
				MESSAGE_TEMPLATE, 
				ExceptionHelper.GetTextWithValue(listIndexExpression), 
				ExpressionHelper.GetText(countExpression).TrimEndUntil('.').TrimEnd('.'), 
				ExpressionHelper.GetValue(countExpression)))
		{  }
	}
}
