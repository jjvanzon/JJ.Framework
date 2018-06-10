using System;
using JJ.Framework.Xml.Tests.Helpers;
using JJ.Framework.Xml.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.Xml.Tests
{
    [TestClass]
    public class XmlToObjectConverterTests_SimpleTypes
    {
        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Boolean()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("true", true);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Byte()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<byte>("16", 0x10);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_SByte()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<sbyte>("-16", -0x10);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Int16()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<short>("-2", -2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_UInt16()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ushort>("2", 2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Int32() => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("-2", -2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_UInt32()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<uint>("2", 2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Int64()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<long>("-2", -2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_UInt64()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue<ulong>("2", 2);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_IntPtr()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("-2", new IntPtr(-2));

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_UIntPtr()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("2", new UIntPtr(2));

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Char() => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("a", 'a');

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Double()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("1.23E4", 1.23E4);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Single()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("1.23E4", 1.23E4f);

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_String()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("Hello", "Hello");

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_Guid()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue(
                "82b91b79-c064-4179-85e8-89b551ae9b2e",
                new Guid("82b91b79-c064-4179-85e8-89b551ae9b2e"));

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_TimeSpan()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("12:34", TimeSpan.Parse("12:34"));

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_DateTime()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("2001-02-03 04:56", DateTime.Parse("2001-02-03 04:56"));

        [TestMethod]
        public void Test_XmlToObjectConverter_SimpleType_EnumType()
            => TestHelper.Test_XmlToObjectConverter_SimpleElement_WithChildValue("EnumMember2", EnumType.EnumMember2);
    }
}