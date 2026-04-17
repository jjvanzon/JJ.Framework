// ReSharper disable UnusedParameter.Local
    
namespace JJ.Framework.StringResources.Legacy;

/// <inheritdoc cref="_stringresourcetesteroft" />
public class StringResourceTester<[Dyn(PubPropMethod)] T> : StringResourceTester
{
    /// <inheritdoc cref="_stringresourcetesteroft" />
    public StringResourceTester(
        string[] known, string unknown, string @default, NoLog nolog)
        : base(typeof(T), known, unknown, @default, nolog)
    { }

    /// <inheritdoc cref="_stringresourcetesteroft" />
    public StringResourceTester(
        string[] known, string unknown, string @default, bool nolog = default)
        : base(typeof(T), known, unknown, @default, nolog)
    { }

    /// <inheritdoc cref="_stringresourcetesteroft" />
    public StringResourceTester(
        T resourceObject,
        string[] known, string unknown, string @default, NoLog nolog)
        : base(typeof(T), resourceObject, known, unknown, @default, nolog)
    { }

    /// <inheritdoc cref="_stringresourcetesteroft" />
    public StringResourceTester(
        T resourceObject,
        string[] known, string unknown, string @default, bool nolog = default)
        : base(typeof(T), resourceObject, known, unknown, @default, nolog)
    { }
}
