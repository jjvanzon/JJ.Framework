using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation.Resources
{
    internal static class MessageFormatter
    {
        public static string IsNull(string propertyDisplayName)
        {
            return String.Format(Messages.IsNull, propertyDisplayName);
        }

        public static string NotIsValue(string propertyDisplayName, object value)
        {
            return String.Format(Messages.NotIsValue, propertyDisplayName, value);
        }

        public static string NotAbove(string propertyDisplayName)
        {
            return String.Format(Messages.NotAbove, propertyDisplayName);
        }

        public static string IsNullOrWhiteSpace(string propertyDisplayName)
        {
            return String.Format(Messages.IsNullOrWhiteSpace, propertyDisplayName);
        }

        public static string IsZero(string propertyDisplayName)
        {
            return String.Format(Messages.IsZero, propertyDisplayName);
        }

        public static string IsInteger(string propertyDisplayName)
        {
            return String.Format(Messages.IsInteger, propertyDisplayName);
        }
    }
}
