//// NOTE: This code file is used as a base for the code generated in SimpleExceptionTests.

//using JJ.Framework.Testing;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//// ReSharper disable LocalNameCapturedOnly

//namespace JJ.Framework.Exceptions.Tests
//{
//	[TestClass]
//	public class NullExceptionTests
//	{
//		[TestMethod]
//		public void Test_NullException_WithNameOf()
//		{
//			AssertHelper.ThrowsException<NullException>(
//				() =>
//				{
//					object value;

//					throw new NullException(nameof(value));
//				},
//				"value is null.");
//		}

//		[TestMethod]
//		public void Test_NullException_WithExpression_WithSinglePart()
//		{
//			AssertHelper.ThrowsException<NullException>(
//				() =>
//				{
//					object value = null;

//					throw new NullException(() => value);
//				},
//				"value is null.");
//		}

//		[TestMethod]
//		public void Test_NullException_WithExpression_WithMultipleParts()
//		{
//			AssertHelper.ThrowsException<NullException>(
//				() =>
//				{
//					TestItem item = null;

//					throw new NullException(() => item.Parent);
//				},
//				"item.Parent is null.");
//		}
//	}
//}