namespace JJ.Framework.Logging.Core.Loggers
{
    internal class VersatileLogger : LoggerBase
    {
        private readonly ILogger[] _loggers;

        public VersatileLogger(ILogger[] loggers) => _loggers = loggers ?? throw new NullException(() => loggers);
        
        protected override void WriteLine(string message)
        {
            int count = _loggers.Length;
            for (int i = 0; i < count; i++)
            {
                _loggers[i].Log(message);
            }
        }
    }
}
