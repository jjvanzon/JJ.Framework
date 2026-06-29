namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class NotNullIfNotNull_Tests
{
    private readonly NotNullIfNotNull_TestBase _testBase = new();

    [TestMethod]
    public void Test_NotNullIfNotNull_Constructor() => _testBase.Test_NotNullIfNotNull_Constructor();

    [TestMethod]
    public void Test_NotNullIfNotNull_ParamNull_ReturnObjNull() => _testBase.Test_NotNullIfNotNull_ParamNull_ReturnObjNull();

    [TestMethod]
    public void Test_NotNullIfNotNull_ParamEmptyString_ReturnObjNotNull() => _testBase.Test_NotNullIfNotNull_ParamEmptyString_ReturnObjNotNull();

    [TestMethod]
    public void Test_NotNullIfNotNull_ParalFilled_ReturnObjNotNull() => _testBase.Test_NotNullIfNotNull_ParalFilled_ReturnObjNotNull();
}
