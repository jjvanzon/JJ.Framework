﻿namespace JJ.Framework.PlatformCompatibility.Core.Tests;

[TestClass]
public sealed class PlatformCompatibility_Encoding_Core_Tests
{
    [TestMethod]
    public void PlatformCompatibility_Encoding_Core_Test()
    {
        int previousByteCount = 0;
        
        foreach (var encoding in new [] { Encoding.UTF8, Encoding.Unicode, Encoding.UTF32 })
        {
            // Arrange
            string expected  = "Test Encoding";
            byte[] bytes     = encoding.GetBytes(expected);
            int    byteCount = bytes.Length;
            
            // Log
            Console.WriteLine(@$"text = ""{expected}"", encoding = {encoding.WebName}, bytes = {byteCount}");
            
            // Act
            string actual1 = Encoding_PlatformSafe.GetString_PlatformSafe(encoding, bytes);
            string actual2 = PlatformHelper.GetString_PlatformSafe(encoding, bytes);
            string actual3 = encoding.GetString(bytes);
            
            // Assert                
            AreEqual(expected, actual1);
            AreEqual(expected, actual2);
            AreEqual(expected, actual3);
            IsTrue(byteCount > previousByteCount, "byteCount > previousByteCount");
            
            previousByteCount = byteCount;
            
        }
    }
}