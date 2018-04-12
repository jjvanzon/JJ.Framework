using System.Globalization;

namespace JJ.Framework.Configuration
{
	internal static class AppSettingsReaderHelper
	{
		public static CultureInfo FormatProvider { get; } = new CultureInfo("en-US");
	}
}
