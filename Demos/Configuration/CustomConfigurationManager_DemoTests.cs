using System.Xml.Serialization;
using JJ.Framework.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeTypeModifiers

namespace JJ.Demos.Configuration
{
    [TestClass]
    public class CustomConfigurationManager_DemoTests
    {
        [TestMethod]
        public void Demo_CustomConfigurationManager()
        {
            var config = CustomConfigurationManager.GetSection<ConfigurationSection>();
            int value = config.Items[1].Child.Value;
            Assert.AreEqual(3, value);
        }
    }

    class ConfigurationSection
    {
        public Item[] Items { get; set; }
    }

    class Item
    {
        [XmlAttribute]
        public int Value { get; set; }
        public Item Child { get; set; }
    }
}
