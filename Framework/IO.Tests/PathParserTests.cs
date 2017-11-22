using System;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JJ.Framework.IO.Tests
{
	[TestClass]
	public class PathParserTests
	{
		private readonly string _uniqueName = Guid.NewGuid().ToString();

		[TestMethod]
		public void Test_PathParser_PathNull()
		{
			var parser = new PathParser(null);
			AssertHelper.IsNullOrEmpty(() => parser.Volume);
			AssertHelper.AreEqual(0, () => parser.SubFolders.Length);
			AssertHelper.IsNullOrEmpty(() => parser.FolderPath);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
		}

		[TestMethod]
		public void Test_PathParser_PathEmpty()
		{
			var parser = new PathParser("");
			AssertHelper.IsNullOrEmpty(() => parser.Volume);
			AssertHelper.AreEqual(0, () => parser.SubFolders.Length);
			AssertHelper.IsNullOrEmpty(() => parser.FolderPath);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
		}

		[TestMethod]
		public void Test_PathParser_RootOnly_WithSlash()
		{
			var parser = new PathParser(@"C:\");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(0, () => parser.SubFolders.Length);
			AssertHelper.AreEqual(@"C:\", () => parser.FolderPath);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
		}

		[TestMethod]
		public void Test_PathParser_RootOnly_WithoutSlash()
		{
			var parser = new PathParser(@"C:");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(0, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("C:", () => parser.FolderPath);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
		}

		[TestMethod]
		public void Test_PathParser_FolderPath_OneSubFolder()
		{
			var parser = new PathParser(@"E:\" + _uniqueName);
			AssertHelper.AreEqual("E:", () => parser.Volume);
			AssertHelper.AreEqual(1, () => parser.SubFolders.Length);
			AssertHelper.AreEqual(_uniqueName, () => parser.SubFolders[0]);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
			AssertHelper.AreEqual(@"E:\" + _uniqueName, () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_FolderPath_TwoSubFolders()
		{
			var parser = new PathParser(@"E:\temp\" + _uniqueName);
			AssertHelper.AreEqual("E:", () => parser.Volume);
			AssertHelper.AreEqual(2, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual(_uniqueName, () => parser.SubFolders[1]);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
			AssertHelper.AreEqual(@"E:\temp\" + _uniqueName, () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_FilePath_OneSubFolder()
		{
			var parser = new PathParser(@"C:\temp\" + _uniqueName + ".txt");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(1, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual(_uniqueName + ".txt", () => parser.FileName);
			AssertHelper.AreEqual(@"C:\temp", () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_FilePath_TwoSubFolders()
		{
			var parser = new PathParser(@"C:\temp\temp2\" + _uniqueName + ".txt");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(2, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual("temp2", () => parser.SubFolders[1]);
			AssertHelper.AreEqual(_uniqueName + ".txt", () => parser.FileName);
			AssertHelper.AreEqual(@"C:\temp\temp2", () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_InvalidCharacter_NoException()
		{
			var parser = new PathParser(@"C:\temp\te?mp2\" + _uniqueName + ".txt");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(2, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual("te?mp2", () => parser.SubFolders[1]);
			AssertHelper.AreEqual(_uniqueName + ".txt", () => parser.FileName);
			AssertHelper.AreEqual(@"C:\temp\te?mp2", () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_MisplacedVolumeSeparator_NoException()
		{
			var parser = new PathParser(@"C:\temp\te:mp2\" + _uniqueName + ".txt");
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(2, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual("te:mp2", () => parser.SubFolders[1]);
			AssertHelper.AreEqual(_uniqueName + ".txt", () => parser.FileName);
			AssertHelper.AreEqual(@"C:\temp\te:mp2", () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_ManualIsFileTrue()
		{
			var parser = new PathParser(@"C:\temp\temp2\" + _uniqueName, isFile: true);
			AssertHelper.AreEqual("C:", () => parser.Volume);
			AssertHelper.AreEqual(2, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual("temp2", () => parser.SubFolders[1]);
			AssertHelper.AreEqual(_uniqueName, () => parser.FileName);
			AssertHelper.AreEqual(@"C:\temp\temp2", () => parser.FolderPath);
		}

		[TestMethod]
		public void Test_PathParser_ManualIsFileFalse()
		{
			var parser = new PathParser(@"E:\temp\temp2\" + _uniqueName + ".txt", isFile: false);
			AssertHelper.AreEqual("E:", () => parser.Volume);
			AssertHelper.AreEqual(3, () => parser.SubFolders.Length);
			AssertHelper.AreEqual("temp", () => parser.SubFolders[0]);
			AssertHelper.AreEqual("temp2", () => parser.SubFolders[1]);
			AssertHelper.AreEqual(_uniqueName + ".txt", () => parser.SubFolders[2]);
			AssertHelper.IsNullOrEmpty(() => parser.FileName);
			AssertHelper.AreEqual(@"E:\temp\temp2\" + _uniqueName + ".txt", () => parser.FolderPath);
		}
	}
}