// *
// * Copyright (C) 2005 Mats Helander : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *


namespace Puzzle.NCore.Framework.Logging
{
    public class DebugLogger : SimpleLogger
    {
        public DebugLogger()
        {
        }

        public DebugLogger(LoggingLevel level) : base(level)
        {
        }

        public DebugLogger(LoggingLevel level, bool isVerboseEnabled) : base(level, isVerboseEnabled)
        {
        }

        public DebugLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                           bool isFatalEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled)
        {
        }

        public DebugLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                           bool isFatalEnabled, bool isVerboseEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled, isVerboseEnabled)
        {
        }

        protected override void WriteLine(LoggingLevel level, string text) => System.Diagnostics.Debug.WriteLine(text, level.ToString());
    }
}