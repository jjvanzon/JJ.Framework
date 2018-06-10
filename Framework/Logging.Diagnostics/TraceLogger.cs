using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;

namespace JJ.Framework.Logging.Diagnostics
{
	/// <summary> Logs a debug trace. Well usable in unit tests to log detailed performance info and other messages. </summary>
	[PublicAPI]
	public static class TraceLogger
	{
		public static void Message(string message) => Trace.WriteLine(message);
	    public static void LogValue(string name, object value) => Message($"{name}: {value}");
	    public static void LogPerformance(Stopwatch stopwatch) => LogPerformance(null, stopwatch, 1);
	    public static void LogPerformance(Stopwatch stopwatch, int repeats) => LogPerformance(null, stopwatch, repeats);

	    public static void LogPerformance(string name, Stopwatch stopwatch = null, int repeats = 0)
		{
			bool hasText = false;
			var sb = new StringBuilder();

			if (!string.IsNullOrEmpty(name))
			{
				sb.Append(name);
				hasText = true;
			}

			if (repeats > 1)
			{
				if (hasText) sb.Append(" ");

				sb.Append($"({FormatNumber(repeats)} repeats)");

				hasText = true;
			}

			if (stopwatch != null)
			{
				if (hasText) sb.Append(": ");

				sb.Append($"{FormatNumber(stopwatch.ElapsedMilliseconds)} ms");

				hasText = true;

				if (stopwatch.ElapsedMilliseconds < 100)
				{
					if (hasText) sb.Append(", ");

					sb.Append($"{FormatNumber(stopwatch.ElapsedTicks)} ticks");
				}

				hasText = true;
			}

			Message(sb.ToString());
		}

        private static string FormatNumber(long number) => number.ToString("###,###,###,###,###,##0");
        private static string FormatNumber(int number) => number.ToString("###,###,###,###,###,##0");
    }
}
