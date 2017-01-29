using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;

namespace JJ.Framework.Validation.Resources
{
    public static class ValidationMessageFormatter
    {
        public static string Contains(string propertyDisplayName, object valueOrName)
        {
            return string.Format(ValidationMessages.Contains_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string LengthExceeded(string propertyDisplayName, int length)
        {
            return string.Format(ValidationMessages.LengthExceeded_WithName_AndLength, propertyDisplayName, length);
        }

        public static string FileAlreadyExists(string filePath)
        {
            return string.Format(ValidationMessages.FileAlreadyExists_WithFilePath, filePath);
        }

        public static string FileNotFound(string filePath)
        {
            return string.Format(ValidationMessages.FileNotFound_WithFilePath, filePath);
        }

        public static string FolderAlreadyExists(string folderPath)
        {
            return string.Format(ValidationMessages.FolderAlreadyExists_WithFolderPAth, folderPath);
        }

        public static string FolderNotFound(string folderPath)
        {
            return string.Format(ValidationMessages.FolderNotFound_WithFolderPath, folderPath);
        }

        public static string GreaterThan(string propertyDisplayName, object limitOrName)
        {
            return string.Format(ValidationMessages.GreaterThan_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string GreaterThanOrEqual(string propertyDisplayName, object limitOrName)
        {
            return string.Format(ValidationMessages.GreaterThanOrEqual_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string HasNulls(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.HasNulls_WithName, propertyDisplayName);
        }

        public static string Invalid(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.Invalid_WithName, propertyDisplayName);
        }

        public static string InvalidChoice(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.InvalidChoice_WithName, propertyDisplayName);
        }

        public static string InvalidIndex(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.InvalidIndex_WithName, propertyDisplayName);
        }

        public static string IsBrokenNumber(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsBrokenNumber_WithName, propertyDisplayName);
        }

        public static string IsEmpty(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsEmpty_WithName, propertyDisplayName);
        }

        public static string IsEqual(string propertyDisplayName, object valueOrName)
        {
            return string.Format(ValidationMessages.IsEqual_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string IsFilledIn(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsFilledIn_WithName, propertyDisplayName);
        }

        public static string IsInfinity(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsInfinity_WithName, propertyDisplayName);
        }

        public static string IsInList(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsInList_WithName, propertyDisplayName);
        }

        public static string IsInteger(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsInteger_WithName, propertyDisplayName);
        }

        public static string IsNaN(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsNaN_WithName, propertyDisplayName);
        }

        public static string Exists(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.Exists_WithName, propertyDisplayName);
        }

        public static string IsOfType(string propertyDisplayName, string typeName)
        {
            return string.Format(ValidationMessages.IsOfType_WithName_AndTypeName, propertyDisplayName, typeName);
        }

        public static string IsZero(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.IsZero_WithName, propertyDisplayName);
        }

        public static string LessThan(string propertyDisplayName, object limitOrName)
        {
            return string.Format(ValidationMessages.LessThan_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string LessThanOrEqual(string propertyDisplayName, object limitOrName)
        {
            return string.Format(ValidationMessages.LessThanOrEqual_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string NotBoth(string propertyDisplayName1, string propertyDisplayName2)
        {
            return string.Format(ValidationMessages.NotBoth_WithTwoNames, propertyDisplayName1, propertyDisplayName2);
        }

        public static string NotBrokenNumber(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotBrokenNumber_WithName, propertyDisplayName);
        }

        public static string NotContains(string propertyDisplayName, object valueOrName)
        {
            return string.Format(ValidationMessages.NotContains_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string NotEmpty(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotEmpty_WithName, propertyDisplayName);
        }

        public static string NotEqual(string propertyDisplayName, object valueOrName)
        {
            return string.Format(ValidationMessages.NotEqual_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string NotFilledIn(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotFilledIn_WithName, propertyDisplayName);
        }

        public static string NotInList(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotInList_WithName, propertyDisplayName);
        }

        public static string NotInList<TItem>(string propertyDisplayName, IEnumerable<TItem> possibleValues)
        {
            string joined = String_PlatformSupport.Join(", ", possibleValues);
            string message = string.Format(ValidationMessages.NotInList_WithName_AndAllowedValues, propertyDisplayName, joined);
            return message;
        }

        public static string NotInList<TItem>(string propertyDisplayName, TItem value, IEnumerable<TItem> possibleValues)
        {
            string joinedPossibleValues = String_PlatformSupport.Join(", ", possibleValues);
            string message = string.Format(ValidationMessages.NotInList_WithName_AndValue_AndAllowedValues, propertyDisplayName, value, joinedPossibleValues);
            return message;
        }

        public static string NotInList(string propertyDisplayName, object value)
        {
            string message = string.Format(ValidationMessages.NotInList_WithName_AndValue, propertyDisplayName, value);
            return message;
        }

        public static string NotInteger(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotInteger_WithName, propertyDisplayName);
        }

        public static string NotOfType(string propertyDisplayName, string typeName)
        {
            return string.Format(ValidationMessages.NotOfType_WithName_AndTypeName, propertyDisplayName, typeName);
        }

        public static string NotUniqueSingular(string propertyDisplayNameSingular)
        {
            return string.Format(ValidationMessages.NotUnique_WithName_Singular, propertyDisplayNameSingular);
        }

        public static string NotUniquePlural(string propertyDisplayNamePlural)
        {
            return string.Format(ValidationMessages.NotUnique_WithName_Plural, propertyDisplayNamePlural);
        }

        public static string NotExists(string propertyDisplayName)
        {
            return string.Format(ValidationMessages.NotExists_WithName, propertyDisplayName);
        }

        public static string NotExists(string propertyDisplayName, object value)
        {
            return string.Format(ValidationMessages.NotExists_WithName_AndValue, propertyDisplayName, value);
        }
    }
}