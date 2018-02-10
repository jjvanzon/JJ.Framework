using System;
using System.Drawing;

namespace JJ.Framework.Drawing
{
	internal static class DpiHelper
	{
		public const float DEFAULT_DPI = 96;

		public static float GetAntiDpiFactor(float dpi) => DEFAULT_DPI / dpi;

		public static float GetDpi(Graphics graphics)
		{
			if (graphics == null) throw new ArgumentNullException(nameof(graphics));
			return graphics.DpiY;
		}
	}
}
