using System;

namespace JJ.Framework.Data
{
    public class RepositoryMethodNotImplementedException : Exception
    {
        public RepositoryMethodNotImplementedException()
            : base("Repository method not implemented. Implement it in a specialized technology-specific repository.")
        { }
    }
}
