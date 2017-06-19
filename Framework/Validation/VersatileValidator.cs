using JJ.Framework.Exceptions;
using System;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using System.Collections.Generic;
using JJ.Framework.Common;
using System.Globalization;
using JetBrains.Annotations;
using JJ.Framework.Collections;

namespace JJ.Framework.Validation
{
    public abstract class VersatileValidator : ValidatorBase
    {
        private object _value;
        private string _propertyKey;
        private string _propertyDisplayName;
        private IFormatProvider _formatProvider;

        /// <param name="propertyDisplayName">
        /// Indicates which property value we are going to validate.
        /// </param>
        /// <param name="propertyExpression">
        /// Used to extract both the value and a property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        /// <param name="formatProvider">
        /// Use this parameter if e.g. the number format is different from the current culture.
        /// </param>
        [NotNull]
        public VersatileValidator For([NotNull] Expression<Func<object>> propertyExpression, string propertyDisplayName, [CanBeNull] IFormatProvider formatProvider = null)
        {
            object value = ExpressionHelper.GetValue(propertyExpression);

            string key = MessageKeyHelper.GetMessageKeyFromExpression(propertyExpression);

            return For(value, key, propertyDisplayName, formatProvider);
        }

        /// <summary>
        /// Indicates which property value we are going to validate.
        /// </summary>
        /// <param name="key">
        /// A technical key of the property we are going to validate.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// </param>
        /// <param name="propertyDisplayName">
        /// Used in messages to indicate what property the validation message is about.
        /// </param>
        /// <param name="formatProvider">
        /// Use this parameter if e.g. the number format is different from the current culture.
        /// </param>
        [NotNull]
        public VersatileValidator For(object value, string key, string propertyDisplayName, [CanBeNull] IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(key)) throw new NullOrEmptyException(() => key);
            if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);

            _value = value;
            _propertyKey = key;
            _propertyDisplayName = propertyDisplayName;

            _formatProvider = formatProvider ?? CultureHelper.GetCurrentCulture();

