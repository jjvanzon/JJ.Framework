using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Wishes.Logging.Config;
using JJ.Framework.Wishes.Logging.Loggers;
using static JJ.Framework.Reflection.ReflectionHelper;
using static JJ.Framework.Wishes.Logging.Config.LoggingConfigFetcher;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggingFactory
    {
        // NOTE: Checks omitted for micro-optimization.
        
        // Creating Loggers
        
        public static ILogger CreateLoggerFromConfig(string sectionName = null) 
            => CreateLoggerFromConfig(GetLoggingConfig(sectionName));

        public static ILogger CreateLoggerFromConfig(LoggingConfiguration config)
        {
            var loggerIDs  = GetLoggerIDs(config);
            var categories = GetCategories(config);
            ILogger logger = CreateLogger_FromIDs(loggerIDs);
            
            logger.SetCategories(categories);
            
            return logger;
        }
        
        private static ILogger CreateLogger_FromIDs(string[] loggerIDs)
        {
            switch (loggerIDs.Length)
            {
                case 0 : return new EmptyLogger();
                case 1 : return CreateLogger_FromID(loggerIDs[0]);
                default: return new VersatileLogger(CreateLoggers_FromIDs(loggerIDs));
            }
        }
        
        private static ILogger[] CreateLoggers_FromIDs(string[] loggerIDs)
        {
            var loggers = new ILogger[loggerIDs.Length];
            for (int i = 0; i < loggerIDs.Length; i++)
            {
                loggers[i] = CreateLogger_FromID(loggerIDs[i]);
            }
            return loggers;
        }
        
        private static ILogger CreateLogger_FromID(string loggerID) 
            => TryCreateLogger_ByEnum(loggerID) ?? (ILogger)Activator.CreateInstance(GetLoggerType(loggerID));
        
        private static ILogger TryCreateLogger_ByEnum(string loggerID)
        {
            if (!Enum.TryParse(loggerID, ignoreCase: true , out LoggerEnum value))
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

        private static Type GetLoggerType(string loggerID)
        {
            lock (_loggerTypeDictionaryLock)
            {
                if (_loggerTypeDictionary.TryGetValue(loggerID, out Type type))
                {
                    return type;
                }

                type = TryGetLoggerType_FromAssemblyName(loggerID) ?? Type.GetType(loggerID);
                
                if (type == null)
                {
                    throw new Exception($"{nameof(LoggerEnum)} nor Assembly nor Type found with identifier: '{loggerID}'");
                }
                
                _loggerTypeDictionary[loggerID] = type;

                return type;
            }
        }
        
        private static Type TryGetLoggerType_FromAssemblyName(string assemblyName)
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