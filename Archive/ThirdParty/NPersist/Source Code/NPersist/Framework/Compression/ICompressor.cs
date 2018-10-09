using System;

namespace Puzzle.NPersist.Framework.Compression
{
	public interface ICompressor
	{
		byte[] Compress(byte[] data);
		byte[] Decompress(byte[] data);
		
	}
}
