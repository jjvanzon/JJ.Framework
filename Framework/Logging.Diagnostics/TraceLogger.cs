using System;
using System.Diagnostics;
using System.Text;

namespace JJ.Framework.Logging
{
    /// <summary>
    /// Logs a debug trace. Well usable in unit tests to log detailed performance info and other messages.
    /// </summary>
    public static class TraceLogger
    {
        public static void Message(string message)
        {
            Trace.WriteLine(message);
        }

        public static void LogValue(string name, object value)
        {
            TraceLogger.Message(string.Format("{0}: {1}", name, value));
        }

        public static void LogPerformance(Stopwatch stopwatch)
        {
            TraceLogger.LogPerformance(null, stopwatch, 1);
        }

        public static void LogPerformance(Stopwatch stopwatch, int repeats)
        {
            TraceLogger.LogPerformance(null, stopwatch, repeats);
        }

        public static void LogPerformance(string name, Stopwatch stopwatch = null, int repeats = 0)
        {
            bool hasText = false;
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(name))
            {
                sb.Append(name);
                hasText = true;
            }

            if (repeats > 1)
            {
                if (hasText) sb.Append(" ");

                sb.Append(
                    string.Format("({0} repeats)", 
                    FormatNumber(repeats)));

                hasText = true;
            }

            if (stopwatch != null)
            {
                if (hasText) sb.Append(": ");

                sb.Append(
                    string.Format("{0} ms", 
                    FormatNumber(stopwatch.ElapsedMilliseconds)));

                hasText = true;

                if (stopwatch.ElapsedMilliseconds < 100)
                {
                    if (hasText) sb.Append(", ");

                    sb.Append(
                        string.Format("{0} ticks",
                        FormatNumber(stopwatch.ElapsedTicks)));
                }

                hasText = true;
            }

            TraceLogger.Message(sb.ToString());
        }

        private static string FormatNumber(long number)
        {
            return number.ToString("###,###,###,###,###,##0");
        }

        private static string FormatNumber(int number)
        {
            return number.ToString("###,###,###,###,###,##0");
        }
    }}
