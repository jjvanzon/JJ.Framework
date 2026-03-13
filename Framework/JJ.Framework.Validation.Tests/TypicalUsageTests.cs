namespace JJ.Framework.Validation.Legacy.Tests;

using static TypicalUsageTests.Color;
[Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
[TestClass]
public class TypicalUsageTests
{
    public enum Color { Red = 1, Green = 2, Blue = 3 }

    private class SimpleModel
    {
        public string Name        { get; set; }
        public string Description { get; set; }
        public Color  Color       { get; set; }
        public string Status      { get; set; }
        public int    Score       { get; set; }
    }

    private class TypicalValidator(SimpleModel obj) : FluentValidator<SimpleModel>(obj, postponeExecute: false)
    {
        protected override void Execute()
        {
            For(() => Object, "Simple Model").NotNull();

            if (Object != null)
            {
                For(() => Object.Name, "Name").NotNullOrWhiteSpace();
                For(() => Object.Description, "Description").NotInteger();
                For(() => Object.Color, "Color").In(Red, Green).IsEnumValue<Color>();
                For(() => Object.Status, "Status").Is("Active").IsNot("Deleted");
                For(() => Object.Score, "Score").NotZero().Above(0).Min(1).Max(100);
            }
        }
    }

    private static SimpleModel ValidModel() => new() 
    {
        Name        = "Alice",
        Description = "A lovely person",
        Color       = Red,
        Status      = "Active",
        Score       = 50
    };

    [TestMethod]
    public void TypicalValidator_ValidModel_IsValid()
    {
        SimpleModel model = ValidModel();
        IValidator validator = new TypicalValidator(model);
        IsTrue(validator.IsValid);
    }

    [TestMethod]
    public void TypicalValidator_NullModel_NotValid()
    {
        IValidator validator = new TypicalValidator(null);
        IsFalse(validator.IsValid);
        
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Simple Model", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Simple Model");
    }

    [TestMethod]
    public void TypicalValidator_EmptyName_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Name = "";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);
        
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Name", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Name");
    }

    [TestMethod]
    public void TypicalValidator_IntegerDescription_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Description = "42";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Description", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Description", "integer");
    }

    [TestMethod]
    public void TypicalValidator_ColorNotInList_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Color = Blue;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Color", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Color");
    }

    [TestMethod]
    public void TypicalValidator_StatusNotActive_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Status = "Inactive";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Status", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Status", "Active");
    }

    [TestMethod]
    public void TypicalValidator_StatusDeleted_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Status = "Deleted";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(2, validator.ValidationMessages.Count);
        Contains("Status", validator.ValidationMessages[0].Text);
        Contains("Status", validator.ValidationMessages[1].Text);
        Throws(() => validator.Verify(), "Status", "Deleted");
    }

    [TestMethod]
    public void TypicalValidator_ZeroScore_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Score = 0;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(3, validator.ValidationMessages.Count);
        Contains("Score", validator.ValidationMessages[0].Text);
        Contains("Score", validator.ValidationMessages[1].Text);
        Contains("Score", validator.ValidationMessages[2].Text);
        Throws(() => validator.Verify(), """
                                         Score is required.
                                         Score is not above 0.
                                         Score must be at least 1.
                                         """);
    }

    [TestMethod]
    public void TypicalValidator_ScoreTooHigh_NotValid()
    {
        SimpleModel model = ValidModel();
        model.Score = 101;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Score", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Score", "100");
    }
}
