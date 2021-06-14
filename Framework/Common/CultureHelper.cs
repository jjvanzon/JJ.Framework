using System.Globalization;
using System.Threading;
using JetBrains.Annotations;

namespace JJ.Framework.Common
{
    /// <summary>
    /// Setting the current culture reliably, may look a bit verbose.
    /// Using this helper may look a bit more to the point.
    /// Also certain syntaxes may have not worked on certain platforms once.
    /// Using this helper may prevent that problem.
    /// </summary>
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
