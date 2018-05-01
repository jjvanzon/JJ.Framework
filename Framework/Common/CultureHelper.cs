using System;
using System.Globalization;
using System.Threading;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
	[PublicAPI]
	public static class CultureHelper
	{
		public static void SetCurrentCultureName(string cultureName)
		{
			var cultureInfo = new CultureInfo(cultureName);
			SetCurrentCulture(cultureInfo);
		}

		public static void SetCurrentCulture(CultureInfo cultureInfo)
		{
			Thread.CurrentThread.CurrentCulture = cultureInfo;
			Thread.CurrentThread.CurrentUICulture = cultureInfo;
		}

		public static CultureInfo GetCurrentCulture() => Thread.CurrentThread.CurrentCulture;

		public static string GetCurrentCultureName() => Thread.CurrentThread.CurrentCulture.Name;

		// ReSharper disable once UnusedParameter.Global
		[Obsolete("Use SetCurrentCultureName instead.", true)]
		public static void SetThreadCultureName(string cultureName)
		{
			throw new NotSupportedException("Use SetCurrentCultureName instead.");
		}
	}
}
