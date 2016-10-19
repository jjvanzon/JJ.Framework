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
        protected override IClassAccessor CreateClassAccessor(Class obj)
        {
            var accessor = new ClassAccessor_UsingStrings(obj);
            return accessor;
        }

        protected override IDerivedClassAccessor CreateDerivedClassAccessor(DerivedClass obj)
        {
            var accessor = new DerivedClassAccessor_UsingStrings(obj);
            return accessor;
        }

        protected override IClassAccessor CreateBaseAccessor(DerivedClass obj)
        {
            var accessor = new ClassAccessor_UsingStrings(obj, typeof(Class));
            return accessor;
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticField()
        {
            ClassAccessor_UsingStrings.StaticField = 1;
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingStrings.StaticField);

            ClassAccessor_UsingStrings.StaticField = 2;
            AssertHelper.AreEqual(2, () => ClassAccessor_UsingStrings.StaticField);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticProperty()
        {
            ClassAccessor_UsingStrings.StaticProperty = 1;
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingStrings.StaticProperty);

            ClassAccessor_UsingStrings.StaticProperty = 2;
            AssertHelper.AreEqual(2, () => ClassAccessor_UsingStrings.StaticProperty);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticMethod()
        {
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingStrings.StaticMethod(1));
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
