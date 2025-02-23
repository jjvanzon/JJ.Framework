using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging
{
    internal class ConsoleLogger : LoggerBase
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
            
            // Might help intense parallelism from mangling logs.
            Console.Out.Flush();
        }
    }
}
