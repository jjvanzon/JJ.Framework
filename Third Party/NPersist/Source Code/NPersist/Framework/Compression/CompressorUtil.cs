using System;

namespace Puzzle.NPersist.Framework.Compression
{
	public class CompressorUtil
	{
		public static string CompressToBase64(string dataToCompress)
		{
			byte[] byteData = System.Text.ASCIIEncoding.Default.GetBytes(dataToCompress);
			GawdCompressor packer = new GawdCompressor();
			byte[] packed = packer.Compress(byteData);
			string base64=Convert.ToBase64String(packed);

			return base64;
		}

		public static string DecompressFromBase64(string base64)
		{
			byte[] bytedata = Convert.FromBase64String(base64);
			GawdCompressor packer = new GawdCompressor();
			//byte[] unpacked = packer.Compress(bytedata);
			byte[] unpacked = packer.Decompress(bytedata);
			string unpackedString = System.Text.ASCIIEncoding.Default.GetString(unpacked);
			return unpackedString;
		}
	}
}
