using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Wishes.Logging
{
    public abstract class LoggerBase : ILogger
    {
        public abstract void Log(string message);
    }
}
