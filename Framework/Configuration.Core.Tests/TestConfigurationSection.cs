using System.Xml.Serialization;

namespace JJ.Framework.Configuration.Core.Tests;

public class TestConfigurationSection
{
    [XmlAttribute]
    public int IntValue { get; set; }

    [XmlAttribute]
    public string StringValue { get; set; } = "";
}
