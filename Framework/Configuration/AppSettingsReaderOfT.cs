using System;
using System.Configuration;
using System.Globalization;
using System.Linq.Expressions;
using JJ.Framework.Conversion;
using JJ.Framework.Reflection;

namespace JJ.Framework.Configuration
{
	public static class AppSettingsReader<TInterface>
	{
		private static readonly CultureInfo _formatProvider = new CultureInfo("en-US");

		public static TValue Get<TValue>(Expression<Func<TInterface, TValue>> expression)
		{
			string name = ExpressionHelper.GetName(expression);
			string stringValue = ConfigurationManager.AppSettings[name];
			var value = SimpleTypeConverter.ParseValue<TValue>(stringValue, _formatProvider);
			return value;
		}
	}
}
