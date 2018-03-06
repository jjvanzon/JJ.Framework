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
	public class NotUniqueExceptionTests
	{
		[TestMethod]
		public void Test_NotUniqueException_WithExpression()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					var testItem = new TestItem();

					throw new NotUniqueException(() => testItem);
				},
				"testItem not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueException_WithExpression_AndKey()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					int testInt = 1;
					var testItem = new TestItem();

					throw new NotUniqueException(() => testItem, new { testInt });
				},
				"testItem with key { testInt = 1 } not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueException_WithType()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					int testInt = 1;

					throw new NotUniqueException(typeof(TestItem));
				},
				"TestItem not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueException_WithType_AndKey()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					int testInt = 1;

					throw new NotUniqueException(typeof(TestItem), new { testInt });
				},
				"TestItem with key { testInt = 1 } not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueException_WithNameOf()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					var testItem = new TestItem();

					throw new NotUniqueException(nameof(testItem));
				},
				"testItem not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueException_WithNameOf_AndKey()
		{
			AssertHelper.ThrowsException<NotUniqueException>(
				() =>
				{
					int testInt = 1;
					var testItem = new TestItem();

					throw new NotUniqueException(nameof(testItem), new { testInt });
				},
				"testItem with key { testInt = 1 } not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueExceptionOfT_NoKey()
		{
			AssertHelper.ThrowsException<NotUniqueException<TestItem>>(
				() => throw new NotUniqueException<TestItem>(),
				"TestItem not unique.");
		}

		[TestMethod]
		public void Test_NotUniqueExceptionOfT_WithKey()
		{
			AssertHelper.ThrowsException<NotUniqueException<TestItem>>(
				() =>
				{
					int testInt = 1;

					throw new NotUniqueException<TestItem>(new { testInt });
				},
				"TestItem with key { testInt = 1 } not unique.");
		}
	}
}