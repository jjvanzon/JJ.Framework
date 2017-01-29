using System;
using System.Linq;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation
{
    internal static class DebugHelper
    {
        internal static string GetDebuggerDisplay(ValidationMessages validationMessages)
        {
            if (validationMessages == null) throw new NullException(() => validationMessages);

            return String_PlatformSupport.Join(Environment.NewLine, validationMessages.Select(x => string.Format("{0}: {1}", x.PropertyKey, x.Text)));
        }
    }
}