            return this;
        }

        // Nullability

        [NotNull]
        public VersatileValidator NotNull()
        {
            if (_value == null)
            {
                ValidationMessages.AddNotFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator NotNullOrEmpty()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                ValidationMessages.AddNotFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator NotNullOrWhiteSpace()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (String_PlatformSupport.IsNullOrWhiteSpace(stringValue))
            {
                ValidationMessages.AddNotFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsNull()
        {
            if (_value != null)
            {
                ValidationMessages.AddIsFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsNullOrEmpty()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (!string.IsNullOrEmpty(stringValue))
            {
                ValidationMessages.AddIsFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsNullOrWhiteSpace()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                ValidationMessages.AddIsFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        // Strings

        [NotNull]
        public VersatileValidator MaxLength(int maxLength)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            if (stringValue.Length > maxLength)
            {
                ValidationMessages.AddLengthExceededMessage(_propertyKey, _propertyDisplayName, maxLength);
            }

            return this;
        }

        // Equation

        [NotNull]
        public VersatileValidator In<TValue>([NotNull] IEnumerable<TValue> possibleValues)
        {
            if (possibleValues == null) throw new NullException(() => possibleValues);

            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            // ReSharper disable once PossibleMultipleEnumeration
            bool isAllowed = possibleValues.Where(x => Equals(x, _value)).Any();

            if (!isAllowed)
            {
                // ReSharper disable once PossibleMultipleEnumeration
                ValidationMessages.AddNotInListMessage(_propertyKey, _propertyDisplayName, possibleValues);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator In(params object[] possibleValues)
        {
            if (possibleValues == null) throw new NullException(() => possibleValues);

            return In((IEnumerable<object>)possibleValues);
        }

        [NotNull]
        public VersatileValidator Is(object value)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            string otherStringValue = Convert.ToString(value, _formatProvider);

            if (!string.Equals(stringValue, otherStringValue))
            {
                ValidationMessages.AddNotEqualMessage(_propertyKey, _propertyDisplayName, value);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsNot(object value)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            string otherStringValue = Convert.ToString(value, _formatProvider);

            if (string.Equals(stringValue, otherStringValue))
            {
                ValidationMessages.AddIsEqualMessage(_propertyKey, _propertyDisplayName, value);
            }

            return this;
        }

        // Comparison

        [NotNull]
        public VersatileValidator GreaterThan<TValue>(TValue limit)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);
            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int comparisonResult;
            if (limit is DateTime)
            {
                comparisonResult = CompareDateTimes(_value, limit);
            }
            else
            {
                comparisonResult = CompareNumbers(_value, limit);
            }

            bool isValid = comparisonResult > 0;
            if (!isValid)
            {
                ValidationMessages.AddLessThanOrEqualMessage(_propertyKey, _propertyDisplayName, limit);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator GreaterThanOrEqual<TValue>(TValue limit)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);
            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int comparisonResult;
            if (limit is DateTime)
            {
                comparisonResult = CompareDateTimes(_value, limit);
            }
            else
            {
                comparisonResult = CompareNumbers(_value, limit);
            }

            bool isValid = comparisonResult >= 0;
            if (!isValid)
            {
                ValidationMessages.AddLessThanMessage(_propertyKey, _propertyDisplayName, limit);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator LessThanOrEqual<TValue>(TValue limit)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);
            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int comparisonResult;
            if (limit is DateTime)
            {
                comparisonResult = CompareDateTimes(_value, limit);
            }
            else
            {
                comparisonResult = CompareNumbers(_value, limit);
            }

            bool isValid = comparisonResult <= 0;
            if (!isValid)
            {
                ValidationMessages.AddGreaterThanMessage(_propertyKey, _propertyDisplayName, limit);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator LessThan<TValue>(TValue limit)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);
            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int comparisonResult;
            if (limit is DateTime)
            {
                comparisonResult = CompareDateTimes(_value, limit);
            }
            else
            {
                comparisonResult = CompareNumbers(_value, limit);
            }

            bool isValid = comparisonResult < 0;
            if (!isValid)
            {
                ValidationMessages.AddGreaterThanOrEqualMessage(_propertyKey, _propertyDisplayName, limit);
            }

            return this;
        }

        /// <summary> Compares DateTimes, but in a way that either value could also be a string. </summary>
        private int CompareDateTimes(object a, object b)
        {
            DateTime dateTimeA = Convert.ToDateTime(a, _formatProvider);
            DateTime dateTimeB = Convert.ToDateTime(b, _formatProvider);
            return dateTimeA.CompareTo(dateTimeB);
        }

        /// <summary>
        /// Converts both values to decimal, so comparisons are number-based, and strings are interpreted as numbers.
        /// </summary>
        private int CompareNumbers(object a, object b)
        {
            decimal decimalA = Convert.ToDecimal(a, _formatProvider);
            decimal decimalB = Convert.ToDecimal(b, _formatProvider);
            return decimalA.CompareTo(decimalB);
        }

        // Type checks

        [NotNull]
        public VersatileValidator IsInteger()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int convertedValue;
            if (!int.TryParse(stringValue, NumberStyles.Integer, _formatProvider, out convertedValue))
            {
                ValidationMessages.AddNotIntegerMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator NotInteger()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            int convertedValue;
            if (int.TryParse(stringValue, NumberStyles.Integer, _formatProvider, out convertedValue))
            {
                ValidationMessages.AddIsIntegerMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsDouble()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            if (!DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                ValidationMessages.AddNotBrokenNumberMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        [NotNull]
        public VersatileValidator IsEnum<TEnum>()
            where TEnum : struct
        {
            string stringValue = Convert.ToString(_value, _formatProvider);
            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            Type sourceType = _value.GetType();

            bool isEnum;
            if (sourceType == typeof(string))
            {
                isEnum = IsEnum_WithStringComparison<TEnum>(_value);
            }
            else
            {
                isEnum = IsEnum_WithNumericComparison<TEnum>(_value);
            }

            if (!isEnum)
            {
                ValidationMessages.AddIsInvalidChoiceMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        private bool IsEnum_WithNumericComparison<TEnum>(object value)
            where TEnum : struct
        {
            IList<TEnum> enumValues = EnumHelper.GetValues<TEnum>();

            // Convert to a canonical form.
            // "Every enumeration type has an underlying type, which can be any integral type except char."
            // (https://msdn.microsoft.com/en-us/library/sbbt4032.aspx)
            decimal[] underlyingValues = enumValues.Select(x => (decimal)Convert.ChangeType(x, typeof(decimal))).ToArray();
            decimal underlyingValue = (decimal)Convert.ChangeType(value, typeof(decimal));

            bool isEnum = underlyingValues.Contains(underlyingValue);
            return isEnum;
        }

        private bool IsEnum_WithStringComparison<TEnum>(object value)
        {
            // Not an array, that might result in reference comparison,
            // but a HashSet, so it does value comparison.
            HashSet<string> enumNames = Enum.GetNames(typeof(TEnum)).ToHashSet();

            string valueString = Convert.ToString(value, _formatProvider);

            bool isEnum = enumNames.Contains(valueString);
            return isEnum;
        }

        // Other

        [NotNull]
        public VersatileValidator NotNaN()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            // ReSharper disable once InvertIf
            if (DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                if (double.IsNaN(convertedValue))
                {
                    ValidationMessages.AddIsNaNMessage(_propertyKey, _propertyDisplayName);
                }
            }

            return this;
        }

        [NotNull]
        public VersatileValidator NotInfinity()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            // ReSharper disable once InvertIf
            if (DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                if (double.IsInfinity(convertedValue))
                {
                    ValidationMessages.AddIsInfinityMessage(_propertyKey, _propertyDisplayName);
                }
            }

            return this;
        }

        [NotNull]
        public VersatileValidator NotZero()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            // ReSharper disable once InvertIf
            if (DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (convertedValue == 0.0)
                {
                    ValidationMessages.AddIsZeroMessage(_propertyKey, _propertyDisplayName);
                }
            }

            return this;
        }
    }
}
