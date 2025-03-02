using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    internal class VersatileLogger : LoggerBase
    {
        private readonly ILogger[] _loggers;

        public VersatileLogger(ILogger[] loggers) => _loggers = loggers ?? throw new NullException(() => loggers);
        
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
