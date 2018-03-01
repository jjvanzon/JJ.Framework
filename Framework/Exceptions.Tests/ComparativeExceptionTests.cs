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
		public void Test_ComparativeException_NoExpressions()
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
		public void Test_ComparativeException_AIsExpression_BIsValue()
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
		public void Test_ComparativeException_AIsExpression_BIsValue_ShowValueA()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					double valueA = -1;
					double valueB = 0;
					throw new LessThanException(() => valueA, valueB, showValueA: true);
				},
				"valueA of -1 is less than 0.");
		}

		[TestMethod]
		public void Test_ComparativeException_AIsValue_BIsExpression()
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
		public void Test_ComparativeException_AIsValue_BIsExpression_ShowValueB()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					double valueA = -1;
					double valueB = 0;
					throw new LessThanException(valueA, () => valueB, showValueB: true);
				},
				"-1 is less than valueB of 0.");
		}

		[TestMethod]
		public void Test_ComparativeException_AIsExpression_BIsExpression()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					var item = new TestItem();
					double value = 0;
					throw new LessThanException(() => item.Parent, () => value);
				},
				"item.Parent is less than value.");
		}

		[TestMethod]
		public void Test_ComparativeException_AIsExpression_BIsExpression_ShowValueA_ShowValueB()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					double valueA = -1;
					double valueB = 0;
					throw new LessThanException(() => valueA, () => valueB, showValueA: true, showValueB: true);
				},
				"valueA of -1 is less than valueB of 0.");
		}

		[TestMethod]
		public void Test_ComparativeException_AIsExpression_BIsExpression_ShowValueA()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					double valueA = -1;
					double valueB = 0;
					throw new LessThanException(() => valueA, () => valueB, showValueA: true);
				},
				"valueA of -1 is less than valueB.");
		}

		[TestMethod]
		public void Test_ComparativeException_AIsExpression_BIsExpression_ShowValueB()
		{
			AssertHelper.ThrowsException<LessThanException>(
				() =>
				{
					double valueA = -1;
					double valueB = 0;
					throw new LessThanException(() => valueA, () => valueB, showValueB: true);
				},
				"valueA is less than valueB of 0.");
		}
	}
}