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
}
