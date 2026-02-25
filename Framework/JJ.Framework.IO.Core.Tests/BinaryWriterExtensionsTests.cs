using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace JJ.Framework.IO.Core.Tests;

[TestClass]
public class BinaryWriterExtensionsTests
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct TestStruct
    {
        public int A;
        public short B;
        public byte C;
    }

    [TestMethod]
    public void WriteStruct_ReadStruct_Roundtrip()
    {
        var original = new TestStruct { A = 0x11223344, B = 0x5566, C = 0x77 };

        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteStruct(original);
        }

        ms.Position = 0;

        using (var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true))
        {
            var result = reader.ReadStruct<TestStruct>();
            AreEqual(original.A, result.A);
            AreEqual(original.B, result.B);
            AreEqual(original.C, result.C);
        }
    }

    [TestMethod]
    public void WriteStruct_WritesExpectedNumberOfBytes()
    {
        var s = new TestStruct { A = 1, B = 2, C = 3 };

        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteStruct(s);
        }

        int expectedSize = Marshal.SizeOf(typeof(TestStruct));
        AreEqual(expectedSize, (int)ms.Length);
    }

    [TestMethod]
    public void WriteMultiple_ReadMultiple_OrderPreserved()
    {
        var s1 = new TestStruct { A = 1, B = 10, C = 100 };
        var s2 = new TestStruct { A = 2, B = 20, C = 200 };

        using var ms = new MemoryStream();
        using (var writer = new BinaryWriter(ms, Encoding.UTF8, leaveOpen: true))
        {
            writer.WriteStruct(s1);
            writer.WriteStruct(s2);
        }

        ms.Position = 0;

        using (var reader = new BinaryReader(ms, Encoding.UTF8, leaveOpen: true))
        {
            var r1 = reader.ReadStruct<TestStruct>();
            var r2 = reader.ReadStruct<TestStruct>();

            AreEqual(s1.A, r1.A);
            AreEqual(s1.B, r1.B);
            AreEqual(s1.C, r1.C);

            AreEqual(s2.A, r2.A);
            AreEqual(s2.B, r2.B);
            AreEqual(s2.C, r2.C);
        }
    }
}
