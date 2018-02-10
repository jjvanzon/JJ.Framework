using System;
using System.Configuration;
using System.Linq.Expressions;
using JJ.Framework.Conversion;
using JJ.Framework.Reflection;

namespace JJ.Framework.Configuration
{
	public static class AppSettingsReader<TInterface>
	{
		public static TValue Get<TValue>(Expression<Func<TInterface, TValue>> expression)
		{
			string name = ExpressionHelper.GetName(expression);
			string stringValue = ConfigurationManager.AppSettings[name];
			var value = SimpleTypeConverter.ParseValue<TValue>(stringValue);
			return value;
		}
	}
}
