// ReSharper disable ObjectCreationAsStatement
// ReSharper disable ExpressionIsAlwaysNull

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class SideEffectTests
{
    private class DelegateSideEffect(Action action) : ISideEffect
    {
        private readonly Action _action = action ?? throw new ArgumentNullException(nameof(action));

        public void Execute() => _action();
    }

    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [TestMethod]
    public void SideEffect_Execute_CallsDelegate()
    {
        bool wasCalled = false;
        ISideEffect sideEffect = new DelegateSideEffect(() => wasCalled = true);
        sideEffect.Execute();
        IsTrue(() => wasCalled);
    }

    [TestMethod]
    public void SideEffect_WithDelegate_Exception_Propagates()
    {
        ISideEffect sideEffect = new DelegateSideEffect(() => throw new InvalidOperationException("boom"));
        AssertHelper.ThrowsException<InvalidOperationException>(() => sideEffect.Execute(), "boom");
    }

    private class InitNameSideEffect(Question entity) : ISideEffect
    {
        private readonly Question _entity = entity ?? throw new ArgumentNullException(nameof(entity));

        public void Execute()
        {
            if (string.IsNullOrWhiteSpace(_entity.Name))
            {
                _entity.Name = "New Name";
            }
        }
    }

    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    [TestMethod]
    public void SideEffect_InitName_ChangesEntityProperty()
    {
        Question entity = CreateEmptyQuestion();

        IsFalse(() => string.Equals(entity.Name, "New Name"));

        new InitNameSideEffect(entity).Execute();

        IsTrue(() => string.Equals(entity.Name, "New Name"));
    }

    [TestMethod]
    public void SideEffect_InitName_ConstructorGuardsAgainstNull()
    {
        Question? nullEntity = null;
        ThrowsException<ArgumentNullException>(() => new InitNameSideEffect(nullEntity!));
    }
}
