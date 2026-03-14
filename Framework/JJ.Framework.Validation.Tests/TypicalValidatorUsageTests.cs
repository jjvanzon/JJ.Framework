// ReSharper disable ExpressionIsAlwaysNull

namespace JJ.Framework.Validation.Legacy.Tests;

#if !NET9_0_OR_GREATER
[Suppress("Trimmer", "IL2026", Justification = ArrayInit + " " + WhenShowIndexerValues)]
#endif
[TestClass]
public class TypicalValidatorUsageTests
{
    private class TypicalValidator(TestModel obj) : FluentValidator<TestModel>(obj, postponeExecute: false)
    {
        protected override void Execute()
        {
            For(() => Object, "Simple Model").NotNull();

            if (Object != null)
            {
                For(() => Object.Name, "Name").NotNullOrWhiteSpace();
                For(() => Object.Description, "Description").NotInteger();
                For(() => Object.Color, "Color").In(Red, Green).IsEnumValue<ColorEnum>();
                For(() => Object.Status, "Status").Is("Active").IsNot("Deleted");
                For(() => Object.Score, "Score").NotZero().Above(0).Min(1).Max(100);
            }
        }
    }

    private static TestModel CreateValidModel() => new() 
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
        // Use
        TestModel model = CreateValidModel();
        IValidator validator = new TypicalValidator(model);
        IsTrue(validator.IsValid);
    }

    [TestMethod]
    public void TypicalValidator_NullModel_NotValid()
    {
        // Use
        IValidator validator = new TypicalValidator(null);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Simple Model", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Simple Model");
    }

    [TestMethod]
    public void TypicalValidator_EmptyName_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Name = "";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Name", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Name");
    }

    [TestMethod]
    public void TypicalValidator_IntegerDescription_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Description = "42";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Description", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Description", "integer");
    }

    [TestMethod]
    public void TypicalValidator_ColorNotInList_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Color = Blue;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Color", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Color");
    }

    [TestMethod]
    public void TypicalValidator_StatusNotActive_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Status = "Inactive";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Status", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Status", "Active");
    }

    [TestMethod]
    public void TypicalValidator_StatusDeleted_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Status = "Deleted";
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(2, validator.ValidationMessages.Count);
        Contains("Status", validator.ValidationMessages[0].Text);
        Contains("Status", validator.ValidationMessages[1].Text);
        Throws(() => validator.Verify(), "Status", "Deleted");
    }

    [TestMethod]
    public void TypicalValidator_ZeroScore_NotValid()
    {
        // Use
        TestModel model = CreateValidModel();
        model.Score = 0;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
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
        // Use
        TestModel model = CreateValidModel();
        model.Score = 101;
        IValidator validator = new TypicalValidator(model);
        IsFalse(validator.IsValid);

        // Assert
        AreEqual(1, validator.ValidationMessages.Count);
        Contains("Score", validator.ValidationMessages[0].Text);
        Throws(() => validator.Verify(), "Score", "100");
    }

    // Escape guards (null/empty skips irrelevant checks)

    /// <summary>
    /// When the value is null, methods that would produce irrelevant messages bail out early.
    /// E.g. if a name is missing, we don't also want to report it's not an integer.
    /// </summary>
    [TestMethod]
    public void EmptyValue_SkipsIrrelevantChecks()
    {
        var validator = new TestValidator();

        object? emptyScore = null;

        validator.For(emptyScore, "TotalScore", "Total Score")
                 .NotNull()
                 .NotZero()
                 .NotInteger()
                 .In("Active", "Inactive", "Pending")
                 .Is("Active")
                 .IsNot("Deleted")
                 .Above(0)
                 .Min(1)
                 .Max(100)
                 .IsEnumValue<ColorEnum>();

        IsFalse  (validator.IsValid);
        NotNull  (validator.ValidationMessages);
        AreEqual (1, validator.ValidationMessages.Count);
        IsNotNull(validator.ValidationMessages[0]);
        AreEqual ("TotalScore", validator.ValidationMessages[0].PropertyKey);
        AreEqual ("Total Score is required.", validator.ValidationMessages[0].Text);
        Throws   (() => validator.Verify(), "Total Score is required.");
    }

    [TestMethod]
    public void NonNullValue_ReportsMultipleMessages()
    {
        var validator = new TestValidator();

        object value = 0;

        validator.For(value, "TotalScore", "Total Score")
                 .NotNull()
                 .NotZero()
                 .Above(0)
                 .Min(1)
                 .Max(100)
                 .In("Active", "Inactive", "Pending")
                 .Is("Active")
                 .IsNot("Deleted")
                 .NotInteger()
                 .IsEnumValue<ColorEnum>();

        IsFalse(validator.IsValid);
        AreEqual(7, validator.ValidationMessages.Count);

        AreEqual("TotalScore", validator.ValidationMessages[0].PropertyKey);
        AreEqual("Total Score is required.", validator.ValidationMessages[0].Text);

        AreEqual("TotalScore", validator.ValidationMessages[1].PropertyKey);
        AreEqual("Total Score is not above 0.", validator.ValidationMessages[1].Text);

        AreEqual("TotalScore", validator.ValidationMessages[2].PropertyKey);
        AreEqual("Total Score must be at least 1.", validator.ValidationMessages[2].Text);

        AreEqual("TotalScore", validator.ValidationMessages[3].PropertyKey);
        AreEqual("Total Score should have one of the values: Active, Inactive, Pending.", validator.ValidationMessages[3].Text);

        AreEqual("TotalScore", validator.ValidationMessages[4].PropertyKey);
        AreEqual("Total Score should be Active.", validator.ValidationMessages[4].Text);

        AreEqual("TotalScore", validator.ValidationMessages[5].PropertyKey);
        AreEqual("Total Score cannot be an integer number.", validator.ValidationMessages[5].Text);

        AreEqual("TotalScore", validator.ValidationMessages[6].PropertyKey);
        AreEqual("Total Score does not have a valid value.", validator.ValidationMessages[6].Text);

        Throws(() => validator.Verify(), """
                                         Total Score is required.
                                         Total Score is not above 0.
                                         Total Score must be at least 1.
                                         Total Score should have one of the values: Active, Inactive, Pending.
                                         Total Score should be Active.
                                         Total Score cannot be an integer number.
                                         Total Score does not have a valid value.
                                         """);

    }
}
