using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JJ.Framework.IO
{
    public static class StreamHelper
    {
        // TODO: These might not be the best ways to convert.

        public static byte[] StreamToBytes(Stream stream, int bufferSize = 8192)
        {
            if (stream == null) throw new ArgumentNullException("stream");

            // Use memory stream as an intermediate, because not all Stream types support the Length property.
            using (var stream2 = new MemoryStream())
            {
                Stream_PlatformSupport.CopyTo(stream, stream2);
                return stream2.ToArray();
            }
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        public static Stream StringToStream(string text, Encoding encoding)
        {
            byte[] bytes = StringToBytes(text, encoding);
            Stream stream = BytesToStream(bytes);
            return stream;
        }

        public static string StreamToString(Stream stream, Encoding encoding)
        {
            if (encoding == null) throw new ArgumentNullException("encoding");
            byte[] bytes = StreamToBytes(stream);
            string text = encoding.GetString(bytes);
            return text;
        }

        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            if (encoding == null) throw new ArgumentNullException("encoding");
            return encoding.GetBytes(text);
        }
    }
}
