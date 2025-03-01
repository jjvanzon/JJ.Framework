using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    internal class EmptyLogger : ILogger
    {
        public void Log(string message) { }
        public void Log(string category, string message) { }
    }
}
