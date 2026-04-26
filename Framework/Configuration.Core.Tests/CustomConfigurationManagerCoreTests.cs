namespace JJ.Framework.Configuration.Core.Tests;

[TestClass]
public class CustomConfigurationManagerCoreTests
{
    const string SectionName = "jj.framework.configuration.core.tests";

    [TestMethod]
    public void CustomConfigurationManagerCore_TryGetSection_BySectionName_ReturnsSection()
    {
        var section = CustomConfigurationManagerCore.TryGetSection<TestConfigurationSection>(SectionName);

        AreEqual(42, section?.IntValue);
        AreEqual("hello", section?.StringValue);
    }

    [TestMethod]
    public void CustomConfigurationManagerCore_TryGetSection_BySectionName_WhenAbsent_ReturnsNull()
    {
        var section = CustomConfigurationManagerCore.TryGetSection<TestConfigurationSection>("nonexistent.section");

        IsNull(section);
    }
}
