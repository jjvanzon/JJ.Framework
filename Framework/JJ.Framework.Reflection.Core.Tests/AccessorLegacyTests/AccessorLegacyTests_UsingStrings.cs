using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests

{
    [TestClass]
    public class AccessorLegacyTests_UsingStrings : AccessorLegacyTestsBase
    {
        protected override IClassAccessorLegacy CreateClassAccessor(ClassLegacy obj)
        {
            var accessor = new ClassAccessorLegacy_UsingStrings(obj);
            return accessor;
        }

        protected override IDerivedClassAccessorLegacy CreateDerivedClassAccessor(DerivedClassLegacy obj)
        {
            var accessor = new DerivedClassAccessorLegacy_UsingStrings(obj);
            return accessor;
        }

        protected override IClassAccessorLegacy CreateBaseAccessor(DerivedClassLegacy obj)
        {
            var accessor = new ClassAccessorLegacy_UsingStrings(obj, typeof(ClassLegacy));
            return accessor;
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticField()
        {
            ClassAccessorLegacy_UsingStrings._staticField = 1;
            AssertHelper.AreEqual(1, () => ClassAccessorLegacy_UsingStrings._staticField);

            ClassAccessorLegacy_UsingStrings._staticField = 2;
            AssertHelper.AreEqual(2, () => ClassAccessorLegacy_UsingStrings._staticField);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticProperty()
        {
            ClassAccessorLegacy_UsingStrings.StaticProperty = 1;
            AssertHelper.AreEqual(1, () => ClassAccessorLegacy_UsingStrings.StaticProperty);

            ClassAccessorLegacy_UsingStrings.StaticProperty = 2;
            AssertHelper.AreEqual(2, () => ClassAccessorLegacy_UsingStrings.StaticProperty);
        }

        [TestMethod]
        public void Test_Accessor_UsingStrings_StaticMethod() => AssertHelper.AreEqual(1, () => ClassAccessorLegacy_UsingStrings.StaticMethod(1));

        [TestMethod]
        public void Test_Accessor_UsingStrings_Field() => Test_Accessor_Field();

        [TestMethod]
        public void Test_Accessor_UsingStrings_Field_InBaseClass() => Test_Accessor_Field_InBaseClass();

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property() => Test_Accessor_Property();

        [TestMethod]
        public void Test_Accessor_UsingStrings_Property_InBaseClass() => Test_Accessor_Property_InBaseClass();

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method() => Test_Accessor_Method();

        [TestMethod]
        public void Test_Accessor_UsingStrings_Method_InBaseClass() => Test_Accessor_Method_InBaseClass();

        [TestMethod]
        public void Test_Accessor_UsingStrings_HiddenMember() => Test_Accessor_HiddenMember();

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethod() => Test_Accessor_VoidMethod();

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethodInt() => Test_Accessor_VoidMethodInt();

        [TestMethod]
        public void Test_Accessor_UsingStrings_VoidMethodIntInt() => Test_Accessor_VoidMethodIntInt();

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethod() => Test_Accessor_IntMethod();

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethodInt() => Test_Accessor_IntMethodInt();

        [TestMethod]
        public void Test_Accessor_UsingStrings_IntMethodIntInt() => Test_Accessor_IntMethodIntInt();
    }
}