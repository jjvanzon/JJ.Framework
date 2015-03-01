using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Testing;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    public abstract class AccessorTestsBase
    {
        protected abstract IMyClassAccessor CreateMyClassAccessor(MyClass obj);
        protected abstract IMyDerivedClassAccessor CreateMyDerivedClassAccessor(MyDerivedClass obj);
        protected abstract IMyClassAccessor CreateBaseAccessor(MyDerivedClass obj);

        protected void Test_Accessor_Field()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);

            accessor._field = 1;
            AssertHelper.AreEqual(1, () => accessor._field);

            accessor._field = 2;
            AssertHelper.AreEqual(2, () => accessor._field);
        }

        protected void Test_Accessor_Field_InBaseClass()
        {
            var obj = new MyDerivedClass();
            IMyClassAccessor accessor = CreateBaseAccessor(obj);

            accessor._field = 1;
            AssertHelper.AreEqual(1, () => accessor._field);

            accessor._field = 2;
            AssertHelper.AreEqual(2, () => accessor._field);
        }

        protected void Test_Accessor_Property()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);

            accessor.Property = 1;
            AssertHelper.AreEqual(1, () => accessor.Property);

            accessor.Property = 2;
            AssertHelper.AreEqual(2, () => accessor.Property);
        }

        protected void Test_Accessor_Property_InBaseClass()
        {
            var obj = new MyDerivedClass();
            IMyClassAccessor accessor = CreateBaseAccessor(obj);

            accessor.Property = 1;
            AssertHelper.AreEqual(1, () => accessor.Property);

            accessor.Property = 2;
            AssertHelper.AreEqual(2, () => accessor.Property);
        }

        protected void Test_Accessor_Method()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_Method_InBaseClass()
        {
            var obj = new MyDerivedClass();
            IMyClassAccessor accessor = CreateBaseAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_HiddenMember()
        {
            var obj = new MyDerivedClass();
            IMyDerivedClassAccessor accessor = CreateMyDerivedClassAccessor(obj);

            accessor.MemberToHide = 1;
            accessor.Base_MemberToHide = 2;

            AssertHelper.AreEqual(1, () => accessor.MemberToHide);
            AssertHelper.AreEqual(2, () => accessor.Base_MemberToHide);
        }

        protected void Test_Accessor_VoidMethod()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            accessor.VoidMethod();
        }

        protected void Test_Accessor_VoidMethodInt()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            accessor.VoidMethodInt(1);
        }

        protected void Test_Accessor_VoidMethodIntInt()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            accessor.VoidMethodIntInt(1, 1);
        }

        protected void Test_Accessor_IntMethod()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethod());
        }

        protected void Test_Accessor_IntMethodInt()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodInt(1));
        }

        protected void Test_Accessor_IntMethodIntInt()
        {
            var obj = new MyClass();
            IMyClassAccessor accessor = CreateMyClassAccessor(obj);
            AssertHelper.AreEqual(1, () => accessor.IntMethodIntInt(1, 1));
        }
    }
}
