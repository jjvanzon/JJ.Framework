// Copied from 2021 legacy, with renames to adjust to 2015 code.

using System.IO;
using System.Reflection;
using JJ.Framework.Common.Core.Tests.Helpers;
using JJ.Framework.IO;
using JJ.Framework.IO.Core;

// ReSharper disable InvokeAsExtensionMethod
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Core.Tests
{
    [TestClass]
    public class EmbeddedResourceHelperLegacyTests
    {
        private const string EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 1 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 2 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE = "Text of embedded resource file 1 with sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE = "Text of embedded resource file 2 with sub name space";

        private static readonly Assembly _assembly = typeof(EmbeddedResourceHelperLegacyTests).Assembly;
        private static readonly Assembly _assembly2 = typeof(DummyClass).Assembly;

        private static readonly Encoding _encoding = Encoding.UTF8;
        private static readonly byte[] _expectedBytes_OfFile1_WithoutSubNameSpace = StreamHelperLegacy.StringToBytes(EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2_WithoutSubNameSpace = StreamHelperLegacy.StringToBytes(EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile1_WithSubNameSpace = StreamHelperLegacy.StringToBytes(EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2_WithSubNameSpace = StreamHelperLegacy.StringToBytes(EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);

        // GetEmbeddedResourceText

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetText_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetText_WithSubNameSpace_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        // GetEmbeddedResourceBytes

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_WithoutSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_WithSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        // GetEmbeddedResourceStream

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_WithoutSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_WithSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }
        
        // GetName

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Core.Tests.EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Core.Tests.EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Core.Tests.EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Core.Tests.EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_Succeeds()
        {
            {
                string expectedName1 = "JJ.Framework.Common.Core.Tests.TestResources.EmbeddedResourceFile1_WithSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = "JJ.Framework.Common.Core.Tests.TestResources.EmbeddedResourceFile2_WithSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        // Resources From Different Assemblies

        [TestMethod]
        public void Test_EmbeddedResourceHelper_ResourcesFromDifferentAssemblies()
        {
            string textFromTestAssembly = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE, () => textFromTestAssembly);

            string textFromHelperAssembly = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly2, "TestResources", "EmbeddedResourceFile.txt");
            AssertHelper.AreEqual("Text from different assembly.", () => textFromHelperAssembly);
        }

        // Not Found

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", "ImaginaryFile.txt"),
                "Embedded resource 'JJ.Framework.Common.Core.Tests.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = "JJ.Framework.Common.Core.Tests.ImaginaryFile.txt";
            string actualName = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "ImaginaryFile.txt");
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = "JJ.Framework.Common.Core.Tests.TestResources.ImaginaryFile.txt";
            string actualName = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", "ImaginaryFile.txt");
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        // Assembly Null

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null.\r\nParameter name: assembly");

        // File Name Null or White Space

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");
    }
}
