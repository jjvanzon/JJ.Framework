using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class ElementWithNullableTypes
    {
        public int? Nullable { get; set; }

        public bool? NullableBoolean { get; set; }
        public byte? NullableByte { get; set; }
        public sbyte? NullableSByte { get; set; }
        public short? NullableInt16 { get; set; }
        public ushort? NullableUInt16 { get; set; }
        public int? NullableInt32 { get; set; }
        public uint? NullableUInt32 { get; set; }
        public long? NullableInt64 { get; set; }
        public ulong? NullableUInt64 { get; set; }
        public IntPtr? NullableIntPtr { get; set; }
        public UIntPtr? NullableUIntPtr { get; set; }
        public char? NullableChar { get; set; }
        public double? NullableDouble { get; set; }
        public float? NullableSingle { get; set; }

        public Guid? NullableGuid { get; set; }
        public TimeSpan? NullableTimeSpan { get; set; }
        public DateTime? NullableDateTime { get; set; }

        public EnumType? NullableEnumType { get; set; }
    }
}
