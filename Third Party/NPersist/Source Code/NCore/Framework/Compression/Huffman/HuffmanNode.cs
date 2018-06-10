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
    public class HuffmanNode
    {
        public HuffmanNode()
        {
        }

        public byte Data;
        public byte Bit;
        public int BitMask;
        public int BitCount;
        public int Occurrences = 0;
        public bool IsLeaf = true;

        public HuffmanNode LeftNode;
        public HuffmanNode RightNode;

        public override string ToString() => string.Format("{0} - {1}", Data, Occurrences);
    }
}