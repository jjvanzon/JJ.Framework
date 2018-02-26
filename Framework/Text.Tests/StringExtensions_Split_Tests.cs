using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Text.Tests
{
	[TestClass]
	public class StringExtensions_Split_Tests
	{
		[TestMethod]
		public void Test_StringExtensions_SplitWithQuotation()
		{
			string input = @"1234,""1234"",""12,34"",""12""""34"",1""23""4,""12""34"",""12""34""";
			IList<string> split2 = input.SplitWithQuotation(",", '"');
		}
	}
}
