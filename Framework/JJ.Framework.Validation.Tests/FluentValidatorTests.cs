// ReSharper disable ExpressionIsAlwaysNull
// ReSharper disable PropertyCanBeMadeInitOnly.Local
// ReSharper disable UnusedMember.Global

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
