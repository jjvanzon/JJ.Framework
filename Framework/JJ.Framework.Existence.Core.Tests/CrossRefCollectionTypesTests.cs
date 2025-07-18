namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CrossRefCollectionTypesTests
{
    [TestMethod]
    public void AllSystemCollections_HaveHelpers()
    {
        var supportedTypeNames = 
            new [] { typeof(FilledInExtensions), typeof(FilledInHelper) }
                .SelectMany(x => x.GetMethods())
                .SelectMany(x => x.GetParameters())
                .Select(x => x.ParameterType.Name)
                .Distinct()
                .ToArray();

        var systemTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => a.GetName().Name!.StartsWith("System"))
            .SelectMany(a => a.GetExportedTypes())
            .ToArray();
        
        var excludedTypes = new List<Type>();
        var unsupportedTypes = new List<Type>();
        
        foreach (var systemType in systemTypes)
        {
            string nameSpace = systemType.Namespace ?? "";
            string assemblyName = systemType.Assembly.GetName().Name ?? "";

            bool looksLikeCollection =
                systemType.GetProperty("Count") != null ||
                systemType.GetProperty("Length") != null ||
                systemType.GetProperty("IsEmpty") != null ||
                systemType.GetProperty("IsDefaultOrEmpty") != null;

            if (!looksLikeCollection) continue;
            
            bool excludeFromMatch = 
                // Name shows as T[], not Array.
                string.Equals(systemType.Name, "Array") ||
                // Would cause overload ambiguity if included
                string.Equals(systemType.Name, "ICollection") ||
                // Has unmanaged type argument: outside our territory
                string.Equals(systemType.Name, "SequenceReader`1") ||
                // Accidentally public
                string.Equals(systemType.Name, "ListDictionaryInternal") || 
                string.Equals(systemType.Name, "TreeSet`1") ||
                string.Equals(systemType.FullName, "System.Linq.Lookup`2") ||
                string.Equals(systemType.FullName, "System.Collections.Generic.SortedList`2+ValueList") || 
                string.Equals(systemType.FullName, "System.Collections.Generic.SortedList`2+KeyList") || 
                // From specific APIs:
                assemblyName.StartsWith("System.ServiceModel") ||
                nameSpace.StartsWith("System.CodeDom") ||
                nameSpace.StartsWith("System.ComponentModel") ||
                nameSpace.StartsWith("System.Configuration") ||
                nameSpace.StartsWith("System.Data") ||
                nameSpace.StartsWith("System.Diagnostics") ||
                nameSpace.StartsWith("System.Drawing") ||
                nameSpace.StartsWith("System.Formats.Tar") ||
                nameSpace.StartsWith("System.IO") ||
                nameSpace.StartsWith("System.Net") ||
                nameSpace.StartsWith("System.Numerics") ||
                nameSpace.StartsWith("System.Reflection.Metadata") ||
                nameSpace.StartsWith("System.Reflection.PortableExecutable") ||
                nameSpace.StartsWith("System.Runtime.CompilerServices") ||
                nameSpace.StartsWith("System.Runtime.InteropServices") ||
                nameSpace.StartsWith("System.Runtime.Intrinsics") ||
                nameSpace.StartsWith("System.Runtime.Serialization") ||
                nameSpace.StartsWith("System.Security") ||
                nameSpace.StartsWith("System.Text.Json") ||
                nameSpace.StartsWith("System.Text.RegularExpressions") ||
                nameSpace.StartsWith("System.Text.Unicode") ||
                nameSpace.StartsWith("System.Threading") ||
                nameSpace.StartsWith("System.Xml");
            
            if (excludeFromMatch)
            {
                excludedTypes.Add(systemType);
                continue;
            }

            bool isSupported = supportedTypeNames.Contains(systemType.Name);
            // ncrunch: no coverage start
            if (!isSupported)
            {
                unsupportedTypes.Add(systemType); 
            }
        }
        
        if (unsupportedTypes.Any())
        {
            Fail($"The following {unsupportedTypes.Count} types look like collections, but are not supported:" + NewLine + Join(NewLine, unsupportedTypes));
        }
    }
    // ncrunch: no coverage end
}