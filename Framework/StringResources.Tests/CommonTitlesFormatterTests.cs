namespace JJ.Framework.StringResources.Legacy.Tests;

using static CommonTitlesFormatter;

[TestClass]
public class CommonTitlesFormatterTests() 
    : StringResourceTester(
        typeof(CommonTitlesFormatter),
        @default: "",
        known: ["en-US", "nl-NL"],
        unknown: "de-DE")
{
    private static readonly CultureInfo _enUS = GetCultureInfo("en-US");
    private static readonly CultureInfo _nlNL = GetCultureInfo("nl-NL");

    [TestMethod]
    public void CommonTitlesFormatter_AllPublicStatics_ReturnText_ForKnownCultures() 
        => AssertAllMembers();
    
    [TestMethod]
    public void CommonTitlesFormatter_UnknownCulture_DefaultsToEnUS() 
        => AssertUnknownCulture();

    [TestMethod]
    public void CommonTitlesFormatter_CheckExactTexts_InvariantCulture()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            AreEqual("Number of Items", EntityCount("Items"));
            AreEqual("Number of X",     EntityCount("X"    ));
            AreEqual("Number of ",      EntityCount(""     ));
            AreEqual("Number of ",      EntityCount(null   ));
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void CommonTitlesFormatter_CheckExactTexts_enUS()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = _enUS;
            AreEqual("Number of Items", EntityCount("Items"));
            AreEqual("Number of X",     EntityCount("X"    ));
            AreEqual("Number of ",      EntityCount(""     ));
            AreEqual("Number of ",      EntityCount(null   ));
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void CommonTitlesFormatter_CheckExactTexts_nlNL()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = _nlNL;
            AreEqual("Aantal Items", EntityCount("Items"));
            AreEqual("Aantal X",     EntityCount("X"    ));
            AreEqual("Aantal ",      EntityCount(""     ));
            AreEqual("Aantal ",      EntityCount(null   ));
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
}