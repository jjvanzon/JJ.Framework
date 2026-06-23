
#pragma warning disable IDE0002

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class EnvironmentHelperCoreTests
{
    [TestMethod]
    public void EnvironmentVariableIsDefined_True_Test()
    {
        (string key, string value) = RandomKeyAndValue();
        
        try
        {
            SetEnvironmentVariable(key, value);
            IsTrue(EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
        }
        finally
        {
            SetEnvironmentVariable(key, null);
        }
    }
    
    [TestMethod]
    public void EnvironmentVariableIsDefined_False_Test()
    {
        (string key, string value) = RandomKeyAndValue();
        
        IsFalse(EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
    }
    
    [TestMethod]
    public void EnvironmentVariableIsDefined_SetReset_Test()
    {
        (string key, string value) = RandomKeyAndValue();
        
        try
        {
            SetEnvironmentVariable(key, value);
            IsTrue(EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
        }
        finally
        {
            SetEnvironmentVariable(key, null);
            IsFalse(EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
        }
    }
    
    [TestMethod]
    public void EnvironmentHelper_IsNCrunch()
    {
        #if NCRUNCH
            IsTrue(EnvironmentHelper.IsNCrunch);
        #else
            IsFalse(EnvironmentHelper.IsNCrunch);
        #endif
    }
    
    [TestMethod]
    public void EnvironmentHelper_IsAzurePipelines()
    {
        var tfBuildEnvVal = Environment.GetEnvironmentVariable("TF_BUILD");
        AreEqual(string.Equals(tfBuildEnvVal, "True", OrdinalIgnoreCase), EnvironmentHelper.IsAzurePipelines);
    }

    private static (string key, string value) RandomKeyAndValue()
    {
        string guid  = $"{NewGuid()}";
        string key   = "TestKey-"   + guid;
        string value = "TestValue-" + guid;
        return (key, value);
    }
}