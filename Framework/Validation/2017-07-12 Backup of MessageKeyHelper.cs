//using JJ.Framework.Common;
//using JJ.Framework.Reflection;
//using System;
//using System.Linq.Expressions;
//using JetBrains.Annotations;

//namespace JJ.Framework.Validation
//{
//    internal static class MessageKeyHelper
//    {
//        public static string GetMessageKeyFromExpression([NotNull] Expression<Func<object>> keyExpression)
//        {
//            string key = ExpressionHelper.GetText(keyExpression, true);

//            // Always cut off the root object, e.g. "MyObject.MyProperty" becomes "MyProperty".
//            key = key.TrimStartUntil(".").TrimStart(".");

//            return key;
//        }
//    }
//}
