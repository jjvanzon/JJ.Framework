using System.IO;

namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Stream_Core_Tests
{
    [TestMethod]
    public void PlatformCompatibility_Stream_Copy_Core_Test()
    {
        Stream_Copy_Test((stream1, stream2, buffSize) => stream1.CopyTo(stream2, buffSize));
        Stream_Copy_Test(Stream_PlatformSupport.CopyTo);
        Stream_Copy_Test(PlatformHelperLegacy.Stream_CopyTo_PlatformSupport);
    }
        
    private void Stream_Copy_Test(Action<Stream, Stream, int> streamCopy)
    {
        // Arrange
        byte[] sourceArray  = [ 1, 2, 3, 4, 5 ];
        int bufferSize = sourceArray.Length;
        Stream sourceStream = new MemoryStream(sourceArray);
        var destArray = new byte[5];
        Stream destStream = new MemoryStream(destArray);
        
        // Act
        streamCopy(sourceStream, destStream, bufferSize);

        // Assert
        IsTrue(() => destArray.SequenceEqual(sourceArray));
    }
}