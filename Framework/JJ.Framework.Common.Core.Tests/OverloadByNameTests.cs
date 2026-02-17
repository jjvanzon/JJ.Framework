// ReSharper disable MethodOverloadWithOptionalParameter

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class OverloadByNameTests
{

    [TestMethod]
    public void Test_OverloadByName()
    {
        AreEqual(30, MyMethod1(3));
        AreEqual(30, MyMethod1(param: 3));
        AreEqual(60, MyMethod1(differentParam: 3));
    }

    [TestMethod]
    public void Test_NameOvl()
    {
        AreEqual(150, MyMethod2(3));
        AreEqual(150, MyMethod2(param: 3));
        AreEqual(210, MyMethod2(differentParam: 3));
    }

    private int MyMethod1(int param) => param * 10;
    private int MyMethod1(int differentParam, OverloadByName ovl =default) => differentParam * 20;

    private int MyMethod2(int param) => param * 50;
    private int MyMethod2(int differentParam, NameOvl ovl = default) => differentParam * 70;

}
