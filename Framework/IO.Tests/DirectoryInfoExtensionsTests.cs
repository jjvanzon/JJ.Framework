using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
	[TestClass]
	public class DirectoryInfoExtensionsTests
	{
		private readonly FileFunctionsTests _base = new FileFunctionsTests();

		[TestMethod]
		public void Test_DirectoryInfoExtensions_Clear()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directory = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_ClearFolder(folderPath, () => directory.Clear());
		}

		[TestMethod]
		public void Test_DirectoryInfoExtensions_ClearRecursive()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directory = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_ClearFolderRecursive(folderPath, () => directory.ClearRecursive());
		}

		[TestMethod]
		public void Test_DirectoryInfoExtensions_GetSize()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directory = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_GetFolderSize(folderPath, () => directory.GetSize());
		}

		[TestMethod]
		public void Test_DirectoryInfoExtensions_GetSizeRecursive()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directory = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_GetFolderSizeRecursive(folderPath, () => directory.GetSizeRecursive());
		}

		[TestMethod]
		public void Test_DirectoryInfoExtensions_CountFilesRecursive()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directory = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_CountFilesRecursive(folderPath, () => directory.CountFilesRecursive());
		}

		[TestMethod]
		public void Test_DirectoryInfoExtensions_IsEmpty()
		{
			string folderPath = TestHelper.GenerateFolderName(MethodBase.GetCurrentMethod());
			var directoryInfo = new DirectoryInfo(folderPath);
			_base.Test_FileFunctions_FolderIsEmpty(folderPath, () => directoryInfo.IsEmpty());
		}
	}
}