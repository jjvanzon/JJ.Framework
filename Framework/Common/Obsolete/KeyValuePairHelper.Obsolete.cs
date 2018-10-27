using System;
using System.Collections.Generic;
// ReSharper disable CheckNamespace
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global

namespace JJ.Framework.Common
{
    [Obsolete(OBSOLETE_MESSAGE, true)]
	public static class KeyValuePairHelper
    {
        private const string OBSOLETE_MESSAGE = "Use JJ.Framework.Collections instead.";

        [Obsolete(OBSOLETE_MESSAGE, true)]
        public static IDictionary<string, object> ConvertNamesAndValuesListToDictionary(IList<object> namesAndValues)
	        => throw new NotSupportedException(OBSOLETE_MESSAGE);

        [Obsolete(OBSOLETE_MESSAGE, true)]
		public static IList<KeyValuePair<string, object>> ConvertNamesAndValuesListToKeyValuePairs(IList<object> namesAndValues)
	        => throw new NotSupportedException(OBSOLETE_MESSAGE);
	}
}
