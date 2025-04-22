using static System.Environment;
using static System.Guid;

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class EnvironmentHelperTests
{
    [TestMethod]
    public void EnvironmentVariableIsDefined_True_Test()
    {
        (string key, string value) = RandomKeyAndValue();
        
        try
        {
            SetEnvironmentVariable(key, value);
            IsTrue(() => EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
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
        
        IsFalse(() => EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
    }
    
    [TestMethod]
    public void EnvironmentVariableIsDefined_SetReset_Test()
    {
        (string key, string value) = RandomKeyAndValue();
        
        try
        {
            SetEnvironmentVariable(key, value);
            IsTrue(() => EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
        }
        finally
        {
            SetEnvironmentVariable(key, null);
            IsFalse(() => EnvironmentHelper.EnvironmentVariableIsDefined(key, value));
        }
    }
    
    private static (string key, string value) RandomKeyAndValue()
    {
        string guid  = $"{NewGuid()}";
        string key   = "TestKey-"   + guid;
        string value = "TestValue-" + guid;
        return (key, value);
    }
}