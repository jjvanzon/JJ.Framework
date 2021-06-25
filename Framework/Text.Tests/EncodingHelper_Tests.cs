using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.IO;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Text.Tests
{
    [TestClass]
    public class EncodingHelper_Tests
    {
        [TestMethod]
        public void Test_EncodingHelper_AddUTF8ByteOrderMark_NullBytes_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EncodingHelper.AddUTF8ByteOrderMark(null),
                "Value cannot be null.\r\nParameter name: bytes");

        [TestMethod]
        public void Test_EncodingHelper_AddUTF8ByteOrderMark_Succeeds()
        {
            // Arrange
            string text = "Test text";
            byte[] bytes_WithoutByteOrderMark = StreamHelper.StringToBytes(text, Encoding.UTF8, includeByteOrderMark: false);

            // Act
            byte[] actualBytes = EncodingHelper.AddUTF8ByteOrderMark(bytes_WithoutByteOrderMark);

            // Assert
            {
                // Whole Sequence
                byte[] expectedBytes =  StreamHelper.StringToBytes(text, Encoding.UTF8, includeByteOrderMark: true);
                AssertHelper.IsTrue(() => expectedBytes.SequenceEqual(actualBytes));

                int byteOrderMarkLength = 3;

                // Byte Order Mark Bytes
                byte[] expectedByteOrderMarkBytes = Encoding.UTF8.GetPreamble();
                byte[] actualByteOrderMarkBytes = actualBytes.Take(byteOrderMarkLength).ToArray();
                AssertHelper.IsTrue(() => expectedByteOrderMarkBytes.SequenceEqual(actualByteOrderMarkBytes));

                // Non-Byte-Order-Mark Bytes
                bool nonByteOrderMarkBytesAreMatch = actualBytes.Skip(byteOrderMarkLength).SequenceEqual(bytes_WithoutByteOrderMark);
                AssertHelper.IsTrue(() => nonByteOrderMarkBytesAreMatch);
            }
        }
    }
}
