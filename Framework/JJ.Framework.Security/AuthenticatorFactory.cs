﻿using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Security.Legacy
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
