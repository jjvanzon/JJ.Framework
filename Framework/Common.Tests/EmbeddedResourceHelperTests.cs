using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.IO;
using JJ.Framework.Testing;
using JJ.Framework.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable InvokeAsExtensionMethod

// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Tests
{
    [TestClass]
    public class EmbeddedResourceHelperTests
    {
        private const string NAME_OF_FILE_1_IN_ROOT = "EmbeddedResourceFile1InRoot.txt";
        private const string NAME_OF_FILE_2_IN_ROOT = "EmbeddedResourceFile2InRoot.txt";
        private const string NAME_OF_FILE_1_IN_SUB_NAME_SPACE = "EmbeddedResourceFile1InSubNameSpace.txt";
        private const string NAME_OF_FILE_2_IN_SUB_NAME_SPACE = "EmbeddedResourceFile2InSubNameSpace.txt";
        private const string NON_EXISTENT_FILE_NAME = "NonExistentFileName.txt";
        private const string EXPECTED_TEXT_OF_FILE_1_IN_ROOT = "Text of embedded resource file 1 in root";
        private const string EXPECTED_TEXT_OF_FILE_2_IN_ROOT = "Text of embedded resource file 2 in root";
        private const string EXPECTED_TEXT_OF_FILE_1_IN_SUB_NAME_SPACE = "Text of embedded resource file 1 in sub name space";
        private const string EXPECTED_TEXT_OF_FILE_2_IN_SUB_NAME_SPACE = "Text of embedded resource file 2 in sub name space";
        private const string SUB_NAME_SPACE = "TestResources";

        private static readonly Assembly _assembly = typeof(EmbeddedResourceHelperTests).Assembly;
        private static readonly Encoding _encoding = Encoding.UTF8;
        private static readonly byte[] _expectedBytes_OfFile1InRoot = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_1_IN_ROOT, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2InRoot = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_2_IN_ROOT, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile1InSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_1_IN_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);
        private static readonly byte[] _expectedBytes_OfFile2InSubNameSpace = StreamHelper.StringToBytes(EXPECTED_TEXT_OF_FILE_2_IN_SUB_NAME_SPACE, _encoding, includeByteOrderMark: true);

        // Without Sub Name Space

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_Succeeds()
        {
            string actualText_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, NAME_OF_FILE_1_IN_ROOT);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_ROOT, () => actualText_OfFile1InRoot);

            string actualText_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, NAME_OF_FILE_2_IN_ROOT);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_ROOT, () => actualText_OfFile2InRoot);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_Succeeds()
        {
            byte[] actualBytes_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, NAME_OF_FILE_1_IN_ROOT);
            bool bytes_OfFile1InRoot_AreValid = actualBytes_OfFile1InRoot.SequenceEqual(_expectedBytes_OfFile1InRoot);
            AssertHelper.IsTrue(() => bytes_OfFile1InRoot_AreValid);

            byte[] actualBytes_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, NAME_OF_FILE_2_IN_ROOT);
            bool bytes_OfFile2InRoot_AreValid = actualBytes_OfFile2InRoot.SequenceEqual(_expectedBytes_OfFile2InRoot);
            AssertHelper.IsTrue(() => bytes_OfFile2InRoot_AreValid);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_Succeeds()
        {
            Stream stream_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, NAME_OF_FILE_1_IN_ROOT);
            string stream_OfFile1InRoot_Text = StreamHelper.StreamToString(stream_OfFile1InRoot, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_ROOT, () => stream_OfFile1InRoot_Text);

            Stream stream_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, NAME_OF_FILE_2_IN_ROOT);
            string stream_OfFile2InRoot_Text = StreamHelper.StreamToString(stream_OfFile2InRoot, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_ROOT, () => stream_OfFile2InRoot_Text);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_Succeeds()
        {
            string actualEmbeddedResourceName_ForFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, NAME_OF_FILE_1_IN_ROOT);
            string expectedEmbeddedResourceName_ForFile1InRoot = "JJ.Framework.Common.Tests.EmbeddedResourceFile1InRoot.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile1InRoot, () => actualEmbeddedResourceName_ForFile1InRoot);

            string actualEmbeddedResourceName_ForFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, NAME_OF_FILE_2_IN_ROOT);
            string expectedEmbeddedResourceName_ForFile2InRoot = "JJ.Framework.Common.Tests.EmbeddedResourceFile2InRoot.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile2InRoot, () => actualEmbeddedResourceName_ForFile2InRoot);
        }

        // Sub Name Space Null Or Empty

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_SubNameSpaceNullOrEmpty_Succeeds()
        {
            string actualText_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, null, NAME_OF_FILE_1_IN_ROOT);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_ROOT, () => actualText_OfFile1InRoot);

            string actualText_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, "", NAME_OF_FILE_2_IN_ROOT);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_ROOT, () => actualText_OfFile2InRoot);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_SubNameSpaceNullOrEmpty_Succeeds()
        {
            byte[] actualBytes_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, null, NAME_OF_FILE_1_IN_ROOT);
            bool bytes_OfFile1InRoot_AreValid = actualBytes_OfFile1InRoot.SequenceEqual(_expectedBytes_OfFile1InRoot);
            AssertHelper.IsTrue(() => bytes_OfFile1InRoot_AreValid);

            byte[] actualBytes_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, "", NAME_OF_FILE_2_IN_ROOT);
            bool bytes_OfFile2InRoot_AreValid = actualBytes_OfFile2InRoot.SequenceEqual(_expectedBytes_OfFile2InRoot);
            AssertHelper.IsTrue(() => bytes_OfFile2InRoot_AreValid);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_SubNameSpaceNullOrEmpty_Succeeds()
        {
            Stream stream_OfFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, null, NAME_OF_FILE_1_IN_ROOT);
            string stream_OfFile1InRoot_Text = StreamHelper.StreamToString(stream_OfFile1InRoot, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_ROOT, () => stream_OfFile1InRoot_Text);

            Stream stream_OfFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, "", NAME_OF_FILE_2_IN_ROOT);
            string stream_OfFile2InRoot_Text = StreamHelper.StreamToString(stream_OfFile2InRoot, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_ROOT, () => stream_OfFile2InRoot_Text);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_SubNameSpaceNullOrEmpty_Succeeds()
        {
            string actualEmbeddedResourceName_ForFile1InRoot = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, null, NAME_OF_FILE_1_IN_ROOT);
            string expectedEmbeddedResourceName_ForFile1InRoot = "JJ.Framework.Common.Tests.EmbeddedResourceFile1InRoot.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile1InRoot, () => actualEmbeddedResourceName_ForFile1InRoot);

            string actualEmbeddedResourceName_ForFile2InRoot = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, "", NAME_OF_FILE_2_IN_ROOT);
            string expectedEmbeddedResourceName_ForFile2InRoot = "JJ.Framework.Common.Tests.EmbeddedResourceFile2InRoot.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile2InRoot, () => actualEmbeddedResourceName_ForFile2InRoot);
        }

        // With Sub Name Space

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace()
        {
            string actualText_OfFile1InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_SUB_NAME_SPACE);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_SUB_NAME_SPACE, () => actualText_OfFile1InSubNameSpace);

            string actualText_OfFile2InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_IN_SUB_NAME_SPACE);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_SUB_NAME_SPACE, () => actualText_OfFile2InSubNameSpace);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace()
        {
            byte[] actualBytes_OfFile1InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_SUB_NAME_SPACE);
            bool bytes_OfFile1InSubNameSpace_AreValid = actualBytes_OfFile1InSubNameSpace.SequenceEqual(_expectedBytes_OfFile1InSubNameSpace);
            AssertHelper.IsTrue(() => bytes_OfFile1InSubNameSpace_AreValid);

            byte[] actualBytes_OfFile2InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_IN_SUB_NAME_SPACE);
            bool bytes_OfFile2InSubNameSpace_AreValid = actualBytes_OfFile2InSubNameSpace.SequenceEqual(_expectedBytes_OfFile2InSubNameSpace);
            AssertHelper.IsTrue(() => bytes_OfFile2InSubNameSpace_AreValid);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace()
        {
            Stream stream_OfFile1InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_SUB_NAME_SPACE);
            string stream_OfFile1InSubNameSpace_Text = StreamHelper.StreamToString(stream_OfFile1InSubNameSpace, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_1_IN_SUB_NAME_SPACE, () => stream_OfFile1InSubNameSpace_Text);

            Stream stream_OfFile2InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_IN_SUB_NAME_SPACE);
            string stream_OfFile2InSubNameSpace_Text = StreamHelper.StreamToString(stream_OfFile2InSubNameSpace, _encoding);
            AssertHelper.AreEqual(EXPECTED_TEXT_OF_FILE_2_IN_SUB_NAME_SPACE, () => stream_OfFile2InSubNameSpace_Text);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace()
        {
            string actualEmbeddedResourceName_ForFile1InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_SUB_NAME_SPACE);
            string expectedEmbeddedResourceName_ForFile1InSubNameSpace = "JJ.Framework.Common.Tests.TestResources.EmbeddedResourceFile1InSubNameSpace.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile1InSubNameSpace, () => actualEmbeddedResourceName_ForFile1InSubNameSpace);

            string actualEmbeddedResourceName_ForFile2InSubNameSpace = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, NAME_OF_FILE_2_IN_SUB_NAME_SPACE);
            string expectedEmbeddedResourceName_ForFile2InSubNameSpace = "JJ.Framework.Common.Tests.TestResources.EmbeddedResourceFile2InSubNameSpace.txt";
            AssertHelper.AreEqual(expectedEmbeddedResourceName_ForFile2InSubNameSpace, () => actualEmbeddedResourceName_ForFile2InSubNameSpace);
        }

        // Not Found

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, NON_EXISTENT_FILE_NAME),
                $"Embedded resource 'JJ.Framework.Common.Tests.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_NonExistent_Succeeds()
        {
            string expectedEmbeddedResourceName = "JJ.Framework.Common.Tests.NonExistentFileName.txt";
            string actualEmbeddedResourceName = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, NON_EXISTENT_FILE_NAME);
            AssertHelper.AreEqual(expectedEmbeddedResourceName, () => actualEmbeddedResourceName);
        }

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace_NonExistent_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME),
                "Embedded resource 'JJ.Framework.Common.Tests.TestResources.NonExistentFileName.txt' not found.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace_NonExistent_Succeeds()
        {
            string expectedEmbeddedResourceName = "JJ.Framework.Common.Tests.TestResources.NonExistentFileName.txt";
            string actualEmbeddedResourceName = EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, NON_EXISTENT_FILE_NAME);
            AssertHelper.AreEqual(expectedEmbeddedResourceName, () => actualEmbeddedResourceName);
        }

        // Assembly Null

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace_AssemblyNull_ThrowsException()
            => AssertHelper.ThrowsException<ArgumentNullException>(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(assembly: null, SUB_NAME_SPACE, NAME_OF_FILE_1_IN_ROOT),
                "Value cannot be null.\r\nParameter name: assembly");

        // File Name Null or White Space

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithoutSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace_FileNameNull_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, fileName: null),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace_FileNameSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, fileName: ""),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceText_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceText(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceBytes_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceBytes(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceStream_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceStream(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");

        [TestMethod]
        public void Test_EmbeddedResourceHelper_GetEmbeddedResourceName_WithSubNameSpace_FileNameIsWhiteSpace_ThrowsException()
            => AssertHelper.ThrowsException(
                () => EmbeddedResourceHelper.GetEmbeddedResourceName(_assembly, SUB_NAME_SPACE, fileName: "    "),
                "fileName is null or white space.");
    }
}
