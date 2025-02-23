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
