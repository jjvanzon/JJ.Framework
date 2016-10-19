using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Security
{
    /// <summary> This interface serves as a base for authenticators for various types of authentication. </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Returns whether the specific type of authentication requires sending a password over the line.
        /// A password might not be required e.g. if the password is already hashed into a security token.
        /// </summary>
        bool PasswordIsRequired { get; }

        /// <summary> Determines whether the provided user credentials are authentic. </summary>
        bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> valuesToHashFromServer);

        /// <summary> Throws an exception if the provided user credentials cannot be authenticated. </summary>
        void Authenticate(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> valuesToHashFromServer);

        /// <summary> Gets a token required for the specific authentication type. </summary>
        string GetToken(string password, IList<string> valuesToHash);

        // Overloads with params

        /// <summary> Determines whether the provided user credentials are authentic. </summary>
        bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, params string[] valuesToHashFromServer);

        /// <summary> Throws an exception if the provided user credentials cannot be authenticated. </summary>
        void Authenticate(string passwordFromClient, string tokenFromClient, string passwordFromServer, params string[] valuesToHashFromServer);

        /// <summary> Gets a token required for the specific authentication type. </summary>
        string GetToken(string password, params string[] valuesToHash); 
    }
}
