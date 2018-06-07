using JetBrains.Annotations;

namespace JJ.Framework.Web
{
    [PublicAPI]
    public static class HttpStatusCodes
    {
        public const int NOT_AUTHENTICATED_401 = 401;
        public const int NOT_AUTHORIZED_403 = 403;
        public const int INTERNAL_SERVER_ERROR_500 = 500;
    }
}