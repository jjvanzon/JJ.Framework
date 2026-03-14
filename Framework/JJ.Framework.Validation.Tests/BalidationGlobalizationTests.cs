using System.Globalization;
using static System.Globalization.CultureInfo;
using static System.Threading.Thread;

namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidationGlobalizationTests
{
    [TestMethod]
    public void Messages_Default()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            var validator = new TestValidator(v => v
                .For(null,  "Name",  "First Name").NotNull()
                .For("  ", "Name",  "First Name").NotNullOrWhiteSpace()
                .For(0,    "Score", "Score"      ).NotZero());
            AreEqual("First Name is null.",               validator.ValidationMessages[0].Text);
            AreEqual("First Name is null or white space.", validator.ValidationMessages[1].Text);
            AreEqual("Score is zero.",                    validator.ValidationMessages[2].Text);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void Messages_EnUS()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = new("en-US");
            var validator = new TestValidator(v => v
                .For(null,  "Name",  "First Name").NotNull()
                .For("  ", "Name",  "First Name").NotNullOrWhiteSpace()
                .For(0,    "Score", "Score"      ).NotZero());
            AreEqual("First Name is required.", validator.ValidationMessages[0].Text);
            AreEqual("First Name is required.", validator.ValidationMessages[1].Text);
            AreEqual("Score is required.",      validator.ValidationMessages[2].Text);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }

    [TestMethod]
    public void Messages_NlNL()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = new("nl-NL");
            var validator = new TestValidator(v => v
                .For(null,  "Name",  "First Name").NotNull()
                .For("  ", "Name",  "First Name").NotNullOrWhiteSpace()
                .For(0,    "Score", "Score"      ).NotZero());
            AreEqual("First Name is verplicht.", validator.ValidationMessages[0].Text);
            AreEqual("First Name is verplicht.", validator.ValidationMessages[1].Text);
            AreEqual("Score is verplicht.",      validator.ValidationMessages[2].Text);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
}
