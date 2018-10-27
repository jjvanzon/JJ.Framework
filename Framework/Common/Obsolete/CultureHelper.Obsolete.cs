using System;
// ReSharper disable CheckNamespace

namespace JJ.Framework.Common
{
	public static partial class CultureHelper
	{
		// ReSharper disable once UnusedParameter.Global
		[Obsolete("Use SetCurrentCultureName instead.", true)]
		public static void SetThreadCultureName(string cultureName) => throw new NotSupportedException("Use SetCurrentCultureName instead.");
	}
}
