
namespace JJ.Framework.PlatformCompatibility.Tests;

[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class PropertyInfo_PlatformSafe_CoreTests
{
    public int Value { get; set; }

    [Obsolete("reason")]
    public int ValueWithAttr { get; set; } // ncrunch: no coverage

    [TestMethod]
    public void PropertyInfo_GetCustomAttribute_PlatformSupport_ReturnsAttribute()
    {
        // Arrange
        PropertyInfo prop = typeof(PropertyInfo_PlatformSafe_CoreTests).GetProperty("ValueWithAttr");
        ThrowIfNull(prop);

        // Act
        var attrViaExtension = prop.GetCustomAttribute_PlatformSupport<ObsoleteAttribute>();
        var attrViaHelper = PlatformHelperLegacy.PropertyInfo_GetCustomAttribute_PlatformSupport<ObsoleteAttribute>(prop);

        // Assert
        IsNotNull(() => attrViaExtension);
        IsNotNull(() => attrViaHelper);
        AreEqual("reason", () => attrViaExtension.Message);
        AreEqual("reason", () => attrViaHelper.Message);
    }

    [TestMethod]
    public void PropertyInfo_SetValue_PlatformSupport_SetsValue()
    {
        // Arrange
        PropertyInfo prop = typeof(PropertyInfo_PlatformSafe_CoreTests).GetProperty("Value");
        ThrowIfNull(prop);

        // Act
        prop.SetValue_PlatformSupport(this, 123);

        // Assert
        AreEqual(123, () => Value);

        // Act (static variant)
        PlatformHelperLegacy.PropertyInfo_SetValue_PlatformSupport(prop, this, 456);

        // Assert
        AreEqual(456, () => Value);
    }

}
