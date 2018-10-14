// *
// * Copyright (C) 2005 Roger Alsing : http://www.puzzleframework.com
// *
// * This library is free software; you can redistribute it and/or modify it
// * under the terms of the GNU Lesser General Public License 2.1 or later, as
// * published by the Free Software Foundation. See the included license.txt
// * or http://www.gnu.org/copyleft/lesser.html for details.
// *
// *
using System;
using System.Collections;

namespace Puzzle.NCore.Framework.Logging
{
    public interface ILogManager
    {
        void Debug(LogMessage message, LogMessage verbose);
        void Info(LogMessage message, LogMessage verbose);
        void Warn(LogMessage message, LogMessage verbose);
        void Error(LogMessage message, LogMessage verbose);
        void Fatal(LogMessage message, LogMessage verbose);

        void Debug(LogMessage message, LogMessage verbose, Exception t);
        void Info(LogMessage message, LogMessage verbose, Exception t);
        void Warn(LogMessage message, LogMessage verbose, Exception t);
        void Error(LogMessage message, LogMessage verbose, Exception t);
        void Fatal(LogMessage message, LogMessage verbose, Exception t);

        void Debug(object sender, LogMessage message, LogMessage verbose);
        void Info(object sender, LogMessage message, LogMessage verbose);
        void Warn(object sender, LogMessage message, LogMessage verbose);
        void Error(object sender, LogMessage message, LogMessage verbose);
        void Fatal(object sender, LogMessage message, LogMessage verbose);


        void Debug(object sender, LogMessage message);
        void Info(object sender, LogMessage message);
        void Warn(object sender, LogMessage message);
        void Error(object sender, LogMessage message);
        void Fatal(object sender, LogMessage message);

        void Debug(object sender, string message);
        void Info(object sender, string message);
        void Warn(object sender, string message);
        void Error(object sender, string message);
        void Fatal(object sender, string message);

    //    void Debug(object sender, object message, object verbose, Exception t);
    //    void Info(object sender, object message, object verbose, Exception t);
    //    void Warn(object sender, object message, object verbose, Exception t);
    //    void Error(object sender, object message, object verbose, Exception t);
    //    void Fatal(object sender, object message, object verbose, Exception t);

        IList Loggers { get; set; }
    }
}