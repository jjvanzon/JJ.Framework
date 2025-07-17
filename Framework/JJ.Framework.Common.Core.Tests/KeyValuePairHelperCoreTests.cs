namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class KeyValuePairHelperCoreTests
{
    [TestMethod]
    public void KeyValuePairHelper_ConvertNamesAndValuesListToDictionary_Core_Test()
    {
        IDictionary<string, object> dictionary =
            KeyValuePairHelper.ConvertNamesAndValuesListToDictionary("Name1", 5, "Name2", 7, "Name3", 11);
        
        IsNotNull(dictionary);
        
        AreEqual(3, dictionary.Count);
        
        IsTrue(dictionary.ContainsKey("Name1"));
        IsTrue(dictionary.ContainsKey("Name2"));
        IsTrue(dictionary.ContainsKey("Name3"));
        
        AreEqual(5,  dictionary["Name1"]);
        AreEqual(7,  dictionary["Name2"]);
        AreEqual(11, dictionary["Name3"]);
    }
    
    [TestMethod]
    public void KeyValuePairHelper_ConvertNamesAndValuesListToKeyValuePairs_Core_Test()
    {
        IList<KeyValuePair<string, object>> list =
            KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs("Name1", 5, "Name2", 7, "Name3", 11);
        
        IsNotNull(list);
        
        AreEqual(3, list.Count);
        
        IsNotNull(list[0]);
        IsNotNull(list[1]);
        IsNotNull(list[2]);
        
        AreEqual("Name1", list[0].Key);
        AreEqual("Name2", list[1].Key);
        AreEqual("Name3", list[2].Key);
        
        AreEqual(5,  list[0].Value);
        AreEqual(7,  list[1].Value);
        AreEqual(11, list[2].Value);
    }
    
    /// <inheritdoc cref="_keyvaluepairnulltest" />
    [TestMethod]
    public void KeyValuePairHelper_ConvertNamesAndValuesListToDictionary_NullInput_Core_Test()
    {
        IDictionary<string, object> dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(null);
        IsNotNull(dictionary);
        AreEqual(0, dictionary.Count);
    }
    
    /// <inheritdoc cref="_keyvaluepairnulltest" />
    [TestMethod]
    public void KeyValuePairHelper_ConvertNamesAndValuesListToKeyValuePairs_NullInput_Core_Test()
    {
        IList<KeyValuePair<string, object>> list = KeyValuePairHelper.ConvertNamesAndValuesListToKeyValuePairs(null);
        IsNotNull(list);
        AreEqual(0, list.Count);
    }
}