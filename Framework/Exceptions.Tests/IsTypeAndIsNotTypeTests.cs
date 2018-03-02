using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly
// ReSharper disable RedundantAssignment
// ReSharper disable ConvertToConstant.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class IsTypeAndIsNotTypeTests
	{
		[TestMethod]
		public void Test_IsNotTypeException_WithExpression_AndType()
		{
			AssertHelper.ThrowsException<IsNotTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsNotTypeException(() => testInt, typeof(TestItem));
				},
				"Int32 testInt is not of type TestItem.");
		}

		[TestMethod]
		public void Test_IsNotTypeException_WithExpression_AndTypeName()
		{
			AssertHelper.ThrowsException<IsNotTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsNotTypeException(() => testInt, "TestItem");
				},
				"Int32 testInt is not of type TestItem.");
		}

		[TestMethod]
		public void Test_IsNotTypeException_WithNameOf_AndType()
		{
			AssertHelper.ThrowsException<IsNotTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsNotTypeException(nameof(testInt), typeof(TestItem));
				},
				"testInt is not of type TestItem.");
		}

		[TestMethod]
		public void Test_IsNotTypeException_WithNameOf_AndTypeName()
		{
			AssertHelper.ThrowsException<IsNotTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsNotTypeException(nameof(testInt), "TestItem");
				},
				"testInt is not of type TestItem.");
		}

		[TestMethod]
		public void Test_IsNotTypeExceptionOfT()
		{
			AssertHelper.ThrowsException<IsNotTypeException<TestItem>>(
				() =>
				{
					int testInt = 1;

					throw new IsNotTypeException<TestItem>(() => testInt);
				},
				"Int32 testInt is not of type TestItem.");
		}

		[TestMethod]
		public void Test_IsTypeException_WithExpression_AndType()
		{
			AssertHelper.ThrowsException<IsTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsTypeException(() => testInt, typeof(TestItem));
				},
				"testInt cannot be of type TestItem.");
		}

		[TestMethod]
		public void Test_IsTypeException_WithExpression_AndTypeName()
		{
			AssertHelper.ThrowsException<IsTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsTypeException(() => testInt, "TestItem");
				},
				"testInt cannot be of type TestItem.");
		}

		[TestMethod]
		public void Test_IsTypeException_WithNameOf_AndType()
		{
			AssertHelper.ThrowsException<IsTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsTypeException(nameof(testInt), typeof(TestItem));
				},
				"testInt cannot be of type TestItem.");
		}

		[TestMethod]
		public void Test_IsTypeException_WithNameOf_TypeName()
		{
			AssertHelper.ThrowsException<IsTypeException>(
				() =>
				{
					int testInt = 1;

					throw new IsTypeException(nameof(testInt), "TestItem");
				},
				"testInt cannot be of type TestItem.");
		}

		[TestMethod]
		public void Test_IsTypeExceptionOfT()
		{
			AssertHelper.ThrowsException<IsTypeException<TestItem>>(
				() =>
				{
					int testInt = 1;

					throw new IsTypeException<TestItem>(() => testInt);
				},
				"testInt cannot be of type TestItem.");
		}
	}
}
