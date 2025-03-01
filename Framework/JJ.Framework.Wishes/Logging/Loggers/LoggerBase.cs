using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        public abstract void Log(string message);
    }
}
