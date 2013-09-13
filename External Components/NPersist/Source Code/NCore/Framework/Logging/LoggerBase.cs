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
    /// Summary description for Logger.
    /// </summary>
    public class LoggerBase : ILogger
    {
        public LoggerBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public LoggerBase(bool isVerboseEnabled) : this(LoggingLevel.All, isVerboseEnabled)
        {
        }

        public LoggerBase(LoggingLevel level) : this(level, true)
        {
        }

        public LoggerBase(LoggingLevel level, bool isVerboseEnabled)
        {
            this.isVerboseEnabled = isVerboseEnabled;
            switch (level)
            {
                case LoggingLevel.All:
                    isDebugEnabled = true;
                    isInfoEnabled = true;
                    isWarnEnabled = true;
                    isErrorEnabled = true;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Debug:
                    isDebugEnabled = true;
                    isInfoEnabled = true;
                    isWarnEnabled = true;
                    isErrorEnabled = true;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Info:
                    isDebugEnabled = false;
                    isInfoEnabled = true;
                    isWarnEnabled = true;
                    isErrorEnabled = true;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Warn:
                    isDebugEnabled = false;
                    isInfoEnabled = false;
                    isWarnEnabled = true;
                    isErrorEnabled = true;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Error:
                    isDebugEnabled = false;
                    isInfoEnabled = false;
                    isWarnEnabled = false;
                    isErrorEnabled = true;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Fatal:
                    isDebugEnabled = false;
                    isInfoEnabled = false;
                    isWarnEnabled = false;
                    isErrorEnabled = false;
                    isFatalEnabled = true;
                    break;
                case LoggingLevel.Off:
                    isDebugEnabled = false;
                    isInfoEnabled = false;
                    isWarnEnabled = false;
                    isErrorEnabled = false;
                    isFatalEnabled = false;
                    break;
            }
        }

        public LoggerBase(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                          bool isFatalEnabled)
        {
            this.isDebugEnabled = isDebugEnabled;
            this.isInfoEnabled = isInfoEnabled;
            this.isWarnEnabled = isWarnEnabled;
            this.isErrorEnabled = isErrorEnabled;
            this.isFatalEnabled = isFatalEnabled;
        }

        public LoggerBase(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled,
                          bool isFatalEnabled, bool isVerboseEnabled)
        {
            this.isDebugEnabled = isDebugEnabled;
            this.isInfoEnabled = isInfoEnabled;
            this.isWarnEnabled = isWarnEnabled;
            this.isErrorEnabled = isErrorEnabled;
            this.isFatalEnabled = isFatalEnabled;
            this.isVerboseEnabled = isVerboseEnabled;
        }

        #region ILogger Members

        private bool isVerboseEnabled = true;
        private bool isDebugEnabled = true;
        private bool isInfoEnabled = true;
        private bool isWarnEnabled = true;
        private bool isErrorEnabled = true;
        private bool isFatalEnabled = true;

        protected virtual void Log(LoggingLevel level, object message, object verbose)
        {
        }

        protected virtual void Log(LoggingLevel level, object message, object verbose, Exception t)
        {
        }

        protected virtual void Log(LoggingLevel level, object sender, object message, object verbose)
        {
        }

        protected virtual void Log(LoggingLevel level, object sender, object message, object verbose, Exception t)
        {
        }

        public virtual void Debug(object message, object verbose)
        {
            if (IsDebugEnabled)
                Log(LoggingLevel.Debug, message, verbose);
        }

        public virtual void Info(object message, object verbose)
        {
            if (IsInfoEnabled)
                Log(LoggingLevel.Info, message, verbose);
        }

        public virtual void Warn(object message, object verbose)
        {
            if (IsWarnEnabled)
                Log(LoggingLevel.Warn, message, verbose);
        }

        public virtual void Error(object message, object verbose)
        {
            if (IsErrorEnabled)
                Log(LoggingLevel.Error, message, verbose);
        }

        public virtual void Fatal(object message, object verbose)
        {
            if (IsFatalEnabled)
                Log(LoggingLevel.Fatal, message, verbose);
        }

        public virtual void Debug(object message, object verbose, Exception t)
        {
            if (IsDebugEnabled)
                Log(LoggingLevel.Debug, message, verbose, t);
        }

        public virtual void Info(object message, object verbose, Exception t)
        {
            if (IsInfoEnabled)
                Log(LoggingLevel.Info, message, verbose, t);
        }

        public virtual void Warn(object message, object verbose, Exception t)
        {
            if (IsWarnEnabled)
                Log(LoggingLevel.Warn, message, verbose, t);
        }

        public virtual void Error(object message, object verbose, Exception t)
        {
            if (IsErrorEnabled)
                Log(LoggingLevel.Error, message, verbose, t);
        }

        public virtual void Fatal(object message, object verbose, Exception t)
        {
            if (IsFatalEnabled)
                Log(LoggingLevel.Fatal, message, verbose, t);
        }

        public virtual void Debug(object sender, object message, object verbose)
        {
            if (IsDebugEnabled)
                Log(LoggingLevel.Debug, sender, message, verbose);
        }

        public virtual void Info(object sender, object message, object verbose)
        {
            if (IsInfoEnabled)
                Log(LoggingLevel.Info, sender, message, verbose);
        }

        public virtual void Warn(object sender, object message, object verbose)
        {
            if (IsWarnEnabled)
                Log(LoggingLevel.Warn, sender, message, verbose);
        }

        public virtual void Error(object sender, object message, object verbose)
        {
            if (IsErrorEnabled)
                Log(LoggingLevel.Error, sender, message, verbose);
        }

        public virtual void Fatal(object sender, object message, object verbose)
        {
            if (IsFatalEnabled)
                Log(LoggingLevel.Fatal, sender, message, verbose);
        }

        public virtual void Debug(object sender, object message, object verbose, Exception t)
        {
            if (IsDebugEnabled)
                Log(LoggingLevel.Debug, sender, message, verbose, t);
        }

        public virtual void Info(object sender, object message, object verbose, Exception t)
        {
            if (IsInfoEnabled)
                Log(LoggingLevel.Info, sender, message, verbose, t);
        }

        public virtual void Warn(object sender, object message, object verbose, Exception t)
        {
            if (IsWarnEnabled)
                Log(LoggingLevel.Warn, sender, message, verbose, t);
        }

        public virtual void Error(object sender, object message, object verbose, Exception t)
        {
            if (IsErrorEnabled)
                Log(LoggingLevel.Error, sender, message, verbose, t);
        }

        public virtual void Fatal(object sender, object message, object verbose, Exception t)
        {
            if (IsFatalEnabled)
                Log(LoggingLevel.Fatal, sender, message, verbose, t);
        }

        public virtual bool IsVerboseEnabled
        {
            get { return isVerboseEnabled; }
            set { isVerboseEnabled = value; }
        }

        public virtual bool IsDebugEnabled
        {
            get { return isDebugEnabled; }
        }

        public virtual bool IsInfoEnabled
        {
            get { return isInfoEnabled; }
        }

        public virtual bool IsWarnEnabled
        {
            get { return isWarnEnabled; }
        }

        public virtual bool IsErrorEnabled
        {
            get { return isErrorEnabled; }
        }

        public virtual bool IsFatalEnabled
        {
            get { return isFatalEnabled; }
        }

        #endregion		
    }
}