using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable UnusedVariable
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class StringExtensions_Split_Tests
    {
        [TestMethod]
        public void Test_StringExtensions_SplitWithQuotation()
        {
            string input = "1234,'1234','12,34','12''34',1'23'4,'12'34','12'34','',";
            
            IList<string> split = input.SplitWithQuotation(",", '\'');

            AssertHelper.IsNotNull(() => split);
            AssertHelper.AreEqual(8, () => split.Count);
            AssertHelper.AreEqual("1234", () => split[0]);
            AssertHelper.AreEqual("1234", () => split[1]);
            AssertHelper.AreEqual("12,34", () => split[2]);
            AssertHelper.AreEqual("12'34", () => split[3]);
            AssertHelper.AreEqual("1234", () => split[4]);
            AssertHelper.AreEqual("1234,1234", () => split[5]);
            AssertHelper.AreEqual("", () => split[6]);
            AssertHelper.AreEqual("", () => split[7]);
        }
    }
}
