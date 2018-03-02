

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

						throw new GreaterThanException(() => valueA, valueB, showValueA: true);
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

						throw new GreaterThanException(valueA, () => valueB, showValueB: true);
					},
					"-1 is greater than valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new GreaterThanException(() => item.Parent, () => value);
					},
					"item.Parent is greater than value.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 is greater than valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 is greater than valueB.");
			}

			[TestMethod]
			public void Test_GreaterThanException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA is greater than valueB of 0.");
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

						throw new LessThanOrEqualException(() => valueA, valueB, showValueA: true);
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

						throw new LessThanOrEqualException(valueA, () => valueB, showValueB: true);
					},
					"-1 is less than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new LessThanOrEqualException(() => item.Parent, () => value);
					},
					"item.Parent is less than or equal to value.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 is less than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 is less than or equal to valueB.");
			}

			[TestMethod]
			public void Test_LessThanOrEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<LessThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new LessThanOrEqualException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA is less than or equal to valueB of 0.");
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

						throw new GreaterThanOrEqualException(() => valueA, valueB, showValueA: true);
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

						throw new GreaterThanOrEqualException(valueA, () => valueB, showValueB: true);
					},
					"-1 is greater than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new GreaterThanOrEqualException(() => item.Parent, () => value);
					},
					"item.Parent is greater than or equal to value.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 is greater than or equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 is greater than or equal to valueB.");
			}

			[TestMethod]
			public void Test_GreaterThanOrEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<GreaterThanOrEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new GreaterThanOrEqualException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA is greater than or equal to valueB of 0.");
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

						throw new EqualException(() => valueA, valueB, showValueA: true);
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

						throw new EqualException(valueA, () => valueB, showValueB: true);
					},
					"-1 is equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new EqualException(() => item.Parent, () => value);
					},
					"item.Parent is equal to value.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 is equal to valueB of 0.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 is equal to valueB.");
			}

			[TestMethod]
			public void Test_EqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<EqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new EqualException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA is equal to valueB of 0.");
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

						throw new NotEqualException(() => valueA, valueB, showValueA: true);
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

						throw new NotEqualException(valueA, () => valueB, showValueB: true);
					},
					"-1 does not equal valueB of 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new NotEqualException(() => item.Parent, () => value);
					},
					"item.Parent does not equal value.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 does not equal valueB of 0.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 does not equal valueB.");
			}

			[TestMethod]
			public void Test_NotEqualException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotEqualException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotEqualException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA does not equal valueB of 0.");
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

						throw new ContainsException(() => valueA, valueB, showValueA: true);
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

						throw new ContainsException(valueA, () => valueB, showValueB: true);
					},
					"-1 should not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new ContainsException(() => item.Parent, () => value);
					},
					"item.Parent should not contain value.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 should not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 should not contain valueB.");
			}

			[TestMethod]
			public void Test_ContainsException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<ContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new ContainsException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA should not contain valueB of 0.");
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

						throw new NotContainsException(() => valueA, valueB, showValueA: true);
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

						throw new NotContainsException(valueA, () => valueB, showValueB: true);
					},
					"-1 does not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						var item = new TestItem();
						double value = 0;

						throw new NotContainsException(() => item.Parent, () => value);
					},
					"item.Parent does not contain value.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(() => valueA, () => valueB, showValueA: true, showValueB: true);
					},
					"valueA of -1 does not contain valueB of 0.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueA()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(() => valueA, () => valueB, showValueA: true);
					},
					"valueA of -1 does not contain valueB.");
			}

			[TestMethod]
			public void Test_NotContainsException_AIsExpression_BIsExpression_ShowValueB()
			{
				AssertHelper.ThrowsException<NotContainsException>(
					() =>
					{
						double valueA = -1;
						double valueB = 0;

						throw new NotContainsException(() => valueA, () => valueB, showValueB: true);
					},
					"valueA does not contain valueB of 0.");
			}
		
	}
}