using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class ElementWithSimpleTypes
    {
        public bool Boolean { get; set; }
        public byte Byte { get; set; }
        public sbyte SByte { get; set; }
        public short Int16 { get; set; }
        public ushort UInt16 { get; set; }
        public int Int32 { get; set; }
        public uint UInt32 { get; set; }
        public long Int64 { get; set; }
        public ulong UInt64 { get; set; }
        public IntPtr IntPtr { get; set; }
        public UIntPtr UIntPtr { get; set; }
        public char Char { get; set; }
        public double Double { get; set; }
        public float Single { get; set; }

        public string String { get; set; }
        public Guid Guid { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public DateTime DateTime { get; set; }

        public EnumType EnumType { get; set; }
    }
}
