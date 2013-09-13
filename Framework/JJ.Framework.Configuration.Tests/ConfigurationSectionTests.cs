using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace JJ.Framework.Configuration.Tests
{
    [TestClass]
    public class ConfigurationSectionTests
    {
        [TestMethod]
        public void Test_Configuration_Example()
        {
            var configuration = new ConfigurationSection<IMySettings>("my.assembly.name");
            int mySetting = configuration.GetValue(x => x.MySetting);
        }

        [TestMethod]
        public void Test_Configuration_IntAttribute()
        {
            int intAttribute_Value = Configuration<IConfiguration>.GetValue(x => x.IntAttribute);
            Assert.AreEqual(100, intAttribute_Value);
        }

        [TestMethod]
        public void Test_Configuration_StringAttribute()
        {
            string stringAttribute_Value = Configuration<IConfiguration>.GetValue(x => x.StringAttribute);
            Assert.AreEqual("stringAttribute_Value", stringAttribute_Value);
        }

        [TestMethod]
        public void Test_Configuration_Attribute_WithAlternativeName()
        {
            string stringAttribute2_Value = Configuration<IConfiguration>.GetValue(x => x.StringAttribute2);
            Assert.AreEqual("stringAttribute2_Value", stringAttribute2_Value);
        }

        [TestMethod]
        public void Test_Configuration_Element()
        {
            string element_Value = Configuration<IConfiguration>.GetValue(x => x.Element);
            Assert.AreEqual("element_Value", element_Value);
        }

        [TestMethod]
        public void Test_Configuration_Element_WithAlternativeName()
        {
            string element2_Value = Configuration<IConfiguration>.GetValue(x => x.Element2);
            Assert.AreEqual("element2_Value", element2_Value);
        }

        [TestMethod]
        public void Test_Configuration_ChildElement()
        {
            string childElement_Value = Configuration<IConfiguration>.GetValue(x => x.SubConfiguration.ChildElement);
            Assert.AreEqual("childElement_Value", childElement_Value);
        }

        [TestMethod]
        public void Test_Configuration_Array()
        {
            string arrayItem_0_Value = Configuration<IConfiguration>.GetValue(x => x.Array[0]);
            Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);

            string arrayItem_1_Value = Configuration<IConfiguration>.GetValue(x => x.Array[1]);
            Assert.AreEqual("arrayItem_1_Value", arrayItem_1_Value);
        }

        [TestMethod]
        public void Test_Configuration_ArrayLength()
        {
            int arrayLength = Configuration<IConfiguration>.GetValue(x => x.Array.Length);
            Assert.AreEqual(2, arrayLength);
        }

        [TestMethod]
        public void Test_Configuration_ArrayIndex_WithVariable()
        {
            int i = 0;
            string arrayItem_0_Value = Configuration<IConfiguration>.GetValue(x => x.Array[i]);
            Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);
        }
        
        //[TestMethod]
        //public void Test_Configuration_TrySomething_WithArrays()
        //{
        //    //string[] array = Configuration<IConfiguration>.GetArray(x => x.Array);

        //    /*foreach (string modelAssembly in Configuration<IPersistenceConfiguration>.GetArray(x => x.ModelAssemblies))
        //    {
                
        //    }*/

        //    /*foreach (ConfigurationNode<ISubConfiguration> item in Configuration<IConfiguration>.GetNodes(x => x.ArrayOfSubConfigurations))
        //    {
        //        int value = item.GetValue(x => x.ChildElement);
        //    }*/

        //    /*foreach (ConfigurationNode<ISubConfiguration> item in Configuration<IConfiguration>.GetNodes(x => x.ArrayOfSubConfigurations))
        //    {
        //        foreach (ConfigurationNode<ISubConfiguration> item2 in item.GetNodes(x => x.ArrayOfSubConfigurations))
        //        {
        //            int value = item.GetValue(x => x.ChildElement);
        //        }
        //    }*/
        //}

        //[TestMethod]
        //public void Test_Configuration_TrySomething_WithConcreteTypes()
        //{
        //    //PersistenceConfiguration configuration = ConfigurationManager.GetSection<PersistenceConfiguration>()
        //    //System.Configuration.ConfigurationManager.GetSection(
        //}

        [TestMethod]
        public void Test_ConfigurationSection_Constructors()
        {
            ConfigurationSection<IConfiguration> configuration;

            // Method 1: section name based on configuration interface's assembly.
            configuration = new ConfigurationSection<IConfiguration>();

            // Method 2: section name based on assembly.
            configuration = new ConfigurationSection<IConfiguration>(typeof(IConfiguration).Assembly);

            // Method 3: custom section name.
            configuration = new ConfigurationSection<IConfiguration>("jj.framework.configuration.tests");
            
            int intAttribute_Value = configuration.GetValue(x => x.IntAttribute);
        }
    }
}
