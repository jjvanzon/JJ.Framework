namespace JJ.Framework.Security
{
	public enum AuthenticationTypeEnum
	{
		/// <summary>
		/// This authentication type does not store the passwords literly on the server,
		/// but hashes them with the SHA256 algorithm.
		/// 'Salt' is appended to the password before hashing.
		/// The salt is stored on the server next to the hashed password.
		/// The client sends the password over the line in plain text.
		/// The server then rehashes the password from the client along with the salt stored on the server.
		/// The result must equal the hashed password on the server.
		/// This authentication type ensures that when the database is hacked, 
		/// the hacker cannot use the user credentials to access the user's account.
		/// However, since the password is sent over the line in plain text,
		/// a man-in-the-middle attack could allow a hacker to intercept the password anyway.
		/// </summary>
		HashedSaltedPasswordSHA256,

		/// <summary>
		/// Compares the password the user sent to the password as it is literly stored in the data store.
		/// </summary>
		LiteralPassword
	}
}
