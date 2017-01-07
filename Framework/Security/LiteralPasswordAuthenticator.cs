using System.Collections.Generic;

namespace JJ.Framework.Security
{
    public class LiteralPasswordAuthenticator : AuthenticatorBase
    {
        public override bool PasswordIsRequired
        {
            get { return true; }
        }

        public override bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> tokenValuesFromServer)
        {
            return passwordFromClient == passwordFromServer;
        }
    }
}
