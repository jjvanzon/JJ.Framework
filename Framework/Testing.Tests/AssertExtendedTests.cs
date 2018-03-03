using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Testing.Tests
{
	[TestClass]
	public class AssertExtendedTests
	{
		[TestMethod]
		public void Test_ThrowsException_HasException()
		{
			AssertHelper.ThrowsException(() => throw new Exception());
		}

		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void Test_ThrowsException_WithNoException()
		{
			AssertHelper.ThrowsException(() => { });
		}
	}
}