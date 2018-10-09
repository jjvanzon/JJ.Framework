using System;
using System.Collections;

namespace Puzzle.NPersist.Framework.Compression
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
			HuffmanNode a = (HuffmanNode)x;
			HuffmanNode b = (HuffmanNode)y;

			if (a.Occurrences == b.Occurrences)
				return 0;

			if  (a.Occurrences > b.Occurrences)
				return 1;
			else
				return -1;
		}
	}
}
