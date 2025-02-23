using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JJ.Framework.Reflection;
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
            if (config.Loggers == null) throw new NullException(() => config.Loggers);
            
            var loggerConfigs = config.Loggers.Where(x => x.Enabled ?? DefaultEnabled).ToArray();
            
            int count = loggerConfigs.Length;
            
            _loggers = new ILogger[count];
            
            for (int i = 0; i < count; i++)
            {
                _loggers[i] = CreateLogger(config.Loggers[i].Type);
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
