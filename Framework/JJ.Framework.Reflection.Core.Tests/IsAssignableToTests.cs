namespace JJ.Framework.Reflection.Core.Tests;

[TestClass]
public class IsAssignableToTests
{
    [TestMethod]
    public void IsAssignableTo_True()
    {
        IsTrue(() => typeof(int).IsAssignableTo(typeof(object)));
        IsTrue(() => typeof(string).IsAssignableTo(typeof(object)));
        IsTrue(() => typeof(Exception).IsAssignableTo(typeof(Exception)));
        IsTrue(() => typeof(NullReferenceException).IsAssignableTo(typeof(Exception)));
        IsTrue(() => typeof(ArgumentNullException).IsAssignableTo(typeof(Exception)));
        IsTrue(() => typeof(ArgumentException).IsAssignableTo(typeof(Exception)));
        IsTrue(() => typeof(DummyClass).IsAssignableTo(typeof(IDummy)));
    }
    
    [TestMethod]
    public void IsAssignableTo_False()
    {
        IsFalse(() => typeof(object).IsAssignableTo(typeof(int)));
        IsFalse(() => typeof(object).IsAssignableTo(typeof(string)));
        IsFalse(() => typeof(Exception).IsAssignableTo(typeof(NullReferenceException)));
        IsFalse(() => typeof(IDummy).IsAssignableTo(typeof(DummyClass)));
    }
}
