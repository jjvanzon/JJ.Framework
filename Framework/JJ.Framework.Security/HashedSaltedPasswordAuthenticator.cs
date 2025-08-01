﻿using JJ.Framework.Common;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Security.Legacy
{
    public class HashedSaltedPasswordAuthenticator : AuthenticatorBase
    {
        private const int SALT_BYTES_LENGTH = 24;

        private AuthenticationTypeEnum _authenticationType;

        internal HashedSaltedPasswordAuthenticator(AuthenticationTypeEnum authenticationType)
        { 
            _authenticationType = authenticationType;
        }

        public override bool PasswordIsRequired
        {
            get { return true; }
        }

        public override bool IsAuthentic(string passwordFromClient, string tokenFromClient, string passwordFromServer, IList<string> tokenValuesFromServer)
        {
            if (tokenValuesFromServer == null)
            {
                return false;
            }
            if (tokenValuesFromServer.Count != 1)
            {
                return false;
            }

            string saltFromServer = tokenValuesFromServer[0];

            string hashedSaltedPasswordFromClient = GenerateHash(passwordFromClient, saltFromServer);

            // The password on the server is the hashed password.
            if (hashedSaltedPasswordFromClient == passwordFromServer)
            {
                return false;
            }

            return true;
        }

        public override string GetToken(string password, IList<string> valuesToHash)
        {
            return null;
        }

        public string GenerateSalt()
        {
            #pragma warning disable SYSLIB0023 // Obsolete: RNGCryptoServiceProvider
            var randomNumberCrypto = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[SALT_BYTES_LENGTH];
            randomNumberCrypto.GetBytes(saltBytes);
            #pragma warning restore CS0618
            string saltString = Convert.ToBase64String(saltBytes);
            return saltString;
        }

        public string GenerateHash(string password, string salt)
        {
            string saltedPasswordString = password + salt;
            byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPasswordString);

            HashAlgorithm hashAlgorithm = CreateHashAlgorithm(_authenticationType);
            byte[] hashBytes = hashAlgorithm.ComputeHash(saltedPasswordBytes);

            return Convert.ToBase64String(hashBytes);
        }

        private HashAlgorithm CreateHashAlgorithm(AuthenticationTypeEnum authenticationType)
        {
            switch (authenticationType)
            {
                case AuthenticationTypeEnum.HashedSaltedPasswordSHA256:
                    return SHA256.Create();

                default:
                    throw new ValueNotSupportedException(authenticationType);
            }
        }
    }
}
