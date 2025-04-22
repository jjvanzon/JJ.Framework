using JJ.Framework.Common.Core.docs;

namespace JJ.Framework.Common.Core;

/// <inheritdoc cref="_configurationhelpercore" />
public static class ConfigurationHelperCore
{
    /// <inheritdoc cref="_configurationhelpercore" />
    public static T? TryGetSection<T>()
    {
        try
        {
            return ConfigurationHelper.GetSection<T>();
        }
        catch (Exception exception)
        {
            bool startsWithText = exception.Message.StartsWith("Configuration section of type");
            bool containsText = exception.Message.Contains("was not set");
            if (startsWithText && containsText)
            {
                return default;
            }
            
            throw;
        }
    }
}