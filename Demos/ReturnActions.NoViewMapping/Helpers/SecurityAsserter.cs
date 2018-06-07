using System.Security.Authentication;
using JetBrains.Annotations;
// ReSharper disable MemberCanBeMadeStatic.Global

namespace JJ.Demos.ReturnActions.NoViewMapping.Helpers
{
    internal class SecurityAsserter
    {
        [AssertionMethod]
        public void Assert(string authenticatedUserName)
        {
            if (string.IsNullOrEmpty(authenticatedUserName))
            {
                throw new AuthenticationException();
            }
        }
    }
}