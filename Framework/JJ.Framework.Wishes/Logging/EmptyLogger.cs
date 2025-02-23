using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Wishes.Logging
{
    internal class EmptyLogger : ILogger
    {
        public void Log(string message) { }
    }
}
