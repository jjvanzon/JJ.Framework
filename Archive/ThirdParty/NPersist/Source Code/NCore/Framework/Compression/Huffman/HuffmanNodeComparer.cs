// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *

using System.Collections;

namespace Puzzle.NCore.Framework.Compression
{
    public class HuffmanNodeComparer : IComparer
    {
        public HuffmanNodeComparer()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int Compare(object x, object y)
        {
            HuffmanNode a = (HuffmanNode) x;
            HuffmanNode b = (HuffmanNode) y;

            if (a.Occurrences == b.Occurrences)
                return 0;

            if (a.Occurrences > b.Occurrences)
                return 1;
            else
                return -1;
        }
    }
}