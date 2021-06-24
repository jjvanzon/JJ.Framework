using System;
using System.Reflection;
using JJ.Framework.PlatformCompatibility.Tests.Helpers;
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
        public void Test_Property_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.Property;
            int actual = (int)MemberTypes_PlatformSafe.Property;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PropertyInfo_MemberType_FromDotNet_Returns_Property()
        {
            MemberTypes expected = MemberTypes.Property;
            MemberTypes actual = MemberTypes_TestHelper.PropertyInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PropertyInfo_MemberType_PlatformSafe_Returns_Property()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Property;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.PropertyInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Field

        [TestMethod]
        public void Test_Field_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.Field;
            int actual = (int)MemberTypes_PlatformSafe.Field;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_FieldInfo_MemberType_FromDotNet_Returns_Field()
        {
            MemberTypes expected = MemberTypes.Field;
            MemberTypes actual = MemberTypes_TestHelper.FieldInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_FieldInfo_MemberType_PlatformSafe_Returns_Field()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Field;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.FieldInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Method

        [TestMethod]
        public void Test_Method_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.Method;
            int actual = (int)MemberTypes_PlatformSafe.Method;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_MethodInfo_MemberType_FromDotNet_Returns_Method()
        {
            MemberTypes expected = MemberTypes.Method;
            MemberTypes actual = MemberTypes_TestHelper.MethodInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_MethodInfo_MemberType_PlatformSafe_Returns_Method()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Method;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.MethodInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Constructor

        [TestMethod]
        public void Test_Constructor_PlatformSafe_MemberTypes()
        {
            int expected = (int)MemberTypes.Constructor;
            int actual = (int)MemberTypes_PlatformSafe.Constructor;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ConstructorInfo_MemberType_FromDotNet_Returns_Constructor()
        {
            MemberTypes expected = MemberTypes.Constructor;
            MemberTypes actual = MemberTypes_TestHelper.ConstructorInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ConstructorInfo_MemberType_PlatformSafe_Returns_Constructor()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Constructor;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.ConstructorInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Event

        [TestMethod]
        public void Test_Event_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.Event;
            int actual = (int)MemberTypes_PlatformSafe.Event;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EventInfo_MemberType_FromDotNet_Returns_Event()
        {
            MemberTypes expected = MemberTypes.Event;
            MemberTypes actual = MemberTypes_TestHelper.EventInfo.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EventInfo_MemberType_PlatformSafe_Returns_Event()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.Event;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.EventInfo.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.Type

        [TestMethod]
        public void Test_TypeInfo_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.TypeInfo;
            int actual = (int)MemberTypes_PlatformSafe.TypeInfo;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Type_MemberType_FromDotNet_Returns_TypeInfo()
        {
            MemberTypes expected = MemberTypes.TypeInfo;
            MemberTypes actual = MemberTypes_TestHelper.Type.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Type_MemberType_PlatformSafe_Returns_TypeInfo()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.TypeInfo;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.Type.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // MemberTypes.NestedType

        [TestMethod]
        public void Test_NestedType_MemberTypes_PlatformSafe()
        {
            int expected = (int)MemberTypes.NestedType;
            int actual = (int)MemberTypes_PlatformSafe.NestedType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_NestedType_MemberType_FromDotNet_Returns_NestedType()
        {
            MemberTypes expected = MemberTypes.NestedType;
            MemberTypes actual = MemberTypes_TestHelper.NestedType.MemberType;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_NestedType_MemberType_PlatformSafe_Returns_NestedType()
        {
            MemberTypes_PlatformSafe expected = MemberTypes_PlatformSafe.NestedType;
            MemberTypes_PlatformSafe actual = MemberTypes_TestHelper.NestedType.MemberType_PlatformSafe();
            Assert.AreEqual(expected, actual);
        }

        // Edge Cases

        [TestMethod]
        public void Test_EdgeCase_MemberTypes_PlatformSafe_Undefined()
        {
            int expected = 0;
            int actual = (int)MemberTypes_PlatformSafe.Undefined;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EdgeCase_MemberType_Null_ThrowsException_UsingPlatformHelper()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => PlatformHelper.MemberType_PlatformSafe(null),
                "Value cannot be null.\r\nParameter name: memberInfo");

        [TestMethod]
        public void Test_EdgeCase_MemberType_Unsupported_ThrowsException_UsingPlatformHelper()
            => AssertHelper.ThrowsException<NotSupportedException>(
                () => MemberTypes_TestHelper.CustomMemberInfo.MemberType_PlatformSafe(),
                $"memberInfo has the unsupported type: '{typeof(CustomMemberInfo)}'");
   }
}
