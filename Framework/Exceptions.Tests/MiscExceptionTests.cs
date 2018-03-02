using System.Collections.Generic;
using JJ.Framework.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable LocalNameCapturedOnly
// ReSharper disable RedundantAssignment
// ReSharper disable ConvertToConstant.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace JJ.Framework.Exceptions.Tests
{
	[TestClass]
	public class MiscExceptionTests
	{
		[TestMethod]
		public void Test_FileAlreadyExistsException()
		{
			const string filePath = "test.txt";

			AssertHelper.ThrowsException<FileAlreadyExistException>(
				() => throw new FileAlreadyExistException(filePath),
				"File 'test.txt' already exists.");
		}

		[TestMethod]
		public void Test_FileDoesNotExistsException()
		{
			const string filePath = "test.txt";

			AssertHelper.ThrowsException<FileDoesNotExistException>(
				() => throw new FileDoesNotExistException(filePath),
				"File 'test.txt' does not exist.");
		}

		[TestMethod]
		public void Test_FolderAlreadyExistsException()
		{
			const string folderPath = "C:\\MyFolder";

			AssertHelper.ThrowsException<FolderAlreadyExistsException>(
				() => throw new FolderAlreadyExistsException(folderPath),
				"Folder 'C:\\MyFolder' already exists.");
		}

		[TestMethod]
		public void Test_FolderDoesNotExistException()
		{
			const string folderPath = "C:\\MyFolder";

			AssertHelper.ThrowsException<FolderDoesNotExistException>(
				() => throw new FolderDoesNotExistException(folderPath),
				"Folder 'C:\\MyFolder' does not exist.");
		}

		[TestMethod]
		public void Test_InvalidIndexException()
		{
			AssertHelper.ThrowsException<InvalidIndexException>(
				() =>
				{
					int index = 1;
					var list = new List<int>();

					throw new InvalidIndexException(() => index, () => list.Count);
				},
				"index 1 is an invalid index for list with count 0.");
		}

		[TestMethod]
		public void Test_InvalidValueException()
		{
			AssertHelper.ThrowsException<InvalidValueException>(
				() =>
				{
					var testEnum = TestEnum.EnumMemberA;

					throw new InvalidValueException(testEnum);
				},
				"Invalid TestEnum value: 'EnumMemberA'.");
		}

		[TestMethod]
		public void Test_IsEnumTypeException()
		{
			AssertHelper.ThrowsException<IsEnumTypeException>(
				() => throw new IsEnumTypeException(typeof(TestItem)),
				"Type TestItem cannot be an enum.");
		}

		[TestMethod]
		public void Test_IsEnumTypeExceptionOfT()
		{
			AssertHelper.ThrowsException<IsEnumTypeException<TestItem>>(
				() => throw new IsEnumTypeException<TestItem>(),
				"Type TestItem cannot be an enum.");
		}

		[TestMethod]
		public void Test_NotEnumTypeException()
		{
			AssertHelper.ThrowsException<NotEnumTypeException>(
				() => throw new NotEnumTypeException(typeof(TestItem)),
				"Type TestItem is not an enum.");
		}

		[TestMethod]
		public void Test_NotEnumTypeExceptionOfT()
		{
			AssertHelper.ThrowsException<NotEnumTypeException<TestItem>>(
				() => throw new NotEnumTypeException<TestItem>(),
				"Type TestItem is not an enum.");
		}

		[TestMethod]
		public void Test_PropertyNotFoundException()
		{
			AssertHelper.ThrowsException<PropertyNotFoundException>(
				() => throw new PropertyNotFoundException(typeof(TestItem), "MyProperty"),
				"Property 'MyProperty' not found on type 'JJ.Framework.Exceptions.Tests.TestItem'.");
		}

		[TestMethod]
		public void Test_PropertyNotFoundExceptionOfT()
		{
			AssertHelper.ThrowsException<PropertyNotFoundException<TestItem>>(
				() => throw new PropertyNotFoundException<TestItem>("MyProperty"),
				"Property 'MyProperty' not found on type 'JJ.Framework.Exceptions.Tests.TestItem'.");
		}

		[TestMethod]
		public void Test_TypeNotFoundException()
		{
			AssertHelper.ThrowsException<TypeNotFoundException>(
				() => throw new TypeNotFoundException("TestItemSomething"),
				"Type 'TestItemSomething' not found.");
		}

		[TestMethod]
		public void Test_UnexpectedTypeException()
		{
			AssertHelper.ThrowsException<UnexpectedTypeException>(
				() =>
				{
					int testInt = 1;

					throw new UnexpectedTypeException(() => testInt);
				},
				"testInt has an unexpected type: Int32.");
		}

		[TestMethod]
		public void Test_ValueNotSupportedException()
		{
			AssertHelper.ThrowsException<ValueNotSupportedException>(
				() =>
				{
					var testEnum = TestEnum.Undefined;

					throw new ValueNotSupportedException(testEnum);
				},
				"TestEnum value 'Undefined' is not supported.");
		}
	}
}