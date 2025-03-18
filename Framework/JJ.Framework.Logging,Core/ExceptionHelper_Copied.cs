using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Collections.Core;

namespace JJ.Framework.Logging.Core
{
    public static class ExceptionHelper_Copied
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
            if (ex == null) throw new ArgumentNullException(nameof(ex));
            
            string message = ex.Message;
            if (includeStackTrace)
            {
                message += Environment.NewLine + ex.StackTrace;
            }
            return message;
        }

        public static bool HasExceptionOrInnerExceptionsOfType(this Exception exception, Type exceptionType)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (exceptionType == null) throw new ArgumentNullException(nameof(exceptionType));

            bool any = exception.SelfAndAncestors(x => x.InnerException).OfType(exceptionType).Any();
            return any;
        }
        
        public static bool HasExceptionOrInnerExceptionsOfType(this Exception exception, Type exceptionType, string message)
        {
            if (exception     == null) throw new ArgumentNullException(nameof(exception));
            if (exceptionType == null) throw new ArgumentNullException(nameof(exceptionType));
            
            bool any = exception.SelfAndAncestors(x => x.InnerException)
                                .OfType(exceptionType)
                                .Where(x => string.Equals(x.Message, message, StringComparison.Ordinal))
                                .Any();
            return any;
        }

        public static bool HasExceptionOrInnerExceptionsOfType<T>(this Exception exception)
            => HasExceptionOrInnerExceptionsOfType(exception, typeof(T));
    }
}