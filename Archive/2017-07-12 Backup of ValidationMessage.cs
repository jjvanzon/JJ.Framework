//using JJ.Framework.Exceptions;
//using System.Diagnostics;
//using JJ.Framework.PlatformCompatibility;

//namespace JJ.Framework.Validation
//{
//    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
//    public class ValidationMessage
//    {
//        public string Key { get; }
//        public string Text { get; }

//        public ValidationMessage(string key, string text)
//        {
//            if (String_PlatformSupport.IsNullOrWhiteSpace(key)) throw new NullOrWhiteSpaceException(() => key);
//            if (string.IsNullOrEmpty(text)) throw new NullException(() => text);

//            Key = key;
//            Text = text;
//        }

//        private string DebuggerDisplay => $"{Key}: {Text}";
//    }
//}
