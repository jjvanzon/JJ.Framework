using System;
using System.Reflection;
//using static JJ.Framework.Reflection.Core.Reflect;
#pragma warning disable CS0168 // Variable is declared but never used

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
                AssertExceptionIsAllowed(ex);
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
                AssertExceptionIsAllowed(ex);
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
                AssertExceptionIsAllowed(ex);
            }
            
            return config;
        }
        
        /// <summary> Allow 'Not Found' Exception </summary>
        private static void AssertExceptionIsAllowed(Exception ex)
        {
            const string allowedStart    = "Configuration section";
            const string allowedEnd      = "not found.";
            
            string message               = ex                .Message ?? "";
            string innerMessage          = ex.InnerException?.Message ?? "";

            bool   messageIsAllowed      = message     .StartsWith(allowedStart) && message     .EndsWith(allowedEnd);
            bool   innerMessageIsAllowed = innerMessage.StartsWith(allowedStart) && innerMessage.EndsWith(allowedEnd);

            if (messageIsAllowed) return;
            if (innerMessageIsAllowed) return;

            throw new Exception($"Exception message only allowed to start with '{allowedStart}' and end with '{allowedEnd}'.", ex);
        }
    }
}