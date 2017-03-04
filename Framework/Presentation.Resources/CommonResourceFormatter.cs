namespace JJ.Framework.Presentation.Resources
{
    public static class CommonResourceFormatter
    {
        public static string Add => CommonResources.Add;
        public static string AreYouSureYouWishToDeleteWithName(string objectTypeName, string objectName) => string.Format(CommonResources.AreYouSureYouWishToDeleteWithName, objectTypeName, objectName);
        public static string Cancel => CommonResources.Cancel;
        public static string CannotDeleteObjectWithName(string objectTypeName, string objectName) => string.Format(CommonResources.CannotDeleteObjectWithName, objectTypeName, objectName);
        public static string Close => CommonResources.Close;
        public static string CloseObject(string objectTypeName) => string.Format(CommonResources.CloseObject, objectTypeName);
        public static string Delete => CommonResources.Delete;
        public static string DeleteObject(string objectTypeName) => string.Format(CommonResources.DeleteObject, objectTypeName);
        public static string Edit => CommonResources.Edit;
        public static string EditObject(string objectTypeName) => string.Format(CommonResources.EditObject, objectTypeName);
        public static string False => CommonResources.False;
        public static string FilePath => CommonResources.FilePath;
        public static string ID => CommonResources.ID;
        public static string Item => CommonResources.Item;
        public static string Language => CommonResources.Language;
        public static string LogIn => CommonResources.LogIn;
        public static string LogOut => CommonResources.LogOut;
        public static string Menu => CommonResources.Menu;
        public static string Messages => CommonResources.Messages;
        public static string Name => CommonResources.Name;
        public static string New => CommonResources.New;
        public static string No => CommonResources.No;
        public static string None => CommonResources.None;
        public static string NoObject(string objectName) => string.Format(CommonResources.NoObject, objectName);
        public static string NotAuthorized => CommonResources.NotAuthorized;
        public static string ObjectCount(string objectNamePlural) => string.Format(CommonResources.ObjectCount, objectNamePlural);
        public static string ObjectDetails(string objectTypeName) => string.Format(CommonResources.ObjectDetails, objectTypeName);
        public static string ObjectIsDeleted(string objectTypeName) => string.Format(CommonResources.ObjectIsDeleted, objectTypeName);
        public static string ObjectNotFound(string objectName) => string.Format(CommonResources.ObjectNotFound, objectName);
        public static string ObjectNotFoundWithID(string objectName, object id) => string.Format(CommonResources.ObjectNotFoundWithID, objectName, id);
        public static string ObjectProperties(string objectTypeName) => string.Format(CommonResources.ObjectProperties, objectTypeName);
        public static string OK => CommonResources.OK;
        public static string Properties => CommonResources.Properties;
        public static string Remove => CommonResources.Remove;
        public static string Save => CommonResources.Save;
        public static string SaveObject(string objectTypeName) => string.Format(CommonResources.SaveObject, objectTypeName);
        public static string Search => CommonResources.Search;
        public static string True => CommonResources.True;
        public static string Yes => CommonResources.Yes;
    }
}