using JJ.Framework.Configuration.Tests.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConfiguration = JJ.Framework.Configuration.Tests.Settings.TestConfiguration;

// ReSharper disable UnusedVariable
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable RedundantAssignment

namespace JJ.Framework.Configuration.Tests
{
	[TestClass]
	public class CustomConfigurationManagerTests
	{
		[TestMethod]
		public void Test_Configuration_Example()
		{
			var mySettings = CustomConfigurationManager.GetSection<MySettings>("my.assembly.name");
			int mySetting = mySettings.MySetting;
		}

		[TestMethod]
		public void Test_Configuration_IntAttribute()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			int intAttribute_Value = configuration.IntAttribute;
			Assert.AreEqual(100, intAttribute_Value);
		}

		[TestMethod]
		public void Test_Configuration_StringAttribute()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string stringAttribute_Value = configuration.StringAttribute;
			Assert.AreEqual("stringAttribute_Value", stringAttribute_Value);
		}

		[TestMethod]
		public void Test_Configuration_Attribute_WithAlternativeName()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string stringAttribute2_Value = configuration.StringAttribute2;
			Assert.AreEqual("stringAttribute2_Value", stringAttribute2_Value);
		}

		[TestMethod]
		public void Test_Configuration_Element()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string element_Value = configuration.Element;
			Assert.AreEqual("element_Value", element_Value);
		}

		[TestMethod]
		public void Test_Configuration_Element_WithAlternativeName()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string element2_Value = configuration.Element2;
			Assert.AreEqual("element2_Value", element2_Value);
		}

		[TestMethod]
		public void Test_Configuration_ChildElement()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string childElement_Value = configuration.SubConfiguration.ChildElement;
			Assert.AreEqual("childElement_Value", childElement_Value);
		}

		[TestMethod]
		public void Test_Configuration_Array()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			string arrayItem_0_Value = configuration.Array[0];
			Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);

			string arrayItem_1_Value = configuration.Array[1];
			Assert.AreEqual("arrayItem_1_Value", arrayItem_1_Value);
		}

		[TestMethod]
		public void Test_Configuration_ArrayLength()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			int arrayLength = configuration.Array.Length;
			Assert.AreEqual(2, arrayLength);
		}

		[TestMethod]
		public void Test_Configuration_ArrayIndex_WithVariable()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			int i = 0;
			string arrayItem_0_Value = configuration.Array[i];
			Assert.AreEqual("arrayItem_0_Value", arrayItem_0_Value);
		}

		[TestMethod]
		public void Test_Configuration_TrySomething_WithConcreteTypes()
		{
			var configuration = CustomConfigurationManager.GetSection<TestConfiguration>();
			int intAttribute_Value = configuration.IntAttribute;
			Assert.AreEqual(100, intAttribute_Value);
		}

		[TestMethod]
		public void Test_ConfigurationSection_Constructors()
		{
			TestConfiguration configuration;

			// Method 1: section name based on configuration interface's assembly.
			configuration = CustomConfigurationManager.GetSection<TestConfiguration>();

			// Method 2: section name based on assembly.
			configuration = CustomConfigurationManager.GetSection<TestConfiguration>(typeof(TestConfiguration).Assembly);

			// Method 3: custom section name.
			configuration = CustomConfigurationManager.GetSection<TestConfiguration>("jj.framework.configuration.tests");

			int intAttribute_Value = configuration.IntAttribute;
		}
	}
}