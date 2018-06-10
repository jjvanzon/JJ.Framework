using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
	public class ExpressionToValueTranslator_UsingPureCompilation : IExpressionToValueTranslator
	{
		public object Result { get; private set; }

		public void Visit<T>(Expression<Func<T>> expression)
		{
			Func<T> function = expression.Compile();
			Result = function();
		}
	}
}
