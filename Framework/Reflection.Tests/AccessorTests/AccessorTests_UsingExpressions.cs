using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    [TestClass]
    public class AccessorTests_UsingExpressions : AccessorTestsBase
    {
        protected override IClassAccessor CreateClassAccessor(Class obj)
        {
            var accessor = new ClassAccessor_UsingExpressions(obj);
            return accessor;
        }

        protected override IDerivedClassAccessor CreateDerivedClassAccessor(DerivedClass obj)
        {
            var accessor = new DerivedClassAccessor_UsingExpressions(obj);
            return accessor;
        }

        protected override IClassAccessor CreateBaseAccessor(DerivedClass obj)
        {
            var accessor = new ClassAccessor_UsingExpressions(obj, typeof(Class));
            return accessor;
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_StaticField()
        {
            ClassAccessor_UsingExpressions.StaticField = 1;
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingExpressions.StaticField);

            ClassAccessor_UsingExpressions.StaticField = 2;
            AssertHelper.AreEqual(2, () => ClassAccessor_UsingExpressions.StaticField);
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_StaticProperty()
        {
            ClassAccessor_UsingExpressions.StaticProperty = 1;
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingExpressions.StaticProperty);

            ClassAccessor_UsingExpressions.StaticProperty = 2;
            AssertHelper.AreEqual(2, () => ClassAccessor_UsingExpressions.StaticProperty);
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_StaticMethod()
        {
            AssertHelper.AreEqual(1, () => ClassAccessor_UsingExpressions.StaticMethod(1));
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Field()
        {
            base.Test_Accessor_Field();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Field_InBaseClass()
        {
            base.Test_Accessor_Field_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Property()
        {
            base.Test_Accessor_Property();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Property_InBaseClass()
        {
            base.Test_Accessor_Property_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Method()
        {
            base.Test_Accessor_Method();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_Method_InBaseClass()
        {
            base.Test_Accessor_Method_InBaseClass();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_HiddenMember()
        {
            base.Test_Accessor_HiddenMember();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_VoidMethod()
        {
            base.Test_Accessor_VoidMethod();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_VoidMethodInt()
        {
            base.Test_Accessor_VoidMethodInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_VoidMethodIntInt()
        {
            base.Test_Accessor_VoidMethodIntInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_IntMethod()
        {
            base.Test_Accessor_IntMethod();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_IntMethodInt()
        {
            base.Test_Accessor_IntMethodInt();
        }

        [TestMethod]
        public void Test_Accessor_UsingExpressions_IntMethodIntInt()
        {
            base.Test_Accessor_IntMethodIntInt();
        }
    }
}
