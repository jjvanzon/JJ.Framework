using JJ.Framework.PlatformCompatibility;
using System.Collections.Generic;
using System.Linq;
using JJ.Framework.Exceptions;

namespace JJ.Framework.Validation.Resources
{
	public static class ValidationResourceFormatter
	{
		public static string AreEmpty(string displayName) => string.Format(ValidationResources.AreEmpty_WithName, displayName);
		public static string Contains(string displayName, object valueOrName) => string.Format(ValidationResources.Contains_WithName_AndValue, displayName, valueOrName);
		public static string LengthExceeded(string displayName, int length) => string.Format(ValidationResources.LengthExceeded_WithName_AndLength, displayName, length);
		public static string FileAlreadyExists(string filePath) => string.Format(ValidationResources.FileAlreadyExists_WithFilePath, filePath);
		public static string FileNotFound(string filePath) => string.Format(ValidationResources.FileNotFound_WithFilePath, filePath);
		public static string FolderAlreadyExists(string folderPath) => string.Format(ValidationResources.FolderAlreadyExists_WithFolderPAth, folderPath);
		public static string FolderNotFound(string folderPath) => string.Format(ValidationResources.FolderNotFound_WithFolderPath, folderPath);
		public static string GreaterThan(string displayName, object limitOrName) => string.Format(ValidationResources.GreaterThan_WithName_AndLimit, displayName, limitOrName);
		public static string GreaterThanOrEqual(string displayName, object limitOrName) => string.Format(ValidationResources.GreaterThanOrEqual_WithName_AndLimit, displayName, limitOrName);
		public static string HasNulls(string displayName) => string.Format(ValidationResources.HasNulls_WithName, displayName);
		public static string Invalid(string displayName) => string.Format(ValidationResources.Invalid_WithName, displayName);
		public static string InvalidChoice(string displayName) => string.Format(ValidationResources.InvalidChoice_WithName, displayName);
		public static string InvalidIndex(string displayName) => string.Format(ValidationResources.InvalidIndex_WithName, displayName);
		public static string IsBrokenNumber(string displayName) => string.Format(ValidationResources.IsBrokenNumber_WithName, displayName);
		public static string IsEmpty(string displayName) => string.Format(ValidationResources.IsEmpty_WithName, displayName);
		public static string IsEqual(string displayName, object valueOrName) => string.Format(ValidationResources.IsEqual_WithName_AndValue, displayName, valueOrName);
		public static string IsFilledIn(string displayName) => string.Format(ValidationResources.IsFilledIn_WithName, displayName);
		public static string IsInfinity(string displayName) => string.Format(ValidationResources.IsInfinity_WithName, displayName);
		public static string IsInList(string displayName) => string.Format(ValidationResources.IsInList_WithName, displayName);
		public static string IsInteger(string displayName) => string.Format(ValidationResources.IsInteger_WithName, displayName);
		public static string IsNaN(string displayName) => string.Format(ValidationResources.IsNaN_WithName, displayName);
		public static string Exists(string displayName) => string.Format(ValidationResources.Exists_WithName, displayName);
		public static string IsOfType(string displayName, string typeName) => string.Format(ValidationResources.IsOfType_WithName_AndTypeName, displayName, typeName);
		public static string IsZero(string displayName) => string.Format(ValidationResources.IsZero_WithName, displayName);
		public static string LessThan(string displayName, object limitOrName) => string.Format(ValidationResources.LessThan_WithName_AndLimit, displayName, limitOrName);
		public static string LessThanOrEqual(string displayName, object limitOrName) => string.Format(ValidationResources.LessThanOrEqual_WithName_AndLimit, displayName, limitOrName);
		public static string NotBoth(string displayName1, string displayName2) => string.Format(ValidationResources.NotBoth_WithTwoNames, displayName1, displayName2);
		public static string NotBrokenNumber(string displayName) => string.Format(ValidationResources.NotBrokenNumber_WithName, displayName);
		public static string NotContains(string displayName, object valueOrName) => string.Format(ValidationResources.NotContains_WithName_AndValue, displayName, valueOrName);
		public static string NotEmptySingular(string displayNameSingular) => string.Format(ValidationResources.NotEmpty_WithName_Singular, displayNameSingular);
		public static string NotEmptyPlural(string displayNamePlural) => string.Format(ValidationResources.NotEmpty_WithName_Plural, displayNamePlural);
		public static string NotEqual(string displayName, object valueOrName) => string.Format(ValidationResources.NotEqual_WithName_AndValue, displayName, valueOrName);
		public static string NotFilledIn(string displayName) => string.Format(ValidationResources.NotFilledIn_WithName, displayName);
		public static string NotFilledIn() => ValidationResources.NotFilledIn;
		public static string NotInList(string displayName) => string.Format(ValidationResources.NotInList_WithName, displayName);

		public static string NotInList<TItem>(string displayName, IEnumerable<TItem> possibleValues)
		{
			string joined = String_PlatformSupport.Join(", ", possibleValues);
			string message = string.Format(ValidationResources.NotInList_WithName_AndAllowedValues, displayName, joined);
			return message;
		}

		public static string NotInList<TItem>(string displayName, TItem value, IEnumerable<TItem> possibleValues)
		{
			string joinedPossibleValues = String_PlatformSupport.Join(", ", possibleValues);
			string message = string.Format(ValidationResources.NotInList_WithName_AndValue_AndAllowedValues, displayName, value, joinedPossibleValues);
			return message;
		}

		public static string NotInList(string displayName, object value)
		{
			string message = string.Format(ValidationResources.NotInList_WithName_AndValue, displayName, value);
			return message;
		}

		public static string NotInteger(string displayName) => string.Format(ValidationResources.NotInteger_WithName, displayName);
		public static string NotOfType(string displayName, string typeName) => string.Format(ValidationResources.NotOfType_WithName_AndTypeName, displayName, typeName);
		public static string NotUniqueSingular(string displayNameSingular) => string.Format(ValidationResources.NotUnique_WithName_Singular, displayNameSingular);
		public static string NotUniquePlural(string displayNamePlural) => string.Format(ValidationResources.NotUnique_WithName_Plural, displayNamePlural);
		public static string NotUniqueSingular(string displayNameSingular, object value) => string.Format(ValidationResources.NotUnique_WithName_AndValue_Singular, displayNameSingular, value);

		public static string NotUniqueSingular(string displayNameSingular, IEnumerable<object> duplicateValues)
		{
			if (duplicateValues == null) throw new NullException(() => duplicateValues);

			string formattedDuplicateValues = string.Join(", ", duplicateValues.Select(x => $"'{x}'"));

			return string.Format(ValidationResources.NotUnique_WithName_AndDuplicateValues_Singular, displayNameSingular, formattedDuplicateValues);
		}

		public static string NotUniquePlural(string displayNamePlural, IEnumerable<object> duplicateValues)
		{
			if (duplicateValues == null) throw new NullException(() => duplicateValues);

			string formattedDuplicateValues = string.Join(", ", duplicateValues.Select(x => $"{x}"));

			return string.Format(ValidationResources.NotUnique_WithName_AndDuplicateValues_Plural, displayNamePlural, formattedDuplicateValues);
		}

		public static string NotExists(string displayName) => string.Format(ValidationResources.NotExists_WithName, displayName);
		public static string NotExists(string displayName, object value) => string.Format(ValidationResources.NotExists_WithName_AndValue, displayName, value);
	}
}