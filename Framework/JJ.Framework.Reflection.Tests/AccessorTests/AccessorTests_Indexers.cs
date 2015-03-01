using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    [TestClass]
    public class AccessorTests_Indexers
    {
        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Int()
        {
            var obj = new MyClass();
            var accessor = new MyClassAccessor_UsingStrings(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_String()
        {
            var obj = new MyClass();
            var accessor = new MyClassAccessor_UsingStrings(obj);
            accessor["A"] = "1";
            accessor["B"] = "2";
            AssertHelper.AreEqual("1", () => accessor["A"]);
            AssertHelper.AreEqual("2", () => accessor["B"]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new MyClassAccessor_UsingStrings(obj, typeof(MyClass));
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Named()
        {
            var obj = new MyClassWithNamedIndexer();
            var accessor = new MyClassWithNamedIndexerAccessor(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }
    }
}
