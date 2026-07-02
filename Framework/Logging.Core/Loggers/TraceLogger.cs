using System.Diagnostics;

namespace JJ.Framework.Logging.Core.Loggers
{
    internal class TraceLogger : LoggerBase
    {
        protected override void WriteLine(string message) => Trace.WriteLine(message);
    }
}
