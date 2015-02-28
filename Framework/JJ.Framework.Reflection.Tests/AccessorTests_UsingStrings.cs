using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Reflection.Tests.AccessorTestHelpers;
using JJ.Framework.Testing;

namespace JJ.Framework.Reflection.Tests
{
    // TODO: Refactor to use MyClassAccessor_UsingStrings.cs

    [TestClass]
    public class AccessorTests_UsingStrings
    {
        [TestMethod]
        public void Test_Accessor_UsingStrings_Field()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);

            accessor.SetFieldValue("Field", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetFieldValue("Field"));

            accessor.SetFieldValue("Field", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetFieldValue("Field"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Field_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj, typeof(MyClass));

            accessor.SetFieldValue("Field", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetFieldValue("Field"));

            accessor.SetFieldValue("Field", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetFieldValue("Field"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);

            accessor.SetPropertyValue("Property", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetPropertyValue("Property"));

            accessor.SetPropertyValue("Property", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetPropertyValue("Property"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj, typeof(MyClass));

            accessor.SetPropertyValue("Property", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetPropertyValue("Property"));

            accessor.SetPropertyValue("Property", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetPropertyValue("Property"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);
            AssertHelper.AreEqual(1, () => (int)accessor.InvokeMethod("IntMethodInt", 1));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj, typeof(MyClass));
            AssertHelper.AreEqual(1, () => (int)accessor.InvokeMethod("IntMethodInt", 1));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Int()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);
            accessor.SetIndexerValue(1, 1);
            accessor.SetIndexerValue(2, 2);
            AssertHelper.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
            AssertHelper.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_String()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);
            accessor.SetIndexerValue("A", "1");
            accessor.SetIndexerValue("B", "2");
            AssertHelper.AreEqual("1", () => (string)accessor.GetIndexerValue("A"));
            AssertHelper.AreEqual("2", () => (string)accessor.GetIndexerValue("B"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_Named()
        {
            var obj = new MyClassWithNamedIndexer();
            var accessor = new Accessor(obj);
            accessor.SetIndexerValue(1, 1);
            accessor.SetIndexerValue(2, 2);
            AssertHelper.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
            AssertHelper.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Indexer_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj, typeof(MyClass));
            accessor.SetIndexerValue(1, 1);
            accessor.SetIndexerValue(2, 2);
            AssertHelper.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
            AssertHelper.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticField()
        {
            var accessor = new Accessor(typeof(MyClass));

            accessor.SetFieldValue("StaticField", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetFieldValue("StaticField"));

            accessor.SetFieldValue("StaticField", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetFieldValue("StaticField"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticProperty()
        {
            var accessor = new Accessor(typeof(MyClass));

            accessor.SetPropertyValue("StaticProperty", 1);
            AssertHelper.AreEqual(1, () => (int)accessor.GetPropertyValue("StaticProperty"));

            accessor.SetPropertyValue("StaticProperty", 2);
            AssertHelper.AreEqual(2, () => (int)accessor.GetPropertyValue("StaticProperty"));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticMethod()
        {
            var accessor = new Accessor(typeof(MyClass));
            AssertHelper.AreEqual(1, () => (int)accessor.InvokeMethod("StaticMethod", 1));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_ParamsNull()
        {
            var obj = new MyClass();
            var accessor = new Accessor(obj);
            AssertHelper.ThrowsException(() => accessor.GetIndexerValue(null), "parameters cannot be null.");
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_HiddenMember()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj);
            accessor.SetPropertyValue("MemberToHide", 1);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_BaseMember()
        {
            var obj = new MyDerivedClass();
            var accessor = new Accessor(obj, typeof(MyClass));
            accessor.SetPropertyValue("MemberToHide", 1);
        }
    }
}
