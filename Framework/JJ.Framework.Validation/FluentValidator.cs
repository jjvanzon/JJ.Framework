using JJ.Framework.Reflection;
using JJ.Framework.Validation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.PlatformCompatibility;

namespace JJ.Framework.Validation
{
    public abstract class FluentValidator<TRootObject> : ValidatorBase<TRootObject>
    {
        public FluentValidator(TRootObject obj)
            : base(obj)
        { }

        private object _value;
        private string _propertyKey;
        private string _propertyDisplayName;

        /// <summary>
        /// Indicate which property value we are going to validate.
        /// </summary>
        /// <param name="propertyExpression">
        /// Used to extract both the value and a property key.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// The root of the expression is excluded from the property key, e.g. "() => MyObject.MyProperty" produces the property key "MyProperty".
        /// </param>
        public FluentValidator<TRootObject> For(Expression<Func<object>> propertyExpression, string propertyDisplayName)
        {
            object value = ExpressionHelper.GetValue(propertyExpression);
            string propertyKey = ExpressionHelper.GetText(propertyExpression, true);

            // Always cut off the root object, e.g. "MyObject.MyProperty" becomes "MyProperty".
            propertyKey = propertyKey.CutLeftUntil(".").CutLeft(".");

            return For(value, propertyKey, propertyDisplayName);
        }

        /// <summary>
        /// Indicate which property value we are going to validate.
        /// </summary>
        /// <param name="propertyKey">
        /// A technical key of the property we are going to validate.
        /// The property key is used e.g. to make MVC display validation messages next to the corresponding html input element.
        /// </param>
        /// <param name="propertyDisplayName">
        /// Used in messages to indicate what property the validation message is about.
        /// </param>
        public FluentValidator<TRootObject> For(object value, string propertyKey, string propertyDisplayName)
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

        public void NotNull()
        {
            if (_value == null)
            {
                ValidationMessages.Add(_propertyKey, MessageFormatter.IsNull(_propertyDisplayName));
            }
        }

        public void NotNullOrWhiteSpace()
        {
            string value = Convert.ToString(_value);

            if (String_PlatformSupport.IsNullOrWhiteSpace(value))
            {
                ValidationMessages.Add(_propertyKey, MessageFormatter.IsNullOrWhiteSpace(_propertyDisplayName));
            }
        }

        public void IsValue<TValue>(TValue value)
        {
            if (!Equals(_value, value))
            {
                ValidationMessages.Add(_propertyKey, MessageFormatter.NotIsValue(_propertyDisplayName, value));
            }
        }

        public void Above<TValue>(TValue min)
            where TValue : IComparable
        {
            if (_value == null)
            {
                return;
            }

            IComparable value = (IComparable)_value;

            if (value.CompareTo(min) > 0)
            {
                ValidationMessages.Add(_propertyKey, MessageFormatter.NotAbove(_propertyDisplayName));
            }
        }

        public void NotZero()
        {
            if (Equals(_value, 0))
            {
                ValidationMessages.Add(_propertyKey, MessageFormatter.IsZero(_propertyDisplayName));
            }
        }
    }
}