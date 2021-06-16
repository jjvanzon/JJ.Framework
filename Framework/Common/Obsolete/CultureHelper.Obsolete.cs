using System;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common
{
    public static partial class CultureHelper
    {
        [Obsolete("Use SetCurrentCultureName instead.", true)]
        public static void SetThreadCultureName(string cultureName) => throw new NotSupportedException("Use SetCurrentCultureName instead.");
    }
}
