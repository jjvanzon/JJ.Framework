using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
    [TestClass]
    public class FileFunctionsTests_NumberFilePath
    {
        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_ConditionViolation_BaseFilePathNullOrEmpty()
        {
            AssertHelper.ThrowsException(() =>
                FileHelper.GetNumberedFilePath(null),
                "originalFilePath is null or empty.");

            AssertHelper.ThrowsException(() =>
                FileHelper.GetNumberedFilePath(""),
                "originalFilePath is null or empty.");
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNotNumbered()
        {
            string baseFilePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            string filePath = FileHelper.GetNumberedFilePath(baseFilePath);
            AssertHelper.AreEqual(baseFilePath, () => filePath);
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNumbered()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);
                File.Create(baseFilePath).Close();

                string expectedNumberedFilePath = Path.Combine(folderPath, "temp (1).txt");
                string numberedFilePath = FileHelper.GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AssertHelper.AreEqual(expectedNumberedFilePath, () => numberedFilePath);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNotNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = baseFilePath;
                string actualFilePath1 = FileHelper.GetNumberedFilePath(baseFilePath);
                AssertHelper.AreEqual(expectedFilePath1, () => actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                string actualFilePath2 = FileHelper.GetNumberedFilePath(baseFilePath);
                AssertHelper.AreEqual(expectedFilePath2, () => actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_FirstFileNumbered_TwoFiles()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string baseFilePath = Path.Combine(folderPath, "temp.txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                string expectedFilePath1 = Path.Combine(folderPath, "temp (1).txt");
                string actualFilePath1 = FileHelper.GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AssertHelper.AreEqual(expectedFilePath1, () => actualFilePath1);

                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = Path.Combine(folderPath, "temp (2).txt");
                string actualFilePath2 = FileHelper.GetNumberedFilePath(baseFilePath, mustNumberFirstFile: true);
                AssertHelper.AreEqual(expectedFilePath2, () => actualFilePath2);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_AlternativeNumberFormat()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            string expectedNumberedFilePath = Path.Combine(folderPath, "temp_001.txt");
            string numberedFilePath = FileHelper.GetNumberedFilePath(baseFilePath, "_", "000", "", mustNumberFirstFile: true);
            AssertHelper.AreEqual(expectedNumberedFilePath, () => numberedFilePath);
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_Try12Files()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string baseFilePath = Path.Combine(folderPath, "temp.txt");
            const int fileCount = 12;

            try
            {
                Directory.CreateDirectory(folderPath);

                for (int i = 1; i <= fileCount; i++)
                {
                    string filePath = FileHelper.GetNumberedFilePath(baseFilePath);
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
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string subDirectory = Path.Combine(folderPath, "temp2");

            string originalCurrentDirectory = Environment.CurrentDirectory;

            try
            {
                Directory.CreateDirectory(subDirectory);
                Environment.CurrentDirectory = folderPath;

                const string baseFilePath = @"temp2\temp.txt";

                string filePath1 = FileHelper.GetNumberedFilePath(baseFilePath);
                AssertHelper.AreEqual(@"temp2\temp.txt", () => filePath1);

                try
                {
                    File.Create(filePath1).Close();
                    string filePath2 = FileHelper.GetNumberedFilePath(baseFilePath);
                    AssertHelper.AreEqual(@"temp2\temp (2).txt", () => filePath2);
                }
                finally
                {
                    if (File.Exists(filePath1)) File.Delete(filePath1);
                }
            }
            finally
            {
                if (Directory.Exists(subDirectory)) Directory.Delete(subDirectory);
                Environment.CurrentDirectory = originalCurrentDirectory;
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetNumberedFilePath_InRoot()
        {
            string guid = Guid.NewGuid().ToString();
            string baseFilePath = @"C:\" + guid + ".txt";
            if (File.Exists(baseFilePath)) File.Delete(baseFilePath);

            string expectedFilePath1 = baseFilePath;
            string actualFilePath1 = FileHelper.GetNumberedFilePath(baseFilePath);
            AssertHelper.AreEqual(expectedFilePath1, () => actualFilePath1);

            try
            {
                File.Create(actualFilePath1).Close();

                string expectedFilePath2 = @"C:\" + guid + " (2).txt";
                string actualFilePath2 = FileHelper.GetNumberedFilePath(baseFilePath);
                AssertHelper.AreEqual(expectedFilePath2, () => actualFilePath2);
            }
            finally
            {
                if (File.Exists(actualFilePath1)) File.Delete(actualFilePath1);
            }
        }
    }
}
