using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Wishes.Logging
{
    internal class DebugOutputLogger : LoggerBase
    {
        public override void Log(string message) => Debug.WriteLine(message);
    }
}
