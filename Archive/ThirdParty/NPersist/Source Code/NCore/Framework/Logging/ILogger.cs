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
    /// Summary description for ILog.
    /// </summary>
    public interface ILogger
    {
        void Debug(object message, object verbose);
        void Info(object message, object verbose);
        void Warn(object message, object verbose);
        void Error(object message, object verbose);
        void Fatal(object message, object verbose);

        void Debug(object message, object verbose, Exception t);
        void Info(object message, object verbose, Exception t);
        void Warn(object message, object verbose, Exception t);
        void Error(object message, object verbose, Exception t);
        void Fatal(object message, object verbose, Exception t);

        void Debug(object sender, object message, object verbose);
        void Info(object sender, object message, object verbose);
        void Warn(object sender, object message, object verbose);
        void Error(object sender, object message, object verbose);
        void Fatal(object sender, object message, object verbose);

        void Debug(object sender, object message, object verbose, Exception t);
        void Info(object sender, object message, object verbose, Exception t);
        void Warn(object sender, object message, object verbose, Exception t);
        void Error(object sender, object message, object verbose, Exception t);
        void Fatal(object sender, object message, object verbose, Exception t);

        bool IsVerboseEnabled { get; set; }
        bool IsDebugEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
    }
}