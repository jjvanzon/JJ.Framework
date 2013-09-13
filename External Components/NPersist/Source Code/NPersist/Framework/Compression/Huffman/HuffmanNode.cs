using System;

namespace Puzzle.NPersist.Framework.Compression
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

		public override string ToString()
		{
			return string.Format("{0} - {1}",Data,Occurrences);
		}

	}
}
