using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JJ.Framework.Collections;
using JJ.Framework.Common;
using JJ.Framework.Conversion;
using JJ.Framework.Exceptions.Basic;
// ReSharper disable UnusedMethodReturnValue.Global

namespace JJ.Framework.Validation
{
	public abstract class VersatileValidator : ValidatorBase
	{
		private object _value;
		private string _propertyDisplayName;
		private IFormatProvider _formatProvider;

		/// <summary>
		/// Indicates which property value we are going to validate.
		/// </summary>
		/// <param name="propertyDisplayName">
		/// Used in messages to indicate what property the validation message is about.
		/// </param>
		/// <param name="formatProvider">
		/// Use this parameter if e.g. the number format is different from the current culture.
		/// </param>
		public VersatileValidator For(object value, string propertyDisplayName, IFormatProvider formatProvider = null)
		{
			if (string.IsNullOrEmpty(propertyDisplayName)) throw new NullOrEmptyException(() => propertyDisplayName);

			_value = value;
			_propertyDisplayName = propertyDisplayName;

			_formatProvider = formatProvider ?? CultureHelper.GetCurrentCulture();

			return this;
		}

		// Nullability
		
		public VersatileValidator NotNull()
		{
			if (_value == null)
			{
				Messages.AddNotFilledInMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator NotNullOrEmpty()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				Messages.AddNotFilledInMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator NotNullOrWhiteSpace()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrWhiteSpace(stringValue))
			{
				Messages.AddNotFilledInMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator IsNull()
		{
			if (_value != null)
			{
				Messages.AddIsFilledInMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator IsNullOrEmpty()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (!string.IsNullOrEmpty(stringValue))
			{
				Messages.AddIsFilledInMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator IsNullOrWhiteSpace()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (!string.IsNullOrWhiteSpace(stringValue))
			{
				Messages.AddIsFilledInMessage(_propertyDisplayName);
			}

			return this;
		}

		// Strings
		
		public VersatileValidator MaxLength(int maxLength)
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (stringValue.Length > maxLength)
			{
				Messages.AddLengthExceededMessage(_propertyDisplayName, maxLength);
			}

			return this;
		}

		// Equation
		
		public VersatileValidator In<TValue>(IEnumerable<TValue> possibleValues)
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
				Messages.AddNotInListMessage(_propertyDisplayName, possibleValues);
			}

			return this;
		}
		
		public VersatileValidator In(params object[] possibleValues)
		{
			if (possibleValues == null) throw new NullException(() => possibleValues);

			return In((IEnumerable<object>)possibleValues);
		}

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
				Messages.AddNotEqualMessage(_propertyDisplayName, value);
			}

			return this;
		}
		
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
				Messages.AddIsEqualMessage(_propertyDisplayName, value);
			}

			return this;
		}

		// Comparison
		
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
				Messages.AddLessThanOrEqualMessage(_propertyDisplayName, limit);
			}

			return this;
		}
		
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
				Messages.AddLessThanMessage(_propertyDisplayName, limit);
			}

			return this;
		}

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
				Messages.AddGreaterThanMessage(_propertyDisplayName, limit);
			}

			return this;
		}

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
				Messages.AddGreaterThanOrEqualMessage(_propertyDisplayName, limit);
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
		
		public VersatileValidator IsInteger()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (!int.TryParse(stringValue, NumberStyles.Integer, _formatProvider, out int _))
			{
				Messages.AddNotIntegerMessage(_propertyDisplayName);
			}

			return this;
		}

		public VersatileValidator NotInteger()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (int.TryParse(stringValue, NumberStyles.Integer, _formatProvider, out int _))
			{
				Messages.AddIsIntegerMessage(_propertyDisplayName);
			}

			return this;
		}
		
		public VersatileValidator IsDouble()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (!DoubleParser.TryParse(stringValue, _formatProvider, out double _))
			{
				Messages.AddNotBrokenNumberMessage(_propertyDisplayName);
			}

			return this;
		}
		
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
				Messages.AddIsInvalidChoiceMessage(_propertyDisplayName);
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
		
		public VersatileValidator NotNaN()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			// ReSharper disable once InvertIf
			if (DoubleParser.TryParse(stringValue, _formatProvider, out double convertedValue))
			{
				if (double.IsNaN(convertedValue))
				{
					Messages.AddIsNaNMessage(_propertyDisplayName);
				}
			}

			return this;
		}
		
		public VersatileValidator NotInfinity()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (DoubleParser.TryParse(stringValue, _formatProvider, out double convertedValue))
			{
				if (double.IsInfinity(convertedValue))
				{
					Messages.AddIsInfinityMessage(_propertyDisplayName);
				}
			}

			return this;
		}

		public VersatileValidator NotZero()
		{
			string stringValue = Convert.ToString(_value, _formatProvider);

			if (string.IsNullOrEmpty(stringValue))
			{
				return this;
			}

			if (DoubleParser.TryParse(stringValue, _formatProvider, out double convertedValue))
			{
				// ReSharper disable once CompareOfFloatsByEqualityOperator
				if (convertedValue == 0.0)
				{
					Messages.AddIsZeroMessage(_propertyDisplayName);
				}
			}

			return this;
		}
	}
}
