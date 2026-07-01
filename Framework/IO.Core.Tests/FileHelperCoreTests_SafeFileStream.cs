using static JJ.Framework.IO.Core.FileHelperCore;

namespace JJ.Framework.IO.Core.Tests
{
    [TestClass]
    public class FileHelperCoreTests_SafeFileStream
    {
        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_ConditionViolation_BaseFilePathNullOrEmpty()
        {
            Throws(() =>
                CreateSafeFileStream(null!),
                "originalFilePath is null or empty.");

            Throws(() =>
                CreateSafeFileStream(""),
                "originalFilePath is null or empty.");
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_FirstFileNotNumbered()
        {
            string baseFilePath = TestHelper.GenerateFilePath();
            (string filePath, Stream stream) = CreateSafeFileStream(baseFilePath);
            stream.Dispose();
            AreEqual(baseFilePath, filePath);
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_FirstFileNumbered()
        {
            string folderPath = TestHelper.GenerateFolderPath();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);
                File.Create(baseFilePath).Close();

                string expectedNumberedFilePath = Path.Combine(folderPath, "temp (1).txt");
                (string numberedFilePath, Stream stream) = CreateSafeFileStream(baseFilePath, mustNumberFirstFile: true);
                stream.Dispose();
                AreEqual(expectedNumberedFilePath, numberedFilePath);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_FirstFileNotNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderPath();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = baseFilePath;
                (string actualFilePath1, Stream stream1) = CreateSafeFileStream(baseFilePath);
                stream1.Dispose();
                AreEqual(expectedFilePath1, actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                (string actualFilePath2, Stream stream2) = CreateSafeFileStream(baseFilePath);
                stream2.Dispose();
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_FirstFileNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderPath();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = Path.Combine(folderPath, "temp (1).txt");
                (string actualFilePath1, Stream stream1) = CreateSafeFileStream(baseFilePath, mustNumberFirstFile: true);
                stream1.Dispose();
                AreEqual(expectedFilePath1, actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                (string actualFilePath2, Stream stream2) = CreateSafeFileStream(baseFilePath, mustNumberFirstFile: true);
                stream2.Dispose();
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_AlternativeNumberFormat()
        {
            string folderPath = TestHelper.GenerateFolderPath();
            Directory.CreateDirectory(folderPath);
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            string expectedNumberedFilePath = Path.Combine(folderPath, "temp_001.txt");
            (string numberedFilePath, Stream stream) = CreateSafeFileStream(baseFilePath, "_", "000", "", mustNumberFirstFile: true);
            stream.Dispose();
            AreEqual(expectedNumberedFilePath, numberedFilePath);
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_Try12Files()
        {
            string folderPath = TestHelper.GenerateFolderPath();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            const int fileCount = 12;

            try
            {
                Directory.CreateDirectory(folderPath);

                for (var i = 1; i <= fileCount; i++)
                {
                    (string filePath, Stream stream) = CreateSafeFileStream(baseFilePath);
                    stream.Dispose();
                    File.Create(filePath).Close();
                }
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_RelativePath()
        {
            string folderPath = TestHelper.GenerateFolderPath();

            string originalCurrentDirectory = CurrentDirectory;
            try
            {
                Directory.CreateDirectory(folderPath);
                CurrentDirectory = folderPath;

                const string baseFilePath = "temp.txt";

                const string expectedFilePath1 = "temp.txt";
                (string actualFilePath, Stream stream1) = CreateSafeFileStream(baseFilePath);
                stream1.Dispose();
                AreEqual(expectedFilePath1, actualFilePath);

                File.Create("temp.txt").Close();
                const string expectedFilePath2 = "temp (2).txt";
                (string actualFilePath2, Stream stream2) = CreateSafeFileStream(baseFilePath);
                stream2.Dispose();
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                CurrentDirectory = originalCurrentDirectory;
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        // Not permitted in Azure Pipelines Local Agent
        /*
        [TestMethod]
        public void Test_FileHelper_CreateSafeFileStream_InRoot()
        {
            string guid = Guid.NewGuid().ToString();
            string baseFilePath = @"C:\" + guid + ".txt";
            if (File.Exists(baseFilePath)) File.Delete(baseFilePath);

            string expectedFilePath1 = baseFilePath;
            string actualFilePath1 = CreateSafeFileStream(baseFilePath);
            AreEqual(expectedFilePath1, actualFilePath1);

            try
            {
                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = @"C:\" + guid + " (2).txt";
                string actualFilePath2 = CreateSafeFileStream(baseFilePath);
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                if (File.Exists(actualFilePath1)) File.Delete(actualFilePath1);
            }
        }
        */
    }
}
