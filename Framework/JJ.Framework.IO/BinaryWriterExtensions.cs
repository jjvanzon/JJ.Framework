using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace JJ.Framework.IO.Legacy
{
    /// <summary> Contains some methods for reading and writing structs to a stream. </summary>
    public static class BinaryWriterExtensions
    {
        /// <inheritdoc cref="_readwritestruct" />
        public static void WriteStruct<T>(this BinaryWriter writer, T strct)
            where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = new byte[size];
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(strct, gcHandle.AddrOfPinnedObject(), true);
            writer.BaseStream.Write(buffer, 0, buffer.Length);
            gcHandle.Free();
        }
        
        /// <remarks>
        /// Beware that the performance might not be better than reading the values one by one.
        /// </remarks>
        /// <inheritdoc cref="_readwritestruct" />
        public static T ReadStruct<[Dyn(Ctors)]T>(this BinaryReader reader)
            where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = reader.ReadBytes(size);
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T result = Marshal.PtrToStructure<T>(gcHandle.AddrOfPinnedObject());
            gcHandle.Free();
            return result;
        }
    }
}
