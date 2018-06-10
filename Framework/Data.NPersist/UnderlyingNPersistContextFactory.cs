using System;
using System.Reflection;
using JJ.Framework.Exceptions.Basic;
using Puzzle.NPersist.Framework;

namespace JJ.Framework.Data.NPersist
{
    internal static class UnderlyingNPersistContextFactory
    {
        // TODO: If model assembly is not required the don't make it a parameter.
        // Also: if it is not required, don't check it for null in the ContextBase class.
        public static Context CreateContext(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly)
        {
            DomainModelInfo info = GetDomainModelInfo(mappingAssembly);
            var context = new Context(info.Assembly, info.ResourceName);
            context.SetConnectionString(persistenceLocation);
            return context;
        }

        private class DomainModelInfo
        {
            public Assembly Assembly { get; set; }
            public string ResourceName { get; set; }
        }

        private static DomainModelInfo GetDomainModelInfo(Assembly mappingAssembly)
        {
            if (mappingAssembly == null) throw new NullException(() => mappingAssembly);

            foreach (string resourceName in mappingAssembly.GetManifestResourceNames())
            {
                if (resourceName.EndsWith(".npersist"))
                {
                    return new DomainModelInfo
                    {
                        Assembly = mappingAssembly,
                        ResourceName = resourceName
                    };
                }
            }

            throw new Exception(
                $"The .npersist was not included as an embedded resource in the mapping assembly '{mappingAssembly.GetName().Name}'.");
        }
    }
}