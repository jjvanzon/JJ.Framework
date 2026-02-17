using System.Diagnostics;

namespace JJ.Framework.Logging.Core.Loggers
{
    internal class DebugLogger : LoggerBase
    {
        protected override void WriteLine(string message) => Debug.WriteLine(message);
    }
}
