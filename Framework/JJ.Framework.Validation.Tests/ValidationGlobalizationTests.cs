// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable UnusedMember.Local

namespace JJ.Framework.Validation.Legacy.Tests;

#if !NET9_0_OR_GREATER
[Suppress("Trimmer", "IL2026", Justification = ArrayInit + " " + WhenShowIndexerValues)]
#endif
[TestClass]
public class ValidationGlobalizationTests
{
    private enum Color { Red = 1, Green = 2, Blue = 3 }

    private class TestModel
    {
        public string Name        { get; set; }
        public string Description { get; set; }
        public string Tag         { get; set; }
        public string Status      { get; set; }
        public int    Score       { get; set; }
        public int    Level       { get; set; }
        public Color  Color       { get; set; }
    }

    private static TestModel CreateInvalidModel() => new()
    {
        Description = "  ",
        Tag         = "42",
        Status      = "Deleted",
        Level       = 100
    };

    private class AlwaysInvalidValidator(TestModel obj) : FluentValidator<TestModel>(obj)
    {
        protected override void Execute()
        {
            For(() => Object.Name,        "Name"       ).NotNull();
            For(() => Object.Description, "Description").NotNullOrWhiteSpace();
            For(() => Object.Tag,         "Tag"        ).NotInteger();
            For(() => Object.Status,      "Status"     ).In("Active", "Inactive").Is("Active").IsNot("Deleted");
            For(() => Object.Score,       "Score"      ).NotZero().Above(0).Min(1);
            For(() => Object.Level,       "Level"      ).Max(50);
            For(() => Object.Color,       "Color"      ).IsEnumValue<Color>();
        }
    }

    [TestMethod]
    public void Messages_Default()
    {
        CultureInfo saved = CurrentThread.CurrentUICulture;
        try
        {
            CurrentThread.CurrentUICulture = InvariantCulture;
            IValidator validator = new AlwaysInvalidValidator(CreateInvalidModel());
            AreEqual("Name is null.",                       validator.ValidationMessages[0].Text);
            AreEqual("Description is null or white space.", validator.ValidationMessages[1].Text);
            AreEqual("Tag is integer.",                     validator.ValidationMessages[2].Text);
            AreEqual("Status is not in Active, Inactive.",  validator.ValidationMessages[3].Text);
            AreEqual("Status is not Active.",               validator.ValidationMessages[4].Text);
            AreEqual("Status cannot be Deleted.",           validator.ValidationMessages[5].Text);
            AreEqual("Score is zero.",                      validator.ValidationMessages[6].Text);
            AreEqual("Score is not above 0.",               validator.ValidationMessages[7].Text);
            AreEqual("Score must be at least 1.",           validator.ValidationMessages[8].Text);
            AreEqual("Level can be at most 50.",            validator.ValidationMessages[9].Text);
            AreEqual("Color does not have a valid value.",  validator.ValidationMessages[10].Text);
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
            IValidator validator = new AlwaysInvalidValidator(CreateInvalidModel());
            AreEqual("Name is required.",                                        validator.ValidationMessages[0].Text);
            AreEqual("Description is required.",                                 validator.ValidationMessages[1].Text);
            AreEqual("Tag cannot be an integer number.",                         validator.ValidationMessages[2].Text);
            AreEqual("Status should have one of the values: Active, Inactive.",  validator.ValidationMessages[3].Text);
            AreEqual("Status should be Active.",                                 validator.ValidationMessages[4].Text);
            AreEqual("Status cannot be Deleted.",                                validator.ValidationMessages[5].Text);
            AreEqual("Score is required.",                                       validator.ValidationMessages[6].Text);
            AreEqual("Score is not above 0.",                                    validator.ValidationMessages[7].Text);
            AreEqual("Score must be at least 1.",                                validator.ValidationMessages[8].Text);
            AreEqual("Level can be at most 50.",                                 validator.ValidationMessages[9].Text);
            AreEqual("Color does not have a valid value.",                       validator.ValidationMessages[10].Text);
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
            IValidator validator = new AlwaysInvalidValidator(CreateInvalidModel());
            AreEqual("Name is verplicht.",                                    validator.ValidationMessages[0].Text);
            AreEqual("Description is verplicht.",                             validator.ValidationMessages[1].Text);
            AreEqual("Tag mag geen geheel getal zijn.",                       validator.ValidationMessages[2].Text);
            AreEqual("Status moet een van de waardes Active, Inactive zijn.",  validator.ValidationMessages[3].Text);
            AreEqual("Status moet Active zijn.",                              validator.ValidationMessages[4].Text);
            AreEqual("Status mag niet Deleted zijn.",                         validator.ValidationMessages[5].Text);
            AreEqual("Score is verplicht.",                                   validator.ValidationMessages[6].Text);
            AreEqual("Score is niet hoger dan 0.",                            validator.ValidationMessages[7].Text);
            AreEqual("Score moet minimaal 1 zijn.",                           validator.ValidationMessages[8].Text);
            AreEqual("Level mag maximaal 50 zijn.",                           validator.ValidationMessages[9].Text);
            AreEqual("Color heeft een niet-toegestane waarde.",               validator.ValidationMessages[10].Text);
        }
        finally
        {
            CurrentThread.CurrentUICulture = saved;
        }
    }
}
