using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Demos.GetNames.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Test_Demo_NameTranslator_SingleName()
        {
            string expected = "ItemA";
            string actual = ExpressionHelper.GetName<Item>(x => x.ItemA);

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void Test_Demo_NameTranslator_QualifiedName()
        {
            string expected = "ItemA.ItemB";
            string actual = ExpressionHelper.GetName<Item>(x => x.ItemA.ItemB);

            Assert.AreEqual(expected, actual, "");
        }

        [TestMethod]
        public void Test_Demo_NameTranslator_WithIndexer()
        {
            string expected = "ItemA.List[0].ItemB";
            string actual = ExpressionHelper.GetName<Item>(x => x.ItemA.List[0].ItemB);

            Assert.AreEqual(expected, actual, "");
        }
    }
}
