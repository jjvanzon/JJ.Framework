﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Text;
using JJ.Framework.Exceptions.Basic;
using JJ.Framework.Logging;
using JJ.Framework.Soap.Tests.ServiceInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// ReSharper disable BuiltInTypeReferenceStyle
#pragma warning disable IDE0049 // Simplify Names

namespace JJ.Framework.Soap.Tests.Helpers
{
    internal static class TestHelper
    {
        public static ComplicatedType CreateComplicatedObject()
        {
            var complicatedObject = new ComplicatedType
            {
                // Simple Types
                Boolean = true,
                Byte = 2,
                SByte = -2,
                Int16 = -2,
                UInt16 = 2,
                Int32 = -2,
                UInt32 = 2,
                Int64 = -2,
                UInt64 = 2,
                Char = 'a',
                Double = 1.23E4,
                Single = 1.23E4f,
                String = "Hello",
                Guid = new Guid("ebac0ca5-b89d-4e54-ac01-19351261f004"),
                TimeSpan = TimeSpan.Parse("01:23"),
                DateTime = DateTime.Parse("2001-02-03 04:56"),
                EnumType = EnumType.EnumMember2,

                // Nullable Types
                NullableBoolean = true,
                NullableByte = null,
                NullableSByte = -2,
                NullableInt16 = null,
                NullableUInt16 = 2,
                NullableInt32 = null,
                NullableUInt32 = 2,
                NullableInt64 = null,
                NullableUInt64 = 2,
                NullableChar = 'a',
                NullableDouble = null,
                NullableSingle = 1.23E4f,
                NullableGuid = null,
                NullableTimeSpan = TimeSpan.Parse("01:23"),
                NullableDateTime = null,
                NullableEnumType = EnumType.EnumMember2,

                // Collections
                Array = new[] { 2, 2 },
                ListOfT = new List<int> { 2, 2 },
                IListOfT = new[] { 2, 2 },
                ICollectionOfT = new[] { 2, 2 },
                IEnumerableOfT = new[] { 2, 2 },

                // Composite
                RecursiveObject = new RecursiveType
                {
                    RecursiveObject = new RecursiveType
                    {
                        RecursiveObject = new RecursiveType()
                    }
                },
                CompositeObject = new CompositeType
                {
                    BoolValue = true,
                    StringValue = "Hello"
                },

                // Collections with Different Item Types

                ListOfCompositeObjects = new[]
                {
                    new CompositeType { BoolValue = false, StringValue = null },
                    new CompositeType { BoolValue = false, StringValue = "Hello" },
                    new CompositeType { BoolValue = true, StringValue = null },
                    new CompositeType { BoolValue = true, StringValue = "Hello" },
                },

                ArrayOfBoolean = new[] { true, false },
                //ArrayOfByte = new byte[] { 0x10, 0x20 },
                ArrayOfSByte = new sbyte[] { -2, 2 },
                ArrayOfInt16 = new Int16[] { -2, 2 },
                ArrayOfUInt16 = new UInt16[] { 1, 2 },
                ArrayOfInt32 = new[] { -2, 2 },
                ArrayOfUInt32 = new UInt32[] { 1, 2 },
                ArrayOfInt64 = new Int64[] { -2, 2 },
                ArrayOfUInt64 = new UInt64[] { 1, 2 },
                ArrayOfChar = new[] { 'a', 'b' },
                ArrayOfDouble = new[] { 1.23E4, 2.34E5 },
                ArrayOfSingle = new[] { 1.23E4f, 2.34E5f },
                ArrayOfString = new[] { "Hello", "world", "!" },
                ArrayOfGuid = new[] { Guid.NewGuid(), Guid.NewGuid() },
                ArrayOfTimeSpan = new[] { TimeSpan.Parse("01:00"), TimeSpan.Parse("02:00") },
                ArrayOfDateTime = new[] { DateTime.Parse("2001-02-03 04:05"), DateTime.Parse("2006-07-08 09:10") },
                ArrayOfEnumType = new[] { EnumType.EnumMember1, EnumType.EnumMember2 },

                //ArrayOfNullableBoolean = new bool?[] { null, true, false },
                //ArrayOfNullableByte = new byte?[] { null, 0x10, 0x20 },
                //ArrayOfNullableSByte = new sbyte?[] { null, -2, 2 },
                //ArrayOfNullableInt16 = new Int16?[] { null, -2, 2 },
                //ArrayOfNullableUInt16 = new UInt16?[] { null, 1, 2 },
                //ArrayOfNullableInt32 = new Int32?[] { null, -2, 2 },
                //ArrayOfNullableUInt32 = new UInt32?[] { null, 1, 2 },
                //ArrayOfNullableInt64 = new Int64?[] { null, -2, 2 },
                //ArrayOfNullableUInt64 = new UInt64?[] { null, 1, 2 },
                ////ArrayOfNullableIntPtr = new IntPtr?[] { null, new IntPtr(-2), new IntPtr(2) },
                ////ArrayOfNullableUIntPtr = new UIntPtr?[] { null, new UIntPtr(1), new UIntPtr(2) },
                //ArrayOfNullableChar = new char?[] { null, 'a', 'b' },
                //ArrayOfNullableDouble = new double?[] { null, 1.23E4, 2.34E5 },
                //ArrayOfNullableSingle = new float?[] { null, 1.23E4f, 2.34E5f },
                //ArrayOfNullableGuid = new Guid?[] { null, Guid.NewGuid(), Guid.NewGuid() },
                //ArrayOfNullableTimeSpan = new TimeSpan?[] { null, TimeSpan.Parse("01:00"), TimeSpan.Parse("02:00") },
                //ArrayOfNullableDateTime = new DateTime?[] { null, DateTime.Parse("2001-02-03 04:05"), DateTime.Parse("2006-07-08 09:10") },
                //ArrayOfNullableEnumType = new EnumType?[] { null, EnumType.EnumMember1, EnumType.EnumMember2 },
            };

            return complicatedObject;
        }

        public static void WithInconclusiveConnectionAssertion(Action action)
        {
            if (action == null) throw new NullException(() => action);

            try
            {
                action();
            }
            catch (WebException ex)
            {
                string responseText = TryGetResponseText(ex.Response);
                AssertInconclusive(ex, responseText);
            }
            catch (EndpointNotFoundException ex)
            {
                AssertInconclusive(ex);
            }
        }

        private static void AssertInconclusive(Exception ex, string additionalText = "")
        {
            string message = $"{ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace: false)}{additionalText}";
            Assert.Inconclusive(message);
        }

        /// <summary>Would ignore exceptions.</summary>
        /// <param name="webResponse"> nullable </param>
        private static string TryGetResponseText(WebResponse webResponse)
        {
            try
            {
                if (webResponse == null)
                {
                    return "";
                }

                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        return "";
                    }

                    using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
