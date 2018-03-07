

using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class BasicExceptionTests
	{
		private static readonly TestItem _testItem = new TestItem { Parent = new TestItem() };

		
			[TestMethod]
			public void Test_NullException_WithNameOf()
			{
				AssertHelper.ThrowsException<NullException>(
					() =>
					{
						object value;

						throw new NullException(nameof(value));
					},
					"value is null.");
			}

			[TestMethod]
			public void Test_NullException_WithExpression_WithSinglePart()
			{
				AssertHelper.ThrowsException<NullException>(
					() =>
					{
						object value = 1;

						throw new NullException(() => value);
					},
					"value of 1 is null.");
			}

			[TestMethod]
			public void Test_NullException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NullException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NullException(() => testItem.Parent);
					},
					"testItem.Parent is null.");
			}

			[TestMethod]
			public void Test_NullException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NullException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NullException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is null.");
			}

		
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
						object value = 1;

						throw new CollectionEmptyException(() => value);
					},
					"value of 1 collection is empty.");
			}

			[TestMethod]
			public void Test_CollectionEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<CollectionEmptyException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new CollectionEmptyException(() => testItem.Parent);
					},
					"testItem.Parent collection is empty.");
			}

			[TestMethod]
			public void Test_CollectionEmptyException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<CollectionEmptyException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new CollectionEmptyException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } collection is empty.");
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
						object value = 1;

						throw new CollectionNotEmptyException(() => value);
					},
					"value of 1 collection should be empty.");
			}

			[TestMethod]
			public void Test_CollectionNotEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<CollectionNotEmptyException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new CollectionNotEmptyException(() => testItem.Parent);
					},
					"testItem.Parent collection should be empty.");
			}

			[TestMethod]
			public void Test_CollectionNotEmptyException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<CollectionNotEmptyException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new CollectionNotEmptyException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } collection should be empty.");
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
						object value = 1;

						throw new HasNullsException(() => value);
					},
					"value of 1 contains nulls.");
			}

			[TestMethod]
			public void Test_HasNullsException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<HasNullsException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new HasNullsException(() => testItem.Parent);
					},
					"testItem.Parent contains nulls.");
			}

			[TestMethod]
			public void Test_HasNullsException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<HasNullsException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new HasNullsException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } contains nulls.");
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
						object value = 1;

						throw new HasValueException(() => value);
					},
					"value of 1 should not have a value.");
			}

			[TestMethod]
			public void Test_HasValueException_WithExpression_WithMultipleParts()
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
			public void Test_HasValueException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<HasValueException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new HasValueException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should not have a value.");
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
						object value = 1;

						throw new InfinityException(() => value);
					},
					"value of 1 is Infinity.");
			}

			[TestMethod]
			public void Test_InfinityException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<InfinityException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new InfinityException(() => testItem.Parent);
					},
					"testItem.Parent is Infinity.");
			}

			[TestMethod]
			public void Test_InfinityException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<InfinityException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new InfinityException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is Infinity.");
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
						object value = 1;

						throw new InvalidReferenceException(() => value);
					},
					"value of 1 not found in list.");
			}

			[TestMethod]
			public void Test_InvalidReferenceException_WithExpression_WithMultipleParts()
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
			public void Test_InvalidReferenceException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<InvalidReferenceException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new InvalidReferenceException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } not found in list.");
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
						object value = 1;

						throw new IsDateTimeException(() => value);
					},
					"value of 1 should not be a DateTime.");
			}

			[TestMethod]
			public void Test_IsDateTimeException_WithExpression_WithMultipleParts()
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
			public void Test_IsDateTimeException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<IsDateTimeException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new IsDateTimeException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should not be a DateTime.");
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
						object value = 1;

						throw new IsDecimalException(() => value);
					},
					"value of 1 should not be a Decimal.");
			}

			[TestMethod]
			public void Test_IsDecimalException_WithExpression_WithMultipleParts()
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
			public void Test_IsDecimalException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<IsDecimalException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new IsDecimalException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should not be a Decimal.");
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
						object value = 1;

						throw new IsDoubleException(() => value);
					},
					"value of 1 should not be a double precision floating point number.");
			}

			[TestMethod]
			public void Test_IsDoubleException_WithExpression_WithMultipleParts()
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
			public void Test_IsDoubleException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<IsDoubleException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new IsDoubleException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should not be a double precision floating point number.");
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
						object value = 1;

						throw new IsIntegerException(() => value);
					},
					"value of 1 should not be an integer number.");
			}

			[TestMethod]
			public void Test_IsIntegerException_WithExpression_WithMultipleParts()
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
			public void Test_IsIntegerException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<IsIntegerException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new IsIntegerException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should not be an integer number.");
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
						object value = 1;

						throw new NaNException(() => value);
					},
					"value of 1 is NaN.");
			}

			[TestMethod]
			public void Test_NaNException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NaNException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NaNException(() => testItem.Parent);
					},
					"testItem.Parent is NaN.");
			}

			[TestMethod]
			public void Test_NaNException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NaNException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NaNException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is NaN.");
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
						object value = 1;

						throw new NotDateTimeException(() => value);
					},
					"value of 1 is not a DateTime.");
			}

			[TestMethod]
			public void Test_NotDateTimeException_WithExpression_WithMultipleParts()
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
			public void Test_NotDateTimeException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotDateTimeException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotDateTimeException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is not a DateTime.");
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
						object value = 1;

						throw new NotDecimalException(() => value);
					},
					"value of 1 is not a Decimal.");
			}

			[TestMethod]
			public void Test_NotDecimalException_WithExpression_WithMultipleParts()
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
			public void Test_NotDecimalException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotDecimalException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotDecimalException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is not a Decimal.");
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
						object value = 1;

						throw new NotDoubleException(() => value);
					},
					"value of 1 is not a double precision floating point number.");
			}

			[TestMethod]
			public void Test_NotDoubleException_WithExpression_WithMultipleParts()
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
			public void Test_NotDoubleException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotDoubleException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotDoubleException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is not a double precision floating point number.");
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
						object value = 1;

						throw new NotHasValueException(() => value);
					},
					"value of 1 has no value.");
			}

			[TestMethod]
			public void Test_NotHasValueException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotHasValueException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NotHasValueException(() => testItem.Parent);
					},
					"testItem.Parent has no value.");
			}

			[TestMethod]
			public void Test_NotHasValueException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotHasValueException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotHasValueException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } has no value.");
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
						object value = 1;

						throw new NotInfinityException(() => value);
					},
					"value of 1 should be Infinity.");
			}

			[TestMethod]
			public void Test_NotInfinityException_WithExpression_WithMultipleParts()
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
			public void Test_NotInfinityException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotInfinityException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotInfinityException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should be Infinity.");
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
						object value = 1;

						throw new NotIntegerException(() => value);
					},
					"value of 1 is not an integer number.");
			}

			[TestMethod]
			public void Test_NotIntegerException_WithExpression_WithMultipleParts()
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
			public void Test_NotIntegerException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotIntegerException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotIntegerException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is not an integer number.");
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
						object value = 1;

						throw new NotNaNException(() => value);
					},
					"value of 1 should be NaN.");
			}

			[TestMethod]
			public void Test_NotNaNException_WithExpression_WithMultipleParts()
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
			public void Test_NotNaNException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotNaNException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotNaNException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should be NaN.");
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
						object value = 1;

						throw new NotNullException(() => value);
					},
					"value of 1 should be null.");
			}

			[TestMethod]
			public void Test_NotNullException_WithExpression_WithMultipleParts()
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
			public void Test_NotNullException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotNullException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotNullException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should be null.");
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
						object value = 1;

						throw new NotNullOrEmptyException(() => value);
					},
					"value of 1 should be null or empty.");
			}

			[TestMethod]
			public void Test_NotNullOrEmptyException_WithExpression_WithMultipleParts()
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
			public void Test_NotNullOrEmptyException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotNullOrEmptyException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotNullOrEmptyException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should be null or empty.");
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
						object value = 1;

						throw new NotNullOrWhiteSpaceException(() => value);
					},
					"value of 1 should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NotNullOrWhiteSpaceException(() => testItem.Parent);
					},
					"testItem.Parent should be null or white space.");
			}

			[TestMethod]
			public void Test_NotNullOrWhiteSpaceException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NotNullOrWhiteSpaceException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NotNullOrWhiteSpaceException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } should be null or white space.");
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
						object value = 1;

						throw new NullOrEmptyException(() => value);
					},
					"value of 1 is null or empty.");
			}

			[TestMethod]
			public void Test_NullOrEmptyException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NullOrEmptyException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NullOrEmptyException(() => testItem.Parent);
					},
					"testItem.Parent is null or empty.");
			}

			[TestMethod]
			public void Test_NullOrEmptyException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NullOrEmptyException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NullOrEmptyException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is null or empty.");
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
						object value = 1;

						throw new NullOrWhiteSpaceException(() => value);
					},
					"value of 1 is null or white space.");
			}

			[TestMethod]
			public void Test_NullOrWhiteSpaceException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<NullOrWhiteSpaceException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new NullOrWhiteSpaceException(() => testItem.Parent);
					},
					"testItem.Parent is null or white space.");
			}

			[TestMethod]
			public void Test_NullOrWhiteSpaceException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<NullOrWhiteSpaceException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new NullOrWhiteSpaceException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is null or white space.");
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
						object value = 1;

						throw new ZeroException(() => value);
					},
					"value of 1 is 0.");
			}

			[TestMethod]
			public void Test_ZeroException_WithExpression_WithMultipleParts()
			{
				AssertHelper.ThrowsException<ZeroException>(
					() => 
					{
						TestItem testItem = _testItem;

						throw new ZeroException(() => testItem.Parent);
					},
					"testItem.Parent is 0.");
			}

			[TestMethod]
			public void Test_ZeroException_WithAnonymousType()
			{
				AssertHelper.ThrowsException<ZeroException>(
					() =>
					{
						int customerNumber = 1234;
						TestEnum customerType = TestEnum.Subscriber;

						throw new ZeroException(new { customerNumber, customerType });
					},
					"{ customerNumber = 1234, customerType = Subscriber } is 0.");
			}

		
	}
}