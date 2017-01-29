namespace JJ.Framework.Presentation.Resources
{
    public static class CommonMessageFormatter
    {
        public static string ObjectNotFoundWithID(string objectTypeName, object id)
        {
            return string.Format(CommonMessages.ObjectNotFoundWithID, objectTypeName, id);
        }

        public static string ObjectNotFound(string objectTypeName)
        {
            return string.Format(CommonMessages.ObjectNotFound, objectTypeName);
        }

        public static string CannotDeleteObjectWithName(string objectTypeName, string objectName)
        {
            return string.Format(CommonMessages.CannotDeleteObjectWithName, objectTypeName, objectName);
        }

        public static string AreYouSureYouWishToDeleteWithName(string objectTypeName, string objectName)
        {
            return string.Format(CommonMessages.AreYouSureYouWishToDeleteWithName, objectTypeName, objectName);
        }

        public static string ObjectIsDeleted(string objectTypeName)
        {
            return string.Format(CommonMessages.ObjectIsDeleted, objectTypeName);
        }
    }
}
