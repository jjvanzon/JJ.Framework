// ReSharper disable UnusedMember.Local
// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable PropertyCanBeMadeInitOnly.Local

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
    private class FluentValidatorWithDelegate : FluentValidator<object>
    {
        private readonly Action<FluentValidatorWithDelegate> _impl;

        public FluentValidatorWithDelegate(object model, Action<FluentValidatorWithDelegate> impl)
            : base(model, postponeExecute: true)
        {
            _impl = impl;
            Execute();
        }

        protected override void Execute() => _impl(this);
    }

    private static FluentValidatorWithDelegate Validate(object model, Action<FluentValidatorWithDelegate> impl) => new (model, impl);


    // NotNull

    [TestMethod]
    public void NotNull_Null_AddsMessage()
    {
        IsFalse(Validate(model: null, validator => validator.For(null, "Name", "Name").NotNull()).IsValid);
    }

    [TestMethod]
    public void NotNull_NotNull_NoMessage()
        => IsTrue(Validate(model: "Alice", validator => validator.For("Alice", "Name", "Name").NotNull()).IsValid);

    // NotNullOrWhiteSpace

    [TestMethod]
    public void NotNullOrWhiteSpace_Null_AddsMessage()
        => IsFalse(Validate(model: null, validator => validator.For(null, "Name", "Name").NotNullOrWhiteSpace()).IsValid);

    [TestMethod]
    public void NotNullOrWhiteSpace_Whitespace_AddsMessage()
        => IsFalse(Validate(model: "  ", validator => validator.For("  ", "Name", "Name").NotNullOrWhiteSpace()).IsValid);

    [TestMethod]
    public void NotNullOrWhiteSpace_ValidString_NoMessage()
        => IsTrue(Validate(model: "hello", validator => validator.For("hello", "Name", "Name").NotNullOrWhiteSpace()).IsValid);

    // In

    [TestMethod]
    public void In_ValueInList_NoMessage()
        => IsTrue(Validate(model: "b", validator => validator.For("b", "Name", "Name").In("a", "b", "c")).IsValid);

    [TestMethod]
    public void In_ValueNotInList_AddsMessage()
        => IsFalse(Validate(model: "z", validator => validator.For("z", "Name", "Name").In("a", "b", "c")).IsValid);

    [TestMethod]
    public void In_EmptyValue_NoMessage()
        => IsTrue(Validate(model: "", validator => validator.For("", "Name", "Name").In("a", "b", "c")).IsValid);

    [TestMethod]
    public void In_NullPossibleValues_Throws()
        => Throws(() => Validate(model: "Alice", validator => validator.For("Alice", "Name", "Name").In((object[])null)), "possibleValues");

    // Is

    [TestMethod]
    public void Is_ValueMatches_NoMessage()
        => IsTrue(Validate(model: "Alice", validator => validator.For("Alice", "Name", "Name").Is("Alice")).IsValid);

    [TestMethod]
    public void Is_ValueMismatch_AddsMessage()
        => IsFalse(Validate(model: "Bob", validator => validator.For("Bob", "Name", "Name").Is("Alice")).IsValid);

    [TestMethod]
    public void Is_EmptyString_NoMessage()
        => IsTrue(Validate(model: "", validator => validator.For("", "Name", "Name").Is("Alice")).IsValid);

    // IsNot

    [TestMethod]
    public void IsNot_ValueMismatch_NoMessage()
        => IsTrue(Validate(model: "Bob", validator => validator.For("Bob", "Name", "Name").IsNot("Alice")).IsValid);

    [TestMethod]
    public void IsNot_ValueMatches_AddsMessage()
        => IsFalse(Validate(model: "Alice", validator => validator.For("Alice", "Name", "Name").IsNot("Alice")).IsValid);

    [TestMethod]
    public void IsNot_EmptyString_NoMessage()
        => IsTrue(Validate(model: "", validator => validator.For("", "Name", "Name").IsNot("Alice")).IsValid);

    // NotZero

    [TestMethod]
    public void NotZero_Zero_AddsMessage()
        => IsFalse(Validate(model: 0, validator => validator.For(0, "Name", "Name").NotZero()).IsValid);

    [TestMethod]
    public void NotZero_NonZero_NoMessage()
        => IsTrue(Validate(model: 1, validator => validator.For(1, "Name", "Name").NotZero()).IsValid);

    // Above

    [TestMethod]
    public void Above_ValueAboveMin_NoMessage()
        => IsTrue(Validate(model: 5, validator => validator.For(5, "Name", "Name").Above(3)).IsValid);

    [TestMethod]
    public void Above_ValueEqualsMin_AddsMessage()
        => IsFalse(Validate(model: 3, validator => validator.For(3, "Name", "Name").Above(3)).IsValid);

    [TestMethod]
    public void Above_ValueBelowMin_AddsMessage()
        => IsFalse(Validate(model: 1, validator => validator.For(1, "Name", "Name").Above(3)).IsValid);

    [TestMethod]
    public void Above_NullValue_NoMessage()
        => IsTrue(Validate(model: null, validator => validator.For(null, "Name", "Name").Above(3)).IsValid);

    // Min

    [TestMethod]
    public void Min_ValueAtMin_NoMessage()
        => IsTrue(Validate(model: 3, validator => validator.For(3, "Name", "Name").Min(3)).IsValid);

    [TestMethod]
    public void Min_ValueAboveMin_NoMessage()
        => IsTrue(Validate(model: 5, validator => validator.For(5, "Name", "Name").Min(3)).IsValid);

    [TestMethod]
    public void Min_ValueBelowMin_AddsMessage()
        => IsFalse(Validate(model: 1, validator => validator.For(1, "Name", "Name").Min(3)).IsValid);

    // Max

    [TestMethod]
    public void Max_ValueAtMax_NoMessage()
        => IsTrue(Validate(model: 3, validator => validator.For(3, "Name", "Name").Max(3)).IsValid);

    [TestMethod]
    public void Max_ValueBelowMax_NoMessage()
        => IsTrue(Validate(model: 1, validator => validator.For(1, "Name", "Name").Max(3)).IsValid);

    [TestMethod]
    public void Max_ValueAboveMax_AddsMessage()
        => IsFalse(Validate(model: 5, validator => validator.For(5, "Name", "Name").Max(3)).IsValid);

    // NotInteger

    [TestMethod]
    public void NotInteger_IntegerString_AddsMessage()
        => IsFalse(Validate(model: "42", validator => validator.For("42", "Name", "Name").NotInteger()).IsValid);

    [TestMethod]
    public void NotInteger_NonIntegerString_NoMessage()
        => IsTrue(Validate(model: "hello", validator => validator.For("hello", "Name", "Name").NotInteger()).IsValid);

    [TestMethod]
    public void NotInteger_EmptyString_NoMessage()
        => IsTrue(Validate(model: "", validator => validator.For("", "Name", "Name").NotInteger()).IsValid);

    // IsEnumValue

    [TestMethod]
    public void IsEnumValue_ValidValue_NoMessage()
        => IsTrue(Validate(model: 1, validator => validator.For(1, "Name", "Name").IsEnumValue<Color>()).IsValid);

    [TestMethod]
    public void IsEnumValue_InvalidValue_AddsMessage()
        => IsFalse(Validate(model: 99, validator => validator.For(99, "Name", "Name").IsEnumValue<Color>()).IsValid);

    [TestMethod]
    public void IsEnumValue_EmptyString_NoMessage()
        => IsTrue(Validate(model: "", validator => validator.For("", "Name", "Name").IsEnumValue<Color>()).IsValid);

    // For guard clauses

    [TestMethod]
    public void For_NullPropertyKey_Throws()
        => Throws(() => Validate(model: null, validator => validator.For(null, null, "name")), "propertyKey");

    [TestMethod]
    public void For_NullPropertyDisplayName_Throws()
        => Throws(() => Validate(model: null, validator => validator.For(null, "key", null)), "propertyDisplayName");

    // For with expression

    [TestMethod]
    public void For_WithExpression_Null_AddsMessage()
    {
        var model = new SimpleModel(); // Name is null by default
        IsFalse(Validate(model: null, validator => validator.For(() => model.Name, "Name").NotNull()).IsValid);
    }

    [TestMethod]
    public void For_WithExpression_NotNull_NoMessage()
    {
        var model = new SimpleModel { Name = "hello" };
        IsTrue(Validate(model: null, validator => validator.For(() => model.Name, "Name").NotNull()).IsValid);
    }
}
