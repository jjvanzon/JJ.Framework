using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.IO;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InvokeAsExtensionMethod

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EmbeddedResourceReaderTests
    {
        private const string NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE = "EmbeddedResourceFile1_WithoutSubNameSpace.txt";
        private const string NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE = "EmbeddedResourceFile2_WithoutSubNameSpace.txt";
        private const string NAME_OF_FILE_1_WITH_SUB_NAME_SPACE = "EmbeddedResourceFile1_WithSubNameSpace.txt";
        private const string NAME_OF_FILE_2_WITH_SUB_NAME_SPACE = "EmbeddedResourceFile2_WithSubNameSpace.txt";
        private const string NON_EXISTENT_FILE_NAME = "NonExistent_EmbeddedResourceFileName.txt";
        private const string EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 1 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 2 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE = "Text of embedded resource file 1 with sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE = "Text of embedded resource file 2 with sub name space";
        private const string SUB_NAME_SPACE = "TestResources";

        private static readonly Assembly _assembly = typeof(EmbeddedResourceReaderTests).Assembly;
        private static readonly Encoding _encoding = Encoding.UTF8;
        private static readonly byte[] _expectedBytes_OfFile1_WithoutSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2_WithoutSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile1_WithSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2_WithSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);

        // Without Sub Name Space

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceReader.GetText(_assembly, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceReader.GetText(_assembly, NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceReader.GetBytes(_assembly, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceReader.GetBytes(_assembly, NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceReader.GetStream(_assembly, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceReader.GetStream(_assembly, NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Tests.EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceReader.GetName(_assembly, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Tests.EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceReader.GetName(_assembly, NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        // Sub Name Space Null Or Empty

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceReader.GetText(_assembly, null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceReader.GetText(_assembly, "", NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceReader.GetBytes(_assembly, null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceReader.GetBytes(_assembly, "", NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceReader.GetStream(_assembly, null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceReader.GetStream(_assembly, "", NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Tests.EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceReader.GetName(_assembly, null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Tests.EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceReader.GetName(_assembly, "", NAME_OF_FILE_2_WITHOUT_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        // With Sub Name Space

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_WITH_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_WITH_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_WITH_SUB_NAME_SPACE);
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_WITH_SUB_NAME_SPACE);
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_WITH_SUB_NAME_SPACE);
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_WITH_SUB_NAME_SPACE);
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Tests.TestResources.EmbeddedResourceFile1_WithSubNameSpace.txt";
                string actualName1 = EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_WITH_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Tests.TestResources.EmbeddedResourceFile2_WithSubNameSpace.txt";
                string actualName2 = EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_WITH_SUB_NAME_SPACE);
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        // Not Found

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, NON_EXISTENT_FILE_NAME),
                $"Embedded resource 'JJ.Framework.Common.Tests.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = "JJ.Framework.Common.Tests.NonExistent_EmbeddedResourceFileName.txt";
            string actualName = EmbeddedResourceReader.GetName(_assembly, NON_EXISTENT_FILE_NAME);
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistent_EmbeddedResourceFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = "JJ.Framework.Common.Tests.TestResources.NonExistent_EmbeddedResourceFileName.txt";
            string actualName = EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME);
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        // Assembly Null

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetText(assembly: null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetBytes(assembly: null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetStream(assembly: null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetName(assembly: null, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetText(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetBytes(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetStream(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceReader.GetName(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_WITHOUT_SUB_NAME_SPACE),
                "Value cannot be null.\r\nParameter name: assembly");

        // File Name Null or White Space

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetText(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetBytes(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetStream(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceReader.GetName(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");
    }
}
