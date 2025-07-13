using System;
using System.Reflection;
using static JJ.Framework.Reflection.Core.Reflect;

namespace JJ.Framework.Configuration.Core
{
    /// <inheritdoc cref="_trygetsection"/>
    public static class CustomConfigurationManagerCore
    {
        /// <inheritdoc cref="_trygetsection"/>
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T? TryGetSection<[Dyn(AllProperties)] T>(Assembly assembly)
            where T: new()
        {
            T? config = default;
            
            try
            {
                config = CustomConfigurationManager.GetSection<T>(assembly);
            }
            catch (Exception ex)
            {
                AssertExceptionIsAllowed(ex, assembly);
            }
            
            return config;
        }
        
        /// <inheritdoc cref="_trygetsection"/>
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T? TryGetSection<[Dyn(AllProperties)] T>(string sectionName)
            where T: new()
        {
            T? config = default;
            
            try
            {
                config = CustomConfigurationManager.GetSection<T>(sectionName);
            }
            catch (Exception ex)
            {
                AssertExceptionIsAllowed(ex, sectionName);
            }
            
            return config;
        }
        
        /// <inheritdoc cref="_trygetsection"/>
        [NoTrim(PropertyType + " " + ObjectGetType)]
        public static T? TryGetSection<[Dyn(AllProperties)] T>()
            where T: class, new()
        {
            T? config = null;
            
            try
            {
                config = CustomConfigurationManager.GetSection<T>();
            }
            catch (Exception ex)
            {
                AssertExceptionIsAllowed<T>(ex);
            }
            
            return config;
        }
        
        private static void AssertExceptionIsAllowed<T>(Exception ex)
            => AssertExceptionIsAllowed(ex, GetAssemblyName<T>().ToLower());
        
        private static void AssertExceptionIsAllowed(Exception ex, Assembly assembly) 
            => AssertExceptionIsAllowed(ex, TryGetAssemblyName(assembly)?.ToLower());
        
        private static void AssertExceptionIsAllowed(Exception ex, string? configSectionName)
        {
            // Allow 'Not Found' Exception
            string allowedMessage    = $"Configuration section '{configSectionName}' not found.";
            bool   messageIsAllowed  = string.Equals(ex.Message,                 allowedMessage);
            bool   messageIsAllowed2 = string.Equals(ex.InnerException?.Message, allowedMessage);
            bool   mustThrow         = !messageIsAllowed && !messageIsAllowed2;
            
            if (mustThrow)
            {
                throw new Exception($"The only exceptions message allowed is: '{allowedMessage}'", ex);
            }
        }
    }
}