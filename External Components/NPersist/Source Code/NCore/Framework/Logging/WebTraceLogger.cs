// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using System.Web;

namespace Puzzle.NCore.Framework.Logging
{
    public class WebTraceLogger : LoggerBase
    {
        public WebTraceLogger()
        {
        }

        public WebTraceLogger(LoggingLevel level) : base(level)
        {
        }

        public WebTraceLogger(LoggingLevel level, bool isVerboseEnabled) : base(level, isVerboseEnabled)
        {
        }

        public WebTraceLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                              bool isFatalEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled)
        {
        }

        public WebTraceLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                              bool isFatalEnabled, bool isVerboseEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled, isVerboseEnabled)
        {
        }

        protected virtual void WriteLine(LoggingLevel level, string text)
        {
            HttpContext.Current.Trace.Write(level.ToString(), text);
        }

        protected virtual void WriteLine(LoggingLevel level, string text, object sender)
        {
            string senderName = "";
            if (sender != null)
                senderName = sender.GetType().Name;

            HttpContext.Current.Trace.Write(senderName + "." + level.ToString(), text);
        }

        #region ILogger Members

        protected override void Log(LoggingLevel level, object message, object verbose)
        {
            if (!(IsVerboseEnabled))
                verbose = "";

            WriteLine(level, message.ToString() + "; " + verbose); // do not localize
        }

        protected override void Log(LoggingLevel level, object message, object verbose, Exception t)
        {
            if (!(IsVerboseEnabled))
                verbose = "";

            WriteLine(level, message.ToString() + "; " + t.ToString() + "; " + verbose); // do not localize			
        }

        protected override void Log(LoggingLevel level, object sender, object message, object verbose)
        {
            if (!(IsVerboseEnabled))
                verbose = "";

            WriteLine(level, message.ToString() + "; " + verbose, sender); // do not localize
        }

        protected override void Log(LoggingLevel level, object sender, object message, object verbose, Exception t)
        {
            if (!(IsVerboseEnabled))
                verbose = "";

            WriteLine(level, message.ToString() + "; " + t.ToString() + "; " + verbose, sender); // do not localize			
        }

        #endregion
    }
}