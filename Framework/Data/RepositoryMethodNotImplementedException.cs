using System;
using System.Runtime.CompilerServices;

namespace JJ.Framework.Data
{
    public class RepositoryMethodNotImplementedException : Exception
    {
        public RepositoryMethodNotImplementedException([CallerMemberName] string callerMemberName = null)
            : base($"Repository method {callerMemberName} not implemented. Implement it in a specialized technology-specific repository.")
        { }
    }
}
