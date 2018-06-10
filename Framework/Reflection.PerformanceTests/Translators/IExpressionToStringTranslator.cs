using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
	public interface IExpressionToStringTranslator
	{
		string Result { get; }
		void Visit<T>(Expression<Func<T>> expression);
	}
}
