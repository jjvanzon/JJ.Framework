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
    public class ConsoleLogger : SimpleLogger
    {
        public ConsoleLogger()
        {
        }

        public ConsoleLogger(LoggingLevel level) : base(level)
        {
        }

        public ConsoleLogger(LoggingLevel level, bool isVerboseEnabled) : base(level, isVerboseEnabled)
        {
        }

        public ConsoleLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                             bool isFatalEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled)
        {
        }

        public ConsoleLogger(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                             bool isFatalEnabled, bool isVerboseEnabled)
            : base(isDebugEnabled, isInfoEnabled, isWarnEnabled, isErrorEnabled, isFatalEnabled, isVerboseEnabled)
        {
        }

        protected override void WriteLine(LoggingLevel level, string text) => Console.WriteLine(text);
    }
}