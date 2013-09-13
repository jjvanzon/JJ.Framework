using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Persistence.NPersist
{
    internal static class NPersistContextFactory
    {
        public static Puzzle.NPersist.Framework.Context CreateNPersistContext(string persistenceLocation, params Assembly[] modelAssemblies)
        {
            if (modelAssemblies.Length == 0 )
            {
                throw new Exception("At least one modelAssembly must be provided.");
            }

            string mapFileResourceFileName = GetMapFileResourceName(modelAssemblies);

            //var context = new Puzzle.NPersist.Framework.Context(modelAssemblies[0], mapFileResourceFileName);
            var context = new Puzzle.NPersist.Framework.Context(mapFileResourceFileName);
            context.SetConnectionString(persistenceLocation);
            return context;
        }

        private static string GetMapFileResourceName(Assembly[] modelAssemblies)
        {
            // HACK
            // TODO: Search for a file in the bin.
            return "QuestionAndAnswer.npersist";
            
            foreach (Assembly assembly in modelAssemblies)
            {
                foreach (string resourceName in assembly.GetManifestResourceNames())
                {
                    if (resourceName.EndsWith(".npersist"))
                    {
                        return resourceName;
                    }
                }
            }

            throw new Exception("No .npersist file present in the any of the model assemblies. The .npersist file must be included as an embedded resource in one of the model assemblies.");
        }
    }
}
