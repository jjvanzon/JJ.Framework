using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class KeyValuePairHelper_Obsolete_Tests
    {
        [TestMethod]
        public void Test_KeyValuePairHelper_Obsolete_ConvertNamesAndValuesListToDictionary_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => KeyValuePairHelper_Obsolete_Accessor.ConvertNamesAndValuesListToDictionary(null),
                "Use JJ.Framework.Collections instead.");

        [TestMethod]
        public void Test_KeyValuePairHelper_Obsolete_ConvertNamesAndValuesListToKeyValuePairs_ThrowsException()
            => AssertHelper.ThrowsException_OrInnerException<NotSupportedException>(
                () => KeyValuePairHelper_Obsolete_Accessor.ConvertNamesAndValuesListToKeyValuePairs(null),
                "Use JJ.Framework.Collections instead.");
    }
}
