using System.Text;

namespace JJ.Framework.PlatformCompatibility
{
    public static class Encoding_PlatformSafe
    {
        /// <summary>
        /// The overload with only byte[] does not work on Windows Phone 8.
        /// </summary>
        public static string GetString_PlatformSafe(this Encoding encoding, byte[] bytes)
        {
            return encoding.GetString(bytes, 0, bytes.Length);
        }
    }
}
