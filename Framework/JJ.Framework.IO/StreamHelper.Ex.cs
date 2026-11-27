using static JJ.Framework.IO.Legacy.StreamHelper;

namespace JJ.Framework.IO.Legacy;

public static partial class StreamHelper
{
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

    /// <inheritdoc cref="_streamtostring" />
    public static string StreamToString(Stream stream) => StreamToString(stream, Encoding.UTF8);

    /// <inheritdoc cref="_stringtostream" />
    public static Stream StringToStream(string text) => StringToStream(text, Encoding.UTF8);

    /// <inheritdoc cref="_stringtobytes" />
    public static byte[] StringToBytes(string text) => StringToBytes(text, Encoding.UTF8);

    /// <inheritdoc cref="_bytestostring" />
    public static string BytesToString(byte[] bytes) => BytesToString(bytes, Encoding.UTF8);
}