using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Presentation.Resources
{
    public static class CommonMessageFormatter
    {
        public static string ObjectNotFoundWithID(string objectTypeName, object id)
        {
            return String.Format(CommonMessages.ObjectNotFoundWithID, objectTypeName, id);
        }

        public static string ObjectNotFound(string objectTypeName)
        {
            return String.Format(CommonMessages.ObjectNotFound, objectTypeName);
        }

        public static string CannotDeleteObjectWithName(string objectTypeName, string objectName)
        {
            return String.Format(CommonMessages.CannotDeleteObjectWithName, objectTypeName, objectName);
        }

        public static string AreYouSureYouWishToDeleteWithName(string objectTypeName, string objectName)
        {
            return String.Format(CommonMessages.AreYouSureYouWishToDeleteWithName, objectTypeName, objectName);
        }

        public static string ObjectIsDeleted(string objectTypeName)
        {
            return String.Format(CommonMessages.ObjectIsDeleted, objectTypeName);
        }
    }
}
