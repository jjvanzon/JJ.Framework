using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.IO
{
    /// <summary>
    /// Converts between string, Stream and byte[]. 
    /// Surprisingly different code is required for converting between those three,
    /// and this helper class makes it a bit more consistent.
    /// </summary>
    public static class StreamHelper
    {
        public static byte[] StreamToBytes(Stream stream, int bufferSize = 8192)
        {
            if (stream == null) throw new NullException(() => stream);

            if (!(stream is MemoryStream memoryStream))
            {
                // Use memory stream as an intermediate, because not all Stream types support the Length property.
                memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream, bufferSize);
            }

            return memoryStream.ToArray();
        }

        public static Stream BytesToStream(byte[] bytes) => new MemoryStream(bytes);

        public static string StreamToString(Stream stream, Encoding encoding)
        {
            if (encoding == null) throw new NullException(() => encoding);

            // Do not use Encoding.GetString, because it does not process the byte order mark correctly. StreamReader does.
            using (var reader = new StreamReader(stream, encoding))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

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

        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            if (encoding == null) throw new NullException(() => encoding);

            // Do not use Encoding.GetString, because it does not process the byte order mark correctly. 
            // StreamReader (used by StreamToString) does.
            Stream stream = BytesToStream(bytes);
            string text = StreamToString(stream, encoding);
            return text;
        }
    }
}