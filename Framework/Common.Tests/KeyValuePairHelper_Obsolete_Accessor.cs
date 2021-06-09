using System;
using System.Collections.Generic;
using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Tests
{
    internal static class KeyValuePairHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(Type.GetType( "JJ.Framework.Common.KeyValuePairHelper, JJ.Framework.Common"));

        public static IDictionary<string, object> ConvertNamesAndValuesListToDictionary(IList<object> namesAndValues)
            => (IDictionary<string, object>)_accessor.InvokeMethod(nameof(ConvertNamesAndValuesListToDictionary), namesAndValues);

        public static IList<KeyValuePair<string, object>> ConvertNamesAndValuesListToKeyValuePairs(IList<object> namesAndValues)
            => (IList<KeyValuePair<string, object>>)_accessor.InvokeMethod(nameof(ConvertNamesAndValuesListToKeyValuePairs), namesAndValues);
    }
}
