using System.Security.Authentication;

namespace JJ.Demos.ReturnActions.NoViewMapping.Helpers
{
    internal class SecurityAsserter
    {
        public void Assert(string authenticatedUserName)
        {
            if (string.IsNullOrEmpty(authenticatedUserName))
            {
                throw new AuthenticationException();
            }
        }
    }
}