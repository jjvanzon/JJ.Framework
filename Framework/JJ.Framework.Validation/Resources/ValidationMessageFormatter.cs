using JJ.Framework.PlatformCompatibility;
using System;
using System.Collections.Generic;

namespace JJ.Framework.Validation.Resources
{
    public static class ValidationMessageFormatter
    {
        public static string Contains(string propertyDisplayName, object valueOrName)
        {
            return String.Format(ValidationMessages.Contains_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string LengthExceeded(string propertyDisplayName, int length)
        {
            return String.Format(ValidationMessages.LengthExceeded_WithName_AndLength, propertyDisplayName, length);
        }

        public static string FileAlreadyExists(string filePath)
        {
            return String.Format(ValidationMessages.FileAlreadyExists_WithFilePath, filePath);
        }

        public static string FileNotFound(string filePath)
        {
            return String.Format(ValidationMessages.FileNotFound_WithFilePath, filePath);
        }

        public static string FolderAlreadyExists(string folderPath)
        {
            return String.Format(ValidationMessages.FolderAlreadyExists_WithFolderPAth, folderPath);
        }

        public static string FolderNotFound(string folderPath)
        {
            return String.Format(ValidationMessages.FolderNotFound_WithFolderPath, folderPath);
        }

        public static string GreaterThan(string propertyDisplayName, object limitOrName)
        {
            return String.Format(ValidationMessages.GreaterThan_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string GreaterThanOrEqual(string propertyDisplayName, object limitOrName)
        {
            return String.Format(ValidationMessages.GreaterThanOrEqual_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string HasNulls(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.HasNulls_WithName, propertyDisplayName);
        }

        public static string Invalid(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.Invalid_WithName, propertyDisplayName);
        }

        public static string InvalidIndex(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.InvalidIndex_WithName, propertyDisplayName);
        }

        public static string IsBrokenNumber(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsBrokenNumber_WithName, propertyDisplayName);
        }

        public static string IsEmpty(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsEmpty_WithName, propertyDisplayName);
        }

        public static string IsEqual(string propertyDisplayName, object valueOrName)
        {
            return String.Format(ValidationMessages.IsEqual_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string IsFilledIn(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsFilledIn_WithName, propertyDisplayName);
        }

        public static string IsInfinity(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsInfinity_WithName, propertyDisplayName);
        }

        public static string IsInList(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsInList_WithName, propertyDisplayName);
        }

        public static string IsInteger(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsInteger_WithName, propertyDisplayName);
        }

        public static string IsNaN(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsNaN_WithName, propertyDisplayName);
        }

        public static string Exists(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.Exists_WithName, propertyDisplayName);
        }

        public static string IsOfType(string propertyDisplayName, string typeName)
        {
            return String.Format(ValidationMessages.IsOfType_WithName_AndTypeName, propertyDisplayName, typeName);
        }

        public static string IsZero(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.IsZero_WithName, propertyDisplayName);
        }

        public static string LessThan(string propertyDisplayName, object limitOrName)
        {
            return String.Format(ValidationMessages.LessThan_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string LessThanOrEqual(string propertyDisplayName, object limitOrName)
        {
            return String.Format(ValidationMessages.LessThanOrEqual_WithName_AndLimit, propertyDisplayName, limitOrName);
        }

        public static string NotBrokenNumber(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotBrokenNumber_WithName, propertyDisplayName);
        }

        public static string NotContains(string propertyDisplayName, object valueOrName)
        {
            return String.Format(ValidationMessages.NotContains_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string NotEmpty(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotEmpty_WithName, propertyDisplayName);
        }

        public static string NotEqual(string propertyDisplayName, object valueOrName)
        {
            return String.Format(ValidationMessages.NotEqual_WithName_AndValue, propertyDisplayName, valueOrName);
        }

        public static string NotFilledIn(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotFilledIn_WithName, propertyDisplayName);
        }

        public static string NotInList(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotInList_WithName, propertyDisplayName);
        }

        public static string NotInList(string propertyDisplayName, IList<object> possibleValues)
        {
            string joined = String_PlatformSupport.Join(", ", possibleValues);
            string message = String.Format(ValidationMessages.NotInList_WithName_AndAllowedValues, propertyDisplayName, joined);
            return message;
        }

        public static string NotInList(string propertyDisplayName, object value)
        {
            string message = String.Format(ValidationMessages.NotInList_WithName_AndValue, propertyDisplayName, value);
            return message;
        }

        public static string NotInteger(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotInteger_WithName, propertyDisplayName);
        }

        public static string NotOfType(string propertyDisplayName, string typeName)
        {
            return String.Format(ValidationMessages.NotOfType_WithName_AndTypeName, propertyDisplayName, typeName);
        }

        public static string NotUniqueSingular(string propertyDisplayNameSingular)
        {
            return String.Format(ValidationMessages.NotUnique_WithName_Singular, propertyDisplayNameSingular);
        }

        public static string NotUniquePlural(string propertyDisplayNamePlural)
        {
            return String.Format(ValidationMessages.NotUnique_WithName_Plural, propertyDisplayNamePlural);
        }

        public static string NotExists(string propertyDisplayName)
        {
            return String.Format(ValidationMessages.NotExists_WithName, propertyDisplayName);
        }
    }
}