﻿using System.IO;
using System.Runtime.InteropServices;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.IO
{
    /// <summary> Contains some methods for reading and writing structs to a stream. </summary>
    public static class BinaryWriterExtensions
    {
        public static void WriteStruct<T>(this BinaryWriter writer, T @struct)
            where T : struct
        {
            if (writer == null) throw new NullException(() => writer);

            int size = Marshal.SizeOf(typeof(T));
            var buffer = new byte[size];
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(@struct, gcHandle.AddrOfPinnedObject(), true);
            writer.BaseStream.Write(buffer, 0, buffer.Length);
            gcHandle.Free();
        }
        
        /// <summary>
        /// Beware that the performance might not be better than reading the values one by one.
        /// </summary>
        public static T ReadStruct<T>(this BinaryReader reader)
            where T : struct
        {
            if (reader == null) throw new NullException(() => reader);

            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = reader.ReadBytes(size);
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var result = (T)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(T));
            gcHandle.Free();
            return result;
        }
    }
}
