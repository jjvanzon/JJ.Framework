using JJ.Framework.Configuration;

namespace JJ.Framework.Security
{
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Creates an authenticator using the values out of the config file.
        /// A configuration example can be found in your bin directory.
        /// </summary>
        public static IAuthenticator CreateAuthenticatorFromConfiguration()
        {
            SecurityConfiguration securityConfiguration = CustomConfigurationManager.GetSection<SecurityConfiguration>();

            return AuthenticatorFactory.CreateAuthenticator(securityConfiguration.Authentication.AuthenticationType);
        }
    }
}
