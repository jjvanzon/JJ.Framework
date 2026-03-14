using System.Globalization;
using System.Threading;
using static System.Globalization.CultureInfo;
using static System.Threading.Thread;

namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidationGlobalizationTests
{
    private static readonly CultureInfo _enUS = new ("en-US");
    private static readonly CultureInfo _nlNL = new ("nl-NL");

    private static string GetMessageFromValidator(CultureInfo culture, Action<TestValidator> validatorImpl)
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = culture;
            var validator = new TestValidator(validatorImpl);
            return validator.ValidationMessages[0].Text;
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    // Default (en-US-tech) – InvariantCulture falls back to the default resx

    [TestMethod]
    public void NotNull_Default_IsNullMessage()
        => AreEqual("First Name is null.", GetMessageFromValidator(InvariantCulture, v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_Default_IsNullOrWhiteSpaceMessage()
        => AreEqual("First Name is null or white space.", GetMessageFromValidator(InvariantCulture, v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_Default_IsZeroMessage()
        => AreEqual("Score is zero.", GetMessageFromValidator(InvariantCulture, v => v.For(0, "Score", "Score").NotZero()));

    // en-US – friendlier messages

    [TestMethod]
    public void Globalization_EnUS_IsRequiredMessage()
        => AreEqual("First Name is required.", GetMessageFromValidator(_enUS, v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_EnUS_IsRequiredMessage()
        => AreEqual("First Name is required.", GetMessageFromValidator(_enUS, v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_EnUS_IsRequiredMessage()
        => AreEqual("Score is required.", GetMessageFromValidator(_enUS, v => v.For(0, "Score", "Score").NotZero()));

    // nl-NL – Dutch

    [TestMethod]
    public void NotNull_NlNL_IsVerplichtMessage()
        => AreEqual("First Name is verplicht.", GetMessageFromValidator(_nlNL, v => v.For(null, "Name", "First Name").NotNull()));

    [TestMethod]
    public void NotNullOrWhiteSpace_NlNL_IsVerplichtMessage()
        => AreEqual("First Name is verplicht.", GetMessageFromValidator(_nlNL, v => v.For("  ", "Name", "First Name").NotNullOrWhiteSpace()));

    [TestMethod]
    public void NotZero_NlNL_IsVerplichtMessage()
        => AreEqual("Score is verplicht.", GetMessageFromValidator(_nlNL, v => v.For(0, "Score", "Score").NotZero()));
}
