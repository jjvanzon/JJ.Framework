using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using static JJ.Framework.Reflection.ReflectionHelper;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging
{
    public class LoggerFactory
    {
        private static readonly object _dictionaryLock = new object();
        private static readonly Dictionary<string, Type> _loggerTypeDictionary = new Dictionary<string, Type>();
        
        public static ILogger CreateLoggerFromConfig()
        {
            LogConfig config = LogConfigHelper.GetConfigSection();
            return CreateLogger(config);
        }
        
        public static ILogger CreateLogger(LogConfig config)
        {
            if (config == null) throw new NullException(() => config);
            ILogger logger = new VersatileLogger(config);
            return logger;
        }
        
        internal static ILogger CreateLogger(string name)
        {
            if (!Has(name)) throw new Exception(nameof(name) + " not filled in.");
            
            ILogger logger = TryGetLoggerByEnum(name);
            if (logger != null) return logger;
            
            lock (_dictionaryLock)
            {
                if (_loggerTypeDictionary.TryGetValue(name, out Type type))
                {
                    return CreateLogger(type);
                }

                type  = TryGetTypeFromAssembly(name);
                if (type == null) type = GetTypeByString(name);
                
                _loggerTypeDictionary[name] = type;

                return CreateLogger(type);
            }
        }
        
        private static ILogger TryGetLoggerByEnum(string name)
        {
            if (Enum.TryParse(name, out LoggerEnum value))
            {
                switch (value)
                {
                    case LoggerEnum.Console: return new ConsoleLogger();
                    case LoggerEnum.DebugOutput: return new DebugOutputLogger();
                    default: throw new ValueNotSupportedException(value);
                }
            }
            
            return null;
        }
        
        private static Type TryGetTypeFromAssembly(string assemblyName)
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
            
            return TryGetTypeFromAssembly(assembly);
        }
        
        private static Type TryGetTypeFromAssembly(Assembly assembly)
        {
            var types = GetImplementations<ILogger>(assembly);
            
            // After assembly load succeeds, it is required to contain exactly one ILogger implementation.
            
            switch (types.Length)
            {
                case 0:  throw new Exception("No " + nameof(ILogger) + " implementation found in assembly " + assembly.FullName);
                case 1:  return types[0];
                default: throw new Exception("Multiple " + nameof(ILogger) + " implementations found in assembly " + assembly.FullName);
            }
        }
        
        private static Type GetTypeByString(string typeString)
        {
            var type = Type.GetType(typeString);
            if (type == null)
            {
                throw new Exception("Type " + typeString + " not found.");
            }
            return type;
        }
        
        private static ILogger CreateLogger(Type type)
        {
            if (type == null) throw new NullException(() => type);
            
            object obj = Activator.CreateInstance(type);
            
            if (!(obj is ILogger logger))
            {
                throw new Exception("Type " + type.FullName + " does not implement " + nameof(ILogger) + ".");
            }
            
            return logger;
        }
    }
}
