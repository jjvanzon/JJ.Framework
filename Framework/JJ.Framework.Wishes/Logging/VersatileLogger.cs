using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Reflection;
using static System.Array;
using static JJ.Framework.Wishes.Logging.LogConfigHelper;
using static JJ.Framework.Wishes.Logging.LoggerFactory;

namespace JJ.Framework.Wishes.Logging
{
    internal class VersatileLogger : LoggerBase
    {
        private readonly ILogger[] _loggers;
        
        public VersatileLogger(LogConfig config)
        {
            if (config == null) throw new NullException(() => config);
            if (config.Logs == null) throw new NullException(() => config.Logs);
            
            // TODO: Move this to factory, so you can return different instances based on configuration?

            var loggerConfigs = config.Logs.Where(x => x.Active ?? DefaultActive).ToArray();
            
            int count = loggerConfigs.Length;
            
            _loggers = new ILogger[count];
            
            for (int i = 0; i < count; i++)
            {
                _loggers[i] = CreateLogger(config.Logs[i].Type);
            }   
        }
        
        public override void Log(string message)
        {
            int count = _loggers.Length;
            for (int i = 0; i < count; i++)
            {
                _loggers[i].Log(message);
            }
        }
    }
}
