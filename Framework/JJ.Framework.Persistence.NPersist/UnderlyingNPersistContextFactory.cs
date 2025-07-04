﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Persistence.Legacy.NPersist
{
    internal static class UnderlyingNPersistContextFactory
    {
        // TODO: If model assembly is not required the don't make it a parameter.
        // Also: if it is not required, don't check it for null in the ContextBase class.
        public static Puzzle.NPersist.Framework.Context CreateContext(string persistenceLocation, Assembly modelAssembly, Assembly mappingAssembly)
        {
            DomainModelInfo info = GetDomainModelInfo(mappingAssembly);
            var context = new Puzzle.NPersist.Framework.Context(info.Assembly, info.ResourceName);
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

            throw new Exception(String.Format( "The .npersist was not included as an embedded resource in the mapping assembly '{0}'.", mappingAssembly.GetName().Name));
        }
    }
}
