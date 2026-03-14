using System.Globalization;
using System.Threading;
using static System.Globalization.CultureInfo;

namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class GlobalizationTests
{
    private static string GetMessage(CultureInfo culture, Action<TestValidator> setup)
    {
        var saved = Thread.CurrentThread.CurrentUICulture;
        try
        {
            Thread.CurrentThread.CurrentUICulture = culture;
            var validator = new TestValidator(setup);
            return validator.ValidationMessages[0].Text;
        }
        finally
        {
            Thread.CurrentThread.CurrentUICulture = saved;
        }
    }

    // Default (en-US-tech) – InvariantCulture falls back to the default resx

    [TestMethod]
    public void NotNull_Default_IsNullMessage()
        => AreEqual("First Name is null.", GetMessage(InvariantCulture, v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_Default_IsNullOrWhiteSpaceMessage()
        => AreEqual("First Name is null or white space.", GetMessage(InvariantCulture, v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_Default_IsZeroMessage()
        => AreEqual("Score is zero.", GetMessage(InvariantCulture, v => v.For(0, "Score", "Score").NotZero()));

    // en-US – friendlier messages

    [TestMethod]
    public void NotNull_EnUS_IsRequiredMessage()
        => AreEqual("First Name is required.", GetMessage(new CultureInfo("en-US"), v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_EnUS_IsRequiredMessage()
        => AreEqual("First Name is required.", GetMessage(new CultureInfo("en-US"), v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_EnUS_IsRequiredMessage()
        => AreEqual("Score is required.", GetMessage(new CultureInfo("en-US"), v => v.For(0, "Score", "Score").NotZero()));

    // nl-NL – Dutch

    [TestMethod]
    public void NotNull_NlNL_IsVerplichtMessage()
        => AreEqual("First Name is verplicht.", GetMessage(new CultureInfo("nl-NL"), v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_NlNL_IsVerplichtMessage()
        => AreEqual("First Name is verplicht.", GetMessage(new CultureInfo("nl-NL"), v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_NlNL_IsVerplichtMessage()
        => AreEqual("Score is verplicht.", GetMessage(new CultureInfo("nl-NL"), v => v.For(0, "Score", "Score").NotZero()));
}
