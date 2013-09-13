using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JJ.Framework.Configuration.Tests
{
    [TestClass]
    public class ConfigurationManagerTests
    {
        [TestMethod]
        public void Test_Configuration_Example()
        {
            MySettings mySettings = ConfigurationManager.GetSection<MySettings>("my.assembly.name");
            int mySetting = mySettings.MySetting;
        }

        [TestMethod]
        public void Test_Configuration_IntAttribute()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            int intAttribute_Value = configuration.IntAttribute;
            Assert.AreEqual(100, intAttribute_Value);
        }

        [TestMethod]
        public void Test_Configuration_StringAttribute()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string stringAttribute_Value = configuration.StringAttribute;
            Assert.AreEqual("stringAttribute_Value", stringAttribute_Value);
        }

        [TestMethod]
        public void Test_Configuration_Attribute_WithAlternativeName()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string stringAttribute2_Value = configuration.StringAttribute2;
            Assert.AreEqual("stringAttribute2_Value", stringAttribute2_Value);
        }

        [TestMethod]
        public void Test_Configuration_Element()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string element_Value = configuration.Element;
            Assert.AreEqual("element_Value", element_Value);
        }

        [TestMethod]
        public void Test_Configuration_Element_WithAlternativeName()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string element2_Value = configuration.Element2;
            Assert.AreEqual("element2_Value", element2_Value);
        }

        [TestMethod]
        public void Test_Configuration_ChildElement()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string childElement_Value = configuration.SubConfiguration.ChildElement;
            Assert.AreEqual("childElement_Value", childElement_Value);
        }

        [TestMethod]
        public void Test_Configuration_Array()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            string arrayItem_0_Value = configuration.Array[0];
            Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);

            string arrayItem_1_Value = configuration.Array[1];
            Assert.AreEqual("arrayItem_1_Value", arrayItem_1_Value);
        }

        [TestMethod]
        public void Test_Configuration_ArrayLength()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            int arrayLength = configuration.Array.Length;
            Assert.AreEqual(2, arrayLength);
        }

        [TestMethod]
        public void Test_Configuration_ArrayIndex_WithVariable()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();

            int i = 0;
            string arrayItem_0_Value = configuration.Array[i];
            Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);
        }

        [TestMethod]
        public void Test_Configuration_TrySomething_WithConcreteTypes()
        {
            TestConfiguration configuration = ConfigurationManager.GetSection<TestConfiguration>();
            int intAttribute_Value = configuration.IntAttribute;
            Assert.AreEqual(100, intAttribute_Value);
        }

        [TestMethod]
        public void Test_ConfigurationSection_Constructors()
        {
            TestConfiguration configuration;

            // Method 1: section name based on configuration interface's assembly.
            configuration = ConfigurationManager.GetSection<TestConfiguration>();

            // Method 2: section name based on assembly.
            configuration = ConfigurationManager.GetSection<TestConfiguration>(typeof(TestConfiguration).Assembly);

            // Method 3: custom section name.
            configuration = ConfigurationManager.GetSection<TestConfiguration>("jj.framework.configuration.tests");
            
            int intAttribute_Value = configuration.IntAttribute;
        }
    }
}
