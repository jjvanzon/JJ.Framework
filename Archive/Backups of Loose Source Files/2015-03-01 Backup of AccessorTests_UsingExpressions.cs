using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    [TestClass]
    public class AccessorTests_UsingExpressions
    {
        [TestMethod]
        public void Test_Accessor_UsingExpressions_Field()
        {
            var obj = new MyClass();
            var accessor = new MyClassAccessor_UsingExpressions(obj);

            accessor.Field = 1;
            Assert.AreEqual(1, accessor.Field);

            accessor.Field = 2;
            Assert.AreEqual(2, accessor.Field);
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Field_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new MyDerivedClassAccessor_UsingExpressions(obj);

            accessor.Field = 1;
            Assert.AreEqual(1, accessor.Field);

            accessor.Field = 2;
            Assert.AreEqual(2, accessor.Field);
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Property()
        {
            var obj = new MyClass();
            var accessor = new MyClassAccessor_UsingExpressions(obj);

            accessor.Property = 1;
            Assert.AreEqual(1, accessor.Property);

            accessor.Property = 2;
            Assert.AreEqual(2, accessor.Property);
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Property_InBaseClass()
        {
            var obj = new MyDerivedClass();
            var accessor = new MyDerivedClassAccessor_UsingExpressions(obj);

            accessor.Property = 1;
            Assert.AreEqual(1, accessor.Property);

            accessor.Property = 2;
            Assert.AreEqual(2, accessor.Property);
        }

        // TODO: Finish other tests using MyClassAccessor_UsingExpressions.

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Method()
        //{
        //    var obj = new MyClass();
        //    var accessor = new Accessor(obj);
        //    Assert.AreEqual(1, () => (int)accessor.InvokeMethod("Method", 1));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Method_InBaseClass()
        //{
        //    var obj = new MyDerivedClass();
        //    var accessor = new Accessor(obj, typeof(MyClass));
        //    Assert.AreEqual(1, () => (int)accessor.InvokeMethod("Method", 1));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Indexer_Int()
        //{
        //    var obj = new MyClass();
        //    var accessor = new Accessor(obj);
        //    accessor.SetIndexerValue(1, 1);
        //    accessor.SetIndexerValue(2, 2);
        //    Assert.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
        //    Assert.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Indexer_String()
        //{
        //    var obj = new MyClass();
        //    var accessor = new Accessor(obj);
        //    accessor.SetIndexerValue("A", "1");
        //    accessor.SetIndexerValue("B", "2");
        //    Assert.AreEqual("1", () => (string)accessor.GetIndexerValue("A"));
        //    Assert.AreEqual("2", () => (string)accessor.GetIndexerValue("B"));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Indexer_Named()
        //{
        //    var obj = new MyClassWithNamedIndexer();
        //    var accessor = new Accessor(obj);
        //    accessor.SetIndexerValue(1, 1);
        //    accessor.SetIndexerValue(2, 2);
        //    Assert.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
        //    Assert.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_Indexer_InBaseClass()
        //{
        //    var obj = new MyDerivedClass();
        //    var accessor = new Accessor(obj, typeof(MyClass));
        //    accessor.SetIndexerValue(1, 1);
        //    accessor.SetIndexerValue(2, 2);
        //    Assert.AreEqual(1, () => (int)accessor.GetIndexerValue(1));
        //    Assert.AreEqual(2, () => (int)accessor.GetIndexerValue(2));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_StaticField()
        //{
        //    var accessor = new Accessor(typeof(MyClass));

        //    accessor.SetFieldValue("StaticField", 1);
        //    Assert.AreEqual(1, () => (int)accessor.GetFieldValue("StaticField"));

        //    accessor.SetFieldValue("StaticField", 2);
        //    Assert.AreEqual(2, () => (int)accessor.GetFieldValue("StaticField"));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_StaticProperty()
        //{
        //    var accessor = new Accessor(typeof(MyClass));

        //    accessor.SetPropertyValue("StaticProperty", 1);
        //    Assert.AreEqual(1, () => (int)accessor.GetPropertyValue("StaticProperty"));

        //    accessor.SetPropertyValue("StaticProperty", 2);
        //    Assert.AreEqual(2, () => (int)accessor.GetPropertyValue("StaticProperty"));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_StaticMethod()
        //{
        //    var accessor = new Accessor(typeof(MyClass));
        //    Assert.AreEqual(1, () => (int)accessor.InvokeMethod("StaticMethod", 1));
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_ParamsNull()
        //{
        //    var obj = new MyClass();
        //    var accessor = new Accessor(obj);
        //    Assert.ThrowsException(() => accessor.GetIndexerValue(null), "parameters cannot be null.");
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_HiddenMember()
        //{
        //    var obj = new MyDerivedClass();
        //    var accessor = new Accessor(obj);
        //    accessor.SetPropertyValue("MemberToHide", 1);
        //}

        //[TestMethod]
        //public void Test_Accessor_UsingExpressions_BaseMember()
        //{
        //    var obj = new MyDerivedClass();
        //    var accessor = new Accessor(obj, typeof(MyClass));
        //    accessor.SetPropertyValue("MemberToHide", 1);
        //}
    }
}
