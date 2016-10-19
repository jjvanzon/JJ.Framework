using System;

namespace JJ.Framework.Presentation.Resources
{
    public static class CommonTitleFormatter
    {
        public static string ObjectCount(string entityNamePlural)
        {
            return String.Format(CommonTitles.ObjectCount, entityNamePlural);
        }

        public static string CloseObject(string objectTypeName)
        {
            return String.Format(CommonTitles.CloseObject, objectTypeName);
        }

        public static string DeleteObject(string objectTypeName)
        {
            return String.Format(CommonTitles.DeleteObject, objectTypeName);
        }

        public static string EditObject(string objectTypeName)
        {
            return String.Format(CommonTitles.EditObject, objectTypeName);
        }

        public static string ObjectDetails(string objectTypeName)
        {
            return String.Format(CommonTitles.ObjectDetails, objectTypeName);
        }

        public static string ObjectProperties(string objectTypeName)
        {
            return String.Format(CommonTitles.ObjectProperties, objectTypeName);
        }

        public static string SaveObject(string objectTypeName)
        {
            return String.Format(CommonTitles.SaveObject, objectTypeName);
        }
    }
}
