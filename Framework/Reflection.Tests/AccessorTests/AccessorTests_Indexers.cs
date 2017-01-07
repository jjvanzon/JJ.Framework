using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    [TestClass]
    public class AccessorTests_Indexers
    {
        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Int()
        {
            var obj = new Class();
            var accessor = new ClassAccessor_UsingStrings(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_String()
        {
            var obj = new Class();
            var accessor = new ClassAccessor_UsingStrings(obj);
            accessor["A"] = "1";
            accessor["B"] = "2";
            AssertHelper.AreEqual("1", () => accessor["A"]);
            AssertHelper.AreEqual("2", () => accessor["B"]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_InBaseClass()
        {
            var obj = new DerivedClass();
            var accessor = new ClassAccessor_UsingStrings(obj, typeof(Class));
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Named()
        {
            var obj = new ClassWithNamedIndexer();
            var accessor = new ClassWithNamedIndexerAccessor(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }
    }
}
