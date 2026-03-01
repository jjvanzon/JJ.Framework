using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
    /// <inheritdoc cref="_streamhelper" />
    public static class StreamHelper
    {
        /// <inheritdoc cref="_streamtobytes" />
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

        /// <inheritdoc cref="_bytestostream" />
        public static Stream BytesToStream(byte[] bytes) => new MemoryStream(bytes);

        /// <inheritdoc cref="_streamtostring" />
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

        /// <inheritdoc cref="_stringtostream" />
        public static Stream StringToStream(string text, Encoding encoding, bool includeByteOrderMark = false)
        {
            byte[] bytes = StringToBytes(text, encoding, includeByteOrderMark);
            Stream stream = BytesToStream(bytes);
            return stream;
        }

        /// <inheritdoc cref="_stringtobytes" />
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

        /// <inheritdoc cref="_bytestostring" />
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