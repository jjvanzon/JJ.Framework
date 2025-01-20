using System;
using JJ.Framework.Configuration;
using JJ.Framework.Wishes.Reflection;

namespace JJ.Framework.Wishes.Configuration
{
    /// <inheritdoc cref="_trygetsection"/>
    public static class ConfigurationManagerWishes
    {
        /// <inheritdoc cref="_trygetsection"/>
        public static T TryGetSection<T>()
            where T: class, new()
        {
            T config = null;
            
            try
            {
                config = CustomConfigurationManager.GetSection<T>();
            }
            catch (Exception ex)
            {
                // Allow 'Not Found' Exception
                string configSectionName = ReflectionWishes.GetAssemblyName<T>().ToLower();
                string allowedMessage    = $"Configuration section '{configSectionName}' not found.";
                bool   messageIsAllowed  = string.Equals(ex.Message,                 allowedMessage);
                bool   messageIsAllowed2 = string.Equals(ex.InnerException?.Message, allowedMessage);
                bool   mustThrow         = !messageIsAllowed && !messageIsAllowed2;
                
                if (mustThrow)
                {
                    throw;
                }
            }
            
            return config;
        }
    }
}