namespace JJ.Framework.Configuration.Core.Tests;

[Suppress("Trimmer", "IL2026", Justification = PropertyTypeAnd + ObjectGetType)]
[TestClass]
public class CustomConfigurationManagerCoreTests
{
    private const string SECTION_NAME = "jj.framework.configuration.core.tests";

    [TestMethod]
    public void CustomConfigurationManagerCore_TryGetSection_BySectionName_ReturnsSection()
    {
        var section = CustomConfigurationManagerCore.TryGetSection<TestConfigurationSection>(SECTION_NAME);
        IsNotNull(section);
        AreEqual(42, section.IntValue);
        AreEqual("hello", section.StringValue);
    }

    [TestMethod]
    public void CustomConfigurationManagerCore_TryGetSection_BySectionName_WhenAbsent_ReturnsNull()
    {
        var section = CustomConfigurationManagerCore.TryGetSection<TestConfigurationSection>("nonexistent.section");
        IsNull(section);
    }
}
