using System;
using System.Linq.Expressions;

namespace JJ.Framework.Reflection.PerformanceTests.Translators
{
	public class ExpressionToValueCustomTranslator_Dummy : IExpressionToValueTranslator
	{
		public object Result { get; set; }

		public void Visit<T>(Expression<Func<T>> expression)
		{
			if (typeof(T) == typeof(string))
			{
				Result = "1234";
			}
			else
			{
				Result = Activator.CreateInstance<T>();
			}
		}
	}
}
