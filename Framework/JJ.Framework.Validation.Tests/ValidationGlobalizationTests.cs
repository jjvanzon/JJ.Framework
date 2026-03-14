// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace JJ.Framework.Validation.Legacy.Tests;

#if !NET9_0_OR_GREATER
[Suppress("Trimmer", "IL2026", Justification = ArrayInit + " " + WhenShowIndexerValues)]
#endif
[TestClass]
public class ValidationGlobalizationTests
{
    private class TestModel
    {
        public string Name  { get; set; }
        public int    Score { get; set; }
    }

    private class AlwaysInvalidValidator(TestModel obj) : FluentValidator<TestModel>(obj)
    {
        protected override void Execute()
        {
            For(() => Object.Name,  "First Name").NotNull().NotNullOrWhiteSpace();
            For(() => Object.Score, "Score"     ).NotZero();
        }
    }

    [TestMethod]
    public void Messages_Default()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            IValidator validator = new AlwaysInvalidValidator(new TestModel());
            AreEqual("First Name is null.",                validator.ValidationMessages[0].Text);
            AreEqual("First Name is null or white space.", validator.ValidationMessages[1].Text);
            AreEqual("Score is zero.",                     validator.ValidationMessages[2].Text);
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
            IValidator validator = new AlwaysInvalidValidator(new TestModel());
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
            IValidator validator = new AlwaysInvalidValidator(new TestModel());
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
