using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JJ.Framework.Xml.Tests.Mocks
{
    internal class ComplicatedElement
    {
        // Basics

        public int SimpleElement { get; set; }

        [XmlElement]
        public int Element_WithExplicitAnnotation { get; set; }

        [XmlAttribute]
        public int Attribute { get; set; }

        // Explicit Names

        [XmlElement("Element_WithExplicitName")]
        public int Element_WithExplicitName { get; set; }

        [XmlAttribute("Attribute_WithExplicitName")]
        public int Attribute_WithExplicitName { get; set; }

        [XmlArray("Array_WithExplicitName")]
        [XmlArrayItem("item")]
        public int[] Array_WithExplicitName { get; set; }

        // Simple Types

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

        public EnumType? NullableEnumType { get; set; }

        [XmlAttribute]
        public int? NullableAttribute_FilledIn { get; set; }

        [XmlAttribute]
        public int? NullableAttribute_LeftBlank { get; set; }

        [XmlAttribute]
        public int? NullableAttribute_Omitted { get; set; }

        // Collections

        [XmlArrayItem("item")]
        public int[] Array { get; set; }

        [XmlArray]
        [XmlArrayItem("item")]
        public int[] Array_WithExplicitAnnotation { get; set; }

        [XmlArrayItem("item")]
        public List<int> ListOfT { get; set; }

        [XmlArrayItem("item")]
        public IList<int> IListOfT { get; set; }

        [XmlArrayItem("item")]
        public ICollection<int> ICollectionOfT { get; set; }

        [XmlArrayItem("item")]
        public IEnumerable<int> IEnumerableOfT { get; set; }

        // It is not possible to support non-generic collection types,
        // because then you have no idea to which item type the elements map.

        /*
        [XmlArrayItem("item")]
        public IList IList { get; set; }

        [XmlArrayItem("item")]
        public ICollection ICollection { get; set; }

        [XmlArrayItem("item")]
        public IEnumerable IEnumerable { get; set; }
        */

        // Composite

        public RecursiveElement RecursiveElement { get; set; }
    }
}