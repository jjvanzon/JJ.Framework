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

    private class FieldSideEffect : ISideEffect
    {
        private readonly Entity _entity;
        private readonly string _newName;

        public FieldSideEffect(Entity entity, string newName)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _newName = newName ?? throw new ArgumentNullException(nameof(newName));
        }

        public void Execute() => _entity.Name = _newName;
    }

    [TestMethod]
    public void SideEffect_Execute_CallsAction()
    {
        bool wasCalled = false;
        ISideEffect sideEffect = new DelegateSideEffect(() => wasCalled = true);
        sideEffect.Execute();
        IsTrue(wasCalled);
    }

    [TestMethod]
    public void SideEffect_Exception_Propagates()
    {
        ISideEffect sideEffect = new DelegateSideEffect(() => throw new InvalidOperationException("boom"));
        Throws<InvalidOperationException>(() => sideEffect.Execute(), "boom");
    }

    [TestMethod]
    public void SideEffect_Field_ChangesEntityProperty()
    {
        var entity = CreateSimpleEntity();
        IsFalse(entity.Name == "Updated");

        ISideEffect sideEffect = new FieldSideEffect(entity, "Updated");
        sideEffect.Execute();

        IsTrue(entity.Name == "Updated");
    }

    [TestMethod]
    public void SideEffect_Field_ConstructorGuardsAgainstNull()
    {
        Throws<ArgumentNullException>(() => new FieldSideEffect(null!, "x"));
        Throws<ArgumentNullException>(() => new FieldSideEffect(CreateSimpleEntity(), null!));
    }
}
