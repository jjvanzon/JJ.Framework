using JJ.Framework.PlatformCompatibility;
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

        public static string IsNot(string propertyDisplayName, object value)
        {
            return String.Format(Messages.IsNot, propertyDisplayName, value);
        }

        public static string NotAbove(string propertyDisplayName, object min)
        {
            return String.Format(Messages.NotAbove, propertyDisplayName, min);
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

        public static string Min(string propertyDisplayName, object min)
        {
            return String.Format(Messages.Min, propertyDisplayName, min);
        }

        public static string IsNotValidEnumValue(string propertyDisplayName)
        {
            return String.Format(Messages.IsNotValidEnumValue, propertyDisplayName);
        }

        public static string CannotBe(string propertyDisplayName, object value)
        {
            return String.Format(Messages.CannotBe, propertyDisplayName, value);
        }

        public static string Max(string propertyDisplayName, object max)
        {
            return String.Format(Messages.Max, propertyDisplayName, max);
        }

        public static string NotIn(string propertyDisplayName, object value, object[] possibleValues)
        {
            string joined = String_PlatformSupport.Join(", ", possibleValues);
            string message = String.Format(Messages.NotIn, propertyDisplayName, joined);
            return message;
        }
    }
}
