//#pragma warning disable IDE0200

namespace JJ.Framework.Reflection.Legacy.Tests;

[TestClass]
public class TypeExtensions_TestsEx
{
    [TestMethod]
    public void Test_GetUnderlyingNullableType()
    {
        AreEqual(typeof(int), typeof(int?).GetUnderlyingNullableType());
        AreEqual(typeof(bool), typeof(bool?).GetUnderlyingNullableType());
    }

    [TestMethod]
    public void Test_IsReferenceType()
    {
        IsTrue(typeof(string).IsReferenceType());
        IsTrue(typeof(object).IsReferenceType());
        IsTrue(typeof(int[]).IsReferenceType());
        IsTrue(typeof(IEnumerable<int>).IsReferenceType());
        IsFalse(typeof(int).IsReferenceType());
        IsFalse(typeof(int?).IsReferenceType());
    }
}
