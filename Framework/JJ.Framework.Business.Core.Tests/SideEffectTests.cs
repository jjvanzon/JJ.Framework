
#pragma warning disable IDE0290

namespace JJ.Framework.Business.Core.Tests;

[TestClass]
public class SideEffectTests
{
    private class DelegateSideEffect : ISideEffect
    {
        private readonly Action _action;

        public DelegateSideEffect(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Execute() => _action();
    }

    [TestMethod]
    public void SideEffect_Execute_CallsDelegate()
    {
        bool wasCalled = false;
        ISideEffect sideEffect = new DelegateSideEffect(() => wasCalled = true);
        sideEffect.Execute();
        IsTrue(wasCalled);
    }

    [TestMethod]
    public void SideEffect_WithDelegate_Exception_Propagates()
    {
        ISideEffect sideEffect = new DelegateSideEffect(() => throw new InvalidOperationException("boom"));
        Throws<InvalidOperationException>(() => sideEffect.Execute(), "boom");
    }

    private class InitNameSideEffect : ISideEffect
    {
        private readonly Question _entity;

        public InitNameSideEffect(Question entity)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
        }

        public void Execute()
        {
            if (!Has(_entity.Name))
            {
                _entity.Name = "New Name";
            }
        }
    }

    [TestMethod]
    public void SideEffect_InitName_ChangesEntityProperty()
    {
        Question entity = CreateEmptyQuestion();
        IsFalse(entity.Name == "New Name");

        new InitNameSideEffect(entity).Execute();

        IsTrue(entity.Name.Is("New Name"));
    }

    [TestMethod]
    public void SideEffect_InitName_ConstructorGuardsAgainstNull()
    {
        Question? nullEntity = null;
        Throws(() => new InitNameSideEffect(nullEntity!), "entity", "null");
    }
}
