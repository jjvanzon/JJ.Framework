using System;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	/// <summary>
	/// Used to create generic ExpressionHelpers for variations that do not have a ToStringTranslator.
	/// </summary>
	public class ExpressionToStringCustomTranslator_Dummy : IExpressionToStringTranslator
	{
		public string Result { get; private set; }

		public void Visit<T>(Expression<Func<T>> expression) => Result = "Dummy text";
	}
}