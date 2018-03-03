using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JJ.Framework.Exceptions;
using JJ.Framework.Text;

namespace JJ.Framework.IO
{
	public static class FileHelper
	{
		/// <summary>
		/// If the originalFilePath already exists,
		/// a higher and higher number is inserted into the file name 
		/// until a file name is encountered that does not exists.
		/// Than that file path file path is returned.
		/// </summary>
		/// <param name="originalFilePath">
		/// The absolute path to a file name, that does not yet have a number in it.
		/// </param>
		public static string GetNumberedFilePath(
			string originalFilePath,
			string numberPrefix = " (",
			string numberFormatString = "#",
			string numberSuffix = ")",
			bool mustNumberFirstFile = false)
		{
			if (string.IsNullOrEmpty(originalFilePath)) throw new NullOrEmptyException(() => originalFilePath);

			if (!mustNumberFirstFile && !File.Exists(originalFilePath))
			{
				return originalFilePath;
			}

			string folderPath = Path.GetDirectoryName(originalFilePath).TrimEnd(@"\"); // Remove slash from root (e.g. @"C:\")
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(originalFilePath);
			string fileExtension = Path.GetExtension(originalFilePath);
			string separator = !string.IsNullOrEmpty(folderPath) ? "\\" : "";

			int number = mustNumberFirstFile ? 1 : 2;
			string filePath;
			do
			{
				filePath = $@"{folderPath}{separator}{fileNameWithoutExtension}{numberPrefix}{number.ToString(numberFormatString)}{numberSuffix}{fileExtension}";
				number++;
			} while (File.Exists(filePath));

			return filePath;
		}

		/// <summary> In contrast to Directory.Delete(), it only deletes the content in it, not the directory itself. </summary>
		public static void ClearFolder(string folderPath)
		{
			AssertFolderExists(folderPath);
			var directoryInfo = new DirectoryInfo(folderPath);
			ClearFolder(directoryInfo);
		}

		/// <summary> In contrast to Directory.Delete(), it only deletes the content in it, not the directory itself. </summary>
		public static void ClearFolder(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);

			foreach (FileInfo file in directoryInfo.GetFiles())
			{
				file.Delete();
			}
		}

		/// <summary> In contrast to Directory.Delete(), it only deletes the content in it, not the directory itself. </summary>
		public static void ClearFolderRecursive(string folderPath)
		{
			AssertFolderExists(folderPath);
			ClearFolderRecursive(new DirectoryInfo(folderPath));
		}

		/// <summary> In contrast to Directory.Delete(), it only deletes the content in it, not the directory itself. </summary>
		public static void ClearFolderRecursive(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);

			foreach (FileInfo fileInfo in directoryInfo.GetFiles())
			{
				fileInfo.Delete();
			}

			foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
			{
				ClearFolderRecursive(subDirectoryInfo);
				subDirectoryInfo.Delete();
			}
		}

