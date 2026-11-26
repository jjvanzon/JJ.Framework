using System.Text;

namespace JJ.Framework.Configuration.Core;

public static class CustomConfigManagerCore
{
    // Cache

    private static readonly Dictionary<(Type, string), object> _dict = new();
    private static readonly Lock _dictLock = new();

    // GetSection

    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>() => throw new NotImplementedException();
    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(Assembly asm) => throw new NotImplementedException();
    /// <inheritdoc cref="_getsection" />
    public static TConfig GetSection<TConfig>(string name) => throw new NotImplementedException();

    // TryGetSection

    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>() => throw new NotImplementedException();
    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(Assembly asm ) => throw new NotImplementedException();
    /// <inheritdoc cref="_trygetsection" />
    public static TConfig? TryGetSection<TConfig>(string   name) => throw new NotImplementedException();

    // SetSection

    public static void SetSection<TConfig>(               TConfig obj) => throw new NotImplementedException();
    public static void SetSection<TConfig>(Assembly asm,  TConfig obj) => throw new NotImplementedException();
    public static void SetSection<TConfig>(string   name, TConfig obj) => throw new NotImplementedException();
    public static void SetSection<TConfig>(               string xml                                                               ) => throw new NotImplementedException();
    public static void SetSection<TConfig>(               byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(               Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(               string fileName, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(Assembly asm,  string xml                                                               ) => throw new NotImplementedException();
    public static void SetSection<TConfig>(Assembly asm,  byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(Assembly asm,  Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(Assembly asm,  string fileName, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(string   name, string xml                                                               ) => throw new NotImplementedException();
    public static void SetSection<TConfig>(string   name, byte[] bytes,    Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(string   name, Stream stream,   Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();
    public static void SetSection<TConfig>(string   name, string fileName, Encoding? encoding = null, bool hasByteOrderMark = false) => throw new NotImplementedException();

    // RefreshSection

    public static void RefreshSection<TConfig>() => throw new NotImplementedException();
    public static void RefreshSection   (Assembly asm) => throw new NotImplementedException();
    public static void RefreshSection   (string  name) => throw new NotImplementedException();
    public static void RefreshSection<TConfig>(Assembly asm) => throw new NotImplementedException();
    public static void RefreshSection<TConfig>(string  name) => throw new NotImplementedException();

    // Resolve

    private static string ResolveSectionName() => throw new NotImplementedException();
    private static string ResolveConfigFile() => throw new NotImplementedException();
}