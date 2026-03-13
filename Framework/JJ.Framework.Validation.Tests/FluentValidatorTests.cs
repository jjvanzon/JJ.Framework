// ReSharper disable ExpressionIsAlwaysNull

namespace JJ.Framework.Validation.Legacy.Tests;

#if !NET9_0_OR_GREATER
[Suppress("Trimmer", "IL2026", Justification = ArrayInit + " " + WhenShowIndexerValues)]
#endif
[TestClass]
public class FluentValidatorTests
{
    public enum Color { Red = 1, Green = 2, Blue = 3 }

    private class SimpleModel
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Allows injecting the Execute method implementation.
    /// </summary>
    private class TestValidator : FluentValidator<object>
    {
        private readonly Action<TestValidator> _impl;

        public TestValidator(Action<TestValidator>? impl = null)
            : base(null, postponeExecute: true)
        {
            impl ??= _ => { };
            _impl = impl;
            Execute();
        }

        protected override void Execute() => _impl(this);
    }

    // NotNull

    [TestMethod]
    public void NotNull_Null_AddsMessage() 
        => IsFalse(new TestValidator(validator => validator.For(null, "FirstName", "First Name").NotNull()).IsValid);

    [TestMethod]
    public void NotNull_NotNull_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("Alice", "FirstName", "First Name").NotNull()).IsValid);

    // NotNullOrWhiteSpace

    [TestMethod]
    public void NotNullOrWhiteSpace_Null_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(null, "FirstName", "First Name").NotNullOrWhiteSpace()).IsValid);

    [TestMethod]
    public void NotNullOrWhiteSpace_Whitespace_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For("  ", "FirstName", "First Name").NotNullOrWhiteSpace()).IsValid);

    [TestMethod]
    public void NotNullOrWhiteSpace_ValidString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("hello", "FirstName", "First Name").NotNullOrWhiteSpace()).IsValid);

    // In

    [TestMethod]
    public void In_ValueInList_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("Inactive", "OrderStatus", "Order Status").In("Active", "Inactive", "Pending")).IsValid);

    [TestMethod]
    public void In_ValueNotInList_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For("Deleted", "OrderStatus", "Order Status").In("Active", "Inactive", "Pending")).IsValid);

    [TestMethod]
    public void In_EmptyValue_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("", "OrderStatus", "Order Status").In("Active", "Inactive", "Pending")).IsValid);

    [TestMethod]
    public void In_NullPossibleValues_Throws()
        => Throws(() => new TestValidator(validator => validator.For("Active", "OrderStatus", "Order Status").In((object[])null)), "possibleValues");

    // Is

    [TestMethod]
    public void Is_ValueMatches_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("Active", "OrderStatus", "Order Status").Is("Active")).IsValid);

    [TestMethod]
    public void Is_ValueMismatch_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For("Deleted", "OrderStatus", "Order Status").Is("Active")).IsValid);

    [TestMethod]
    public void Is_EmptyString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("", "OrderStatus", "Order Status").Is("Active")).IsValid);

    // IsNot

    [TestMethod]
    public void IsNot_ValueMismatch_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("Inactive", "OrderStatus", "Order Status").IsNot("Deleted")).IsValid);

    [TestMethod]
    public void IsNot_ValueMatches_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For("Deleted", "OrderStatus", "Order Status").IsNot("Deleted")).IsValid);

    [TestMethod]
    public void IsNot_EmptyString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("", "OrderStatus", "Order Status").IsNot("Deleted")).IsValid);

    // NotZero

    [TestMethod]
    public void NotZero_Zero_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(0, "TotalScore", "Total Score").NotZero()).IsValid);

    [TestMethod]
    public void NotZero_NonZero_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(50, "TotalScore", "Total Score").NotZero()).IsValid);

    // Above

    [TestMethod]
    public void Above_ValueAboveMin_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(5, "TotalScore", "Total Score").Above(3)).IsValid);

    [TestMethod]
    public void Above_ValueEqualsMin_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(3, "TotalScore", "Total Score").Above(3)).IsValid);

    [TestMethod]
    public void Above_ValueBelowMin_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(1, "TotalScore", "Total Score").Above(3)).IsValid);

    [TestMethod]
    public void Above_NullValue_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(null, "TotalScore", "Total Score").Above(3)).IsValid);

    // Min

    [TestMethod]
    public void Min_ValueAtMin_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(3, "TotalScore", "Total Score").Min(3)).IsValid);

    [TestMethod]
    public void Min_ValueAboveMin_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(5, "TotalScore", "Total Score").Min(3)).IsValid);

    [TestMethod]
    public void Min_ValueBelowMin_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(1, "TotalScore", "Total Score").Min(3)).IsValid);

    // Max

    [TestMethod]
    public void Max_ValueAtMax_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(3, "TotalScore", "Total Score").Max(3)).IsValid);

    [TestMethod]
    public void Max_ValueBelowMax_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(1, "TotalScore", "Total Score").Max(3)).IsValid);

    [TestMethod]
    public void Max_ValueAboveMax_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(5, "TotalScore", "Total Score").Max(3)).IsValid);

    // NotInteger

    [TestMethod]
    public void NotInteger_IntegerString_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For("42", "ItemDescription", "Item Description").NotInteger()).IsValid);

    [TestMethod]
    public void NotInteger_NonIntegerString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("hello", "ItemDescription", "Item Description").NotInteger()).IsValid);

    [TestMethod]
    public void NotInteger_EmptyString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("", "ItemDescription", "Item Description").NotInteger()).IsValid);

    // IsEnumValue

    [TestMethod]
    public void IsEnumValue_ValidValue_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For(1, "FavoriteColor", "Favorite Color").IsEnumValue<Color>()).IsValid);

    [TestMethod]
    public void IsEnumValue_InvalidValue_AddsMessage()
        => IsFalse(new TestValidator(validator => validator.For(99, "FavoriteColor", "Favorite Color").IsEnumValue<Color>()).IsValid);

    [TestMethod]
    public void IsEnumValue_EmptyString_NoMessage()
        => IsTrue(new TestValidator(validator => validator.For("", "FavoriteColor", "Favorite Color").IsEnumValue<Color>()).IsValid);

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
                 .IsEnumValue<Color>();

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
                 .IsEnumValue<Color>();

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

        // Verify() should throw an exception containing all messages in order.
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

    // For guard clauses

    [TestMethod]
    public void For_NullPropertyKey_Throws()
        => Throws(() => new TestValidator(validator => validator.For(null, null, "name")), "propertyKey");

    [TestMethod]
    public void For_NullPropertyDisplayName_Throws()
        => Throws(() => new TestValidator(validator => validator.For(null, "key", null)), "propertyDisplayName");

    // For with expression

    [TestMethod]
    public void For_WithExpression_Null_AddsMessage()
    {
        var model = new SimpleModel(); // Name is null by default
        IsFalse(new TestValidator(validator => validator.For(() => model.Name, "Full Name").NotNull()).IsValid);
    }

    [TestMethod]
    public void For_WithExpression_NotNull_NoMessage()
    {
        var model = new SimpleModel { Name = "hello" };
        IsTrue(new TestValidator(validator => validator.For(() => model.Name, "Full Name").NotNull()).IsValid);
    }
}
