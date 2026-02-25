using System.Runtime.InteropServices;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class BinaryWriterExtensionsTests
{
    private static readonly Encoding DefaultEncoding = Encoding.UTF8;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct TestStruct
    {
        public int   MyInt;
        public short MyShort;
        public byte  MyByte;
    }

    [TestMethod]
    public void WriteStruct_ReadStruct_Roundtrip()
    {
        var inputStruct = new TestStruct { MyInt = 287454020, MyShort = 21862, MyByte = 119 };

        using var memoryStream = new MemoryStream();

        using (var writer = new BinaryWriter(memoryStream, DefaultEncoding, leaveOpen: true))
        {
            writer.WriteStruct(inputStruct);
        }

        memoryStream.Position = 0;

        using (var reader = new BinaryReader(memoryStream))
        {
            var outputStruct = reader.ReadStruct<TestStruct>();
            AreEqual(inputStruct.MyInt,   outputStruct.MyInt);
            AreEqual(inputStruct.MyShort, outputStruct.MyShort);
            AreEqual(inputStruct.MyByte,  outputStruct.MyByte);
        }
    }

    [TestMethod]
    public void WriteStruct_WritesExpectedNumberOfBytes()
    {
        var myStruct = new TestStruct { MyInt = 1, MyShort = 2, MyByte = 3 };

        using var memoryStream = new MemoryStream();

        using (var writer = new BinaryWriter(memoryStream, DefaultEncoding, leaveOpen: true))
        {
            writer.WriteStruct(myStruct);
        }

        int expectedSize = Marshal.SizeOf<TestStruct>();

        AreEqual(expectedSize, (int)memoryStream.Length);
    }

    [TestMethod]
    public void WriteMultiple_ReadMultiple_OrderPreserved()
    {
        var inputStruct1 = new TestStruct { MyInt = 1, MyShort = 10, MyByte = 100 };
        var inputStruct2 = new TestStruct { MyInt = 2, MyShort = 20, MyByte = 200 };

        using var memoryStream = new MemoryStream();

        using (var writer = new BinaryWriter(memoryStream, DefaultEncoding, leaveOpen: true))
        {
            writer.WriteStruct(inputStruct1);
            writer.WriteStruct(inputStruct2);
        }

        memoryStream.Position = 0;

        using (var reader = new BinaryReader(memoryStream))
        {
            var outputStruct1 = reader.ReadStruct<TestStruct>();
            var outputStruct2 = reader.ReadStruct<TestStruct>();

            AreEqual(inputStruct1.MyInt,   outputStruct1.MyInt);
            AreEqual(inputStruct1.MyShort, outputStruct1.MyShort);
            AreEqual(inputStruct1.MyByte,  outputStruct1.MyByte);

            AreEqual(inputStruct2.MyInt,   outputStruct2.MyInt);
            AreEqual(inputStruct2.MyShort, outputStruct2.MyShort);
            AreEqual(inputStruct2.MyByte,  outputStruct2.MyByte);
        }
    }
}
