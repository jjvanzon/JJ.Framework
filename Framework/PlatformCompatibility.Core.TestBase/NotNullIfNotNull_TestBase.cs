using System.Globalization;
using static System.Globalization.CultureInfo;

// ReSharper disable ConvertToConstant.Local
// ReSharper disable VariableCanBeNotNullable

#pragma warning disable CS0219 // Unused variable

// ReSharper disable UnusedParameter.Local

namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class NotNullIfNotNull_TestBase
{
    public void Test_NotNullIfNotNull_Constructor()
    {
        var attr = new NotNullIfNotNullAttribute("testParam");
        AreEqual("testParam", attr.ParameterName);
    }

    public void Test_NotNullIfNotNull_ParamNull_ReturnObjNull()
    {
        CultureInfo? culture = GetCulture(null);
        IsNull(culture);
    }

    public void Test_NotNullIfNotNull_ParamEmptyString_ReturnObjNotNull()
    {
        CultureInfo culture = GetCulture("");
        NotNull(culture);
        AreEqual(culture, InvariantCulture);
    }

    public void Test_NotNullIfNotNull_ParalFilled_ReturnObjNotNull()
    {
        CultureInfo culture = GetCulture("nl-NL");
        NotNull(culture);
        AreEqual("nl-NL", culture.Name);
    }

    [return: NotNullIfNotNull(nameof(name))]
    private CultureInfo? GetCulture(string? name)
    {
        if (name == null) return null;
        return GetCultureInfo(name);
    }
}