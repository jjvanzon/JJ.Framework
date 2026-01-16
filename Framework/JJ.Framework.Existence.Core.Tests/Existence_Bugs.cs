// ReSharper disable CollectionNeverQueried.Local
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Existence_Bugs
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


    enum EnumWith0
    {
        OneLast = 1,
        ZeroFirst = 0 // Swapping doesn't change that default = 0
    }

    /// <summary>
    /// TODO: Trailing String/bool combos are a little less flexible: Too much type confusion.
    /// Add more flag in front overloads to resolve better and more optimally and more well behaved.
    /// </summary>
    [TestMethod]
    public void BUG_Coalesce_FlagInFront_Confusion()
    {
        EnumWith0? With0_Null    = null;
        EnumWith0  With0_Default = default;
        EnumWith0  OneLast       = EnumWith0.OneLast;

        NoNullRet("OneLast",   Coalesce(                    With0_Default, With0_Null).Coalesce(                    OneLast).Coalesce(                    "Never"));
        //NoNullRet("OneLast",   Coalesce(zeroMatters: false, With0_Default, With0_Null).Coalesce(zeroMatters: false, OneLast).Coalesce(zeroMatters: false, "Never"));
        NoNullRet("OneLast",   Coalesce(             false, With0_Default, With0_Null).Coalesce(             false, OneLast).Coalesce(             false, "Never"));
        NoNullRet("ZeroFirst", Coalesce(zeroMatters,        With0_Default, With0_Null).Coalesce(zeroMatters,        OneLast).Coalesce(zeroMatters,        "Never"));
        //NoNullRet("ZeroFirst", Coalesce(zeroMatters: true,  With0_Default, With0_Null).Coalesce(zeroMatters: true,  OneLast).Coalesce(zeroMatters: true,  "Never"));
        NoNullRet("ZeroFirst", Coalesce(             true,  With0_Default, With0_Null).Coalesce(             true,  OneLast).Coalesce(             true,  "Never"));
    }

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