using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JJ.Framework.Logging.Core.Loggers
{
    internal class DebugLogger : LoggerBase
    {
        protected override void WriteLine(string message) => Debug.WriteLine(message);
    }
}
