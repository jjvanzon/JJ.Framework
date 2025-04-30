using JJ.Framework.Testing;

namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    public abstract class AccessorLegacyTestsBase
    {
        protected abstract IClassAccessorLegacy CreateClassAccessor(Class obj);
        protected abstract IDerivedClassAccessorLegacy CreateDerivedClassAccessor(DerivedClass obj);
        protected abstract IClassAccessorLegacy CreateBaseAccessor(DerivedClass obj);

        protected void Test_Accessor_Field()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);

            accessor._field = 1;
            AssertHelper.AreEqual(1, () => accessor._field);

            accessor._field = 2;
            AssertHelper.AreEqual(2, () => accessor._field);
        }

        protected void Test_Accessor_Field_InBaseClass()
        {
            var obj = new DerivedClass();
            IClassAccessorLegacy accessor = CreateBaseAccessor(obj);

            accessor._field = 1;
            AssertHelper.AreEqual(1, () => accessor._field);

            accessor._field = 2;
            AssertHelper.AreEqual(2, () => accessor._field);
        }

        protected void Test_Accessor_Property()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);

            accessor.Property = 1;
            AssertHelper.AreEqual(1, () => accessor.Property);

            accessor.Property = 2;
            AssertHelper.AreEqual(2, () => accessor.Property);
        }

        protected void Test_Accessor_Property_InBaseClass()
        {
            var obj = new DerivedClass();
            IClassAccessorLegacy accessor = CreateBaseAccessor(obj);

            accessor.Property = 1;
            AssertHelper.AreEqual(1, () => accessor.Property);

            accessor.Property = 2;
            AssertHelper.AreEqual(2, () => accessor.Property);
        }

        protected void Test_Accessor_Method()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_Method_InBaseClass()
        {
            var obj = new DerivedClass();
            IClassAccessorLegacy accessor = CreateBaseAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_HiddenMember()
        {
            var obj = new DerivedClass();
            IDerivedClassAccessorLegacy accessor = CreateDerivedClassAccessor(obj);

            accessor.MemberToHide = 1;
            accessor.Base_MemberToHide = 2;

            AssertHelper.AreEqual(1, () => accessor.MemberToHide);
            AssertHelper.AreEqual(2, () => accessor.Base_MemberToHide);
        }

        protected void Test_Accessor_VoidMethod()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            accessor.VoidMethod();
        }

        protected void Test_Accessor_VoidMethodInt()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            accessor.VoidMethodInt(1);
        }

        protected void Test_Accessor_VoidMethodIntInt()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            accessor.VoidMethodIntInt(1, 1);
        }

        protected void Test_Accessor_IntMethod()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethod());
        }

        protected void Test_Accessor_IntMethodInt()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_IntMethodIntInt()
        {
            var obj = new Class();
            IClassAccessorLegacy accessor = CreateClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodIntInt(1, 1));
        }
    }
}
