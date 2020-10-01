using System;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using JJ.Framework.Common;

namespace JJ.Framework.Resources
{
	[PublicAPI]
	public static class CommonResourceFormatter
	{
		private static readonly CultureInfo _fallBackCulture = new CultureInfo("en-US");

		public static string Add => GetText();
		public static string AlreadyExists_WithType_AndName(string type, string name) => GetText_WithTwoPlaceHolders(type, name);
		public static string AreYouSureYouWishToDelete_WithType_AndName(string type, string name)  => GetText_WithTwoPlaceHolders(type, name);
		public static string BackToList => GetText();
		public static string Cancel => GetText();
		public static string CannotDelete_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string CannotDelete_WithType_AndName(string type, string name) => GetText_WithTwoPlaceHolders(type, name);
		public static string CannotDelete_WithName_AndDependency(string name, string dependency)  => GetText_WithTwoPlaceHolders(name, dependency);
		public static string Clone => GetText();
		public static string Clone_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Close => GetText();
		public static string Close_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Confirm => GetText();
		public static string Copy_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Date => GetText();
		public static string DateTime => GetText();
		public static string Delete => GetText();
		public static string Delete_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Details_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Description => GetText();
		public static string Edit => GetText();
		public static string Edit_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string False => GetText();
		public static string FilePath => GetText();
		public static string Folder => GetText();
		public static string General => GetText();
		public static string ID => GetText();
		public static string ID_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string IsActive => GetText();
		public static string IsDeleted_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Item => GetText();
		public static string Language => GetText();
		public static string ListOf_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string LogIn => GetText();
		public static string LogOut => GetText();
		public static string Menu => GetText();
		public static string Messages => GetText();
		public static string Move => GetText();
		public static string Name => GetText();
		public static string Names => GetText();
		public static string New => GetText();
		public static string Next_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string No => GetText();
		public static string None => GetText();
		public static string NoObject_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string NotAuthorized => GetText();
		public static string NotAuthorizedMessage => GetText();
		public static string NotFound_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string NotFound_WithName_AndID(string name, object id) => GetText_WithTwoPlaceHolders(name, id);
		public static string NotFound_WithType_AndName(string type, string name) => GetText_WithTwoPlaceHolders(type, name);
		public static string NotFound_WithItemName_ID_AndListName(string name, object id, string listName)  => GetText_WithThreePlaceHolders(name, id, listName);
		public static string Count_WithNamePlural(string namePlural) => GetText_WithOnePlaceHolder(namePlural);
		public static string OK => GetText();
		public static string OneOrTheOtherMustBeFilledIn(string name1, string name2) => GetText_WithTwoPlaceHolders(name1, name2);
		public static string Open => GetText();
		public static string Password => GetText();
		public static string Properties => GetText();
		public static string Properties_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Redo => GetText();
		public static string Refresh => GetText();
		public static string Remove => GetText();
		public static string Rename_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Recursive => GetText();
		public static string Scan => GetText();
		public static string Save => GetText();
		public static string Save_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Select_WithName(string name) => GetText_WithOnePlaceHolder(name);
		public static string Selection => GetText();
		public static string Search => GetText();
		public static string Text => GetText();
		public static string TreeStructure => GetText();
		public static string True => GetText();
		public static string Type => GetText();
		public static string Undo => GetText();
		public static string Url => GetText();
		public static string UserName => GetText();
		public static string WantToSaveChanges => GetText();
		public static string Yes => GetText();
		public static string Error => GetText();
		public static string ErrorOccurred => GetText();

		// Helpers

		private static string GetText_WithOnePlaceHolder(object arg0, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0);

		private static string GetText_WithTwoPlaceHolders(object arg0, object arg1, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0, arg1);

		private static string GetText_WithThreePlaceHolders(
			object arg0, object arg1, object arg2, [CallerMemberName] string callerMemberName = null)
			=> string.Format(GetText(callerMemberName), arg0, arg1, arg2);

		private static string GetText([CallerMemberName] string callerMemberName = null)
		{
			if (callerMemberName == null)
			{
				throw new Exception(
					$"{nameof(callerMemberName)} is null. Perhaps the wrong helper method called was called: " +
					$"{nameof(GetText)}, {nameof(GetText_WithOnePlaceHolder)}, {nameof(GetText_WithTwoPlaceHolders)}, etc.");
			}

			string resourceString = CommonResources.ResourceManager.GetString(callerMemberName);

			if (!string.IsNullOrWhiteSpace(resourceString))
			{
				return resourceString;
			}

			resourceString = CommonResources.ResourceManager.GetString(callerMemberName, _fallBackCulture);

			if (string.IsNullOrWhiteSpace(resourceString))
			{
				throw new Exception(
					$"{nameof(resourceString)} is null or whitespace for resource name '{callerMemberName}' both " +
					$"current culture '{CultureHelper.GetCurrentCultureName()}' and fallback culture '{_fallBackCulture.Name}'.");
			}

			return resourceString;
		}
	}
}
