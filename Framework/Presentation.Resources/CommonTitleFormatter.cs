namespace JJ.Framework.Presentation.Resources
{
    public static class CommonTitleFormatter
    {
        public static string ObjectCount(string entityNamePlural)
        {
            return string.Format(CommonTitles.ObjectCount, entityNamePlural);
        }

        public static string CloseObject(string objectTypeName)
        {
            return string.Format(CommonTitles.CloseObject, objectTypeName);
        }

        public static string DeleteObject(string objectTypeName)
        {
            return string.Format(CommonTitles.DeleteObject, objectTypeName);
        }

        public static string EditObject(string objectTypeName)
        {
            return string.Format(CommonTitles.EditObject, objectTypeName);
        }

        public static string ObjectDetails(string objectTypeName)
        {
            return string.Format(CommonTitles.ObjectDetails, objectTypeName);
        }

        public static string ObjectProperties(string objectTypeName)
        {
            return string.Format(CommonTitles.ObjectProperties, objectTypeName);
        }

        public static string SaveObject(string objectTypeName)
        {
            return string.Format(CommonTitles.SaveObject, objectTypeName);
        }
    }
}
