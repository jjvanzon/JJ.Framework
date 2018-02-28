//using System;
//using System.IO;

//namespace JJ.Framework.PlatformCompatibility
//{
//	/// <summary>
//	/// Contains substitutes for static Stream methods that are not present in some .NET versions.
//	/// </summary>
//	public static class Stream_PlatformSupport
//	{
//		/// <summary>
//		/// .Net 4 substitute
//		/// </summary>
//		[Obsolete]
//		public static void CopyTo(Stream source, Stream dest, int bufferSize = 8192)
//		{
//			PlatformHelper.Stream_CopyTo_PlatformSupport(source, dest, bufferSize);
//		}
//	}
//}
