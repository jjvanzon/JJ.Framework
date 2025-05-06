using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    [TestClass]
    public class AccessorLegacyTests_Indexers
    {
        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Int()
        {
            var obj = new ClassLegacy();
            // ReSharper disable once UseObjectOrCollectionInitializer
            var accessor = new ClassAccessorLegacy_UsingStrings(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_String()
        {
            var obj = new ClassLegacy();
            // ReSharper disable once UseObjectOrCollectionInitializer
            var accessor = new ClassAccessorLegacy_UsingStrings(obj);
            accessor["A"] = "1";
            accessor["B"] = "2";
            AssertHelper.AreEqual("1", () => accessor["A"]);
            AssertHelper.AreEqual("2", () => accessor["B"]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_InBaseClass()
        {
            var obj = new DerivedClassLegacy();
            // ReSharper disable once UseObjectOrCollectionInitializer
            var accessor = new ClassAccessorLegacy_UsingStrings(obj, typeof(ClassLegacy));
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Named()
        {
            var obj = new ClassLegacy_NamedIndexer();
            // ReSharper disable once UseObjectOrCollectionInitializer
            var accessor = new ClassLegacy_NamedIndexer_Accessor(obj);
            accessor[1] = 1;
            accessor[2] = 2;
            AssertHelper.AreEqual(1, () => accessor[1]);
            AssertHelper.AreEqual(2, () => accessor[2]);
        }
    }
}
