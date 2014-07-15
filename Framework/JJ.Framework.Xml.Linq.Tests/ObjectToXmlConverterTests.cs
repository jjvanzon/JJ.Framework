using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ.Framework.Xml.Linq.Tests.Mocks;
using JJ.Framework.Common;
using JJ.Framework.Soap;

namespace JJ.Framework.Xml.Linq.Tests
{
    [TestClass]
    public class ObjectToXmlConverterTests
    {
        [TestMethod]
        public void Test_ObjectToXmlConverter()
        {
            ComplicatedElement sourceObject = CreateComplicatedElement();
            ObjectToXmlConverter converter = new ObjectToXmlConverter(XmlCasingEnum.CamelCase, useNamespaces: true, firstNamespacePrefix: "c");
            string text = converter.ConvertToString(sourceObject);
        }

        private ComplicatedElement CreateComplicatedElement()
        {
            var complicatedElement = new ComplicatedElement
            {
                // Attributes
                Attribute = 2,
                Attribute_WithExplicitName = 2,
                NullableAttribute_FilledIn = 2,
                NullableAttribute_LeftBlank = null,

                // Basics
                SimpleElement = 2,
                Element_WithExplicitAnnotation = 2,

                // Explicit Names
                Element_WithExplicitName = 2,
                Array_WithExplicitName = new int[] { 2, 2 },

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
                IntPtr = new IntPtr(-2),
                UIntPtr = new UIntPtr(2),
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
                NullableIntPtr = new IntPtr(-2),
                NullableUIntPtr = null,
                NullableChar = 'a',
                NullableDouble = null,
                NullableSingle = 1.23E4f,
                NullableGuid = null,
                NullableTimeSpan = TimeSpan.Parse("01:23"),
                NullableDateTime = null,
                NullableEnumType = EnumType.EnumMember2,

                // Collections
                Array = new int[] { 2, 2 },
                Array_WithExplicitAnnotation = new int[] { 2, 2 },
                ListOfT = new List<int> { 2, 2 },
                IListOfT = new int[] { 2, 2 },
                ICollectionOfT = new int[] { 2, 2 },
                IEnumerableOfT = new int[] { 2, 2 },

                // Composite
                RecursiveElement = new RecursiveElement
                {
                    Element = new RecursiveElement
                    {
                        Element = new RecursiveElement()
                    }
                }
            };

            return complicatedElement;
        }
    }
}
