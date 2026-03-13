namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidatorBaseTests
{
    private class EmptyValidator(string obj) : ValidatorBase<string>(obj)
    {
        protected override void Execute() { }
    }

    private class InvalidValidator(string obj) : ValidatorBase<string>(obj)
    {
        protected override void Execute()
            => ValidationMessages.Add("key", "error message");
    }

    private class ValidatorWithGenericSub(string obj) : ValidatorBase<string>(obj)
    {
        protected override void Execute() => Execute<InvalidValidator>();
    }

    private class ValidatorWithGenericSub_WithPrefix(string obj) : ValidatorBase<string>(obj)
    {
        protected override void Execute() => Execute<InvalidValidator>("Pre: ");
    }

    private class ValidatorWithSubWithType(string obj) : ValidatorBase<string>(obj)
    {
        protected override void Execute() => Execute(typeof(InvalidValidator));
    }

    [TestMethod]
    public void IsValid_True_WhenNoMessages()
        => IsTrue(new EmptyValidator("test").IsValid);

    [TestMethod]
    public void IsValid_False_WhenMessageAdded()
        => IsFalse(new InvalidValidator("test").IsValid);

    [TestMethod]
    public void Verify_DoesNotThrow_WhenValid()
        => new EmptyValidator("test").Verify();

    [TestMethod]
    public void Verify_Throws_WhenInvalid()
        => Throws(() => new InvalidValidator("test").Verify(), "error message");

    [TestMethod]
    public void Execute_InjectedSubValidator_MergesMessages()
    {
        EmptyValidator parent = new EmptyValidator("test"); // NOTE: Can't inject sub-validator on IValidator.
        IValidator sub = new InvalidValidator("test");
        parent.Execute(sub, null); // NOTE: This is the only Execute overload that's public for some reason.
        IsFalse(parent.IsValid);
    }

    [TestMethod]
    public void Execute_InjectedSubValidator_AddsPrefix()
    {
        EmptyValidator parent = new EmptyValidator("test"); // NOTE: Can't inject sub-validator on IValidator.
        IValidator sub = new InvalidValidator("test");
        parent.Execute(sub, "Prefix: ");
        AreEqual("Prefix: error message", parent.ValidationMessages[0].Text);
    }

    [TestMethod]
    public void Execute_GenericSubValidator_MergesMessages()
    {
        IValidator validator = new ValidatorWithGenericSub("test");
        IsFalse(validator.IsValid);
        AreEqual(1, validator.ValidationMessages.Count);
    }

    [TestMethod]
    public void Execute_GenericSubValidator_AadsPrefix()
    {
        IValidator validator = new ValidatorWithGenericSub_WithPrefix("test");
        AreEqual("Pre: error message", validator.ValidationMessages[0].Text);
    }

    [TestMethod]
    public void Execute_TypeSubValidator_MergesMessages()
    {
        IValidator validator = new ValidatorWithSubWithType("test");
        IsFalse(validator.IsValid);
        AreEqual(1, validator.ValidationMessages.Count);
    }

    [TestMethod]
    public void Execute_SubValidator_NullValidator_Throws()
        => Throws(() => new EmptyValidator("test").Execute(null, null), "validator");
}
