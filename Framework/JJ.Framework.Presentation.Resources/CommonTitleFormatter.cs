using System;

namespace JJ.Framework.Presentation.Resources
{
    public static class CommonTitleFormatter
    {
        public static string EntityCount(string entityNamePlural)
        {
            return String.Format(CommonTitles.EntityCount, entityNamePlural);
        }

        public static String CloseObject(string objectTypeName)
        {
            return String.Format(CommonTitles.CloseObject, objectTypeName);
        }

        public static String DeleteObject(string objectTypeName)
        {
            return String.Format(CommonTitles.DeleteObject, objectTypeName);
        }

        public static String EditObject(string objectTypeName)
        {
            return String.Format(CommonTitles.EditObject, objectTypeName);
        }

        public static String ObjectDetails(string objectTypeName)
        {
            return String.Format(CommonTitles.ObjectDetails, objectTypeName);
        }

        public static String ObjectProperties(string objectTypeName)
        {
            return String.Format(CommonTitles.ObjectProperties, objectTypeName);
        }

        public static String SaveObject(string objectTypeName)
        {
            return String.Format(CommonTitles.SaveObject, objectTypeName);
        }
    }
}
