namespace JJ.Framework.Common.Core.Tests;

internal static class ConfigurationHelperAccessorCore
{
    private static readonly Accessor _accessor = new (typeof(ConfigurationHelper));
    
    public static IDictionary<Type, object> _sections
    {
        get => _accessor.GetFieldValue(() => _sections);
        set => _accessor.SetFieldValue(() => _sections, value);
    }
}