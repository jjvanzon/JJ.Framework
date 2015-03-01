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
    public class AccessorTests_UsingStrings : AccessorTestsBase
    {
        protected override IMyClassAccessor CreateMyClassAccessor(MyClass obj)
        {
            var accessor = new MyClassAccessor_UsingStrings(obj);
            return accessor;
        }

        protected override IMyDerivedClassAccessor CreateMyDerivedClassAccessor(MyDerivedClass obj)
        {
            var accessor = new MyDerivedClassAccessor_UsingStrings(obj);
            return accessor;
        }

        protected override IMyClassAccessor CreateBaseAccessor(MyDerivedClass obj)
        {
            var accessor = new MyClassAccessor_UsingStrings(obj, typeof(MyClass));
            return accessor;
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticField()
        {
            MyClassAccessor_UsingStrings.StaticField = 1;
            AssertHelper.AreEqual(1, () => MyClassAccessor_UsingStrings.StaticField);

            MyClassAccessor_UsingStrings.StaticField = 2;
            AssertHelper.AreEqual(2, () => MyClassAccessor_UsingStrings.StaticField);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticProperty()
        {
            MyClassAccessor_UsingStrings.StaticProperty = 1;
            AssertHelper.AreEqual(1, () => MyClassAccessor_UsingStrings.StaticProperty);

            MyClassAccessor_UsingStrings.StaticProperty = 2;
            AssertHelper.AreEqual(2, () => MyClassAccessor_UsingStrings.StaticProperty);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticMethod()
        {
            AssertHelper.AreEqual(1, () => MyClassAccessor_UsingStrings.StaticMethod(1));
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Field()
        {
            base.Test_Accessor_Field();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Field_InBaseClass()
        {
            base.Test_Accessor_Field_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property()
        {
            base.Test_Accessor_Property();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property_InBaseClass()
        {
            base.Test_Accessor_Property_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method()
        {
            base.Test_Accessor_Method();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method_InBaseClass()
        {
            base.Test_Accessor_Method_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_HiddenMember()
        {
            base.Test_Accessor_HiddenMember();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethod()
        {
            base.Test_Accessor_VoidMethod();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethodInt()
        {
            base.Test_Accessor_VoidMethodInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethodIntInt()
        {
            base.Test_Accessor_VoidMethodIntInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethod()
        {
            base.Test_Accessor_IntMethod();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethodInt()
        {
            base.Test_Accessor_IntMethodInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethodIntInt()
        {
            base.Test_Accessor_IntMethodIntInt();
        }
    }
}
