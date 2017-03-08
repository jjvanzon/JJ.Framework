using System.IO;
using System.Text;
using JetBrains.Annotations;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Exceptions;

namespace JJ.Framework.IO
{
    public static class StreamHelper
    {
        [NotNull]
        public static byte[] StreamToBytes([NotNull] Stream stream, int bufferSize = 8192)
        {
            if (stream == null) throw new NullException(() => stream);

            MemoryStream memoryStream = stream as MemoryStream;

            if (memoryStream == null)
            {
                // Use memory stream as an intermediate, because not all Stream types support the Length property.
                memoryStream = new MemoryStream();
                Stream_PlatformSupport.CopyTo(stream, memoryStream, bufferSize);
            }

            return memoryStream.ToArray();
        }

        [NotNull]
        public static Stream BytesToStream([NotNull] byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        [NotNull]
        public static string StreamToString([NotNull] Stream stream, [NotNull] Encoding encoding)
        {
            if (encoding == null) throw new NullException(() => encoding);

            // Do not use Encoding.GetString, because it does not process the byte order mark correctly. StreamReader does.
            using (var reader = new StreamReader(stream, encoding))
            {
                string text = reader.ReadToEnd();
                return text;
            }
        }

        [NotNull]
        public static Stream StringToStream(string text, [NotNull] Encoding encoding)
        {
            byte[] bytes = StringToBytes(text, encoding);
            Stream stream = BytesToStream(bytes);
            return stream;
        }

        [NotNull]
        public static byte[] StringToBytes([NotNull] string text, [NotNull] Encoding encoding)
        {
            if (encoding == null) throw new NullException(() => encoding);
            return encoding.GetBytes(text);
        }

        [NotNull]
        public static string BytesToString([NotNull] byte[] bytes, [NotNull] Encoding encoding)
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
