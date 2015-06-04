using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Validation.Resources
{
    public static class ValidationMessageFormatter
    {
        public static string IsNull(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsNull, propertyDisplayName);
        }

        internal static string IsNotNull(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsNotNull, propertyDisplayName);
        }

        public static string IsNot(string propertyDisplayName, object value)
        {
            return String.Format(ValidationMessages.IsNot, propertyDisplayName, value);
        }

        public static string NotAbove(string propertyDisplayName, object min)
        {
            return String.Format(ValidationMessages.NotAbove, propertyDisplayName, min);
        }

        public static string IsNullOrWhiteSpace(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsNullOrWhiteSpace, propertyDisplayName);
        }

        public static string IsZero(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsZero, propertyDisplayName);
        }

        public static string IsInteger(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsInteger, propertyDisplayName);
        }

        internal static string NotInteger(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotInteger, propertyDisplayName);
        }

        public static string NotDouble(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotDouble, propertyDisplayName);
        }

        public static string Min(string propertyDisplayName, object min)
        {
            return String.Format(ValidationMessages.Min, propertyDisplayName, min);
        }

        public static string IsNotValidEnumValue(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsNotValidEnumValue, propertyDisplayName);
        }

        public static string CannotBe(string propertyDisplayName, object value)
        {
            return String.Format(ValidationMessages.CannotBe, propertyDisplayName, value);
        }

        public static string Max(string propertyDisplayName, object max)
        {
            return String.Format(ValidationMessages.Max, propertyDisplayName, max);
        }

        public static string NotIn(string propertyDisplayName, object value, object[] possibleValues)
        {
            string joined = String_PlatformSupport.Join(", ", possibleValues);
            string message = String.Format(ValidationMessages.NotIn, propertyDisplayName, joined);
            return message;
        }

        internal static string ExceedsLength(string propertyDisplayName, int maxLength)
        {
            return String.Format(ValidationMessages.ExceedsLength, propertyDisplayName, maxLength);
        }
    }
}
