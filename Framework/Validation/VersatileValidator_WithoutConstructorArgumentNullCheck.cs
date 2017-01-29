using JJ.Framework.Exceptions;
using System;
using System.Linq;
using System.Linq.Expressions;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;
using System.Collections.Generic;
using JJ.Framework.Common;
using System.Globalization;
using JJ.Framework.Collections;

namespace JJ.Framework.Validation
{
    public abstract class VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> : ValidatorBase<TRootObject>
    {
        /// <param name="postponeExecute">
        /// When set to true, you can do initializations in your constructor
        /// before Execute goes off. If so, then you have to call Execute in your own constructor.
        /// </param>
        public VersatileValidator_WithoutConstructorArgumentNullCheck(TRootObject obj, bool postponeExecute = false)
            : base(obj, postponeExecute)
        { }

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
        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> For(Expression<Func<object>> propertyExpression, string propertyDisplayName, IFormatProvider formatProvider = null)
        {
            object value = ExpressionHelper.GetValue(propertyExpression);

            string propertyKey = PropertyKeyHelper.GetPropertyKeyFromExpression(propertyExpression);

            return For(value, propertyKey, propertyDisplayName, formatProvider);
        }

        /// <summary>
        /// Indicates which property value we are going to validate.
        /// </summary>
        /// <param name="propertyKey">
        /// A technical key of the property we are going to validate.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// </param>
        /// <param name="propertyDisplayName">
        /// Used in messages to indicate what property the validation message is about.
        /// </param>
        /// <param name="formatProvider">
        /// Use this parameter if e.g. the number format is different from the current culture.
        /// </param>
        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> For(object value, string propertyKey, string propertyDisplayName, IFormatProvider formatProvider = null)
        {
            if (propertyKey == null) throw new NullException(() => propertyKey);
            if (propertyDisplayName == null) throw new NullException(() => propertyDisplayName);

            _value = value;
            _propertyKey = propertyKey;
            _propertyDisplayName = propertyDisplayName;

            _formatProvider = formatProvider ?? CultureHelper.GetCurrentCulture();

            return this;
        }

        // Nullability

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNull()
        {
            if (_value == null)
            {
                ValidationMessages.AddRequiredMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNullOrWhiteSpace()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (String_PlatformSupport.IsNullOrWhiteSpace(stringValue))
            {
                ValidationMessages.AddRequiredMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNullOrEmpty()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                ValidationMessages.AddRequiredMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsNull()
        {
            if (_value != null)
            {
                ValidationMessages.AddIsFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsNullOrEmpty()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (!string.IsNullOrEmpty(stringValue))
            {
                ValidationMessages.AddIsFilledInMessage(_propertyKey, _propertyDisplayName);
            }

            return this;
        }

        // Strings

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> MaxLength(int maxLength)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> In<TValue>(IEnumerable<TValue> possibleValues)
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            bool isAllowed = possibleValues.Where(x => Equals(x, _value)).Any();

            if (!isAllowed)
            {
                ValidationMessages.AddNotInListMessage(_propertyKey, _propertyDisplayName, possibleValues);
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> In(params object[] possibleValues)
        {
            if (possibleValues == null) throw new NullException(() => possibleValues);

            return In((IEnumerable<object>)(object[])possibleValues);
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> Is(object value)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsNot(object value)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> GreaterThan<TValue>(TValue limit)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> GreaterThanOrEqual<TValue>(TValue limit)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> LessThanOrEqual<TValue>(TValue limit)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> LessThan<TValue>(TValue limit)
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsInteger()
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotInteger()
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsDouble()
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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsEnum<TEnum>()
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
            TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

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

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNaN()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            if (DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                if (double.IsNaN(convertedValue))
                {
                    ValidationMessages.AddIsNaNMessage(_propertyKey, _propertyDisplayName);
                }
            }

            return this;
        }

        public VersatileValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotInfinity()
        {
            string stringValue = Convert.ToString(_value, _formatProvider);

            if (string.IsNullOrEmpty(stringValue))
            {
                return this;
            }

            double convertedValue;
            if (DoubleHelper.TryParse(stringValue, _formatProvider, out convertedValue))
            {
                if (double.IsInfinity(convertedValue))
                {
                    ValidationMessages.AddIsInfinityMessage(_propertyKey, _propertyDisplayName);
                }
            }

            return this;
        }
    }
}
