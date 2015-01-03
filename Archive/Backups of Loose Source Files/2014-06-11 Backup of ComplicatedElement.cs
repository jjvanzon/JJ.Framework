using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class ComplicatedElement
    {
        // Basics

        public int SimpleElement { get; set; }

        /*
        [XmlElement]
        public int Element_WithExplicitAnnotation { get; set; }
        */

        /*
        [XmlAttribute]
        public int Attribute { get; set; }
        */

        // Composite

        public RecursiveElement RecursiveElement { get; set; }

        // Simple Types

        /*
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

        public EnumType Enum { get; set; }
        */

        // Nullable types

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

        public EnumType? NullableEnum { get; set; }

        // Explicit Names

        /*
        [XmlElement("Element_WithExplicitName")]
        public int Element_WithExplicitName { get; set; }

        [XmlAttribute("Int32Attribute_WithExplicitName")]
        public int Attribute_WithExplicitName { get; set; }
        */

        [XmlArray("Array_WithExplicitName")]
        [XmlArrayItem("item")]
        int[] Array_WithExplicitName { get; set; }

        // Collections

        [XmlArrayItem("item")]
        int[] Array { get; set; }

        [XmlArray]
        [XmlArrayItem("item")]
        int[] Array_WithExplicitAnnotation { get; set; }

        [XmlArrayItem("item")]
        List<int> ListOfT { get; set; }

        [XmlArrayItem("item")]
        IList<int> IListOfT { get; set; }

        [XmlArrayItem("item")]
        ICollection<int> ICollectionOfT { get; set; }

        [XmlArrayItem("item")]
        IEnumerable<int> IEnumerableOfT { get; set; }

        [XmlArrayItem("item")]
        IList IList { get; set; }

        [XmlArrayItem("item")]
        ICollection ICollection { get; set; }

        [XmlArrayItem("item")]
        IEnumerable IEnumerable { get; set; }
    }
}