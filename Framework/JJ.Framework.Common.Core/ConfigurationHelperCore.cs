namespace JJ.Framework.Common.Core;

public static class ConfigurationHelperCore
{
    /// <summary>
    /// Compensates for missing null-tolerant version in ConfigurationHelper.
    /// </summary>
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