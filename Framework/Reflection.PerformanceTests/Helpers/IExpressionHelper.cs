using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Helpers
{
	public interface IExpressionHelper
	{
		string GetString<T>(Expression<Func<T>> expression);
		T GetValue<T>(Expression<Func<T>> expression);
	}
}
