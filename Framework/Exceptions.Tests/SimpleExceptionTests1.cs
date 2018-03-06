

using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class SimpleExceptionTests
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
						object value = null;

						throw new NullException(() => value);
					},
					"value is null.");
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
						TestItem testItem = _testItem;

						throw new CollectionEmptyException(() => testItem.Parent);
					},
					"testItem.Parent collection is empty.");
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
						TestItem testItem = _testItem;

						throw new CollectionNotEmptyException(() => testItem.Parent);
					},
					"testItem.Parent collection should be empty.");
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
						TestItem testItem = _testItem;

						throw new HasNullsException(() => testItem.Parent);
					},
					"testItem.Parent contains nulls.");
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
						TestItem testItem = _testItem;

						throw new InfinityException(() => testItem.Parent);
					},
					"testItem.Parent is Infinity.");
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
						TestItem testItem = _testItem;

						throw new NaNException(() => testItem.Parent);
					},
					"testItem.Parent is NaN.");
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
						TestItem testItem = _testItem;

						throw new NotHasValueException(() => testItem.Parent);
					},
					"testItem.Parent has no value.");
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
						TestItem testItem = _testItem;

						throw new NullOrEmptyException(() => testItem.Parent);
					},
					"testItem.Parent is null or empty.");
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
						TestItem testItem = _testItem;

						throw new NullOrWhiteSpaceException(() => testItem.Parent);
					},
					"testItem.Parent is null or white space.");
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
						TestItem testItem = _testItem;

						throw new ZeroException(() => testItem.Parent);
					},
					"testItem.Parent is 0.");
			}

		
	}
}