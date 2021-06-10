using System;
using System.Collections.Generic;
using JJ.Framework.Reflection;
// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Common.Tests
{
    internal static class KeyValuePairHelper_Obsolete_Accessor
    {
        private static readonly Accessor _accessor = new Accessor(Type.GetType( "JJ.Framework.Common.KeyValuePairHelper, JJ.Framework.Common"));

        public static IDictionary<string, object> ConvertNamesAndValuesListToDictionary(IList<object> namesAndValues)
            => _accessor.InvokeMethod(() => ConvertNamesAndValuesListToDictionary(namesAndValues));

        public static IList<KeyValuePair<string, object>> ConvertNamesAndValuesListToKeyValuePairs(IList<object> namesAndValues)
            => _accessor.InvokeMethod(() => ConvertNamesAndValuesListToKeyValuePairs(namesAndValues));
    }
}
