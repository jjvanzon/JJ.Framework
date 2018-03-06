

using JJ.Framework.Exceptions.Comparative;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class ComparativeExceptionTests
	{
		
			[TestMethod]
			public void Test_LessThanException_NoExpressions()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						double value;

						throw new LessThanException(nameof(value), 0);
					},
					"value is less than 0.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						var item = new TestItem();

						throw new LessThanException(() => item.Parent, 0);
					},
					"item.Parent is less than 0.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanException(() => valueA, valueB);
					},
					"valueA of -1 is less than 0.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						var item = new TestItem();

						throw new LessThanException(0, () => item.Parent);
					},
					"0 is less than item.Parent.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanException(valueA, () => valueB);
					},
					"-1 is less than valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new LessThanException(() => item1.Parent, () => item2);
					},
					"item1.Parent is less than item2.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanException(() => valueA, () => valueB);
					},
					"valueA of -1 is less than valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new LessThanException(() => value, () => testItem);
					},
					"value of -1 is less than testItem.");
			}

			[TestMethod]
			public void Test_LessThanException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new LessThanException(() => testItem, () => value);
					},
					"testItem is less than value of 0.");
			}
		
			[TestMethod]
			public void Test_GreaterThanException_NoExpressions()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double value;

						throw new GreaterThanException(nameof(value), 0);
					},
					"value is greater than 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						var item = new TestItem();

						throw new GreaterThanException(() => item.Parent, 0);
					},
					"item.Parent is greater than 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(() => valueA, valueB);
					},
					"valueA of -1 is greater than 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						var item = new TestItem();

						throw new GreaterThanException(0, () => item.Parent);
					},
					"0 is greater than item.Parent.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(valueA, () => valueB);
					},
					"-1 is greater than valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new GreaterThanException(() => item1.Parent, () => item2);
					},
					"item1.Parent is greater than item2.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(() => valueA, () => valueB);
					},
					"valueA of -1 is greater than valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new GreaterThanException(() => value, () => testItem);
					},
					"value of -1 is greater than testItem.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new GreaterThanException(() => testItem, () => value);
					},
					"testItem is greater than value of 0.");
			}
		
			[TestMethod]
			public void Test_LessThanOrEqualException_NoExpressions()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double value;

						throw new LessThanOrEqualException(nameof(value), 0);
					},
					"value is less than or equal to 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new LessThanOrEqualException(() => item.Parent, 0);
					},
					"item.Parent is less than or equal to 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(() => valueA, valueB);
					},
					"valueA of -1 is less than or equal to 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new LessThanOrEqualException(0, () => item.Parent);
					},
					"0 is less than or equal to item.Parent.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(valueA, () => valueB);
					},
					"-1 is less than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new LessThanOrEqualException(() => item1.Parent, () => item2);
					},
					"item1.Parent is less than or equal to item2.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(() => valueA, () => valueB);
					},
					"valueA of -1 is less than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new LessThanOrEqualException(() => value, () => testItem);
					},
					"value of -1 is less than or equal to testItem.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new LessThanOrEqualException(() => testItem, () => value);
					},
					"testItem is less than or equal to value of 0.");
			}
		
			[TestMethod]
			public void Test_GreaterThanOrEqualException_NoExpressions()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double value;

						throw new GreaterThanOrEqualException(nameof(value), 0);
					},
					"value is greater than or equal to 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new GreaterThanOrEqualException(() => item.Parent, 0);
					},
					"item.Parent is greater than or equal to 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(() => valueA, valueB);
					},
					"valueA of -1 is greater than or equal to 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new GreaterThanOrEqualException(0, () => item.Parent);
					},
					"0 is greater than or equal to item.Parent.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(valueA, () => valueB);
					},
					"-1 is greater than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new GreaterThanOrEqualException(() => item1.Parent, () => item2);
					},
					"item1.Parent is greater than or equal to item2.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(() => valueA, () => valueB);
					},
					"valueA of -1 is greater than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new GreaterThanOrEqualException(() => value, () => testItem);
					},
					"value of -1 is greater than or equal to testItem.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new GreaterThanOrEqualException(() => testItem, () => value);
					},
					"testItem is greater than or equal to value of 0.");
			}
		
			[TestMethod]
			public void Test_EqualException_NoExpressions()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double value;

						throw new EqualException(nameof(value), 0);
					},
					"value is equal to 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						var item = new TestItem();

						throw new EqualException(() => item.Parent, 0);
					},
					"item.Parent is equal to 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(() => valueA, valueB);
					},
					"valueA of -1 is equal to 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						var item = new TestItem();

						throw new EqualException(0, () => item.Parent);
					},
					"0 is equal to item.Parent.");
			}

			[TestMethod]
			public void Test_EqualException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(valueA, () => valueB);
					},
					"-1 is equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new EqualException(() => item1.Parent, () => item2);
					},
					"item1.Parent is equal to item2.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(() => valueA, () => valueB);
					},
					"valueA of -1 is equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new EqualException(() => value, () => testItem);
					},
					"value of -1 is equal to testItem.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new EqualException(() => testItem, () => value);
					},
					"testItem is equal to value of 0.");
			}
		
			[TestMethod]
			public void Test_NotEqualException_NoExpressions()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double value;

						throw new NotEqualException(nameof(value), 0);
					},
					"value does not equal 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new NotEqualException(() => item.Parent, 0);
					},
					"item.Parent does not equal 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(() => valueA, valueB);
					},
					"valueA of -1 does not equal 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						var item = new TestItem();

						throw new NotEqualException(0, () => item.Parent);
					},
					"0 does not equal item.Parent.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(valueA, () => valueB);
					},
					"-1 does not equal valueB of 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new NotEqualException(() => item1.Parent, () => item2);
					},
					"item1.Parent does not equal item2.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(() => valueA, () => valueB);
					},
					"valueA of -1 does not equal valueB of 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new NotEqualException(() => value, () => testItem);
					},
					"value of -1 does not equal testItem.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new NotEqualException(() => testItem, () => value);
					},
					"testItem does not equal value of 0.");
			}
		
			[TestMethod]
			public void Test_ContainsException_NoExpressions()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double value;

						throw new ContainsException(nameof(value), 0);
					},
					"value should not contain 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						var item = new TestItem();

						throw new ContainsException(() => item.Parent, 0);
					},
					"item.Parent should not contain 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(() => valueA, valueB);
					},
					"valueA of -1 should not contain 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						var item = new TestItem();

						throw new ContainsException(0, () => item.Parent);
					},
					"0 should not contain item.Parent.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(valueA, () => valueB);
					},
					"-1 should not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new ContainsException(() => item1.Parent, () => item2);
					},
					"item1.Parent should not contain item2.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(() => valueA, () => valueB);
					},
					"valueA of -1 should not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new ContainsException(() => value, () => testItem);
					},
					"value of -1 should not contain testItem.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new ContainsException(() => testItem, () => value);
					},
					"testItem should not contain value of 0.");
			}
		
			[TestMethod]
			public void Test_NotContainsException_NoExpressions()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double value;

						throw new NotContainsException(nameof(value), 0);
					},
					"value does not contain 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsValue()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						var item = new TestItem();

						throw new NotContainsException(() => item.Parent, 0);
					},
					"item.Parent does not contain 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsValue_ShowValueA()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(() => valueA, valueB);
					},
					"valueA of -1 does not contain 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsValue_BIsExpression()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						var item = new TestItem();

						throw new NotContainsException(0, () => item.Parent);
					},
					"0 does not contain item.Parent.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsValue_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(valueA, () => valueB);
					},
					"-1 does not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						var item1 = new TestItem();
						var item2 = new TestItem();

						throw new NotContainsException(() => item1.Parent, () => item2);
					},
					"item1.Parent does not contain item2.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(() => valueA, () => valueB);
					},
					"valueA of -1 does not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double value = -1;
						var testItem = new TestItem();

						throw new NotContainsException(() => value, () => testItem);
					},
					"value of -1 does not contain testItem.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						var testItem = new TestItem();
						double value = 0;

						throw new NotContainsException(() => testItem, () => value);
					},
					"testItem does not contain value of 0.");
			}
		
	}
}