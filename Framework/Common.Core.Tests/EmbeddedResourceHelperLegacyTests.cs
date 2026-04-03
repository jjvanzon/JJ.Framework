// Copied from 2021 legacy, with renames to adjust to 2015 code.

using System.IO;
using System.Reflection;
using JJ.Framework.IO;
using JJ.Framework.IO.Core;

// ReSharper disable InvokeAsExtensionMethod
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Core.Tests
{
    [TestClass]
    [Suppress("Trimmer", "IL2026", Justification = ArrayInit)]
    public class EmbeddedResourceHelperLegacyTests
    {
        private const string EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 1 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE = "Text of embedded resource file 2 without sub name space";
        private const string EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE = "Text of embedded resource file 1 with sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE = "Text of embedded resource file 2 with sub name space";

        private static readonly Assembly _currentAssembly = typeof(EmbeddedResourceHelperLegacyTests).Assembly;
        private static readonly Assembly _otherAssembly = typeof(DummyClass).Assembly;
        private static readonly string _currentAssemblyName = _currentAssembly.GetName().Name ?? "";

        
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
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetText_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetText_WithSubNameSpace_Succeeds()
        {
            {
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITH_SUB_NAME_SPACE;
                string actualText2 = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        // GetEmbeddedResourceBytes

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_WithoutSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithoutSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithoutSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetBytes_WithSubNameSpace_Succeeds()
        {
            {
                byte[] expectedBytes1 = _expectedBytes_OfFile1_WithSubNameSpace;
                byte[] actualBytes1 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                bool bytesAreValid1 = actualBytes1.SequenceEqual(expectedBytes1);
                AssertHelper.IsTrue(() => bytesAreValid1);
            }
            {
                byte[] expectedBytes2 = _expectedBytes_OfFile2_WithSubNameSpace;
                byte[] actualBytes2 = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                bool bytesAreValid2 = actualBytes2.SequenceEqual(expectedBytes2);
                AssertHelper.IsTrue(() => bytesAreValid2);
            }
        }

        // GetEmbeddedResourceStream

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_WithoutSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITHOUT_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                string expectedText2 = EXPECTED_TEXT_OF_FILE_2_WITHOUT_SUB_NAME_SPACE;
                string actualText2 = StreamHelper.StreamToString(stream2, _encoding);
                AssertHelper.AreEqual(expectedText2, () => actualText2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetStream_WithSubNameSpace_Succeeds()
        {
            {
                Stream stream1 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                string expectedText1 = EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE;
                string actualText1 = StreamHelper.StreamToString(stream1, _encoding);
                AssertHelper.AreEqual(expectedText1, () => actualText1);
            }
            {
                Stream stream2 = EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
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
                string expectedName1 = _currentAssemblyName + ".EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = _currentAssemblyName + ".EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_SubNameSpaceNullOrEmpty_Succeeds()
        {
            {
                string expectedName1 = _currentAssemblyName + ".EmbeddedResourceFile1_WithoutSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, null, "EmbeddedResourceFile1_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = _currentAssemblyName + ".EmbeddedResourceFile2_WithoutSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "", "EmbeddedResourceFile2_WithoutSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_Succeeds()
        {
            {
                string expectedName1 = _currentAssemblyName + ".TestResources.EmbeddedResourceFile1_WithSubNameSpace.txt";
                string actualName1 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName1, () => actualName1);
            }
            {
                string expectedName2 = _currentAssemblyName + ".TestResources.EmbeddedResourceFile2_WithSubNameSpace.txt";
                string actualName2 = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", "EmbeddedResourceFile2_WithSubNameSpace.txt");
                AssertHelper.AreEqual(expectedName2, () => actualName2);
            }
        }

        // Resources From Different Assemblies

        [TestMethod]
        public void Test_EmbeddedResourceHelper_ResourcesFromDifferentAssemblies()
        {
            string textFromTestAssembly = EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", "EmbeddedResourceFile1_WithSubNameSpace.txt");
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_WITH_SUB_NAME_SPACE, () => textFromTestAssembly);

            string textFromHelperAssembly = EmbeddedResourceHelper.GetEmbeddedResourceText(_otherAssembly, "TestResources", "EmbeddedResourceFile.txt");
            AssertHelper.AreEqual("Text from different assembly.", () => textFromHelperAssembly);
        }

        // Not Found

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", "ImaginaryFile.txt"),
                $"Embedded resource '{_currentAssemblyName}.TestResources.ImaginaryFile.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = _currentAssemblyName + ".ImaginaryFile.txt";
            string actualName = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "ImaginaryFile.txt");
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_NonExistent_Succeeds()
        {
            string expectedName = _currentAssemblyName + ".TestResources.ImaginaryFile.txt";
            string actualName = EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", "ImaginaryFile.txt");
            AssertHelper.AreEqual(expectedName, () => actualName);
        }

        // Assembly Null

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertCore.ThrowsExceptionContaining<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, "TestResources", "MyFile.txt"),
                "Value cannot be null", "Parameter", "assembly");

        // File Name Null or White Space

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetText_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_currentAssembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetBytes_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_currentAssembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetStream_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_currentAssembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameIsSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceReader_GetName_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_currentAssembly, "TestResources", fileName: "    "),
                "fileName is null or white space.");
    }
}
