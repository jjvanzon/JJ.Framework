using System;
using System.Linq.Expressions;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class ExceptionTests
	{
		private static readonly (Type, string)[] _simpleExceptionTypeTuples =
		{
			(typeof(NullException), "{0} is null."),
			(typeof(CollectionEmptyException), "{0} collection is empty."),
			(typeof(CollectionNotEmptyException), "{0} collection should be empty."),
			(typeof(HasNullsException), "{0} contains nulls."),
			(typeof(HasValueException), "{0} should not have a value."),
			(typeof(InfinityException), "{0} is Infinity."),
			(typeof(InvalidReferenceException), "{0} not found in list."),
			(typeof(IsDateTimeException), "{0} should not be a DateTime."),
			(typeof(IsDecimalException), "{0} should not be a Decimal."),
			(typeof(IsDoubleException), "{0} should not be a double precision floating point number."),
			(typeof(IsIntegerException), "{0} should not be an integer number."),
			(typeof(NaNException), "{0} is NaN."),
			(typeof(NotDateTimeException), "{0} is not a DateTime."),
			(typeof(NotDecimalException), "{0} is not a Decimal."),
			(typeof(NotDoubleException), "{0} is not a double precision floating point number."),
			(typeof(NotHasValueException), "{0} has no value."),
			(typeof(NotInfinityException), "{0} should be Infinity."),
			(typeof(NotIntegerException), "{0} is not an integer number."),
			(typeof(NotNaNException), "{0} should be NaN."),
			(typeof(NotNullException), "{0} should be null."),
			(typeof(NotNullOrEmptyException), "{0} should be null or empty."),
			(typeof(NotNullOrWhiteSpaceException), "{0} should be null or white space."),
			(typeof(NullOrEmptyException), "{0} is null or empty."),
			(typeof(NullOrWhiteSpaceException), "{0} is null or white space."),
			(typeof(ZeroException), "{0} is 0.")
		};

		[TestMethod]
		public void Test_SimpleExceptions_WithNameOf()
		{
			object value;

			foreach ((Type type, string messageTemplate) in _simpleExceptionTypeTuples)
			{
				AssertHelper.ThrowsException(
					() => throw (Exception)Activator.CreateInstance(type, nameof(value)),
					type,
					string.Format(messageTemplate, "value"));
			}
		}

		[TestMethod]
		public void Test_SimpleExceptions_WithExpression_WithSinglePart()
		{
			foreach ((Type type, string messageTemplate) in _simpleExceptionTypeTuples)
			{
				AssertHelper.ThrowsException(
					() =>
					{
						object value = null;
						Expression<Func<object>> expression = () => value;
						throw (Exception)Activator.CreateInstance(type, expression);
					},
					type,
					string.Format(messageTemplate, "value"));
			}
		}

		[TestMethod]
		public void Test_SimpleExceptions_WithExpression_WithMultipleParts()
		{
			foreach ((Type type, string messageTemplate) in _simpleExceptionTypeTuples)
			{
				AssertHelper.ThrowsException(
					() =>
					{
						TestItem item = null;
						Expression<Func<object>> expression = () => item.Parent;
						throw (Exception)Activator.CreateInstance(type, expression);
					},
					type,
					string.Format(messageTemplate, "item.Parent"));
			}
		}
	}
}