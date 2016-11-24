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

namespace Puzzle.NCore.Framework.Logging
{
    /// <summary>
    /// Summary description for ConsoleLogger.
    /// </summary>
    public class SimpleLogger : LoggerBase
    {
        public SimpleLogger()
        {
        }

        public SimpleLogger(LoggingLevel level) : base(level)
        {
        }

        public SimpleLogger(LoggingLevel level, bool isVerboseEnabled) : base(level, isVerboseEnabled)
        {
        }

        public SimpleLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                            bool isFatalEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled)
        {
        }

        public SimpleLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                            bool isFatalEnabled, bool isVerboseEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled, isVerboseEnabled)
        {
        }

        #region ILogger Members

        protected override void Log(LoggingLevel level, object message, object verbose)
        {
            if (!(IsVerboseEnabled))
                verbose = "";
            WriteLine(level,
                      DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss") + "; " + level.ToString() + "; " + message.ToString() +
                      "; " + verbose); // do not localize
        }

        protected override void Log(LoggingLevel level, object message, object verbose, Exception t)
        {
            if (!(IsVerboseEnabled))
                verbose = "";
            WriteLine(level,
                      DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss") + "; " + level.ToString() + "; " + message.ToString() +
                      "; " + t.ToString() + "; " + verbose); // do not localize			
        }

        protected override void Log(LoggingLevel level, object sender, object message, object verbose)
        {
            if (!(IsVerboseEnabled))
                verbose = "";
            WriteLine(level,
                      DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss") + "; " + level.ToString() + "; " +
                      sender.GetType().ToString() + "; " + message.ToString() + "; " + verbose); // do not localize
        }

        protected override void Log(LoggingLevel level, object sender, object message, object verbose, Exception t)
        {
            if (!(IsVerboseEnabled))
                verbose = "";
            WriteLine(level,
                      DateTime.Now.ToString("yyyy-dd-MM HH:mm:ss") + "; " + level.ToString() + "; " +
                      sender.GetType().ToString() + "; " + message.ToString() + "; " + t.ToString() + "; " + verbose);
            // do not localize			
        }

        #endregion

        protected virtual void WriteLine(LoggingLevel level, string text)
        {
            Console.WriteLine(text);
        }
    }
}