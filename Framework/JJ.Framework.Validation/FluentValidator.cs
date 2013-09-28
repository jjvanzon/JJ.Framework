using JJ.Framework.Validation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Validation
{
    public abstract class FluentValidator<T> : ValidatorBase<T>
    {
        public FluentValidator(T obj)
            : base(obj)
        { }

        private object _value;
        private string _propertyDisplayName;

        public FluentValidator<T> For(object value, string propertyDisplayName)
        {
            if (propertyDisplayName == null)
            {
                throw new ArgumentNullException("propertyDisplayName");
            }

            _propertyDisplayName = propertyDisplayName;
            _value = value;

            return this;
        }

        public void NotNull()
        {
            if (_value == null)
            {
                ValidationMessages.Add(_propertyDisplayName, FormattedMessages.IsNull(_propertyDisplayName));
            }
        }

        public void NotNullOrWhiteSpace()
        {
            string value = Convert.ToString(_value);

            if (String.IsNullOrWhiteSpace(value))
            {
                ValidationMessages.Add(_propertyDisplayName, FormattedMessages.IsNullOrWhiteSpace(_propertyDisplayName));
            }
        }

        public void IsValue<TValue>(TValue value)
        {
            if (!Equals(_value, value))
            {
                ValidationMessages.Add(_propertyDisplayName, FormattedMessages.NotIsValue(_propertyDisplayName, value));
            }
        }

        public void Above<TValue>(TValue min)
            where TValue: IComparable
        {
            if (_value == null)
            {
                return;
            }

            IComparable value =(IComparable)_value;

            if (value.CompareTo(min) > 0)
            {
                ValidationMessages.Add(_propertyDisplayName, FormattedMessages.NotAbove(_propertyDisplayName));
            }
        }
    }
}
