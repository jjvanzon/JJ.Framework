using System;
using System.Reflection;
using JJ.Framework.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Demos.Reflection
{
    [TestClass]
    public class Demo_Type_GetMethod_OutParameter_Tests
    {
        [TestMethod]
        public void Demo_Type_GetMethod_OutParameter_WithCalling_MakeByRefType_ReturnsNotNull()
        {
            Type type = typeof(Demo_Type_GetMethod_OutParameter_Helper);
            const string methodName = nameof(Demo_Type_GetMethod_OutParameter_Helper.Method_OutParameter);
            Type parameterType = typeof(double).MakeByRefType();

            MethodInfo method =
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNotNull(() => method);
        }

        [TestMethod]
        public void Demo_Type_GetMethod_OutParameter_WithoutCalling_MakeByRefType_ReturnsNull()
        {
            Type type = typeof(Demo_Type_GetMethod_OutParameter_Helper);
            const string methodName = nameof(Demo_Type_GetMethod_OutParameter_Helper.Method_OutParameter);
            Type parameterType = typeof(double);

            MethodInfo method =
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNull(() => method);
        }

        [TestMethod]
        public void Demo_Type_GetMethod_NonRefParameter_ReturnsNotNull()
        {
            Type type = typeof(Demo_Type_GetMethod_OutParameter_Helper);
            const string methodName = nameof(Demo_Type_GetMethod_OutParameter_Helper.Method_NonRefParameter);
            Type parameterType = typeof(int);

            MethodInfo method =
                type.GetMethod(methodName, ReflectionHelper.BINDING_FLAGS_ALL, null, new[] { parameterType }, null);

            AssertHelper.IsNotNull(() => method);
        }
    }
}
