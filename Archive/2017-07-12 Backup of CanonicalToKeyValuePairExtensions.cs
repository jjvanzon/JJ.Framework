//using System;
//using System.Collections.Generic;
//using System.Linq;
//using JetBrains.Annotations;
//using JJ.Framework.Exceptions;
//using Canonicals = JJ.Data.Canonical;

//namespace JJ.Business.Canonical
//{
//    public static class CanonicalToKeyValuePairExtensions
//    {
//        public static KeyValuePair<string, string> ToKeyValuePair([NotNull] this Canonicals.MessageDto sourceEntity)
//        {
//            if (sourceEntity == null) throw new NullException(() => sourceEntity);

//            return new KeyValuePair<string, string>(sourceEntity.Key, sourceEntity.Text);
//        }

//        public static IList<KeyValuePair<string, string>> ToKeyValuePairs([NotNull] this IEnumerable<Canonicals.MessageDto> sourceList)
//        {
//            if (sourceList == null) throw new NullException(() => sourceList);

//            var destList = sourceList.Select(sourceItem => sourceItem.ToKeyValuePair()).ToList();

//            return destList;
//        }
//    }
//}
