using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Common;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class StringExtensions_Split_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_Split_Tests()
        {
            string input = @"1234,""1234"",""12,34"",""12""""34"",1""23""4,""12""34"",""12""34""";
            string[] split2 = input.SplitWithQuotation_WithoutUnescape(",", '"');
        }
    }
}
