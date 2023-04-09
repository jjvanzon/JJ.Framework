using System;

namespace JJ.Framework.Logging
{
    public static class ExceptionExtensions
    {
        public static string FormatExceptionWithInnerExceptions(this Exception ex, bool includeStackTrace)
            => ExceptionHelper.FormatExceptionWithInnerExceptions(ex, includeStackTrace);

        public static string FormatException(this Exception ex, bool includeStackTrace)
            => ExceptionHelper.FormatException(ex, includeStackTrace);

        public static Exception GetInnermostException(this Exception exception)
            => ExceptionHelper.GetInnermostException(exception);
    }
}
