using System.IO;

namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public class PlatformCompatibility_Stream_Core_Tests
{
    [TestMethod]
    public void PlatformCompatibility_Stream_Copy_Core_Test()
    {
        // Arrange
        int bufferSize = 5;
        byte[] sourceArray  = [ 1, 2, 3, 4, 5 ];
        Stream sourceStream = new MemoryStream(sourceArray);
        
        {
            // Arrange
            sourceStream.Position = 0;
            var destArray = new byte[5];
            Stream destStream = new MemoryStream(destArray);
            
            // Act
            sourceStream.CopyTo(destStream, bufferSize);

            // Assert
            IsTrue(() => destArray.SequenceEqual(sourceArray));
        }
        
        {
            // Arrange
            sourceStream.Position = 0;
            var destArray = new byte[5];
            Stream destStream = new MemoryStream(destArray);
            
            // Act
            PlatformHelperLegacy.Stream_CopyTo_PlatformSupport(sourceStream, destStream, bufferSize);

            // Assert
            IsTrue(() => destArray.SequenceEqual(sourceArray));
        }
        
        {
            // Arrange
            sourceStream.Position = 0;
            var destArray = new byte[5];
            Stream destStream = new MemoryStream(destArray);
            
            // Act
            Stream_PlatformSupport.CopyTo(sourceStream, destStream, bufferSize);

            // Assert
            IsTrue(() => destArray.SequenceEqual(sourceArray));
        }
    }
}