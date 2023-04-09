using System.Collections.Generic;

namespace JJ.Framework.Security
{
    public class LiteralPasswordAuthenticator : AuthenticatorBase
    {
        public override bool PasswordIsRequired => true;

        public override bool IsAuthentic(
            string passwordFromClient,
            string tokenFromClient,
            string passwordFromServer,
            IList<string> tokenValuesFromServer)
            => passwordFromClient == passwordFromServer;
    }
}