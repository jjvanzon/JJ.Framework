using System;
using System.Linq;
using System.Text;

namespace JJ.Framework.Text
{
    public static class EncodingHelper
    {
        public static byte[] AddUTF8ByteOrderMark(byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            return Encoding.UTF8.GetPreamble().Concat(bytes).ToArray();
        }
    }
}
