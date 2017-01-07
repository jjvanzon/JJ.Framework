using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace JJ.Framework.Security
{
    /// <summary> This base class serves as a base for authenticators for various types of authentication. </summary>
    public abstract class AuthenticatorBase : IAuthenticator
    {
        internal AuthenticatorBase()
        { }

        public abstract bool PasswordIsRequired { get; }
        public abstract bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> valuesToHashFromServer);

        public virtual string GetToken(string password, IList<string> valuesToHash)
        {
            return null;
        }

        public void Authenticate(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> valuesToHashFromServer)
        {
            if (!IsAuthentic(passwordFromClient, tokenFromClient, passwordFromServer, valuesToHashFromServer))
            {
                throw new AuthenticationException();
            }
        }

        // Overloads with params

        public bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, params string[] valuesToHashFromServer)
        {
            return IsAuthentic(passwordFromClient, tokenFromClient, passwordFromServer, (IList<string>)valuesToHashFromServer);
        }

        public void Authenticate(string passwordFromClient, string tokenFromClient, string passwordFromServer, params string[] valuesToHashFromServer)
        {
            Authenticate(passwordFromClient, tokenFromClient, passwordFromServer, (IList<string>)valuesToHashFromServer);
        }

        public string GetToken(string password, params string[] valuesToHash)
        {
            if (valuesToHash == null)
            {
                throw new AuthenticationException();
            }

            return GetToken(password, valuesToHash.ToArray());
        }
    }
}
