using JetBrains.Annotations;

namespace JJ.Framework.Resources
{
	[PublicAPI]
	public static class CommonResourceFormatter
	{
		private static readonly ResourceFormatterHelper _helper = new ResourceFormatterHelper(CommonResources.ResourceManager);

		public static string Add => _helper.GetText();
		public static string AlreadyExists_WithType_AndName(string type, string name) => _helper.GetText_WithTwoPlaceHolders(type, name);
		public static string AreYouSureYouWishToDelete_WithType_AndName(string type, string name)  => _helper.GetText_WithTwoPlaceHolders(type, name);
		public static string BackToList => _helper.GetText();
		public static string Cancel => _helper.GetText();
		public static string CannotDelete_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string CannotDelete_WithType_AndName(string type, string name) => _helper.GetText_WithTwoPlaceHolders(type, name);
		public static string CannotDelete_WithName_AndDependency(string name, string dependency)  => _helper.GetText_WithTwoPlaceHolders(name, dependency);
		public static string Clone => _helper.GetText();
		public static string Clone_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Close => _helper.GetText();
		public static string Close_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Confirm => _helper.GetText();
		public static string Copy_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Date => _helper.GetText();
		public static string DateTime => _helper.GetText();
		public static string Delete => _helper.GetText();
		public static string Delete_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Details_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Description => _helper.GetText();
		public static string Edit => _helper.GetText();
		public static string Edit_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string False => _helper.GetText();
		public static string FilePath => _helper.GetText();
		public static string Folder => _helper.GetText();
		public static string General => _helper.GetText();
		public static string ID => _helper.GetText();
		public static string ID_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string IsActive => _helper.GetText();
		public static string IsDeleted_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Item => _helper.GetText();
		public static string Language => _helper.GetText();
		public static string ListOf_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string LogIn => _helper.GetText();
		public static string LogOut => _helper.GetText();
		public static string Menu => _helper.GetText();
		public static string Messages => _helper.GetText();
		public static string Move => _helper.GetText();
		public static string Name => _helper.GetText();
		public static string Names => _helper.GetText();
		public static string New => _helper.GetText();
		public static string Next_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string No => _helper.GetText();
		public static string None => _helper.GetText();
		public static string NoObject_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string NotAuthorized => _helper.GetText();
		public static string NotAuthorizedMessage => _helper.GetText();
		public static string NotFound_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string NotFound_WithName_AndID(string name, object id) => _helper.GetText_WithTwoPlaceHolders(name, id);
		public static string NotFound_WithType_AndName(string type, string name) => _helper.GetText_WithTwoPlaceHolders(type, name);
		public static string NotFound_WithItemName_ID_AndListName(string name, object id, string listName)  => _helper.GetText_WithThreePlaceHolders(name, id, listName);
		public static string Count_WithNamePlural(string namePlural) => _helper.GetText_WithOnePlaceHolder(namePlural);
		public static string OK => _helper.GetText();
		public static string OneOrTheOtherMustBeFilledIn(string name1, string name2) => _helper.GetText_WithTwoPlaceHolders(name1, name2);
		public static string Open => _helper.GetText();
		public static string Password => _helper.GetText();
		public static string Properties => _helper.GetText();
		public static string Properties_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Redo => _helper.GetText();
		public static string Refresh => _helper.GetText();
		public static string Remove => _helper.GetText();
		public static string Rename_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Recursive => _helper.GetText();
		public static string Scan => _helper.GetText();
		public static string Save => _helper.GetText();
		public static string Save_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Select_WithName(string name) => _helper.GetText_WithOnePlaceHolder(name);
		public static string Selection => _helper.GetText();
		public static string Search => _helper.GetText();
		public static string Text => _helper.GetText();
		public static string TreeStructure => _helper.GetText();
		public static string True => _helper.GetText();
		public static string Type => _helper.GetText();
		public static string Undo => _helper.GetText();
		public static string Url => _helper.GetText();
		public static string UserName => _helper.GetText();
		public static string WantToSaveChanges => _helper.GetText();
		public static string Yes => _helper.GetText();
		public static string Error => _helper.GetText();
		public static string ErrorOccurred => _helper.GetText();
	}
}
