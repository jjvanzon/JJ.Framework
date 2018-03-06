using JJ.Framework.Exceptions.Aggregates;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local
// ReSharper disable LocalNameCapturedOnly
// ReSharper disable RedundantAssignment
#pragma warning disable 219

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class NotFoundExceptionTests
	{
		[TestMethod]
		public void Test_NotFoundException_WithExpression()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					var testItem = new TestItem();

					throw new NotFoundException(() => testItem);
				},
				"testItem not found.");
		}

		[TestMethod]
		public void Test_NotFoundException_WithExpression_AndKey()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					int testInt = 1;
					var testItem = new TestItem();

					throw new NotFoundException(() => testItem, new { testInt });
				},
				"testItem with key { testInt = 1 } not found.");
		}

		[TestMethod]
		public void Test_NotFoundException_WithType()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					int testInt = 1;

					throw new NotFoundException(typeof(TestItem));
				},
				"TestItem not found.");
		}

		[TestMethod]
		public void Test_NotFoundException_WithType_AndKey()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					int testInt = 1;

					throw new NotFoundException(typeof(TestItem), new { testInt });
				},
				"TestItem with key { testInt = 1 } not found.");
		}

		[TestMethod]
		public void Test_NotFoundException_WithNameOf()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					var testItem = new TestItem();

					throw new NotFoundException(nameof(testItem));
				},
				"testItem not found.");
		}

		[TestMethod]
		public void Test_NotFoundException_WithNameOf_AndKey()
		{
			AssertHelper.ThrowsException<NotFoundException>(
				() =>
				{
					int testInt = 1;
					var testItem = new TestItem();

					throw new NotFoundException(nameof(testItem), new { testInt });
				},
				"testItem with key { testInt = 1 } not found.");
		}

		[TestMethod]
		public void Test_NotFoundExceptionOfT_NoKey()
		{
			AssertHelper.ThrowsException<NotFoundException<TestItem>>(
				() => throw new NotFoundException<TestItem>(),
				"TestItem not found.");
		}

		[TestMethod]
		public void Test_NotFoundExceptionOfT_WithKey()
		{
			AssertHelper.ThrowsException<NotFoundException<TestItem>>(
				() =>
				{
					int testInt = 1;

					throw new NotFoundException<TestItem>(new { testInt });
				},
				"TestItem with key { testInt = 1 } not found.");
		}
	}
}