using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            string message = ex.Message;
            if (includeStackTrace)
            {
                message += Environment.NewLine + ex.StackTrace;
            }
            return message;
        }
    }
}
