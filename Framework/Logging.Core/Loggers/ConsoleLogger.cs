namespace JJ.Framework.Logging.Core.Loggers
{
    internal class ConsoleLogger : LoggerBase
    {
        protected override void WriteLine(string message)
        {
            Console.WriteLine(message);
            
            // Might help intense parallelism from mangling logs.
            // TODO: Might not be needed anymore (now that logging has been restructured).
            Console.Out.Flush();
        }
    }
}
