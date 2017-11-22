using JJ.Framework.Exceptions;
using JJ.Framework.Soap.Tests.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JJ.Framework.Soap.Tests.Server
{
	public class TestService : ITestService
	{
		public CompositeType GetCompositeObject()
		{
			return new CompositeType
			{
				BoolValue = true,
				StringValue = "Hello world!"
			};
		}

		public TypeWithCollection GetObjectWithCollection()
		{
			return new TypeWithCollection
			{
				StringList = new List<string> { "Hello", "world", "!" }
			};
		}

		public void SendCompositeObject(CompositeType compositeObject)
		{
		}

		public void SendObjectWithCollection(TypeWithCollection objectWithCollection)
		{
		}

		public CompositeType SendAndGetCompositeObject(CompositeType compositeObject)
		{
			string stringValue;
			if (!string.IsNullOrEmpty(compositeObject.StringValue))
			{
				stringValue = compositeObject.StringValue + " to you too!";
			}
			else
			{
				stringValue =  "Hello world!";
			}

			return new CompositeType
			{
				BoolValue = true,
				StringValue = stringValue
			};
		}

		public TypeWithCollection SendAndGetObjectWithCollection(TypeWithCollection objectWithCollection)
		{
			List<string> stringList;
			if (objectWithCollection.StringList.Count == 0)
			{
				stringList = new List<string> { "Hello", "world", "!" };
			}
			else
			{
				stringList = new List<string>();
				stringList.AddRange(objectWithCollection.StringList);
				stringList.Add("to");
				stringList.Add("you");
				stringList.Add("too");
				stringList.Add("!");
			}

			return new TypeWithCollection
			{
				StringList = stringList
			};
		}

		public void SendStringValue(string stringValue)
		{
		}

		public string GetStringValue()
		{
			return "Hello world!";
		}

		public string SendAndGetStringValue(string stringValue)
		{
			return string.Format("{0} {1}", stringValue, "to you too!");
		}

		public ComplicatedType SendAndGetComplicatedObject(ComplicatedType complicatedObject)
		{
			if (complicatedObject.Array == null) throw new NullException(() => complicatedObject.Array);
			if (complicatedObject.ListOfT == null) throw new NullException(() => complicatedObject.ListOfT);
			if (complicatedObject.IListOfT == null) throw new NullException(() => complicatedObject.IListOfT);
			if (complicatedObject.ICollectionOfT == null) throw new NullException(() => complicatedObject.ICollectionOfT);
			if (complicatedObject.IEnumerableOfT == null) throw new NullException(() => complicatedObject.IEnumerableOfT);
			if (complicatedObject.ArrayOfBoolean == null) throw new NullException(() => complicatedObject.ArrayOfBoolean);
			if (complicatedObject.ArrayOfSByte == null) throw new NullException(() => complicatedObject.ArrayOfSByte);
			if (complicatedObject.ArrayOfInt16 == null) throw new NullException(() => complicatedObject.ArrayOfInt16);
			if (complicatedObject.ArrayOfUInt16 == null) throw new NullException(() => complicatedObject.ArrayOfUInt16);
			if (complicatedObject.ArrayOfInt32 == null) throw new NullException(() => complicatedObject.ArrayOfInt32);
			if (complicatedObject.ArrayOfUInt32 == null) throw new NullException(() => complicatedObject.ArrayOfUInt32);
			if (complicatedObject.ArrayOfInt64 == null) throw new NullException(() => complicatedObject.ArrayOfInt64);
			if (complicatedObject.ArrayOfUInt64 == null) throw new NullException(() => complicatedObject.ArrayOfUInt64);
			if (complicatedObject.ArrayOfChar == null) throw new NullException(() => complicatedObject.ArrayOfChar);
			if (complicatedObject.ArrayOfDouble == null) throw new NullException(() => complicatedObject.ArrayOfDouble);
			if (complicatedObject.ArrayOfSingle == null) throw new NullException(() => complicatedObject.ArrayOfSingle);
			if (complicatedObject.ArrayOfString == null) throw new NullException(() => complicatedObject.ArrayOfString);
			if (complicatedObject.ArrayOfGuid == null) throw new NullException(() => complicatedObject.ArrayOfGuid);
			if (complicatedObject.ArrayOfTimeSpan == null) throw new NullException(() => complicatedObject.ArrayOfTimeSpan);
			if (complicatedObject.ArrayOfDateTime == null) throw new NullException(() => complicatedObject.ArrayOfDateTime);
			if (complicatedObject.ArrayOfEnumType == null) throw new NullException(() => complicatedObject.ArrayOfEnumType);

			checked
			{
				var complicatedObject2 = new ComplicatedType
				{
					// Simple Types
					Boolean = false,
					Byte = (byte)(complicatedObject.Byte + 1),
					SByte = (sbyte)(complicatedObject.SByte + 1),
					Int16 = (Int16)(complicatedObject.Int16 + 1),
					UInt16 = (UInt16)(complicatedObject.UInt16 + 1),
					Int32 = complicatedObject.Int32 + 1,
					UInt32 = complicatedObject.UInt32 + 1,
					Int64 = complicatedObject.Int64 + 1,
					UInt64 = complicatedObject.UInt64 + 1,
					Char = (char)(complicatedObject.Char + 1),
					Double = complicatedObject.Double + 1,
					Single = complicatedObject.Single + 1,
					String = (complicatedObject.String ?? "") + " too",
					Guid = new Guid("ebac0ca5-b89d-4e54-ac01-19351261f004"),
					TimeSpan = complicatedObject.TimeSpan.Add(TimeSpan.Parse("01:00")),
					DateTime = complicatedObject.DateTime.AddHours(1),
					EnumType = EnumType.EnumMember1,

					// Nullable Types
					// TODO: Figure out why here you do not need to cast at all, while the not-nullable types need casting.
					NullableBoolean = complicatedObject.NullableBoolean ?? true,
					NullableByte = complicatedObject.NullableByte ?? 1 + 1,
					NullableSByte = complicatedObject.NullableSByte ?? 1 + 1,
					NullableInt16 = complicatedObject.NullableInt16 ?? 1 + 1,
					NullableUInt16 = complicatedObject.NullableUInt16 ?? 1 + 1,
					NullableInt32 = complicatedObject.NullableInt32 ?? 1 + 1,
					NullableUInt32 = complicatedObject.NullableUInt32 ?? 1 + 1,
					NullableInt64 = complicatedObject.NullableInt64 ?? 1 + 1,
					NullableUInt64 = complicatedObject.NullableUInt64 ?? 1 + 1,

					NullableChar = (char)((complicatedObject.NullableChar ?? 'b') + 1),
					NullableDouble = complicatedObject.NullableDouble ?? 1.0 + 1,
					NullableSingle = complicatedObject.NullableSingle ?? 1.0f + 1,
					NullableGuid = complicatedObject.NullableGuid ?? Guid.NewGuid(),
					NullableTimeSpan = TimeSpan.Parse("01:23"),
					NullableDateTime = (complicatedObject.NullableDateTime ?? DateTime.Parse("2001-01-01")).AddHours(1),
					NullableEnumType = complicatedObject.NullableEnumType ?? EnumType.EnumMember1,

					// Collections
					Array = Enumerable.Concat(complicatedObject.Array, new int[] { 2, 2 }).ToArray(),
					ListOfT = Enumerable.Concat(complicatedObject.ListOfT, new List<int> { 2, 2 }).ToList(),
					IListOfT = Enumerable.Concat(complicatedObject.IListOfT, new int[] { 2, 2 }).ToList(),
					ICollectionOfT = Enumerable.Concat(complicatedObject.ICollectionOfT, new int[] { 2, 2 }).ToArray(),
					IEnumerableOfT = Enumerable.Concat(complicatedObject.IEnumerableOfT, new int[] { 2, 2 }).ToArray(),

					// Composite
					RecursiveObject = new RecursiveType
					{
						RecursiveObject = new RecursiveType
						{
							RecursiveObject = complicatedObject.RecursiveObject
						}
					},
					CompositeObject = new CompositeType
					{
						BoolValue = complicatedObject.CompositeObject != null ? complicatedObject.CompositeObject.BoolValue : false,
						StringValue = complicatedObject.CompositeObject != null ? complicatedObject.CompositeObject.StringValue + " too" : null
					},

					// Collections of Different Types
					ListOfCompositeObjects = Enumerable.Concat(complicatedObject.ListOfCompositeObjects, new CompositeType[]
					{
						new CompositeType { BoolValue = false, StringValue = null },
						new CompositeType { BoolValue = false, StringValue = "Hello" },
						new CompositeType { BoolValue = true, StringValue = null },
						new CompositeType { BoolValue = true, StringValue = "Hello" },
					}).ToList(),

					ArrayOfBoolean = Enumerable.Concat(complicatedObject.ArrayOfBoolean, new bool[] { true, false }).ToArray(),
					//ArrayOfByte = Enumerable.Concat(complicatedObject.ArrayOfByte, new byte[] { 0x10, 0x20 }).ToArray(),
					ArrayOfSByte = Enumerable.Concat(complicatedObject.ArrayOfSByte, new sbyte[] { -2, 2 }).ToArray(),
					ArrayOfInt16 = Enumerable.Concat(complicatedObject.ArrayOfInt16, new Int16[] { -2, 2 }).ToArray(),
					ArrayOfUInt16 = Enumerable.Concat(complicatedObject.ArrayOfUInt16, new UInt16[] { 1, 2 }).ToArray(),
					ArrayOfInt32 = Enumerable.Concat(complicatedObject.ArrayOfInt32, new Int32[] { -2, 2 }).ToArray(),
					ArrayOfUInt32 = Enumerable.Concat(complicatedObject.ArrayOfUInt32, new UInt32[] { 1, 2 }).ToArray(),
					ArrayOfInt64 = Enumerable.Concat(complicatedObject.ArrayOfInt64, new Int64[] { -2, 2 }).ToArray(),
					ArrayOfUInt64 = Enumerable.Concat(complicatedObject.ArrayOfUInt64, new UInt64[] { 1, 2 }).ToArray(),
					ArrayOfChar = Enumerable.Concat(complicatedObject.ArrayOfChar, new char[] { 'a', 'b' }).ToArray(),
					ArrayOfDouble = Enumerable.Concat(complicatedObject.ArrayOfDouble, new double[] { 1.23E4, 2.34E5 }).ToArray(),
					ArrayOfSingle = Enumerable.Concat(complicatedObject.ArrayOfSingle, new float[] { 1.23E4f, 2.34E5f }).ToArray(),
					ArrayOfString = Enumerable.Concat(complicatedObject.ArrayOfString, new string[] { "Hello", "world", "!" }).ToArray(),
					ArrayOfGuid = Enumerable.Concat(complicatedObject.ArrayOfGuid, new Guid[] { Guid.NewGuid(), Guid.NewGuid() }).ToArray(),
					ArrayOfTimeSpan = Enumerable.Concat(complicatedObject.ArrayOfTimeSpan, new TimeSpan[] { TimeSpan.Parse("01:00"), TimeSpan.Parse("02:00") }).ToArray(),
					ArrayOfDateTime = Enumerable.Concat(complicatedObject.ArrayOfDateTime, new DateTime[] { DateTime.Parse("2001-02-03 04:05"), DateTime.Parse("2006-07-08 09:10") }).ToArray(),
					ArrayOfEnumType = Enumerable.Concat(complicatedObject.ArrayOfEnumType, new EnumType[] { EnumType.EnumMember1, EnumType.EnumMember2 }).ToArray(),

					//ArrayOfNullableBoolean = Enumerable.Concat(complicatedObject.ArrayOfNullableBoolean, new bool?[] { null, true, false }).ToArray(),
					//ArrayOfNullableByte = Enumerable.Concat(complicatedObject.ArrayOfNullableByte, new byte?[] { null, 0x10, 0x20 }).ToArray(),
					//ArrayOfNullableSByte = Enumerable.Concat(complicatedObject.ArrayOfNullableSByte, new sbyte?[] { null, -2, 2 }).ToArray(),
					//ArrayOfNullableInt16 = Enumerable.Concat(complicatedObject.ArrayOfNullableInt16, new Int16?[] { null, -2, 2 }).ToArray(),
					//ArrayOfNullableUInt16 = Enumerable.Concat(complicatedObject.ArrayOfNullableUInt16, new UInt16?[] { null, 1, 2 }).ToArray(),
					//ArrayOfNullableInt32 = Enumerable.Concat(complicatedObject.ArrayOfNullableInt32, new Int32?[] { null, -2, 2 }).ToArray(),
					//ArrayOfNullableUInt32 = Enumerable.Concat(complicatedObject.ArrayOfNullableUInt32, new UInt32?[] { null, 1, 2 }).ToArray(),
					//ArrayOfNullableInt64 = Enumerable.Concat(complicatedObject.ArrayOfNullableInt64, new Int64?[] { null, -2, 2 }).ToArray(),
					//ArrayOfNullableUInt64 = Enumerable.Concat(complicatedObject.ArrayOfNullableUInt64, new UInt64?[] { null, 1, 2 }).ToArray(),
					//ArrayOfNullableChar = Enumerable.Concat(complicatedObject.ArrayOfNullableChar, new char?[] { null, 'a', 'b' }).ToArray(),
					//ArrayOfNullableDouble = Enumerable.Concat(complicatedObject.ArrayOfNullableDouble, new double?[] { null, 1.23E4, 2.34E5 }).ToArray(),
					//ArrayOfNullableSingle = Enumerable.Concat(complicatedObject.ArrayOfNullableSingle, new float?[] { null, 1.23E4f, 2.34E5f }).ToArray(),
					//ArrayOfNullableGuid = Enumerable.Concat(complicatedObject.ArrayOfNullableGuid, new Guid?[] { null, Guid.NewGuid(), Guid.NewGuid() }).ToArray(),
					//ArrayOfNullableTimeSpan = Enumerable.Concat(complicatedObject.ArrayOfNullableTimeSpan, new TimeSpan?[] { null, TimeSpan.Parse("01:00"), TimeSpan.Parse("02:00") }).ToArray(),
					//ArrayOfNullableDateTime = Enumerable.Concat(complicatedObject.ArrayOfNullableDateTime, new DateTime?[] { null, DateTime.Parse("2001-02-03 04:05"), DateTime.Parse("2006-07-08 09:10") }).ToArray(),
					//ArrayOfNullableEnumType = Enumerable.Concat(complicatedObject.ArrayOfNullableEnumType, new EnumType?[] { null, EnumType.EnumMember1, EnumType.EnumMember2 }).ToArray()
				};

				return complicatedObject2;
			}
		}
	}
}
