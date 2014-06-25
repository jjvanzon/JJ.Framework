using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JJ.Framework.Net4
{
    /// <summary>
    /// Contains substitutes for static Stream methods that are not present in .NET versions lower than 4.0.
    /// </summary>
    public static class Streams
    {
        public static void CopyTo(Stream source, Stream dest, int bufferSize = 8192)
        {
            int bytesRead;
            byte[] buffer = new byte[bufferSize];
            while ((bytesRead = source.Read(buffer, 0, buffer.Length)) != 0)
            {
                dest.Write(buffer, 0, bytesRead);
            }
        }
    }
}
