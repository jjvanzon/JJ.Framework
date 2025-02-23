using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using static JJ.Framework.Reflection.ReflectionHelper;
using static JJ.Framework.Wishes.Logging.LogConfigFetcher;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggerFactory
    {
        // NOTE: Checks omitted for micro-optimization.
        
        // Creating Loggers
        
        public static ILogger CreateLoggerFromConfig()
        {
            string[] loggerNames = GetActiveLoggerNames();
            
            switch (loggerNames.Length)
            {
                case 0 : return new EmptyLogger();
                case 1 : return CreateLogger_FromName(loggerNames[0]);
                default: return new VersatileLogger(CreateLoggers_FromNames(loggerNames));
            }
        }
        
        private static ILogger[] CreateLoggers_FromNames(string[] loggerNames)
        {
            var loggers = new ILogger[loggerNames.Length];
            for (int i = 0; i < loggerNames.Length; i++)
            {
                loggers[i] = CreateLogger_FromName(loggerNames[i]);
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
