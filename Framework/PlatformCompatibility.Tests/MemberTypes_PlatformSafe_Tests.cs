using System;
using System.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.PlatformCompatibility.Tests
{
    [TestClass]
    public class MemberTypes_PlatformSafe_Tests
    {
        // MemberTypes.Property

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Property()
        {
            int expected = (int)MemberTypes.Property;
            int actual = (int)MemberTypes_PlatformSafe.Property;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_PropertyInfo_Returns_Property()
        {
            MemberTypes expected = MemberTypes.Property;
            MemberTypes actual = TestHelper.PropertyInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_PropertyInfo_Returns_Property()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Property;
            MemberTypes_PlatformSafe actual = TestHelper.PropertyInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_PropertyInfo_Returns_Property()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Property;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.PropertyInfo);
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Field

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Field()
        {
            int expected = (int)MemberTypes.Field;
            int actual = (int)MemberTypes_PlatformSafe.Field;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_FieldInfo_Returns_Field()
        {
            MemberTypes expected = MemberTypes.Field;
            MemberTypes actual = TestHelper.FieldInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_FieldInfo_Returns_Field()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Field;
            MemberTypes_PlatformSafe actual = TestHelper.FieldInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_FieldInfo_Returns_Field()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Field;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.FieldInfo);
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Method

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Method()
        {
            int expected = (int)MemberTypes.Method;
            int actual = (int)MemberTypes_PlatformSafe.Method;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_MethodInfo_Returns_Method()
        {
            MemberTypes expected = MemberTypes.Method;
            MemberTypes actual = TestHelper.MethodInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_MethodInfo_Returns_Method()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Method;
            MemberTypes_PlatformSafe actual = TestHelper.MethodInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_MethodInfo_Returns_Method()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Method;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.MethodInfo);
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Constructor

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Constructor()
        {
            int expected = (int)MemberTypes.Constructor;
            int actual = (int)MemberTypes_PlatformSafe.Constructor;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_ConstructorInfo_Returns_Constructor()
        {
            MemberTypes expected = MemberTypes.Constructor;
            MemberTypes actual = TestHelper.ConstructorInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_ConstructorInfo_Returns_Constructor()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Constructor;
            MemberTypes_PlatformSafe actual = TestHelper.ConstructorInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_ConstructorInfo_Returns_Constructor()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Constructor;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.ConstructorInfo);
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Event

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Event()
        {
            int expected = (int)MemberTypes.Event;
            int actual = (int)MemberTypes_PlatformSafe.Event;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_EventInfo_Returns_Event()
        {
            MemberTypes expected = MemberTypes.Event;
            MemberTypes actual = TestHelper.EventInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_EventInfo_Returns_Event()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Event;
            MemberTypes_PlatformSafe actual = TestHelper.EventInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_EventInfo_Returns_Event()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Event;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.EventInfo);
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Type

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_TypeInfo()
        {
            int expected = (int)MemberTypes.TypeInfo;
            int actual = (int)MemberTypes_PlatformSafe.TypeInfo;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformCompatibility_DotNet_MemberType_Type_Returns_TypeInfo()
        {
            MemberTypes expected = MemberTypes.TypeInfo;
            MemberTypes actual = TestHelper.Type.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_Type_Returns_TypeInfo()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.TypeInfo;
            MemberTypes_PlatformSafe actual = TestHelper.Type.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformHelper_MemberType_Type_Returns_TypeInfo()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.TypeInfo;
            MemberTypes_PlatformSafe actual = PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.Type);
            Assert.AreEqual(expected, actual);
        }

        // Edge Cases

        [TestMethod]
        public void Test_MemberTypes_PlatformSafe_Undefined()
        {
            int expected = 0;
            int actual = (int)MemberTypes_PlatformSafe.Undefined;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_Null_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => ((MemberInfo)null).MemberType_PlatformSafe(),
                "Value cannot be null.\r\nParameter name: memberInfo");

        [TestMethod]
        public void Test_PlatformHelper_MemberType_Null_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => PlatformHelper.MemberInfo_MemberType_PlatformSafe(null),
                "Value cannot be null.\r\nParameter name: memberInfo");

        [TestMethod]
        public void Test_PlatformExtensions_MemberType_Unsupported_ThrowsException()
            => AssertHelper.ThrowsException<NotSupportedException>(
                () => TestHelper.CustomMemberInfo.MemberType_PlatformSafe(),
                $"memberInfo has the unsupported type: '{typeof(CustomMemberInfo)}'");

        [TestMethod]
        public void Test_PlatformHelper_MemberType_Unsupported_ThrowsException()
            => AssertHelper.ThrowsException<NotSupportedException>(
                () => PlatformHelper.MemberInfo_MemberType_PlatformSafe(TestHelper.CustomMemberInfo),
                $"memberInfo has the unsupported type: '{typeof(CustomMemberInfo)}'");
    }
}
