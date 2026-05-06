namespace JJ.Framework.Compilation.Core.Tests;

[TestClass]
public class RunningTargetFrameworkTests
{
    [TestMethod]
    public void RunningTargetFramework_WhenNet48_ReturnsNet48()
    {
        #if NET48 && !NCRUNCH
        AreEqual("net48", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet462_ReturnsNet462()
    {
        #if NET462
        AreEqual("net462", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet461_ReturnsNet461()
    {
        #if NET461
        AreEqual("net461", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet5_ReturnsNet5()
    {
        #if NET5_0
        AreEqual("net5.0", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet6_ReturnsNet6()
    {
        #if NET6_0
        AreEqual("net6.0", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet7_ReturnsNet7()
    {
        #if NET7_0
        AreEqual("net7.0", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet8_ReturnsNet8()
    {
        #if NET8_0
        AreEqual("net8.0", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet9_ReturnsNet9()
    {
        #if NET9_0
        AreEqual("net9.0", DotNet.RunningTargetFramework);
        #endif
    }

    [TestMethod]
    public void RunningTargetFramework_WhenNet10_ReturnsNet10()
    {
        #if NET10_0
        AreEqual("net10.0", DotNet.RunningTargetFramework);
        #endif
    }
}
