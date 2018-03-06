

using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class ExceptionsWithNameAndValueTests
	{
		private static readonly TestItem _testItem = new TestItem { Parent = new TestItem() };

		
			[TestMethod]
			public void Test_HasValueException_WithNameOf()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						int value;

						throw new HasValueException(nameof(value));
					},
					"value should not have a value.");
			}

			[TestMethod]
			public void Test_HasValueException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						int value = 1;

						throw new HasValueException(() => value);
					},
					"value of 1 should not have a value.");
			}

			[TestMethod]
			public void Test_HasValueException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new HasValueException(() => testItem.Parent);
					},
					"testItem.Parent should not have a value.");
			}
		
			[TestMethod]
			public void Test_InvalidReferenceException_WithNameOf()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						int value;

						throw new InvalidReferenceException(nameof(value));
					},
					"value not found in list.");
			}

			[TestMethod]
			public void Test_InvalidReferenceException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						int value = 1;

						throw new InvalidReferenceException(() => value);
					},
					"value of 1 not found in list.");
			}

			[TestMethod]
			public void Test_InvalidReferenceException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new InvalidReferenceException(() => testItem.Parent);
					},
					"testItem.Parent not found in list.");
			}
		
			[TestMethod]
			public void Test_IsDateTimeException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						int value;

						throw new IsDateTimeException(nameof(value));
					},
					"value should not be a DateTime.");
			}

			[TestMethod]
			public void Test_IsDateTimeException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						int value = 1;

						throw new IsDateTimeException(() => value);
					},
					"value of 1 should not be a DateTime.");
			}

			[TestMethod]
			public void Test_IsDateTimeException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new IsDateTimeException(() => testItem.Parent);
					},
					"testItem.Parent should not be a DateTime.");
			}
		
			[TestMethod]
			public void Test_IsDecimalException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						int value;

						throw new IsDecimalException(nameof(value));
					},
					"value should not be a Decimal.");
			}

			[TestMethod]
			public void Test_IsDecimalException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						int value = 1;

						throw new IsDecimalException(() => value);
					},
					"value of 1 should not be a Decimal.");
			}

			[TestMethod]
			public void Test_IsDecimalException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new IsDecimalException(() => testItem.Parent);
					},
					"testItem.Parent should not be a Decimal.");
			}
		
			[TestMethod]
			public void Test_IsDoubleException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						int value;

						throw new IsDoubleException(nameof(value));
					},
					"value should not be a double precision floating point number.");
			}

			[TestMethod]
			public void Test_IsDoubleException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						int value = 1;

						throw new IsDoubleException(() => value);
					},
					"value of 1 should not be a double precision floating point number.");
			}

			[TestMethod]
			public void Test_IsDoubleException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new IsDoubleException(() => testItem.Parent);
					},
					"testItem.Parent should not be a double precision floating point number.");
			}
		
			[TestMethod]
			public void Test_IsIntegerException_WithNameOf()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						int value;

						throw new IsIntegerException(nameof(value));
					},
					"value should not be an integer number.");
			}

			[TestMethod]
			public void Test_IsIntegerException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						int value = 1;

						throw new IsIntegerException(() => value);
					},
					"value of 1 should not be an integer number.");
			}

			[TestMethod]
			public void Test_IsIntegerException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new IsIntegerException(() => testItem.Parent);
					},
					"testItem.Parent should not be an integer number.");
			}
		
			[TestMethod]
			public void Test_NotDateTimeException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						int value;

						throw new NotDateTimeException(nameof(value));
					},
					"value is not a DateTime.");
			}

			[TestMethod]
			public void Test_NotDateTimeException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						int value = 1;

						throw new NotDateTimeException(() => value);
					},
					"value of 1 is not a DateTime.");
			}

			[TestMethod]
			public void Test_NotDateTimeException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotDateTimeException(() => testItem.Parent);
					},
					"testItem.Parent is not a DateTime.");
			}
		
			[TestMethod]
			public void Test_NotDecimalException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						int value;

						throw new NotDecimalException(nameof(value));
					},
					"value is not a Decimal.");
			}

			[TestMethod]
			public void Test_NotDecimalException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						int value = 1;

						throw new NotDecimalException(() => value);
					},
					"value of 1 is not a Decimal.");
			}

			[TestMethod]
			public void Test_NotDecimalException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotDecimalException(() => testItem.Parent);
					},
					"testItem.Parent is not a Decimal.");
			}
		
			[TestMethod]
			public void Test_NotDoubleException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						int value;

						throw new NotDoubleException(nameof(value));
					},
					"value is not a double precision floating point number.");
			}

			[TestMethod]
			public void Test_NotDoubleException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						int value = 1;

						throw new NotDoubleException(() => value);
					},
					"value of 1 is not a double precision floating point number.");
			}

			[TestMethod]
			public void Test_NotDoubleException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotDoubleException(() => testItem.Parent);
					},
					"testItem.Parent is not a double precision floating point number.");
			}
		
			[TestMethod]
			public void Test_NotInfinityException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						int value;

						throw new NotInfinityException(nameof(value));
					},
					"value should be Infinity.");
			}

			[TestMethod]
			public void Test_NotInfinityException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						int value = 1;

						throw new NotInfinityException(() => value);
					},
					"value of 1 should be Infinity.");
			}

			[TestMethod]
			public void Test_NotInfinityException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotInfinityException(() => testItem.Parent);
					},
					"testItem.Parent should be Infinity.");
			}
		
			[TestMethod]
			public void Test_NotIntegerException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						int value;

						throw new NotIntegerException(nameof(value));
					},
					"value is not an integer number.");
			}

			[TestMethod]
			public void Test_NotIntegerException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						int value = 1;

						throw new NotIntegerException(() => value);
					},
					"value of 1 is not an integer number.");
			}

			[TestMethod]
			public void Test_NotIntegerException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotIntegerException(() => testItem.Parent);
					},
					"testItem.Parent is not an integer number.");
			}
		
			[TestMethod]
			public void Test_NotNaNException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						int value;

						throw new NotNaNException(nameof(value));
					},
					"value should be NaN.");
			}

			[TestMethod]
			public void Test_NotNaNException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						int value = 1;

						throw new NotNaNException(() => value);
					},
					"value of 1 should be NaN.");
			}

			[TestMethod]
			public void Test_NotNaNException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotNaNException(() => testItem.Parent);
					},
					"testItem.Parent should be NaN.");
			}
		
			[TestMethod]
			public void Test_NotNullException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						int value;

						throw new NotNullException(nameof(value));
					},
					"value should be null.");
			}

			[TestMethod]
			public void Test_NotNullException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						int value = 1;

						throw new NotNullException(() => value);
					},
					"value of 1 should be null.");
			}

			[TestMethod]
			public void Test_NotNullException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotNullException(() => testItem.Parent);
					},
					"testItem.Parent should be null.");
			}
		
			[TestMethod]
			public void Test_NotNullOrEmptyException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						int value;

						throw new NotNullOrEmptyException(nameof(value));
					},
					"value should be null or empty.");
			}

			[TestMethod]
			public void Test_NotNullOrEmptyException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						int value = 1;

						throw new NotNullOrEmptyException(() => value);
					},
					"value of 1 should be null or empty.");
			}

			[TestMethod]
			public void Test_NotNullOrEmptyException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotNullOrEmptyException(() => testItem.Parent);
					},
					"testItem.Parent should be null or empty.");
			}
		
			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithNameOf()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						int value;

						throw new NotNullOrWhiteSpaceException(nameof(value));
					},
					"value should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithExpression_WithValue()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						int value = 1;

						throw new NotNullOrWhiteSpaceException(() => value);
					},
					"value of 1 should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithExpression_NoValue()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						TestItem testItem = _testItem;

						throw new NotNullOrWhiteSpaceException(() => testItem.Parent);
					},
					"testItem.Parent should be null or white space.");
			}
		
	}
}