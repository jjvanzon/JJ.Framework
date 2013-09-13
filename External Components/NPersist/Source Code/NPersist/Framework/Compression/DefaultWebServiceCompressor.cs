using System;

namespace Puzzle.NPersist.Framework.Compression
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

		public string Compress(string dataToCompress)
		{
			return compressionKey + CompressorUtil.CompressToBase64(dataToCompress);
		}

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
