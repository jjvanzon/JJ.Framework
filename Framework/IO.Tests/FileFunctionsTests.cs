using System;
using System.IO;
using System.Reflection;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ImplicitlyCapturedClosure
// ReSharper disable AccessToModifiedClosure

namespace JJ.Framework.IO.Tests
{
    [TestClass]
    public class FileFunctionsTests
    {
        // ClearFolder

        public void Test_FileFunctions_ClearFolder(string folderPath, Action overloadToTest)
        {
            string filePath1 = Path.Combine(folderPath, "temp (1).txt");
            string filePath2 = Path.Combine(folderPath, "temp (2).txt");
            try
            {
                Directory.CreateDirectory(folderPath);
                File.Create(filePath1).Close();
                File.Create(filePath2).Close();

                Assert.AreEqual(2, Directory.GetFiles(folderPath).Length, "temp file count");
                overloadToTest();
                Assert.AreEqual(0, Directory.GetFiles(folderPath).Length, "temp file count");
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ClearFolder_FolderPath()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_ClearFolder(folderPath, () => FileHelper.ClearFolder(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_ClearFolder_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            Test_FileFunctions_ClearFolder(folderPath, () => FileHelper.ClearFolder(directory));
        }

        // ClearFolderRecursive

        public void Test_FileFunctions_ClearFolderRecursive(string folderPath, Action overloadToTest)
        {
            string file1 = Path.Combine(folderPath, "File1.txt");
            string file2 = Path.Combine(folderPath, "File2.txt");
            string subFolder1 = Path.Combine(folderPath, "Subfolder1");
            string subFolder2 = Path.Combine(folderPath, "Subfolder2");
            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

            try
            {
                // Create structure
                Directory.CreateDirectory(folderPath);
                File.Create(file1).Close();
                File.Create(file2).Close();
                Directory.CreateDirectory(subFolder1);
                Directory.CreateDirectory(subFolder2);
                File.Create(subFolder2File1).Close();
                File.Create(subFolder2File2).Close();

                // AssertHelper exists
                AssertHelper.IsTrue(() => File.Exists(file1));
                AssertHelper.IsTrue(() => File.Exists(file2));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

                // Call method to test
                overloadToTest();

                // AssertHelper not exists
                AssertHelper.IsFalse(() => File.Exists(file1));
                AssertHelper.IsFalse(() => File.Exists(file2));
                AssertHelper.IsFalse(() => Directory.Exists(subFolder1));
                AssertHelper.IsFalse(() => Directory.Exists(subFolder2));
                AssertHelper.IsFalse(() => File.Exists(subFolder2File1));
                AssertHelper.IsFalse(() => File.Exists(subFolder2File2));

                // AssertHelper directory itself is not removed
                AssertHelper.IsTrue(() => Directory.Exists(folderPath));
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ClearFolderRecursive_Path()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_ClearFolderRecursive(folderPath, () => FileHelper.ClearFolderRecursive(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_ClearFolderRecursive_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            var directory = new DirectoryInfo(folderPath);
            Test_FileFunctions_ClearFolderRecursive(folderPath, () => FileHelper.ClearFolderRecursive(directory));
        }

        // ApplicationPath

        [TestMethod]
        public void Test_FileFunctions_ApplicationPath()
        {
            Assert.Inconclusive("Cannot determine validity, because the application path cannot (easily) be determined in the test engine.");
            //string binName = Assembly.GetCallingAssembly().ManifestModule.Name;
            //Assert.IsTrue(File.Exists(Path.Combine(FileHelper.ApplicationFolderPath, binName)));
        }

        // IsFolder

        [TestMethod]
        public void Test_FileFunctions_IsFolder_True_Existing()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            try
            {
                Directory.CreateDirectory(folderPath);
                AssertHelper.IsTrue(() => FileHelper.IsFolder(folderPath));
            }
            finally
            {
                DeleteFileOrFolder(folderPath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsFolder_True_NonExistent()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            AssertHelper.IsTrue(() => FileHelper.IsFolder(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_IsFolder_True_LooksLikeFile_Existent()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                Directory.CreateDirectory(filePath);

                AssertHelper.IsTrue(() => FileHelper.IsFolder(filePath));
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsFolder_False_ClearlyLooksLikeFile_NonExistent()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());

            AssertHelper.IsFalse(() => FileHelper.IsFolder(filePath));
        }


        [TestMethod]
        public void Test_FileFunctions_IsFolder_False_HasPeriodButClearlyNotFile()
        {
            string path = Path.Combine(TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod()), "JJ.Framework.IO");

            AssertHelper.IsFalse(() => FileHelper.IsFolder(path));
        }

        // IsFile

        [TestMethod]
        public void Test_FileFunctions_IsFile_True_Existing()
        {
            string fileName = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                File.Create(fileName).Close();

                AssertHelper.IsTrue(() => FileHelper.IsFile(fileName));
            }
            finally
            {
                DeleteFileOrFolder(fileName);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsFile_True_NonExistent()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            AssertHelper.IsTrue(() => FileHelper.IsFile(filePath));
        }

        [TestMethod]
        public void Test_FileFunctions_IsFile_True_LooksLikeFolder_Existing()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            string obscurePath = Path.Combine(folderPath, "temp");
            try
            {
                Directory.CreateDirectory(folderPath);
                File.Create(obscurePath).Close();
                AssertHelper.IsTrue(() => FileHelper.IsFile(obscurePath));
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsFile_False_LooksLikeFolder_NonExistent()
        {
            string path = Path.Combine(TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod()), "temp");
            AssertHelper.IsFalse(() => FileHelper.IsFile(path));
        }

        // GetFolderSize

        public void Test_FileFunctions_GetFolderSize(string folderPath, Func<long> overloadToTest)
        {
            string filePath1 = Path.Combine(folderPath, "temp (1).txt");
            string filePath2 = Path.Combine(folderPath, "temp (2).txt");

            try
            {
                Directory.CreateDirectory(folderPath);

                using (var writer = File.CreateText(filePath1))
                {
                    writer.Write("1234567890");
                }

                using (var writer = File.CreateText(filePath2))
                {
                    writer.Write("12345");
                }

                long folderSize = overloadToTest();

                AssertHelper.AreEqual(15, () => folderSize);
            }
            finally
            {
                Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetFolderSize_Path()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_GetFolderSize(folderPath, () => FileHelper.GetFolderSize(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_GetFolderSize_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_GetFolderSize(folderPath, () => FileHelper.GetFolderSize(folderPath));
        }

        // GetFolderSizeRecursive

        public void Test_FileFunctions_GetFolderSizeRecursive(string folderPath, Func<long> overloadToTest)
        {
            string file1 = Path.Combine(folderPath, "File1.txt");
            string file2 = Path.Combine(folderPath, "File2.txt");
            string subFolder1 = Path.Combine(folderPath, "Subfolder1");
            string subFolder2 = Path.Combine(folderPath, "Subfolder2");
            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

            try
            {
                // Create structure
                Directory.CreateDirectory(folderPath);
                File.WriteAllBytes(file1, new byte[] { 0x10 });
                File.WriteAllBytes(file2, new byte[] { 0x20, 0x30 });
                Directory.CreateDirectory(subFolder1);
                Directory.CreateDirectory(subFolder2);
                File.WriteAllBytes(subFolder2File1, new byte[] { 0x40, 0x50, 0x60 });
                File.WriteAllBytes(subFolder2File2, new byte[] { 0x70, 0x80, 0x90, 0xA0 });

                // AssertHelper exists
                AssertHelper.IsTrue(() => File.Exists(file1));
                AssertHelper.IsTrue(() => File.Exists(file2));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

                // Call method to test
                long size = overloadToTest();

                AssertHelper.AreEqual(10, () => size);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_GetFolderSizeRecursive_Path()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_GetFolderSizeRecursive(folderPath, () => FileHelper.GetFolderSizeRecursive(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_GetFolderSizeRecursive_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            var directory = new DirectoryInfo(folderPath);
            Test_FileFunctions_GetFolderSizeRecursive(folderPath, () => FileHelper.GetFolderSizeRecursive(directory));
        }

        // CountFilesRecursive

        public void Test_FileFunctions_CountFilesRecursive(string folderPath, Func<int> overloadToTest)
        {
            string file1 = Path.Combine(folderPath, "File1.txt");
            string file2 = Path.Combine(folderPath, "File2.txt");
            string subFolder1 = Path.Combine(folderPath, "Subfolder1");
            string subFolder2 = Path.Combine(folderPath, "Subfolder2");
            string subFolder2File1 = Path.Combine(subFolder2, "Subfolder2 file1.txt");
            string subFolder2File2 = Path.Combine(subFolder2, "Subfolder2 file2.txt");

            try
            {
                // Create structure
                Directory.CreateDirectory(folderPath);
                File.Create(file1).Close();
                File.Create(file2).Close();
                Directory.CreateDirectory(subFolder1);
                Directory.CreateDirectory(subFolder2);
                File.Create(subFolder2File1).Close();
                File.Create(subFolder2File2).Close();

                // AssertHelper exists
                AssertHelper.IsTrue(() => File.Exists(file1));
                AssertHelper.IsTrue(() => File.Exists(file2));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder1));
                AssertHelper.IsTrue(() => Directory.Exists(subFolder2));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File1));
                AssertHelper.IsTrue(() => File.Exists(subFolder2File2));

                // Call method to test
                int count = overloadToTest();

                AssertHelper.AreEqual(4, () => count);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_CountFilesRecursive_Path()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());

            Test_FileFunctions_CountFilesRecursive(folderPath, () => FileHelper.CountFilesRecursive(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_CountFilesRecursive_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            var directory = new DirectoryInfo(folderPath);
            Test_FileFunctions_CountFilesRecursive(folderPath, () => FileHelper.CountFilesRecursive(directory));
        }

        // FolderIsEmpty

        public void Test_FileFunctions_FolderIsEmpty(string folderPath, Func<bool> overloadToTest)
        {
            try
            {
                Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, "temp.txt");

                // ReSharper disable once JoinDeclarationAndInitializer
                bool folderIsEmpty;

                folderIsEmpty = overloadToTest();
                AssertHelper.IsTrue(() => folderIsEmpty);

                File.Create(filePath).Close();
                folderIsEmpty = overloadToTest();
                AssertHelper.IsFalse(() => folderIsEmpty);
            }
            finally
            {
                if (Directory.Exists(folderPath)) Directory.Delete(folderPath, recursive: true);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_FolderIsEmpty_Path()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_FolderIsEmpty(folderPath, () => FileHelper.FolderIsEmpty(folderPath));
        }

        [TestMethod]
        public void Test_FileFunctions_FolderIsEmpty_DirectoryInfo()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
            var directory = new DirectoryInfo(folderPath);
            Test_FileFunctions_FolderIsEmpty(folderPath, () => FileHelper.FolderIsEmpty(directory));
        }

        // HideFile, ShowFile

        public void Test_FileFunctions_HideFile_ShowFile(string filePath, Action hideFileOverload, Action showFileOverload)
        {
            try
            {
                File.Create(filePath).Close();

                hideFileOverload();
                var fileInfo1 = new FileInfo(filePath);
                AssertHelper.AreEqual(FileAttributes.Archive | FileAttributes.Hidden, () => fileInfo1.Attributes);

                showFileOverload();
                var fileInfo2 = new FileInfo(filePath);
                AssertHelper.AreEqual(FileAttributes.Archive, () => fileInfo2.Attributes);
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_HideFile_ShowFile_Path()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_HideFile_ShowFile(
                filePath,
                () => FileHelper.HideFile(filePath),
                () => FileHelper.ShowFile(filePath));
        }

        [TestMethod]
        public void Test_FileFunctions_HideFile_ShowFile_FileInfo()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            var fileInfo = new FileInfo(filePath);
            Test_FileFunctions_HideFile_ShowFile(
                filePath,
                () => FileHelper.HideFile(fileInfo),
                () => FileHelper.ShowFile(fileInfo));
        }

        // IsHidden

        public void Test_FileFunctions_IsHidden(string filePath, Func<bool> overloadToTest)
        {
            try
            {
                File.Create(filePath).Close();
                var fileInfo = new FileInfo(filePath);

                // ReSharper disable once JoinDeclarationAndInitializer
                bool isHidden;
                isHidden = overloadToTest();
                AssertHelper.IsFalse(() => isHidden);

                fileInfo.Attributes |= FileAttributes.Hidden;
                isHidden = overloadToTest();
                AssertHelper.IsTrue(() => isHidden);
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsHidden_Path()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_IsHidden(filePath, () => FileHelper.IsHidden(filePath));
        }

        [TestMethod]
        public void Test_FileFunctions_IsHidden_FileInfo()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_IsHidden(filePath, () => FileHelper.IsHidden(new FileInfo(filePath)));
        }

        // MakeReadOnly, MakeWritable

        public void Test_FileFunctions_MakeReadOnly_MakeWritable(string filePath, Action makeReadOnlyOverload, Action makeWritableOverload)
        {
            try
            {
                File.Create(filePath).Close();

                makeReadOnlyOverload();
                var fileInfo1 = new FileInfo(filePath);
                AssertHelper.AreEqual(FileAttributes.Archive | FileAttributes.ReadOnly, () => fileInfo1.Attributes);

                makeWritableOverload();
                var fileInfo2 = new FileInfo(filePath);
                AssertHelper.AreEqual(FileAttributes.Archive, () => fileInfo2.Attributes);
            }
            finally
            {
                var fileInfo = new FileInfo(filePath);
                fileInfo.Attributes &= ~FileAttributes.ReadOnly;
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_MakeReadOnly_MakeWritable_Path()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_MakeReadOnly_MakeWritable(
                filePath,
                () => FileHelper.MakeReadOnly(filePath),
                () => FileHelper.MakeWritable(filePath));
        }

        [TestMethod]
        public void Test_FileFunctions_MakeReadOnly_MakeWritable_FilePath()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            var file = new FileInfo(filePath);
            Test_FileFunctions_MakeReadOnly_MakeWritable(
                filePath,
                () => FileHelper.MakeReadOnly(file),
                () => FileHelper.MakeWritable(file));
        }

        // IsReadOnly

        public void Test_FileFunctions_IsReadOnly(string filePath, Func<bool> overloadToTest)
        {
            try
            {
                File.Create(filePath).Close();
                var fileInfo = new FileInfo(filePath);

                // ReSharper disable once JoinDeclarationAndInitializer
                bool isReadOnly;
                isReadOnly = overloadToTest();
                AssertHelper.IsFalse(() => isReadOnly);

                fileInfo.Attributes |= FileAttributes.ReadOnly;
                isReadOnly = overloadToTest();
                AssertHelper.IsTrue(() => isReadOnly);
            }
            finally
            {
                var fileInfo = new FileInfo(filePath);
                fileInfo.Attributes &= ~FileAttributes.ReadOnly;

                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_IsReadOnly_Path()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_IsReadOnly(filePath, () => FileHelper.IsReadOnly(filePath));
        }

        [TestMethod]
        public void Test_FileFunctions_IsReadOnly_FileInfo()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            Test_FileFunctions_IsReadOnly(filePath, () => FileHelper.IsReadOnly(new FileInfo(filePath)));
        }

        // ReadAllText

        [TestMethod]
        public void Test_FileFunctions_ReadAllText_OriginalRequiresWriteAccess()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                File.Create(filePath).Close();
                using (new FileLock(filePath, LockEnum.Write))
                {
                    AssertHelper.ThrowsException<IOException>(() => { File.ReadAllText(filePath); });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_False()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                File.Create(filePath).Close();
                using (new FileLock(filePath, LockEnum.Write))
                {
                    FileHelper.ReadAllText(filePath, requireWriteAccess: false);
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_True()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                File.Create(filePath).Close();
                using (new FileLock(filePath, LockEnum.Write))
                {
                    // ReSharper disable once RedundantArgumentDefaultValue
                    AssertHelper.ThrowsException<IOException>(() => { FileHelper.ReadAllText(filePath, requireWriteAccess: true); });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllText_RequireWriteAccess_Default_True()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                File.Create(filePath).Close();
                using (new FileLock(filePath, LockEnum.Write))
                {
                    AssertHelper.ThrowsException<IOException>(() => { FileHelper.ReadAllText(filePath); });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        // ReadAllLines

        [TestMethod]
        public void Test_FileFunctions_ReadAllLines_OriginalRequiresWriteAccess()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                string[] lines = { "Line 1", "Line 2" };
                File.WriteAllLines(filePath, lines);

                using (new FileLock(filePath, LockEnum.Write))
                {
                    AssertHelper.ThrowsException<IOException>(() => { File.ReadAllLines(filePath); });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_False()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                string[] lines = { "Line 1", "Line 2" };
                File.WriteAllLines(filePath, lines);

                using (new FileLock(filePath, LockEnum.Write))
                {
                    FileHelper.ReadAllLines(filePath, requireWriteAccess: false);
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_True()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                string[] lines = { "Line 1", "Line 2" };
                File.WriteAllLines(filePath, lines);

                using (new FileLock(filePath, LockEnum.Write))
                {
                    AssertHelper.ThrowsException<IOException>(() =>
                    {
                        // ReSharper disable once RedundantArgumentDefaultValue
                        FileHelper.ReadAllLines(filePath, requireWriteAccess: true);
                    });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ReadAllLines_RequireWriteAccess_Default_True()
        {
            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());
            try
            {
                string[] lines = { "Line 1", "Line 2" };
                File.WriteAllLines(filePath, lines);

                using (new FileLock(filePath, LockEnum.Write))
                {
                    AssertHelper.ThrowsException<IOException>(() =>
                    {
                        FileHelper.ReadAllLines(filePath);
                    });
                }
            }
            finally
            {
                DeleteFileOrFolder(filePath);
            }
        }

        // Condition Violations

        [TestMethod]
        public void Test_FileFunctions_ConditionViolations_PathNullOrEmpty()
        {
            Action[] folderPathActions = {
                () => FileHelper.ClearFolder((string)null),
                () => FileHelper.ClearFolder(""),
                () => FileHelper.ClearFolderRecursive((string)null),
                () => FileHelper.ClearFolderRecursive(""),
                () => FileHelper.GetFolderSize((string)null),
                () => FileHelper.GetFolderSize(""),
                () => FileHelper.GetFolderSizeRecursive((string)null),
                () => FileHelper.GetFolderSizeRecursive(""),
                () => FileHelper.CountFilesRecursive((string)null),
                () => FileHelper.CountFilesRecursive(""),
                () => FileHelper.FolderIsEmpty((string)null),
                () => FileHelper.FolderIsEmpty("")};

            foreach (var action in folderPathActions)
            {
                AssertHelper.ThrowsException(() => action(), "folderPath is null or empty.");
            }

            Action[] filePathActions = {
                () => FileHelper.IsHidden((string)null),
                () => FileHelper.IsHidden(""),
                () => FileHelper.MakeReadOnly((string)null),
                () => FileHelper.MakeReadOnly(""),
                () => FileHelper.MakeWritable((string)null),
                () => FileHelper.MakeWritable(""),
                () => FileHelper.IsReadOnly((string)null),
                () => FileHelper.IsReadOnly(""),
                () => FileHelper.HideFile((string)null),
                () => FileHelper.HideFile(""),
                () => FileHelper.ShowFile((string)null),
                () => FileHelper.ShowFile("")};

            foreach (var action in filePathActions)
            {
                AssertHelper.ThrowsException(() => action(), "filePath is null or empty.");
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ConditionViolations_NotExists()
        {
            string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());

            Action[] folderPathActions = {
                () => FileHelper.ClearFolder(folderPath),
                () => FileHelper.ClearFolderRecursive(folderPath),
                () => FileHelper.GetFolderSize(folderPath),
                () => FileHelper.GetFolderSizeRecursive(folderPath),
                () => FileHelper.CountFilesRecursive(folderPath),
                () => FileHelper.FolderIsEmpty(folderPath)};

            foreach (var action in folderPathActions)
            {
                AssertHelper.ThrowsException(
                    () => action(),
                    $"Folder '{folderPath}' does not exist.");
            }

            string filePath = TestHelper.GenerateFileName(MethodBase.GetCurrentMethod());

            Action[] filePathActions = {
                () => FileHelper.HideFile(filePath),
                () => FileHelper.ShowFile(filePath),
                () => FileHelper.IsHidden(filePath),
                () => FileHelper.MakeReadOnly(filePath),
                () => FileHelper.MakeWritable(filePath),
                () => FileHelper.IsReadOnly(filePath)};

            foreach (var action in filePathActions)
            {
                AssertHelper.ThrowsException(
                    () => action(),
                    $"File '{filePath}' does not exist.");
            }
        }

        [TestMethod]
        public void Test_FileFunctions_ConditionViolations_FileSystemInfoNull()
        {
            Action[] directoryActions = {
                () => FileHelper.ClearFolder((DirectoryInfo)null),
                () => FileHelper.ClearFolderRecursive((DirectoryInfo)null),
                () => FileHelper.GetFolderSize((DirectoryInfo)null),
                () => FileHelper.GetFolderSizeRecursive((DirectoryInfo)null),
                () => FileHelper.CountFilesRecursive((DirectoryInfo)null),
                () => FileHelper.FolderIsEmpty((DirectoryInfo)null)};

            foreach (var action in directoryActions)
            {
                AssertHelper.ThrowsException(
                    () => action(),
                    "directoryInfo is null.");
            }

            Action[] fileActions = {
                () => FileHelper.HideFile((FileInfo)null),
                () => FileHelper.ShowFile((FileInfo)null),
                () => FileHelper.IsHidden((FileInfo)null),
                () => FileHelper.MakeReadOnly((FileInfo)null),
                () => FileHelper.MakeWritable((FileInfo)null),
                () => FileHelper.IsReadOnly((FileInfo)null)};

            foreach (var action in fileActions)
            {
                AssertHelper.ThrowsException(
                    () => action(),
                    "fileInfo is null.");
            }
        }

        // Relative to absolute and back

        [TestMethod]
        public void Test_FileFunctions_ToAbsolutePath_ToRelativePath()
        {
            const string originalRelativePath = @"SubFolder2\..\SubFolder2\File.txt";

            string absolutePath = FileHelper.ToAbsolutePath(@"SubFolder1", originalRelativePath);
            string expectedAbsolutePath = Path.Combine(Environment.CurrentDirectory, @"SubFolder1", @"SubFolder2\File.txt");
            AssertHelper.AreEqual(expectedAbsolutePath, () => absolutePath);

            string relativePath = FileHelper.ToRelativePath(@"SubFolder1\..\SubFolder1", absolutePath);
            const string expectedRelativePath = @"SubFolder2\File.txt";
            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
        }

        [TestMethod]
        public void Test_FileFunctions_ToAbsolutePath_BasePathNull()
        {
            string absolutePath = FileHelper.ToAbsolutePath("Folder");
            string expectedAbsolutePath = Path.Combine(Environment.CurrentDirectory, "Folder");
            AssertHelper.AreEqual(expectedAbsolutePath, () => absolutePath);
        }

        [TestMethod]
        public void Test_FileFunctions_ToAbsolutePath_RelativePathNull()
        {
            string basePath = Environment.CurrentDirectory;
            string absolutePath = FileHelper.ToAbsolutePath(basePath, null);
            AssertHelper.AreEqual(basePath, () => absolutePath);
        }

        [TestMethod]
        public void Test_FileFunctions_RelativePath_BasePathNull()
        {
            string relativePath = FileHelper.ToRelativePath("SubFolder");
            const string expectedRelativePath = "SubFolder";
            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
        }

        [TestMethod]
        public void Test_FileFunctions_ToRelativePath_AbsolutePathNull()
        {
            string relativePath = FileHelper.ToRelativePath("BaseSubFolder", null);
            const string expectedRelativePath = "";
            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
        }

        [TestMethod]
        public void Test_FileFunctions_ToRelativePath_OverloadWithoutBasePath()
        {
            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder", "File.txt"));
            const string expectedRelativePath = @"Folder\File.txt";
            string relativePath = FileHelper.ToRelativePath(absolutePath);
            AssertHelper.AreEqual(expectedRelativePath, () => relativePath);
        }

        [TestMethod]
        public void Test_FileFunctions_PathsAreEqual()
        {
            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder"));
            string relativePath = FileHelper.ToRelativePath(absolutePath);
            AssertHelper.IsTrue(() => FileHelper.PathsAreEqual(absolutePath, relativePath));
        }

        [TestMethod]
        public void Test_FileFunctions_PathsAreEqual_False()
        {
            string absolutePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Folder"));
            string relativePath = FileHelper.ToRelativePath(absolutePath);

            // Change one of the paths.
            absolutePath = Path.Combine(absolutePath, "Folder2");

            AssertHelper.IsFalse(() => FileHelper.PathsAreEqual(absolutePath, relativePath));
        }

        [TestMethod]
        public void Test_FileFunctions_ToAbsolutePath_OverloadWithSingleStringParameter()
        {
            Assert.Inconclusive("Test not implemented yet.");
        }

        // Helpers

        private void DeleteFileOrFolder(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            if (Directory.Exists(path)) Directory.Delete(path);
        }
    }
}
