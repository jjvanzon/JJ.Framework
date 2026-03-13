namespace JJ.Framework.Validation.Legacy.Tests;

[TestClass]
public class ValidatorBaseTests
{
    private class EmptyValidator : ValidatorBase<string>
    {
        public EmptyValidator(string obj) : base(obj) { }
        protected override void Execute() { }
    }

    private class InvalidValidator : ValidatorBase<string>
    {
        public InvalidValidator(string obj) : base(obj) { }
        protected override void Execute()
            => ValidationMessages.Add("key", "error message");
    }

    private class ParentExecutingGenericSub : ValidatorBase<string>
    {
        public ParentExecutingGenericSub(string obj) : base(obj) { }
        protected override void Execute() => Execute<InvalidValidator>();
    }

    private class ParentExecutingGenericSubWithPrefix : ValidatorBase<string>
    {
        public ParentExecutingGenericSubWithPrefix(string obj) : base(obj) { }
        protected override void Execute() => Execute<InvalidValidator>("Pre: ");
    }

    private class ParentExecutingTypeSub : ValidatorBase<string>
    {
        public ParentExecutingTypeSub(string obj) : base(obj) { }
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
    public void Execute_SubValidator_MergesMessages()
    {
        var parent = new EmptyValidator("test");
        var sub = new InvalidValidator("test");
        parent.Execute(sub, null);
        IsFalse(parent.IsValid);
    }

    [TestMethod]
    public void Execute_SubValidator_WithPrefix_PrependsPrefixToMessage()
    {
        var parent = new EmptyValidator("test");
        var sub = new InvalidValidator("test");
        parent.Execute(sub, "Prefix: ");
        AreEqual("Prefix: error message", parent.ValidationMessages[0].Text);
    }

    [TestMethod]
    public void Execute_SubValidator_NullValidator_Throws()
        => Throws(() => new EmptyValidator("test").Execute(null, null), "validator");

    [TestMethod]
    public void Execute_GenericSubValidator_MergesMessages()
    {
        var validator = new ParentExecutingGenericSub("test");
        IsFalse(validator.IsValid);
        AreEqual(1, validator.ValidationMessages.Count);
    }

    [TestMethod]
    public void Execute_GenericSubValidatorWithPrefix_PrependsPrefixToMessage()
    {
        var validator = new ParentExecutingGenericSubWithPrefix("test");
        AreEqual("Pre: error message", validator.ValidationMessages[0].Text);
    }

    [TestMethod]
    public void Execute_TypeSubValidator_MergesMessages()
    {
        var validator = new ParentExecutingTypeSub("test");
        IsFalse(validator.IsValid);
        AreEqual(1, validator.ValidationMessages.Count);
    }
}
