//using System.Diagnostics;
//using JJ.Framework.Business.Helpers;
//using JJ.Framework.Exceptions;

//namespace JJ.Framework.Business
//{
//    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
//    public class Message
//    {
//        public Message(string key, string text)
//        {
//            if (string.IsNullOrEmpty(key)) throw new NullOrEmptyException(() => key);
//            if (string.IsNullOrEmpty(text)) throw new NullOrEmptyException(() => text);

//            Key = key;
//            Text = text;
//        }

//        public string Key { get; }
//        public string Text { get; }

//        private string DebuggerDisplay => DebuggerDisplayFormatter.GetDebuggerDisplay(this);
//    }
//}
