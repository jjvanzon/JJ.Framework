using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace JJ.Framework.IO
{
    public static class BinaryWriterExtensions
    {
        /// <summary>
        /// In other languages / environments I used to be able to write a struct directly to a file.
        /// And in C# I can't. It is just a set of freaking bytes
        /// litterly stored in memory and it needs to be streamed to a file. 
        /// Why are things like that not possible using a BinaryWriter?!?
        /// </summary>
        public static void WriteStruct<T>(this BinaryWriter writer, T strct)
            where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            Marshal.StructureToPtr(strct, gcHandle.AddrOfPinnedObject(), true);
            writer.BaseStream.Write(buffer, 0, buffer.Length);
            gcHandle.Free();
        }
        
        /// <summary>
        /// In other languages / environments I used to be able to write a struct directly to a file.
        /// And in C# I can't. It is just a set of freaking bytes
        /// litterly stored in memory and it needs to be streamed to a file. 
        /// Why are things like that not possible using a BinaryWriter?!?
        /// 
        /// Beware that the performance might not be better than reading the values one by one.
        /// </summary>
        public static T ReadStruct<T>(this BinaryReader reader)
            where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = reader.ReadBytes(size);
            GCHandle gcHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T result = (T)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(T));
            gcHandle.Free();
            return result;
        }
    }
}
