using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Common;

namespace JJ.Framework.Persistence.NPersist
{
    internal static class UnderlyingNPersistContextFactory
    {
        public static Puzzle.NPersist.Framework.Context CreateContext(string persistenceLocation, params Assembly[] modelAssemblies)
        {
            DomainModelInfo info = GetDomainModelInfo(modelAssemblies);
            var context = new Puzzle.NPersist.Framework.Context(info.Assembly, info.ResourceName);
            context.SetConnectionString(persistenceLocation);
            return context;
        }

        private class DomainModelInfo
        {
            public Assembly Assembly { get; set; }
            public string ResourceName { get; set; }
        }

        private static DomainModelInfo GetDomainModelInfo(Assembly[] modelAssemblies)
        {
            foreach (Assembly assembly in modelAssemblies)
            {
                foreach (string resourceName in assembly.GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(".npersist"))
                    {
                        return new DomainModelInfo
                        {
                            Assembly = assembly,
                            ResourceName = resourceName
                        };
                    }
                }
            }
            
            throw new Exception("The .npersist file must be included as an embedded resource in one of the model assemblies.");
        }
    }
}
