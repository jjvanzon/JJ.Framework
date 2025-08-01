﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Common.Legacy 
{
    /// <inheritdoc cref="_keyvaluepairhelper" />
    public static class KeyValuePairHelper
    {
        /// <inheritdoc cref="_keyvaluepairhelper" />
        public static IDictionary<string, object> ConvertNamesAndValuesListToDictionary(params IList<object> namesAndValues)
        {
            var dictionary = new Dictionary<string, object>();
            ConvertNamesAndValuesListWithDelegate(namesAndValues, (x, y) => dictionary.Add(x, y));
            return dictionary;
        }

        /// <inheritdoc cref="_keyvaluepairhelper" />
        public static IList<KeyValuePair<string, object>> ConvertNamesAndValuesListToKeyValuePairs(params IList<object> namesAndValues)
        {
            var list = new List<KeyValuePair<string, object>>();
            ConvertNamesAndValuesListWithDelegate(namesAndValues, (x, y) => list.Add(new KeyValuePair<string,object>(x, y)));
            return list;
        }

        /// <inheritdoc cref="_keyvaluepairhelper" />
        private static void ConvertNamesAndValuesListWithDelegate(IList<object> namesAndValues, Action<string, object> addDelegate)
        {
            // Allow converting null to null.
            if (namesAndValues == null)
            {
                return;
            }

            if (namesAndValues.Count % 2 != 0) throw new Exception("namesAndValues.Count must be a multiple of 2.");

            for (int i = 0; i < namesAndValues.Count; i += 2)
            {
                object name = namesAndValues[i];
                object value = namesAndValues[i + 1];

                if (name == null) throw new Exception("Names in namesAndValues cannot contain nulls.");
                if (name.GetType() != typeof(string)) throw new Exception("Names in namesAndValues must be strings.");

                addDelegate((string)name, value);
            }
        }
    }
}
