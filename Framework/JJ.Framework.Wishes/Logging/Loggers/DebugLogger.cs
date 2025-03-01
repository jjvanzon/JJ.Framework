using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    internal class DebugLogger : LoggerBase
    {
        public override void Log(string message) => Debug.WriteLine(message);
    }
}
