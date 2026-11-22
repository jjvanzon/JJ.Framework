namespace JJ.Framework.Configuration.Core.Tests;

//[Suppress("Trimmer", "IL2026", Justification = PropertyTypeAnd + ObjectGetType)]
//[Suppress("Trimmer", "IL3050", Justification = GenericList)]
[TestClass]
public class CustomConfigurationManagerExTests
{
    private const string SECTION_NAME = "jj.framework.configuration.core.tests";

    [TestMethod]
    public void CustomConfigurationManagerEx_TryGetSection_BySectionName_ReturnsSection()
    {
        var section = CustomConfigurationManagerEx.TryGetSection<TestConfigurationSection>(SECTION_NAME);
        IsNotNull(section);
        AreEqual(42, section.IntValue);
        AreEqual("hello", section.StringValue);
    }

    [TestMethod]
    public void CustomConfigurationManagerEx_TryGetSection_BySectionName_WhenAbsent_ReturnsNull()
    {
        var section = CustomConfigurationManagerEx.TryGetSection<TestConfigurationSection>("nonexistent.section");
        IsNull(section);
    }
}
