
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class RegressionTests
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


}

[TestClass]
public class RegressionTest_Has_GenericType_InfoLost
{
    // Copied from JJ.Business.Synthesizer.Wishes
    // where generic assertion methods were defined
    // that route to a non-generic object? variant in JJ.Framework.Existence.Core,
    // Losing the function of comparing to default values, in this case default(int).

    [TestMethod]
    public void Regression_CallToHas_GenericTypeInfoLost_Test()
    {
        // `strict: false` means 0 = default = ok.
        var sizeOfBitDepth = AssertSizeOfBitDepth(sizeOfBitDepth: 0, strict: false);
    }

    // Squelch irrelevant warnings:
    // ReSharper disable MemberCanBePrivate.Global
    // ReSharper disable ArrangeObjectCreationWhenTypeEvident
    #pragma warning disable CS8604 // Possible null reference argument.

    // Leading up to the faulty call
    static int[] ValidBits { get; } = { 8, 16, 32 };
    static int[] ValidSizesOfBitDepth { get; } = ValidBits.Select(SizeOfBitDepth).ToArray();
    static int SizeOfBitDepth(int bits) => BitsToSizeOfBitDepth(bits);
    static int BitsToSizeOfBitDepth(int bits) => AssertBits(bits, strict: false) / 8;
    static int AssertBits(int bits, bool strict = true) => AssertOptions("Bits", bits, ValidBits, strict);
    static int AssertSizeOfBitDepth(int sizeOfBitDepth, bool strict = true) => AssertOptions("SizeOfBitDepth", sizeOfBitDepth, ValidSizesOfBitDepth, strict);

    // Contains the faulty call
    static T AssertOptions<T>(string name, T value, ICollection<T> validValues, bool strict)
    // NOTE: Adding generic constraint T : struct to caller code: perfectly reasonable but let's see if we can make it automatic.
    //static T AssertOptions<T>(string name, T value, ICollection<T> validValues, bool strict) where T : struct 
    {
        if (value.In(validValues)) return value;
        // The faulty Has call (routes wrong).
        if (!Has(value) && !strict) return value;
        throw NotSupportedException(name, value, validValues);
    }
    
    // Trailed after the faulty call
    static Exception NotSupportedException<T>(string name, object value, IEnumerable<T> validValues) 
        => new Exception(NotSupportedMessage(name, value, validValues));
        
    static string NotSupportedMessage<T>(string name, object value, IEnumerable<T> validValues) 
        => $"{name} = {value} not valid. Supported values: " + Join(", ", validValues);
}