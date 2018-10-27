using System.Globalization;
using System.Threading;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
	[PublicAPI]
	public static partial class CultureHelper
	{
		public static void SetCurrentCulture(CultureInfo cultureInfo)
		{
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}

	    public static void SetCurrentCultureName(string cultureName)
	    {
	        var cultureInfo = new CultureInfo(cultureName);
	        SetCurrentCulture(cultureInfo);
	    }

        public static CultureInfo GetCurrentCulture() => Thread.CurrentThread.CurrentCulture;

		public static string GetCurrentCultureName() => Thread.CurrentThread.CurrentCulture.Name;
	}
}
