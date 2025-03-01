using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    internal class ConsoleLogger : LoggerBase
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
            
            // Might help intense parallelism from mangling logs.
            // TODO: Might not be needed anymore (now that logging has been restructured).
            Console.Out.Flush();
        }
    }
}
