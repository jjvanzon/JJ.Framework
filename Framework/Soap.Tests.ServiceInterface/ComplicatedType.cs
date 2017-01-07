using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace JJ.Framework.Soap.Tests.ServiceInterface
{
    [DataContract]
    public class ComplicatedType
    {
        // Simple Types

        [DataMember]
        public bool Boolean { get; set; }
        [DataMember]
        public byte Byte { get; set; }
        [DataMember]
        public sbyte SByte { get; set; }
        [DataMember]
        public short Int16 { get; set; }
        [DataMember]
        public ushort UInt16 { get; set; }
        [DataMember]
        public int Int32 { get; set; }
        [DataMember]
        public uint UInt32 { get; set; }
        [DataMember]
        public long Int64 { get; set; }
        [DataMember]
        public ulong UInt64 { get; set; }
        [DataMember]
        public char Char { get; set; }
        [DataMember]
        public double Double { get; set; }
        [DataMember]
        public float Single { get; set; }

        [DataMember]
        public string String { get; set; }
        [DataMember]
        public Guid Guid { get; set; }
        [DataMember]
        public TimeSpan TimeSpan { get; set; }
        [DataMember]
        public DateTime DateTime { get; set; }

        [DataMember]
        public EnumType EnumType { get; set; }

        // Nullable types

        [DataMember]
        public bool? NullableBoolean { get; set; }
        [DataMember]
        public byte? NullableByte { get; set; }
        [DataMember]
        public sbyte? NullableSByte { get; set; }
        [DataMember]
        public short? NullableInt16 { get; set; }
        [DataMember]
        public ushort? NullableUInt16 { get; set; }
        [DataMember]
        public int? NullableInt32 { get; set; }
        [DataMember]
        public uint? NullableUInt32 { get; set; }
        [DataMember]
        public long? NullableInt64 { get; set; }
        [DataMember]
        public ulong? NullableUInt64 { get; set; }
        [DataMember]
        public char? NullableChar { get; set; }
        [DataMember]
        public double? NullableDouble { get; set; }
        [DataMember]
        public float? NullableSingle { get; set; }

        [DataMember]
        public Guid? NullableGuid { get; set; }
        [DataMember]
        public TimeSpan? NullableTimeSpan { get; set; }
        [DataMember]
        public DateTime? NullableDateTime { get; set; }

        [DataMember]
        public EnumType? NullableEnumType { get; set; }

        // Collections

        [DataMember]
        public int[] Array { get; set; }
        [DataMember]
        public List<int> ListOfT { get; set; }
        [DataMember]
        public IList<int> IListOfT { get; set; }
        [DataMember]
        public ICollection<int> ICollectionOfT { get; set; }
        [DataMember]
        public IEnumerable<int> IEnumerableOfT { get; set; }

        // Composite

        [DataMember]
        public RecursiveType RecursiveObject { get; set; }

        [DataMember]
        public CompositeType CompositeObject { get; set; }

        // Collections with Different Item Types

        [DataMember]
        public IList<CompositeType> ListOfCompositeObjects { get; set; }

        [DataMember]
        public bool[] ArrayOfBoolean { get; set; }
        //[DataMember]
        //public byte[] ArrayOfByte { get; set; }
        [DataMember]
        public sbyte[] ArrayOfSByte { get; set; }
        [DataMember]
        public short[] ArrayOfInt16 { get; set; }
        [DataMember]
        public ushort[] ArrayOfUInt16 { get; set; }
        [DataMember]
        public int[] ArrayOfInt32 { get; set; }
        [DataMember]
        public uint[] ArrayOfUInt32 { get; set; }
        [DataMember]
        public long[] ArrayOfInt64 { get; set; }
        [DataMember]
        public ulong[] ArrayOfUInt64 { get; set; }
        [DataMember]
        public char[] ArrayOfChar { get; set; }
        [DataMember]
        public double[] ArrayOfDouble { get; set; }
        [DataMember]
        public float[] ArrayOfSingle { get; set; }
        [DataMember]
        public string[] ArrayOfString { get; set; }
        [DataMember]
        public Guid[] ArrayOfGuid { get; set; }
        [DataMember]
        public TimeSpan[] ArrayOfTimeSpan { get; set; }
        [DataMember]
        public DateTime[] ArrayOfDateTime { get; set; }
        [DataMember]
        public EnumType[] ArrayOfEnumType { get; set; }

        ////[DataMember]
        //public bool?[] ArrayOfNullableBoolean { get; set; }
        ////[DataMember]
        //public byte?[] ArrayOfNullableByte { get; set; }
        ////[DataMember]
        //public sbyte?[] ArrayOfNullableSByte { get; set; }
        ////[DataMember]
        //public short?[] ArrayOfNullableInt16 { get; set; }
        ////[DataMember]
        //public ushort?[] ArrayOfNullableUInt16 { get; set; }
        ////[DataMember]
        //public int?[] ArrayOfNullableInt32 { get; set; }
        ////[DataMember]
        //public uint?[] ArrayOfNullableUInt32 { get; set; }
        ////[DataMember]
        //public long?[] ArrayOfNullableInt64 { get; set; }
        ////[DataMember]
        //public ulong?[] ArrayOfNullableUInt64 { get; set; }
        ////[DataMember]
        //public char?[] ArrayOfNullableChar { get; set; }
        ////[DataMember]
        //public double?[] ArrayOfNullableDouble { get; set; }
        ////[DataMember]
        //public float?[] ArrayOfNullableSingle { get; set; }
        ////[DataMember]
        //public Guid?[] ArrayOfNullableGuid { get; set; }
        ////[DataMember]
        //public TimeSpan?[] ArrayOfNullableTimeSpan { get; set; }
        ////[DataMember]
        //public DateTime?[] ArrayOfNullableDateTime { get; set; }
        ////[DataMember]
        //public EnumType?[] ArrayOfNullableEnumType { get; set; }
    }
}