using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable UnusedVariable
#pragma warning disable IDE0022 // Use expression body for methods

namespace JJ.Framework.Collections.Tests
{
    [TestClass]
    public class KeyValuePairHelperTests
    {
        [TestMethod]
        public void Demo_KeyValuePairHelper_ConvertNamesAndValuesListToDictionary()
        {
            MyMethod("Name1", 3, "Name2", 5, "Name3", 6);
        }

        void MyMethod(params object[] namesAndValues)
        {
            var dictionary = KeyValuePairHelper.ConvertNamesAndValuesListToDictionary(namesAndValues);
            // ...
        }
    }
}
