using JJ.Framework.Reflection;

namespace JJ.Framework.Common.Core;

public static class ConfigurationHelperCore
{
    public static T TryGetSection<T>()
    {
        try
        {
            return ConfigurationHelper.GetSection<T>();
        }
        catch (Exception exception)
        {
            // TODO: Catch more exceptions, while not catching too many.
            return default;
        }
    }
}