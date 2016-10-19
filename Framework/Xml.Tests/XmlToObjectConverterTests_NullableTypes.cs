using JJ.Framework.Testing;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Xml.Tests.Helpers;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_NullableTypes
    {
        [TestMethod]
        public void Text_XmlToObjectConverter_NullableType_Boolean_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<bool?>("true", true);
        }

        [TestMethod]
        public void Text_XmlToObjectConverter_NullableType_Boolean_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<bool?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Byte_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<byte?>("16", 0x10);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Byte_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<byte?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_SByte_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<sbyte?>("-16", -0x10);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_SByte_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<sbyte?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int16_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<short?>("-2", -2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int16_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<short?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt16_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ushort?>("2", 2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt16_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ushort?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int32_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<int?>("-2", -2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int32_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<int?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt32_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<uint?>("2", 2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt32_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<uint?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int64_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<long?>("-2", -2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Int64_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<long?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt64_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ulong?>("2", 2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UInt64_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ulong?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_IntPtr_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<IntPtr?>("-2", new IntPtr(-2));
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_IntPtr_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<IntPtr?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UIntPtr_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<UIntPtr?>("2", new UIntPtr(2));
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_UIntPtr_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<UIntPtr?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Char_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<char?>("a", 'a');
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Char_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<char?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Double_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<double?>("1.23E4", 1.23E4);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Double_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<double?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Single_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<float?>("1.23E4", 1.23E4f);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Single_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<float?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Guid_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<Guid?>("82b91b79-c064-4179-85e8-89b551ae9b2e", new Guid("82b91b79-c064-4179-85e8-89b551ae9b2e"));
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_Guid_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<Guid?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_TimeSpan_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<TimeSpan?>("12:34", TimeSpan.Parse("12:34"));
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_TimeSpan_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<TimeSpan?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_DateTime_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<DateTime?>("2001-02-03 04:56", DateTime.Parse("2001-02-03 04:56"));
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_DateTime_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<DateTime?>("", null);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_EnumType_NotNull()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<EnumType?>("EnumMember2", EnumType.EnumMember2);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableType_EnumType_Null()
        {
            TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<EnumType?>("", null);
        }

        // Nullable attributes

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableAttribute_Omitted()
        {
            string xml = @"<root />";

            var converter = new XmlToObjectConverter<Element_WithAttribute<int?>>();
            Element_WithAttribute<int?> destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.IsNull(() => destObject.Attribute);
        }

        [TestMethod]
        public void Test_XmlToObjectConverter_NullableAttribute_LeftBlank()
        {
            string xml = @"<root attribute="""" />";

            var converter = new XmlToObjectConverter<Element_WithAttribute<int?>>();
            Element_WithAttribute<int?> destObject = converter.Convert(xml);

            AssertHelper.IsNotNull(() => destObject);
            AssertHelper.IsNull(() => destObject.Attribute);
        }
    }
}
