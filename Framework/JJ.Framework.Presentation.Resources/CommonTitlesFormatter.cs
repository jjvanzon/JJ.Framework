// ReSharper disable RedundantUsingDirective

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.StringResources.Legacy
{
    /// <inheritdoc cref="_commontitlesformatter" />
    public static class CommonTitlesFormatter
    {
        /// <inheritdoc cref="_commontitlesformatter" />
        public static string EntityCount(string entityNamePlural)
        {
            return String.Format(CommonTitles.EntityCount, entityNamePlural);
        }
    }
}
