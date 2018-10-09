// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System;
using System.Text;

namespace Puzzle.NCore.Framework.Compression
{
    public class CompressorUtil
    {
        public static string CompressToBase64(string dataToCompress)
        {
            byte[] byteData = ASCIIEncoding.Default.GetBytes(dataToCompress);
            GawdCompressor packer = new GawdCompressor();
            byte[] packed = packer.Compress(byteData);
            string base64 = Convert.ToBase64String(packed);

            return base64;
        }

        public static string DecompressFromBase64(string base64)
        {
            byte[] bytedata = Convert.FromBase64String(base64);
            GawdCompressor packer = new GawdCompressor();
            //byte[] unpacked = packer.Compress(bytedata);
            byte[] unpacked = packer.Decompress(bytedata);
            string unpackedString = ASCIIEncoding.Default.GetString(unpacked);
            return unpackedString;
        }
    }
}