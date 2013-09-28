using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Validation.Resources
{
    public static class FormattedMessages
    {
        public static string IsNull(string propertyDisplayName)
        {
            return String.Format(Messages.IsNull, propertyDisplayName);
        }

        public static string NotIsValue(string propertyDisplayName, object value)
        {
            return String.Format(Messages.NotIsValue, propertyDisplayName, value);
        }

        internal static string NotAbove(string propertyDisplayName)
        {
            return String.Format(Messages.NotAbove, propertyDisplayName);
        }

        internal static string IsNullOrWhiteSpace(string propertyDisplayName)
        {
            return String.Format(Messages.IsNullOrWhiteSpace, propertyDisplayName);
        }
    }
}
