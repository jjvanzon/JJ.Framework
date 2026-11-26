namespace JJ.Framework.Configuration.Legacy.Tests;

using static Assert;

[TestClass]
public class CustomConfigurationManagerExTests
{
    private const string SECTION_NAME = "jj.framework.configuration.tests";

    [TestMethod]
    public void CustomConfigurationManagerEx_TryGetSection_BySectionName_ReturnsSection()
    {
        var section = CustomConfigurationManager.TryGetSection<TestConfiguration>(SECTION_NAME);
        IsNotNull( section);
        AreEqual(100, section.IntAttribute);
        AreEqual("stringAttribute_Value", section.StringAttribute);
    }

    [TestMethod]
    public void CustomConfigurationManagerEx_TryGetSection_BySectionName_WhenAbsent_ReturnsNull()
    {
        var section = CustomConfigurationManager.TryGetSection<TestConfiguration>("nonexistent.section");
        IsNull(section);
    }
}
