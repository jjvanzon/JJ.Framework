using JJ.Framework.Reflection.Exceptions;
using JJ.Framework.Validation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;

namespace JJ.Framework.Validation
{
    public abstract class FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> : ValidatorBase<TRootObject>
    {
        /// <param name="postponeExecute">
        /// When set to true, you can do initializations in your constructor
        /// before Execute goes off. If so, then you have to call Execute in your own constructor.
        /// </param>
        public FluentValidator_WithoutConstructorArgumentNullCheck(TRootObject obj, bool postponeExecute = false)
            : base(obj, postponeExecute)
        { }

        private object _value;
        private string _propertyKey;
        private string _propertyDisplayName;

        /// <summary>
        /// Indicate which property value we are going to validate.
        /// This name is used in validation messages and can best be set to a localized resource.
        /// </summary>
        /// <param name="propertyExpression">
        /// Used to extract both the value and a property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> For(Expression<Func<object>> propertyExpression, string propertyDisplayName)
        {
            object value = ExpressionHelper.GetValue(propertyExpression);

            string propertyKey = PropertyKeyHelper.GetPropertyKeyFromExpression(propertyExpression);

            return For(value, propertyKey, propertyDisplayName);
        }

        /// <summary>
        /// Indicate which property value we are going to validate.
        /// This name is used in validation messages and can best be set to a localized resource.
        /// </summary>
        /// <param name="propertyKey">
        /// A technical key of the property we are going to validate.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// </param>
        /// <param name="propertyDisplayName">
        /// Used in messages to indicate what property the validation message is about.
        /// </param>
        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> For(object value, string propertyKey, string propertyDisplayName)
        {
            if (propertyKey == null)
            {
                throw new NullException(() => propertyKey);
            }
            if (propertyDisplayName == null)
            {
                throw new NullException(() => propertyDisplayName);
            }

            _value = value;
            _propertyKey = propertyKey;
            _propertyDisplayName = propertyDisplayName;

            return this;
        }

        // Nullability

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNull()
        {
            if (_value == null)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNull(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNullOrWhiteSpace()
        {
            string value = Convert.ToString(_value);

            if (String_PlatformSupport.IsNullOrWhiteSpace(value))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNullOrWhiteSpace(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotNullOrEmpty()
        {
            string value = Convert.ToString(_value);

            if (String.IsNullOrEmpty(value))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNullOrEmpty(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsNull()
        {
            if (_value != null)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNotNull(_propertyDisplayName));
            }

            return this;
        }

        // Strings

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> MaxLength(int maxLength)
        {
            string str = Convert.ToString(_value);

            if (String.IsNullOrEmpty(str))
            {
                return this;
            }

            if (str.Length > maxLength)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.ExceedsLength(_propertyDisplayName, maxLength));
            }

            return this;
        }

        // Equation

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> In(params object[] possibleValues)
        {
            if (possibleValues == null) throw new NullException(() => possibleValues);

            string convertedValue = Convert.ToString(_value);

            if (String.IsNullOrEmpty(convertedValue))
            {
                return this;
            }

            bool isAllowed = possibleValues.Where(x => Equals(x, _value)).Any();

            if (!isAllowed)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.NotIn(_propertyDisplayName, _value, possibleValues));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> Is<TValue>(TValue value)
        {
            string convertedValue = Convert.ToString(_value);

            if (String.IsNullOrEmpty(convertedValue))
            {
                return this;
            }

            if (!Equals(_value, value))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNot(_propertyDisplayName, value));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsNot<TValue>(TValue value)
        {
            // TODO: The conversion to string seems weird here.
            string convertedValue = Convert.ToString(_value);

            if (String.IsNullOrEmpty(convertedValue))
            {
                return this;
            }

            if (Equals(_value, value))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.CannotBe(_propertyDisplayName, value));
            }

            return this;
        }

        // Comparison

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> Above<TValue>(TValue min)
            where TValue : IComparable
        {
            if (_value == null)
            {
                return this;
            }

            IComparable value = (IComparable)_value;

            if (value.CompareTo(min) <= 0)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.NotAbove(_propertyDisplayName, min));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> MinValue<TValue>(TValue min)
            where TValue : IComparable
        {
            if (_value == null)
            {
                return this;
            }

            IComparable value = (IComparable)_value;

            if (value.CompareTo(min) < 0)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.Min(_propertyDisplayName, min));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> MaxValue<TValue>(TValue max)
            where TValue : IComparable
        {
            if (_value == null)
            {
                return this;
            }

            IComparable value = (IComparable)_value;

            if (value.CompareTo(max) > 0)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.Max(_propertyDisplayName, max));
            }

            return this;
        }

        // Type checks

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> NotInteger()
        {
            string value = Convert.ToString(_value);

            if (String.IsNullOrEmpty(value))
            {
                return this;
            }

            int convertedValue;
            if (Int32.TryParse(value, out convertedValue))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsInteger(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsDouble()
        {
            string value = Convert.ToString(_value);

            if (String.IsNullOrEmpty(value))
            {
                return this;
            }

            double convertedValue;
            if (!Double.TryParse(value, out convertedValue))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.NotDouble(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsInteger()
        {
            string value = Convert.ToString(_value);

            if (String.IsNullOrEmpty(value))
            {
                return this;
            }

            int convertedValue;
            if (!Int32.TryParse(value, out convertedValue))
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.NotInteger(_propertyDisplayName));
            }

            return this;
        }

        public FluentValidator_WithoutConstructorArgumentNullCheck<TRootObject> IsEnumValue<T>()
            where T : struct
        {
            // TODO: This does seem to evaluate numerical strings and enum member name strings correctly.

            // TODO: Can I build generic null-tollerance without converting to string?
            string str = Convert.ToString(_value);
            if (String.IsNullOrEmpty(str))
            {
                return this;
            }

            T[] enumValues = (T[])Enum.GetValues(typeof(T));

            // Convert to a canonical form.
            // "Every enumeration type has an underlying type, which can be any integral type except char."
            // (https://msdn.microsoft.com/en-us/library/sbbt4032.aspx)
            decimal[] underlyingValues = enumValues.Select(x => (decimal)Convert.ChangeType(x, typeof(decimal))).ToArray();
            decimal underlyingValue = (decimal)Convert.ChangeType(_value, typeof(decimal));

            bool isEnum = underlyingValues.Contains(underlyingValue);
            if (!isEnum)
            {
                ValidationMessages.Add(_propertyKey, ValidationMessageFormatter.IsNotValidEnumValue(_propertyDisplayName));
            }

            return this;
        }
    }
}