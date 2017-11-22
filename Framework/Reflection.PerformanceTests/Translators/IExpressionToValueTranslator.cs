using System;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Translators
{
	public interface IExpressionToValueTranslator
	{
		object Result { get; }
		void Visit<T>(Expression<Func<T>> expression);
	}
}
