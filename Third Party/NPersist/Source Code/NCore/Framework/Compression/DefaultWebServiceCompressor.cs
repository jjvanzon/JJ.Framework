// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

namespace Puzzle.NCore.Framework.Compression
{
    /// <summary>
    /// Summary description for DefaultWebServiceCompressor.
    /// </summary>
    public class DefaultWebServiceCompressor : IWebServiceCompressor
    {
        public DefaultWebServiceCompressor()
        {
        }

        private string compressionKey = "<compressed />";

        public string Compress(string dataToCompress) => compressionKey + CompressorUtil.CompressToBase64(dataToCompress);

        public string Decompress(string dataToDecompress)
        {
            if (dataToDecompress.Length >= compressionKey.Length)
            {
                if (dataToDecompress.Substring(0, compressionKey.Length) == compressionKey)
                {
                    return CompressorUtil.DecompressFromBase64(dataToDecompress.Substring(compressionKey.Length));
                }
            }
            return dataToDecompress;
        }
    }
}