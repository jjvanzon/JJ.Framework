using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Logging.Config;
using JJ.Framework.Wishes.Logging.Loggers;
using JJ.Framework.Wishes.Logging.Xml;
using static JJ.Framework.Reflection.ReflectionHelper;

namespace JJ.Framework.Wishes.Logging
{
    internal class LoggingFactoryOld
    {
        // NOTE: Checks omitted for micro-optimization.
        
        private static ILogger _emptyLogger = new EmptyLogger();
        
        // Creating Loggers
        
        public static ILogger CreateLoggerFromConfig(string sectionName = null) 
            => CreateLogger(LoggingConfigFetcherOld.GetLoggingConfig(sectionName));

        public static ILogger CreateLogger(RootLoggingXml config)
        {
            if (config == null) return _emptyLogger;
            
            var loggerConfigs = LoggingConfigFetcherOld.ToLoggerConfigs(config);
            
            switch (loggerConfigs.Count)
            {
                case 0 : return new EmptyLogger();
                case 1 : return CreateLogger(loggerConfigs[0]);
                default:
                {
                    var logger = new VersatileLogger(CreateLoggers(loggerConfigs));
                    var categories = LoggingConfigFetcherOld.GetCategories(config);
                    logger.SetCategories(categories);
                    return logger;
                }
            }
        }
        
        public static ILogger CreateLoggerFromConfig_Old(RootLoggingXml config)
        {
            var loggerIDs  = LoggingConfigFetcherOld.GetLoggerIDs(config);
            var categories = LoggingConfigFetcherOld.GetCategories(config);
            ILogger logger = CreateLogger_FromIDs(loggerIDs);
            
            logger.SetCategories(categories);
            
            return logger;
        }

        private static ILogger CreateLogger(IList<LoggerXml> loggerConfigs)
        { 
            switch (loggerConfigs.Count)
            {
                case 0 : return new EmptyLogger();
                case 1 : return CreateLogger(loggerConfigs[0]);
                default: return new VersatileLogger(CreateLoggers(loggerConfigs));
            }
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
        
        private static ILogger[] CreateLoggers(IList<LoggerXml> configs)
        {
            var loggers = new ILogger[configs.Count];
            for (int i = 0; i < configs.Count; i++)
            {
                loggers[i] = CreateLogger(configs[i]);
            }
            return loggers;
        }
        
        private static ILogger CreateLogger(LoggerXml loggerConfig)
        {
            ILogger logger = CreateLogger_FromID(loggerConfig.Type);
            var categories = LoggingConfigFetcherOld.GetCategories(loggerConfig);
            logger.SetCategories(categories);
            return logger;
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
