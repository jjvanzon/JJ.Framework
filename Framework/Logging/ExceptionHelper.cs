using JJ.Framework.Exceptions;
using System;
using System.Text;
using JJ.Framework.Exceptions.Basic;

namespace JJ.Framework.Logging
{
	public static class ExceptionHelper
	{
		public static string FormatExceptionWithInnerExceptions(Exception ex, bool includeStackTrace)
		{
			var sb = new StringBuilder();
			sb.AppendLine(FormatException(ex, includeStackTrace));

			while (ex.InnerException != null)
			{
				sb.AppendLine("Inner exception:");
				sb.AppendLine(FormatException(ex.InnerException, includeStackTrace));
				ex = ex.InnerException;
			}

			return sb.ToString();
		}

		public static string FormatException(Exception ex, bool includeStackTrace)
		{
			if (ex == null) throw new NullException(() => ex);

			string message = ex.Message;
			if (includeStackTrace)
			{
				message += Environment.NewLine + ex.StackTrace;
			}
			return message;
		}

		public static Exception GetInnermostException(Exception exception)
		{
			const int maxIterations = 100;

			int i = 0;
			while (exception.InnerException != null && i < maxIterations)
			{
				exception = exception.InnerException;
				i++;
			}

			return exception;
		}
	}
}
