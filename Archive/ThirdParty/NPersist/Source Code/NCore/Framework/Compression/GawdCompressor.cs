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
    /// Summary description for Packer.
    /// </summary>
    public class GawdCompressor : ICompressor
    {
        public GawdCompressor()
        {
        }

        private HuffmanCompressor huffmanPacker = new HuffmanCompressor();
        private PatternCompressor patternPacker = new PatternCompressor();

        public byte[] Compress(byte[] data)
        {
            byte[] patternPacked = patternPacker.Compress(data);
            byte[] huffmanPacked = huffmanPacker.Compress(patternPacked);
            return huffmanPacked;
        }

        public byte[] Decompress(byte[] data)
        {
            byte[] Unhuffed = huffmanPacker.Decompress(data);
            byte[] Unpattern = patternPacker.Decompress(Unhuffed);

            return Unpattern;
        }
    }
}