using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
