using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
	[TestClass]
	public class StringExtensionsTests
	{
		[TestMethod]
		public void Test_StringExtensions_CutRightUntil()
		{
			string input = "abcdefg";
			string output = input.TrimEndUntil("de");
			Assert.AreEqual("abcde", output);
		}

		[TestMethod]
		public void Test_StringExtensions_CutLeftUntil()
		{
			string input = "abcdefg";
			string output = input.TrimStartUntil("de");
			Assert.AreEqual("defg", output);
		}

		[TestMethod]
		public void Test_StringExtensions_Left_NotEnoughCharacters_ThrowsException()
		{
			AssertHelper.ThrowsException(() => "1234".Left(5));
		}

		[TestMethod]
		public void Test_StringExtensions_Right_NotEnoughCharacters_ThrowsException()
		{
			AssertHelper.ThrowsException(() => "1234".Right(5));
		}

		[TestMethod]
		public void Test_StringExtensions_TakeLeft()
		{
			string output = "12345".TakeLeft(4);
			AssertHelper.AreEqual("1234", () => output);
		}

		[TestMethod]
		public void Test_StringExtensions_TakeLeft_NotEnoughCharacters_ReturnsLessCharacters()
		{
			string output = "1234".TakeLeft(5);
			AssertHelper.AreEqual("1234", () => output);
		}

		[TestMethod]
		public void Test_StringExtensions_TakeRight()
		{
			string output = "12345".TakeRight(4);
			AssertHelper.AreEqual("2345", () => output);
		}

		[TestMethod]
		public void Test_StringExtensions_TakeRight_NotEnoughCharacters_ReturnsLessCharacters()
		{
			string output = "1234".TakeRight(5);
			AssertHelper.AreEqual("1234", () => output);
		}
	}
}
