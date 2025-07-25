﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JJ.Framework.PlatformCompatibility;
using JJ.Framework.Reflection;

namespace JJ.Framework.IO.Legacy
{
    public static class StreamHelper
    {
        public static byte[] StreamToBytes(Stream stream, int bufferSize = 8192)
        {
            if (stream == null) throw new NullException(() => stream);

            // Use memory stream as an intermediate, because not all Stream types support the Length property.
            using (var stream2 = new MemoryStream())
            {
                Stream_PlatformSupport.CopyTo(stream, stream2, bufferSize);
                return stream2.ToArray();
            }
        }

        public static Stream BytesToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

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

        public static Stream StringToStream(string text, Encoding encoding)
        {
            byte[] bytes = StringToBytes(text, encoding);
            Stream stream = BytesToStream(bytes);
            return stream;
        }

        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            if (encoding == null) throw new NullException(() => encoding);
            return encoding.GetBytes(text);
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
