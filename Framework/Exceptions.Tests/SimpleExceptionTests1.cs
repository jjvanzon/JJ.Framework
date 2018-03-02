

using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class SimpleExceptionTests
	{
		
			[TestMethod]
			public void Test_CollectionEmptyException_WithNameOf()
			{
				AssertHelper.ThrowsException<CollectionEmptyException>(
					() =>
					{
						object value;

						throw new CollectionEmptyException(nameof(value));
					},
					"value collection is empty.");
			}

			[TestMethod]
			public void Test_CollectionEmptyException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<CollectionEmptyException>(
					() =>
					{
						object value = null;

						throw new CollectionEmptyException(() => value);
					},
					"value collection is empty.");
			}

			[TestMethod]
			public void Test_CollectionEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<CollectionEmptyException>(
					() =>
					{
						TestItem item = null;

						throw new CollectionEmptyException(() => item.Parent);
					},
					"item.Parent collection is empty.");
			}

		
			[TestMethod]
			public void Test_CollectionNotEmptyException_WithNameOf()
			{
				AssertHelper.ThrowsException<CollectionNotEmptyException>(
					() =>
					{
						object value;

						throw new CollectionNotEmptyException(nameof(value));
					},
					"value collection should be empty.");
			}

			[TestMethod]
			public void Test_CollectionNotEmptyException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<CollectionNotEmptyException>(
					() =>
					{
						object value = null;

						throw new CollectionNotEmptyException(() => value);
					},
					"value collection should be empty.");
			}

			[TestMethod]
			public void Test_CollectionNotEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<CollectionNotEmptyException>(
					() =>
					{
						TestItem item = null;

						throw new CollectionNotEmptyException(() => item.Parent);
					},
					"item.Parent collection should be empty.");
			}

		
			[TestMethod]
			public void Test_HasNullsException_WithNameOf()
			{
				AssertHelper.ThrowsException<HasNullsException>(
					() =>
					{
						object value;

						throw new HasNullsException(nameof(value));
					},
					"value contains nulls.");
			}

			[TestMethod]
			public void Test_HasNullsException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<HasNullsException>(
					() =>
					{
						object value = null;

						throw new HasNullsException(() => value);
					},
					"value contains nulls.");
			}

			[TestMethod]
			public void Test_HasNullsException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<HasNullsException>(
					() =>
					{
						TestItem item = null;

						throw new HasNullsException(() => item.Parent);
					},
					"item.Parent contains nulls.");
			}

		
			[TestMethod]
			public void Test_HasValueException_WithNameOf()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						object value;

						throw new HasValueException(nameof(value));
					},
					"value should not have a value.");
			}

			[TestMethod]
			public void Test_HasValueException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						object value = null;

						throw new HasValueException(() => value);
					},
					"value should not have a value.");
			}

			[TestMethod]
			public void Test_HasValueException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						TestItem item = null;

						throw new HasValueException(() => item.Parent);
					},
					"item.Parent should not have a value.");
			}

		
			[TestMethod]
			public void Test_InfinityException_WithNameOf()
			{
				AssertHelper.ThrowsException<InfinityException>(
					() =>
					{
						object value;

						throw new InfinityException(nameof(value));
					},
					"value is Infinity.");
			}

			[TestMethod]
			public void Test_InfinityException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<InfinityException>(
					() =>
					{
						object value = null;

						throw new InfinityException(() => value);
					},
					"value is Infinity.");
			}

			[TestMethod]
			public void Test_InfinityException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<InfinityException>(
					() =>
					{
						TestItem item = null;

						throw new InfinityException(() => item.Parent);
					},
					"item.Parent is Infinity.");
			}

		
			[TestMethod]
			public void Test_InvalidReferenceException_WithNameOf()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						object value;

						throw new InvalidReferenceException(nameof(value));
					},
					"value not found in list.");
			}

			[TestMethod]
			public void Test_InvalidReferenceException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						object value = null;

						throw new InvalidReferenceException(() => value);
					},
					"value not found in list.");
			}

			[TestMethod]
			public void Test_InvalidReferenceException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						TestItem item = null;

						throw new InvalidReferenceException(() => item.Parent);
					},
					"item.Parent not found in list.");
			}

		
			[TestMethod]
			public void Test_IsDateTimeException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						object value;

						throw new IsDateTimeException(nameof(value));
					},
					"value should not be a DateTime.");
			}

			[TestMethod]
			public void Test_IsDateTimeException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						object value = null;

						throw new IsDateTimeException(() => value);
					},
					"value should not be a DateTime.");
			}

			[TestMethod]
			public void Test_IsDateTimeException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						TestItem item = null;

						throw new IsDateTimeException(() => item.Parent);
					},
					"item.Parent should not be a DateTime.");
			}

		
			[TestMethod]
			public void Test_IsDecimalException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						object value;

						throw new IsDecimalException(nameof(value));
					},
					"value should not be a Decimal.");
			}

			[TestMethod]
			public void Test_IsDecimalException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						object value = null;

						throw new IsDecimalException(() => value);
					},
					"value should not be a Decimal.");
			}

			[TestMethod]
			public void Test_IsDecimalException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						TestItem item = null;

						throw new IsDecimalException(() => item.Parent);
					},
					"item.Parent should not be a Decimal.");
			}

		
			[TestMethod]
			public void Test_IsDoubleException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						object value;

						throw new IsDoubleException(nameof(value));
					},
					"value should not be a double precision floating point number.");
			}

			[TestMethod]
			public void Test_IsDoubleException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						object value = null;

						throw new IsDoubleException(() => value);
					},
					"value should not be a double precision floating point number.");
			}

			[TestMethod]
			public void Test_IsDoubleException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						TestItem item = null;

						throw new IsDoubleException(() => item.Parent);
					},
					"item.Parent should not be a double precision floating point number.");
			}

		
			[TestMethod]
			public void Test_IsIntegerException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						object value;

						throw new IsIntegerException(nameof(value));
					},
					"value should not be an integer number.");
			}

			[TestMethod]
			public void Test_IsIntegerException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						object value = null;

						throw new IsIntegerException(() => value);
					},
					"value should not be an integer number.");
			}

			[TestMethod]
			public void Test_IsIntegerException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						TestItem item = null;

						throw new IsIntegerException(() => item.Parent);
					},
					"item.Parent should not be an integer number.");
			}

		
			[TestMethod]
			public void Test_NaNException_WithNameOf()
			{
				AssertHelper.ThrowsException<NaNException>(
					() =>
					{
						object value;

						throw new NaNException(nameof(value));
					},
					"value is NaN.");
			}

			[TestMethod]
			public void Test_NaNException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NaNException>(
					() =>
					{
						object value = null;

						throw new NaNException(() => value);
					},
					"value is NaN.");
			}

			[TestMethod]
			public void Test_NaNException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NaNException>(
					() =>
					{
						TestItem item = null;

						throw new NaNException(() => item.Parent);
					},
					"item.Parent is NaN.");
			}

		
			[TestMethod]
			public void Test_NotDateTimeException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						object value;

						throw new NotDateTimeException(nameof(value));
					},
					"value is not a DateTime.");
			}

			[TestMethod]
			public void Test_NotDateTimeException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						object value = null;

						throw new NotDateTimeException(() => value);
					},
					"value is not a DateTime.");
			}

			[TestMethod]
			public void Test_NotDateTimeException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						TestItem item = null;

						throw new NotDateTimeException(() => item.Parent);
					},
					"item.Parent is not a DateTime.");
			}

		
			[TestMethod]
			public void Test_NotDecimalException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						object value;

						throw new NotDecimalException(nameof(value));
					},
					"value is not a Decimal.");
			}

			[TestMethod]
			public void Test_NotDecimalException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						object value = null;

						throw new NotDecimalException(() => value);
					},
					"value is not a Decimal.");
			}

			[TestMethod]
			public void Test_NotDecimalException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						TestItem item = null;

						throw new NotDecimalException(() => item.Parent);
					},
					"item.Parent is not a Decimal.");
			}

		
			[TestMethod]
			public void Test_NotDoubleException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						object value;

						throw new NotDoubleException(nameof(value));
					},
					"value is not a double precision floating point number.");
			}

			[TestMethod]
			public void Test_NotDoubleException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						object value = null;

						throw new NotDoubleException(() => value);
					},
					"value is not a double precision floating point number.");
			}

			[TestMethod]
			public void Test_NotDoubleException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						TestItem item = null;

						throw new NotDoubleException(() => item.Parent);
					},
					"item.Parent is not a double precision floating point number.");
			}

		
			[TestMethod]
			public void Test_NotHasValueException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotHasValueException>(
					() =>
					{
						object value;

						throw new NotHasValueException(nameof(value));
					},
					"value has no value.");
			}

			[TestMethod]
			public void Test_NotHasValueException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotHasValueException>(
					() =>
					{
						object value = null;

						throw new NotHasValueException(() => value);
					},
					"value has no value.");
			}

			[TestMethod]
			public void Test_NotHasValueException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotHasValueException>(
					() =>
					{
						TestItem item = null;

						throw new NotHasValueException(() => item.Parent);
					},
					"item.Parent has no value.");
			}

		
			[TestMethod]
			public void Test_NotInfinityException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						object value;

						throw new NotInfinityException(nameof(value));
					},
					"value should be Infinity.");
			}

			[TestMethod]
			public void Test_NotInfinityException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						object value = null;

						throw new NotInfinityException(() => value);
					},
					"value should be Infinity.");
			}

			[TestMethod]
			public void Test_NotInfinityException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						TestItem item = null;

						throw new NotInfinityException(() => item.Parent);
					},
					"item.Parent should be Infinity.");
			}

		
			[TestMethod]
			public void Test_NotIntegerException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						object value;

						throw new NotIntegerException(nameof(value));
					},
					"value is not an integer number.");
			}

			[TestMethod]
			public void Test_NotIntegerException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						object value = null;

						throw new NotIntegerException(() => value);
					},
					"value is not an integer number.");
			}

			[TestMethod]
			public void Test_NotIntegerException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						TestItem item = null;

						throw new NotIntegerException(() => item.Parent);
					},
					"item.Parent is not an integer number.");
			}

		
			[TestMethod]
			public void Test_NotNaNException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						object value;

						throw new NotNaNException(nameof(value));
					},
					"value should be NaN.");
			}

			[TestMethod]
			public void Test_NotNaNException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						object value = null;

						throw new NotNaNException(() => value);
					},
					"value should be NaN.");
			}

			[TestMethod]
			public void Test_NotNaNException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						TestItem item = null;

						throw new NotNaNException(() => item.Parent);
					},
					"item.Parent should be NaN.");
			}

		
			[TestMethod]
			public void Test_NotNullException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						object value;

						throw new NotNullException(nameof(value));
					},
					"value should be null.");
			}

			[TestMethod]
			public void Test_NotNullException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						object value = null;

						throw new NotNullException(() => value);
					},
					"value should be null.");
			}

			[TestMethod]
			public void Test_NotNullException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						TestItem item = null;

						throw new NotNullException(() => item.Parent);
					},
					"item.Parent should be null.");
			}

		
			[TestMethod]
			public void Test_NotNullOrEmptyException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						object value;

						throw new NotNullOrEmptyException(nameof(value));
					},
					"value should be null or empty.");
			}

			[TestMethod]
			public void Test_NotNullOrEmptyException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						object value = null;

						throw new NotNullOrEmptyException(() => value);
					},
					"value should be null or empty.");
			}

			[TestMethod]
			public void Test_NotNullOrEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						TestItem item = null;

						throw new NotNullOrEmptyException(() => item.Parent);
					},
					"item.Parent should be null or empty.");
			}

		
			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						object value;

						throw new NotNullOrWhiteSpaceException(nameof(value));
					},
					"value should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						object value = null;

						throw new NotNullOrWhiteSpaceException(() => value);
					},
					"value should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						TestItem item = null;

						throw new NotNullOrWhiteSpaceException(() => item.Parent);
					},
					"item.Parent should be null or white space.");
			}

		
			[TestMethod]
			public void Test_NullOrEmptyException_WithNameOf()
			{
				AssertHelper.ThrowsException<NullOrEmptyException>(
					() =>
					{
						object value;

						throw new NullOrEmptyException(nameof(value));
					},
					"value is null or empty.");
			}

			[TestMethod]
			public void Test_NullOrEmptyException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NullOrEmptyException>(
					() =>
					{
						object value = null;

						throw new NullOrEmptyException(() => value);
					},
					"value is null or empty.");
			}

			[TestMethod]
			public void Test_NullOrEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NullOrEmptyException>(
					() =>
					{
						TestItem item = null;

						throw new NullOrEmptyException(() => item.Parent);
					},
					"item.Parent is null or empty.");
			}

		
			[TestMethod]
			public void Test_NullOrWhiteSpaceException_WithNameOf()
			{
				AssertHelper.ThrowsException<NullOrWhiteSpaceException>(
					() =>
					{
						object value;

						throw new NullOrWhiteSpaceException(nameof(value));
					},
					"value is null or white space.");
			}

			[TestMethod]
			public void Test_NullOrWhiteSpaceException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NullOrWhiteSpaceException>(
					() =>
					{
						object value = null;

						throw new NullOrWhiteSpaceException(() => value);
					},
					"value is null or white space.");
			}

			[TestMethod]
			public void Test_NullOrWhiteSpaceException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NullOrWhiteSpaceException>(
					() =>
					{
						TestItem item = null;

						throw new NullOrWhiteSpaceException(() => item.Parent);
					},
					"item.Parent is null or white space.");
			}

		
			[TestMethod]
			public void Test_ZeroException_WithNameOf()
			{
				AssertHelper.ThrowsException<ZeroException>(
					() =>
					{
						object value;

						throw new ZeroException(nameof(value));
					},
					"value is 0.");
			}

			[TestMethod]
			public void Test_ZeroException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<ZeroException>(
					() =>
					{
						object value = null;

						throw new ZeroException(() => value);
					},
					"value is 0.");
			}

			[TestMethod]
			public void Test_ZeroException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<ZeroException>(
					() =>
					{
						TestItem item = null;

						throw new ZeroException(() => item.Parent);
					},
					"item.Parent is 0.");
			}

		
	}
}