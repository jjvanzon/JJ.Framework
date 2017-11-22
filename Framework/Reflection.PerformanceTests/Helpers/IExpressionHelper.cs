using System;
using System.Linq.Expressions;

namespace JJ.OneOff.ExpressionTranslatorPerformanceTests.Helpers
{
	public interface IExpressionHelper
	{
		string GetString<T>(Expression<Func<T>> expression);
		T GetValue<T>(Expression<Func<T>> expression);
	}
}
