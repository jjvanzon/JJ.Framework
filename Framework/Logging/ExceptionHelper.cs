using System;
using System.Linq;
using System.Text;
using JJ.Framework.Collections;
// ReSharper disable ReplaceWithSingleCallToAny

namespace JJ.Framework.Logging
{
    /// <summary> May also contain extension methods. </summary>
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
            if (ex == null) throw new ArgumentNullException(nameof(ex));

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

            var i = 0;
            while (exception.InnerException != null && i < maxIterations)
            {
                exception = exception.InnerException;
                i++;
            }

            return exception;
        }

        public static bool HasExceptionOrInnerExceptionsOfType(this Exception exception, Type exceptionType)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (exceptionType == null) throw new ArgumentNullException(nameof(exceptionType));

            bool any = exception.SelfAndAncestors(x => x.InnerException).OfType(exceptionType).Any();
            return any;
        }

        public static bool HasExceptionOrInnerExceptionsOfType<T>(this Exception exception)
            => HasExceptionOrInnerExceptionsOfType(exception, typeof(T));


        public static bool HasExceptionOrInnerExceptionsOfType(this Exception exception, Type exceptionType, string message)
        {
            if (exception == null) throw new ArgumentNullException(nameof(exception));
            if (exceptionType == null) throw new ArgumentNullException(nameof(exceptionType));

            bool any = exception.SelfAndAncestors(x => x.InnerException)
                                .OfType(exceptionType)
                                .Where(x => string.Equals(x.Message, message))
                                .Any();
            return any;
        }

        public static bool HasExceptionOrInnerExceptionsOfType<T>(this Exception exception, string message)
            => HasExceptionOrInnerExceptionsOfType(exception, typeof(T), message);

    }
}
