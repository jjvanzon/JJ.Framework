using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Reflection;
using static JJ.Framework.IO.Legacy.StreamHelper;

namespace JJ.Framework.IO.Core
{
    public static class StreamHelperLegacy
    {
        public static Stream StringToStream(string text, Encoding encoding, bool includeByteOrderMark = false)
        {
            byte[] bytes = StringToBytes(text, encoding, includeByteOrderMark);
            Stream stream = BytesToStream(bytes);
            return stream;
        }

        public static byte[] StringToBytes(string text, Encoding encoding, bool includeByteOrderMark = false)
        {
            if (encoding == null) throw new NullException(() => encoding);

            byte[] bytes = encoding.GetBytes(text);

            if (Equals(encoding, Encoding.UTF8) && includeByteOrderMark)
            {
                bytes = encoding.GetPreamble().Concat(bytes).ToArray();
            }

            return bytes;
        }

    }
}
