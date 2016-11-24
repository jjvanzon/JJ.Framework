using System;
using System.IO;

namespace Puzzle.NPersist.Framework.Compression
{
	public struct PatternLink
	{
		public ulong FilePosition;
		public int NextMatch;
	}

	public class PatternCompressor :  ICompressor
	{
		private ulong[] patternHashArray = new ulong[0x1000000] ; //3 byte key lookup
		private PatternLink[] patternLinkArray ;
		private const byte escapeByte = 01;

		public PatternCompressor()
		{
		}

		private Stream compressedStream = new  MemoryStream ();
		public byte[] Compress (byte[] data)
		{						
			patternLinkArray = new PatternLink[data.Length+1] ;

			//write filesize at start of stream
			int fileSize = data.Length;
			byte[] fileSizeBytes = BitConverter.GetBytes(fileSize);
			compressedStream.Write(fileSizeBytes,0,fileSizeBytes.Length) ;


			return PatternCompress(data);
		}

		private byte[] PatternCompress(byte[] data)
		{
			for (int i=0;i<data.Length;i++)
			{								
				UInt16 matchCount=0;
				int current = data[i];
				int lookupPos = 0;
				UInt16 bestMatchCount = 0;
				int bestMatchPos = 0;

				if (i<data.Length-2)
				{
					byte current2 = data[i+1];
					byte current3 = data[i+2];

					ulong key = (ulong)current << 16;
					key |= (ulong)current2 << 8;
					key |= (ulong)current3 ;

					int prevIndex = (int)patternHashArray[key];

					int currentPrevIndex = prevIndex;
		
					
					bestMatchCount = 0;
					bestMatchPos = 0;
					if (prevIndex != 0)
					{
						

						do
						{
							matchCount = 0;
							PatternLink link = patternLinkArray[currentPrevIndex];
							lookupPos = (int)link.FilePosition;

						while (matchCount+i < data.Length && matchCount < UInt16.MaxValue &&  data[i+matchCount] == data[lookupPos+matchCount])
							matchCount++;

							//matchCount --;

							if (matchCount > bestMatchCount)
							{
								bestMatchCount = matchCount;
								bestMatchPos = lookupPos;
							}

							currentPrevIndex = link.NextMatch;

						}while (currentPrevIndex != 0);
					}
					

					patternHashArray[key] = (ulong)i+1;
					PatternLink newLink = new PatternLink() ;
					newLink.FilePosition = (ulong)i;
					newLink.NextMatch = prevIndex;
					patternLinkArray[i+1]=newLink;
				}

				int relativeLookupPos = i-bestMatchPos;

				if (bestMatchCount > 4 && relativeLookupPos < 0x100 && bestMatchCount < 0x100)
				{
					WriteBytes (escapeByte,1);
					WriteBytes (0u,1); // 0 = short relative
					WriteBytes((ulong)bestMatchCount,1);
					WriteBytes((ulong)relativeLookupPos,1);
					i += bestMatchCount-1;
				}
				else if (bestMatchCount > 5 && relativeLookupPos < 0x10000 && bestMatchCount <0x100)
				{
					WriteBytes (escapeByte,1);
					WriteBytes (1u,1); // 1 = 65k range relative
					WriteBytes((ulong)bestMatchCount,1);
					WriteBytes((ulong)relativeLookupPos,2);
					
					i += bestMatchCount-1;
				}
				else 
					if (bestMatchCount > 8 )
				{


					WriteBytes (escapeByte,1);
					WriteBytes (2u,1); // long lookup
					WriteBytes((ulong)bestMatchCount,2);
					WriteBytes((ulong)bestMatchPos,4);
					i += bestMatchCount-1;								
				}
				else
				{
					WriteBytes((ulong)current,1);
				}
			}
	
	
	
	
			byte[] compressedBytes = new byte[compressedStream.Length] ;
			compressedStream.Position = 0;
			compressedStream.Read(compressedBytes,0,compressedBytes.Length);
			return compressedBytes;
		}

		private void WriteBytes(ulong data, int count)
		{
			//byte[] bytes = BitConverter.GetBytes(data);

			for (int i=count-1;i>=0;i--)
			{
				
				byte b = (byte)((data >> (8 * i)) & 0xff);
				compressedStream.WriteByte(b) ;
			}
		}

		public byte[] Decompress(byte[] data)
		{
			int fileSize = BitConverter.ToInt32(data,0);
			byte[] result = new byte[fileSize] ;
			int position = 0;

			for (int i=4;i<data.Length;i++)
			{
				byte currentByte = data[i];

				//				if (position== 6154)
				//					Console.Write("jj") ;

				if (currentByte == escapeByte)
				{
					int matchPos = 0;
					int matchLength = 0;
					byte packType = data[i+1];
					if (packType == 0)
					{
						matchLength = data[i+2];
						matchPos = position -  data[i+3];
						i+=3;
					}
					if (packType == 1)
					{
						matchLength = data[i+2];
						byte high = data[i+3];
						byte low = data[i+4];

						int relativePos = (high << 8) | low;
						matchPos = position - relativePos;

						i+=4;
					}
					if (packType == 2)
					{

						byte high = data[i+2];
						byte low = data[i+3];

						matchLength = (high << 8) | low;

						byte ahigh = data[i+4];
						byte alow = data[i+5];
						byte bhigh = data[i+6];
						byte blow = data[i+7];

						matchPos = (ahigh << 24 ) | (alow << 16) | ((bhigh << 8) | (blow));

						i+=7;
						
					}



					for (int j = matchPos;j < matchPos + matchLength ; j++)
					{						 
						byte lookupByte =result[j];
						result[position] = lookupByte;
						position ++;						
					}
				}
				else
				{
					result[position] = currentByte;
					position ++;
				}
			}

			return result;
		}
	}
}
