using JJ.Framework.Exceptions;

namespace JJ.Framework.Security
{
    public static class AuthenticatorFactory
    {
        public static IAuthenticator CreateAuthenticator(AuthenticationTypeEnum authenticationType)
        {
            switch (authenticationType)
            {
                case AuthenticationTypeEnum.HashedSaltedPasswordSHA256:
                    return new HashedSaltedPasswordAuthenticator(authenticationType);

                case AuthenticationTypeEnum.LiteralPassword:
                    return new LiteralPasswordAuthenticator();

                default:
                    throw new InvalidValueException(authenticationType);
            }
        }
    }
}
