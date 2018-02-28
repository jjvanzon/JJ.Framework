using System.Globalization;
using System.Threading;

namespace JJ.Framework.Common
{
	public static class CultureHelper
	{
		public static void SetThreadCultureName(string cultureName)
		{
			var cultureInfo = new CultureInfo(cultureName);
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}

		public static CultureInfo GetCurrentCulture() => Thread.CurrentThread.CurrentCulture;
	}
}
