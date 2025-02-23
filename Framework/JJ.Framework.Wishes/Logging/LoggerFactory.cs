using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using static JJ.Framework.Reflection.ReflectionHelper;
using static JJ.Framework.Wishes.Logging.LogConfigHelper;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggerFactory
    {
        // NOTE: Checks omitted for micro-optimization.
        
        // Creating Loggers
        
        public static ILogger CreateLoggerFromConfig()
        {
            LogConfig       config  = GetConfigSection();
            LoggerElement[] configs = GetActiveLoggerConfigs(config);
            
            switch (configs.Length)
            {
                case 1:  return CreateLogger_FromName(configs[0].Type);
                default: return new VersatileLogger(CreateLoggers_FromConfigElements(configs));
                case 0 : return new EmptyLogger();
            }
        }
        
        private static ILogger[] CreateLoggers_FromConfigElements(LoggerElement[] configs)
        {
            var loggers = new ILogger[configs.Length];
            for (int i = 0; i < configs.Length; i++)
            {
                loggers[i] = CreateLogger_FromName(configs[i].Type);
            }
            return loggers;
        }
        
        private static ILogger CreateLogger_FromName(string name) 
            => TryCreateLogger_ByEnum(name) ?? (ILogger)Activator.CreateInstance(GetLoggerType(name));
        
        private static ILogger TryCreateLogger_ByEnum(string name)
        {
            if (!Enum.TryParse(name, out LoggerEnum value))
            {
                return null;
            }

            switch (value)
            {
                case LoggerEnum.Console: return new ConsoleLogger();
                case LoggerEnum.Debug:   return new DebugLogger();
                default:                 throw new ValueNotSupportedException(value);
            }
        }
        
        // Getting Logger Types

        private static readonly object _loggerTypeDictionaryLock = new object();
        private static readonly Dictionary<string, Type> _loggerTypeDictionary = new Dictionary<string, Type>();

        private static Type GetLoggerType(string name)
        {
            lock (_loggerTypeDictionaryLock)
            {
                if (_loggerTypeDictionary.TryGetValue(name, out Type type))
                {
                    return type;
                }

                type = TryGetLoggerType_FromAssembly(name) ?? Type.GetType(name);
                
                _loggerTypeDictionary[name] = type;

                return type;
            }
        }
        
        private static Type TryGetLoggerType_FromAssembly(string assemblyName)
        {
            // Try load assembly.
            Assembly assembly;
            try
            {
                assembly = Assembly.Load(assemblyName);
            }
            catch
            {
                // Assembly load failed. Found type = null.
                return null;
            }
            
            // After assembly load succeeds, it is required to contain exactly one ILogger implementation.
            return GetImplementation<ILogger>(assembly);
        }
    }
}
