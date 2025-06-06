// ReSharper disable CollectionNeverQueried.Local
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Regression
{
    [TestMethod]
    public void FilledIn_MethodResolution_Object_Over_GenericInterface_Regression()
    {
        // ImmutableArray<T> works out even with fallback to plain T - default(T) apparently is an empty collection (because it is a struct?)
        {
            var filled = new ImmutableArray<int> [ 1, 2, 3 ];
            IsTrue(FilledIn(filled));

            var empty = new ImmutableArray<int>();
            IsFalse(FilledIn(empty));
            
        }
        
        // Interface IList<T> is supported:
        {
            IList<int> filled = ImmutableList.Create(1, 2, 3);
            IsTrue(FilledIn(filled));

            IList<int> empty = ImmutableList.Create<int>();
            IsFalse(FilledIn(empty));
        }
        
        // ImmutableList is a class => non-supported collection type - failed.
        {
            ImmutableList<int> filled = ImmutableList.Create(1, 2, 3);
            IsTrue(FilledIn(filled));

            ImmutableList<int> empty = ImmutableList.Create<int>();
            //ThrowsException(() => IsFalse(FilledIn(empty)));
            IsFalse(FilledIn(empty)); // Fixed!
        }
    }
        
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

[TestClass]
public class RegressionTest_CallToHas_FromGenericContext_TypeInfoLost
{
    // Copied from JJ.Business.Synthesizer.Wishes
    // where generic assertion methods were defined
    // that route to a non-generic `object?` variant in JJ.Framework.Existence.Core,
    // losing the function of comparing to default values, in this case default(int).

    [TestMethod]
    public void Regression_CallToHas_FromGenericContext_TypeInfoLost()
    {
        // `strict: false` means 0 = default = ok.
        var sizeOfBitDepth = AssertSizeOfBitDepth(sizeOfBitDepth: 0, strict: false);
    }

    // Leading up to the faulty call
    static int[] ValidBits { get; } = { 8, 16, 32 };
    static int[] ValidSizesOfBitDepth { get; } = ValidBits.Select(SizeOfBitDepth).ToArray();
    static int SizeOfBitDepth(int bits) => BitsToSizeOfBitDepth(bits);
    static int BitsToSizeOfBitDepth(int bits) => AssertBits(bits, strict: false) / 8;
    static int AssertBits(int bits, bool strict = true) => AssertOptions("Bits", bits, ValidBits, strict);
    static int AssertSizeOfBitDepth(int sizeOfBitDepth, bool strict = true) => AssertOptions("SizeOfBitDepth", sizeOfBitDepth, ValidSizesOfBitDepth, strict);

    // Contains the faulty call
    static T AssertOptions<T>(string name, T value, ICollection<T> validValues, bool strict)
    // NOTE: Adding generic constraint T : struct to caller code works. but it shouldn't be the API user's responsibility.
    //static T AssertOptions<T>(string name, T value, ICollection<T> validValues, bool strict) where T : struct 
    {
        if (value.In(validValues)) return value;
        // The faulty Has call (routed wrong to object? instead of T.)
        if (!Has(value) && !strict) return value;
        // ncrunch: no coverage start
        throw NotSupportedException(name, value, validValues);
    }
    
    // Trailed after the faulty call
    static Exception NotSupportedException<T>(string name, object? value, IEnumerable<T> validValues) 
        => new Exception(NotSupportedMessage(name, value, validValues));
        
    static string NotSupportedMessage<T>(string name, object? value, IEnumerable<T> validValues) 
        => $"{name} = {value} not valid. Supported values: " + Join(", ", validValues);
    // ncrunch: no coverage end
}