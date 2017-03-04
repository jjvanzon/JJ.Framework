namespace JJ.Framework.Presentation.Resources
{
    public static class CommonMessageFormatter
    {
        public static string ObjectNotFoundWithID(string objectName, object id)
        {
            return string.Format(CommonMessages.ObjectNotFoundWithID, objectName, id);
        }

        public static string ObjectNotFound(string objectName)
        {
            return string.Format(CommonMessages.ObjectNotFound, objectName);
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
