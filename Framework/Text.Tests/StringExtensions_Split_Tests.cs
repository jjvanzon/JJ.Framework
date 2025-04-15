using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static JJ.Framework.Testing.AssertHelper;

// ReSharper disable UnusedVariable

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
        
        [TestMethod]
        public void SplitWithQuotation_ComplexExample()
        {
            string input = 
            """
            1234,"1234","12,34","12""34",1"23"4,"12"34","12"34"
            """;
            
            IList<string> split = input.SplitWithQuotation(",", '"');
            
            IsNotNull(() => split);
            AreEqual(6, () => split.Count);
            AreEqual("1234",   () => split[0]);
            AreEqual("1234",   () => split[1]);
            AreEqual("12,34",  () => split[2]);
            AreEqual("12\"34", () => split[3]);

            // Quirk: Quotes in the middle are untouched:
            
            //AreEqual("1234", () => split[4]); // Right
            AreEqual("1\"23\"4", () => split[4]); // Wrong
            
            //AreEqual("""1234,1234""", () => split[5]); // Right?
            AreEqual("""12"34","12"34""", () => split[5]); // Wrong
        }
    }
}