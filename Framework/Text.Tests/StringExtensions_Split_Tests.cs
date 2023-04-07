using System.Collections.Generic;
// ReSharper disable UnusedVariable

namespace JJ.Framework.Text.Tests
{
    public class StringExtensions_Split_Tests
    {
        [Fact]
        public void Test_StringExtensions_SplitWithQuotation()
        {
            string input = @"1234,""1234"",""12,34"",""12""""34"",1""23""4,""12""34"",""12""34""";
            IList<string> split2 = input.SplitWithQuotation(",", '"');
        }
    }
}
