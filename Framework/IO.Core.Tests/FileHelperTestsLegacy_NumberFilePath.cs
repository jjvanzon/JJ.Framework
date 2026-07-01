using static JJ.Framework.IO.Core.FileHelperCore;

namespace JJ.Framework.IO.Core.Tests
{
    [TestClass]
    public class FileHelperTestsLegacy_NumberFilePath
    {
        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_ConditionViolation_BaseFilePathNullOrEmpty()
        {
            Throws(() =>
                GetNumberedFilePath(null!),
                "originalFilePath is null or empty.");

            Throws(() =>
                GetNumberedFilePath(""),
                "originalFilePath is null or empty.");
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNotNumbered()
        {
            string baseFilePath = TestHelper.GenerateFileName();
            string filePath = GetNumberedFilePath(baseFilePath);
            AreEqual(baseFilePath, filePath);
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNumbered()
        {
            string folderPath = TestHelper.GenerateFolderName();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);
                File.Create(baseFilePath).Close();

                string expectedNumberedFilePath = Path.Combine(folderPath, "temp (1).txt");
                string numberedFilePath = GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AreEqual(expectedNumberedFilePath, numberedFilePath);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNotNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderName();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = baseFilePath;
                string actualFilePath1 = GetNumberedFilePath(baseFilePath);
                AreEqual(expectedFilePath1, actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                string actualFilePath2 = GetNumberedFilePath(baseFilePath);
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderName();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = Path.Combine(folderPath, "temp (1).txt");
                string actualFilePath1 = GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AreEqual(expectedFilePath1, actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                string actualFilePath2 = GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AreEqual(expectedFilePath2, actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_AlternativeNumberFormat()
        {
            string folderPath = TestHelper.GenerateFolderName();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            string expectedNumberedFilePath = Path.Combine(folderPath, "temp_001.txt");
            string numberedFilePath = GetNumberedFilePath(baseFilePath, "_", "000", "", mustNumberFirstFile: true);
            AreEqual(expectedNumberedFilePath, numberedFilePath);
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_Try12Files()
        {
            string folderPath = TestHelper.GenerateFolderName();
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            const int fileCount = 12;

            try
            {
                Directory.CreateDirectory(folderPath);

                for (var i = 1; i <= fileCount; i++)
                {
                    string filePath = GetNumberedFilePath(baseFilePath);
                    File.Create(filePath).Close();
                }
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_RelativePath()
        {
            string folderPath = TestHelper.GenerateFolderName();

            string originalCurrentDirectory = CurrentDirectory;
            try
            {
                Directory.CreateDirectory(folderPath);
                CurrentDirectory = folderPath;

                const string baseFilePath = "temp.txt";

                const string expectedFilePath1 = "temp.txt";
                string actualFilePath = GetNumberedFilePath(baseFilePath);
                AreEqual(expectedFilePath1, actualFilePath);

                File.Create("temp.txt").Close();
                const string expectedFilePath2 = "temp (2).txt";
                string actualFilePath2 = GetNumberedFilePath(baseFilePath);
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
        public void Test_FileFunctions_GetNumberedFilePath_InRoot()
        {
            string guid = Guid.NewGuid().ToString();
            string baseFilePath = @"C:\" + guid + ".txt";
            if (File.Exists(baseFilePath)) File.Delete(baseFilePath);

            string expectedFilePath1 = baseFilePath;
            string actualFilePath1 = GetNumberedFilePath(baseFilePath);
            AreEqual(expectedFilePath1, actualFilePath1);

            try
            {
                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = @"C:\" + guid + " (2).txt";
                string actualFilePath2 = GetNumberedFilePath(baseFilePath);
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