		/// <summary>Gets that path without command line parameters, or executable file name, etc.</summary>
		public static string ApplicationFolderPath
		{
			get
			{
				string value = Environment.CommandLine; // "C:\Folder\Program.exe" /C
				value = value.TrimEndUntil(@""""); // "C:\Folder\Program.exe"
				value = value.TrimEnd(@""""); // "C:\Folder\Program.exe
				value = value.TrimStart(@""""); // C:\Folder\Program.exe
				return Path.GetDirectoryName(value); // C:\Folder
			}
		}

		/// <summary>
		/// If the folder actually exists, true is returned.
		/// Otherwise, it returns true if the path does not have an extension.
		/// </summary>
		public static bool IsFolder(string path)
		{
			// ReSharper disable once ConvertIfStatementToReturnStatement
			if (Directory.Exists(path)) return true;
			return string.IsNullOrEmpty(Path.GetExtension(path));
		}

		/// <summary>
		/// If the file actually exists, true is returned.
		/// Otherwise, it returns true if the path has an extension.
		/// </summary>
		public static bool IsFile(string path)
		{
			if (File.Exists(path)) return true;
			return !string.IsNullOrEmpty(Path.GetExtension(path));
		}

		public static void AssertFolderExists(string folderPath)
		{
			if (string.IsNullOrEmpty(folderPath)) throw new NullOrEmptyException(() => folderPath);
			if (!Directory.Exists(folderPath)) throw new FolderDoesNotExistException(folderPath);
		}

		public static long GetFolderSize(string folderPath)
		{
			AssertFolderExists(folderPath);
			var directoryInfo = new DirectoryInfo(folderPath);
			return GetFolderSize(directoryInfo);
		}

		public static long GetFolderSize(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);
			IList<FileInfo> fileInfos = directoryInfo.GetFiles();
			return fileInfos.Sum(x => x.Length);
		}

		public static long GetFolderSizeRecursive(string folderPath)
		{
			AssertFolderExists(folderPath);
			var directoryInfo = new DirectoryInfo(folderPath);
			return GetFolderSizeRecursive(directoryInfo);
		}

		public static long GetFolderSizeRecursive(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);

			long size = directoryInfo.GetFiles().Sum(x => x.Length);

			// ReSharper disable once LoopCanBeConvertedToQuery
			foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
			{
				size += GetFolderSizeRecursive(subDirectoryInfo);
			}

			return size;
		}

		public static int CountFilesRecursive(string folderPath)
		{
			AssertFolderExists(folderPath);
			var directoryInfo = new DirectoryInfo(folderPath);
			return CountFilesRecursive(directoryInfo);
		}

		public static int CountFilesRecursive(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);

			int count = directoryInfo.GetFiles().Length;

			// ReSharper disable once LoopCanBeConvertedToQuery
			foreach (DirectoryInfo subFolder in directoryInfo.GetDirectories())
			{
				count += CountFilesRecursive(subFolder);
			}

			return count;
		}

		public static bool FolderIsEmpty(string folderPath)
		{
			AssertFolderExists(folderPath);
			var directoryInfo = new DirectoryInfo(folderPath);
			return FolderIsEmpty(directoryInfo);
		}

		public static bool FolderIsEmpty(DirectoryInfo directoryInfo)
		{
			if (directoryInfo == null) throw new NullException(() => directoryInfo);
			return directoryInfo.GetFileSystemInfos().Length == 0;
		}

		public static void AssertFileExists(string filePath)
		{
			if (string.IsNullOrEmpty(filePath)) throw new NullOrEmptyException(() => filePath);
			if (!File.Exists(filePath)) throw new FileDoesNotExistException(filePath);
		}

		public static void HideFile(string filePath)
		{
			AssertFileExists(filePath);

			var fileInfo = new FileInfo(filePath);
			HideFile(fileInfo);
		}

		public static void HideFile(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			fileInfo.Attributes |= FileAttributes.Hidden;
		}

		public static void ShowFile(string filePath)
		{
			AssertFileExists(filePath);
			var file = new FileInfo(filePath);
			ShowFile(file);
		}

		public static void ShowFile(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			fileInfo.Attributes &= ~FileAttributes.Hidden;
		}

		public static bool IsHidden(string filePath)
		{
			AssertFileExists(filePath);
			var fileInfo = new FileInfo(filePath);
			return IsHidden(fileInfo);
		}

		public static bool IsHidden(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			return fileInfo.Attributes.HasFlag(FileAttributes.Hidden);
		}

		public static void MakeReadOnly(string filePath)
		{
			AssertFileExists(filePath);
			var fileInfo = new FileInfo(filePath);
			MakeReadOnly(fileInfo);
		}

		public static void MakeReadOnly(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			fileInfo.Attributes |= FileAttributes.ReadOnly;
		}

		public static void MakeWritable(string filePath)
		{
			AssertFileExists(filePath);
			var fileInfo = new FileInfo(filePath);
			MakeWritable(fileInfo);
		}

		public static void MakeWritable(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			fileInfo.Attributes &= ~FileAttributes.ReadOnly;
		}

		public static bool IsReadOnly(string filePath)
		{
			AssertFileExists(filePath);
			var fileInfo = new FileInfo(filePath);
			return IsReadOnly(fileInfo);
		}

		public static bool IsReadOnly(FileInfo fileInfo)
		{
			if (fileInfo == null) throw new NullException(() => fileInfo);
			return fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly);
		}

		public static string ReadAllText(string path, bool requireWriteAccess = true)
		{
			if (requireWriteAccess)
			{
				// File.ReadAllText always requires write permission.
				return File.ReadAllText(path);
			}

			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}

		public static string[] ReadAllLines(string path, bool requireWriteAccess = true)
		{
			if (requireWriteAccess)
			{
				// File.ReadAllLines always requires write permission.
				return File.ReadAllLines(path);
			}

			var lines = new List<string>();
			using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (var reader = new StreamReader(stream))
				{
					while (!reader.EndOfStream)
					{
						lines.Add(reader.ReadLine());
					}
				}
			}
			return lines.ToArray();
		}

		public static string ToAbsolutePath(string path)
		{
			return ToAbsolutePath(null, path);
		}

		public static string ToAbsolutePath(string basePath, string path)
		{
			basePath = basePath ?? "";
			path = path ?? "";

			return Path.GetFullPath(Path.Combine(basePath, path));
		}

		public static string ToRelativePath(string path)
		{
			return ToRelativePath(null, path);
		}

		public static string ToRelativePath(string basePath, string path)
		{
			if (string.IsNullOrEmpty(basePath))
			{
				basePath = Environment.CurrentDirectory;
			}

			path = path ?? "";

			string absoluteBasePath = Path.GetFullPath(basePath);
			string absoluteBasePathToUpper = absoluteBasePath.ToUpper();
			string absolutePathToUpper = path.ToUpper();
			string relativePathUpperCase = absolutePathToUpper.TrimStart(absoluteBasePathToUpper);
			relativePathUpperCase = relativePathUpperCase.TrimStart(@"\");
			string relativePath = path.Right(relativePathUpperCase.Length);
			return relativePath;
		}

		public static bool PathsAreEqual(string path1, string path2)
		{
			path1 = path1 ?? "";
			path1 = Path.GetFullPath(path1);
			path2 = path2 ?? "";
			path2 = Path.GetFullPath(path2);

			return string.Equals(path1, path2, StringComparison.OrdinalIgnoreCase);
		}
	}
}