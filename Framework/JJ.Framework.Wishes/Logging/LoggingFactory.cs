using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Logging.Config;
using JJ.Framework.Wishes.Logging.Loggers;
using JJ.Framework.Wishes.Logging.Mappers;

namespace JJ.Framework.Wishes.Logging
{
    public static class LoggingFactory
    {
        private static ILogger _emptyLogger = new EmptyLogger();
        
        public static ILogger CreateLoggerFromConfig(string sectionName = null)
        {
            RootLoggingConfig rootLoggingConfig = LoggingConfigFetcher.GetLoggingConfig(sectionName);
            return CreateLogger(rootLoggingConfig);
        }

        public static ILogger CreateLogger(RootLoggingXml rootLoggingXml)
        {
            RootLoggingConfig rootLoggingConfig = LoggingConfigFetcher.GetLoggingConfig(rootLoggingXml);
            return CreateLogger(rootLoggingConfig);
        }

        
        public static ILogger CreateLogger(RootLoggingConfig rootLoggingConfig)
        {
            if (rootLoggingConfig == null) throw new NullException(() => rootLoggingConfig);
            
            if (!rootLoggingConfig.Active) return _emptyLogger;
            
            IList<LoggerConfig> loggerConfigs = rootLoggingConfig.Loggers;
            switch (loggerConfigs.Count)
            {
                case 0 : return new EmptyLogger();
                case 1 : return CreateLogger(loggerConfigs[0]);
                default: return new VersatileLogger(loggerConfigs.Select(CreateLogger).ToArray());
            }
        }

        private static ILogger CreateLogger(LoggerConfig loggerConfig)
        {
            if (loggerConfig == null) throw new NullException(() => loggerConfig);
            
            ILogger logger = TryCreateLogger_ByEnum(loggerConfig);
            
            if (logger == null)
            {
                logger =  CreateLogger_FromResolvedType(loggerConfig);
            }
            
            return logger;
        }
        
        private static ILogger TryCreateLogger_ByEnum(LoggerConfig loggerConfig)
        {
            if (loggerConfig == null) throw new NullException(() => loggerConfig);
            
            if (!Enum.TryParse(loggerConfig.Type, ignoreCase: true, out LoggerEnum loggerEnum))
            {
                return null;
            }

            ILogger logger;
            
            switch (loggerEnum)
            {
                case LoggerEnum.Console: logger = new ConsoleLogger(); break;
                case LoggerEnum.Debug: logger = new DebugLogger(); break;
                default: throw new ValueNotSupportedException(loggerEnum);
            }
            
            SetCategories(logger, loggerConfig);
            
            return logger;
        }

        private static ILogger CreateLogger_FromResolvedType(LoggerConfig loggerConfig)
        {
            if (loggerConfig == null) throw new NullException(() => loggerConfig);
            Type type = GetLoggerType(loggerConfig.Type);
            ILogger logger = (ILogger)Activator.CreateInstance(type);
            SetCategories(logger, loggerConfig);
            return logger;
        }
        
        private static void SetCategories(ILogger logger, LoggerConfig loggerConfig)
        {
            if (logger == null) throw new NullException(() => logger);
            if (loggerConfig == null) throw new NullException(() => loggerConfig);
            var categories = loggerConfig.Categories.Select(x => x.Name).ToArray();
            logger.SetCategories(categories);
        }

        // Getting Logger Types

        private static readonly object _loggerTypeDictionaryLock = new object();
        private static readonly Dictionary<string, Type> _loggerTypeDictionary = new Dictionary<string, Type>();

        private static Type GetLoggerType(string loggerType)
        {
            lock (_loggerTypeDictionaryLock)
            {
                if (_loggerTypeDictionary.TryGetValue(loggerType, out Type type))
                {
                    return type;
                }

                type = TryGetLoggerType_FromAssemblyName(loggerType) ?? 
                       Type.GetType(loggerType);
                
                if (type == null)
                {
                    throw new Exception($"{nameof(LoggerEnum)} nor Assembly nor Type found with identifier: '{loggerType}'");
                }
                
                _loggerTypeDictionary[loggerType] = type;

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
            return ReflectionHelper.GetImplementation<ILogger>(assembly);
        }
    }
}
