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
    public class LogManager : ILogManager
    {
        public LogManager()
        {
        }

        #region Public Property Loggers

        private IList loggers = new ArrayList();

        public IList Loggers
        {
            get => loggers;
            set => loggers = value;
        }

        #endregion

        public virtual void Debug(LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Debug(message.ToString(), verbose.ToString());
            }
        }

        public virtual void Info(LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Info(message.ToString(), verbose.ToString());
            }
        }

        public virtual void Warn(LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Warn(message.ToString(), verbose.ToString());
            }
        }

        public virtual void Error(LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Error(message.ToString(), verbose.ToString());
            }
        }

        public virtual void Fatal(LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Fatal(message.ToString(), verbose.ToString());
            }
        }

        public virtual void Debug(LogMessage message, LogMessage verbose, Exception t)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Debug(message.ToString(), verbose.ToString(), t);
            }
        }

        public virtual void Info(LogMessage message, LogMessage verbose, Exception t)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Info(message.ToString(), verbose.ToString(), t);
            }
        }

        public virtual void Warn(LogMessage message, LogMessage verbose, Exception t)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Warn(message.ToString(), verbose.ToString(), t);
            }
        }

        public virtual void Error(LogMessage message, LogMessage verbose, Exception t)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Error(message.ToString(), verbose.ToString(), t);
            }
        }

        public virtual void Fatal(LogMessage message, LogMessage verbose, Exception t)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Fatal(message.ToString(), verbose.ToString(), t);
            }
        }

        public virtual void Debug(object sender, LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Debug(sender, message.ToString(), verbose.ToString());
            }
        }

        public virtual void Info(object sender, LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Info(sender, message.ToString(), verbose.ToString());
            }
        }

        public virtual void Warn(object sender, LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Warn(sender, message.ToString(), verbose.ToString());
            }
        }

        public virtual void Error(object sender, LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Error(sender, message.ToString(), verbose.ToString());
            }
        }

        public virtual void Fatal(object sender, LogMessage message, LogMessage verbose)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Fatal(sender, message.ToString(), verbose.ToString());
            }
        }



        public virtual void Debug(object sender, LogMessage message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Debug(sender, message.ToString(), "");
            }
        }

        public virtual void Info(object sender, LogMessage message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Info(sender, message.ToString(), "");
            }
        }

        public virtual void Warn(object sender, LogMessage message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Warn(sender, message.ToString(), "");
            }
        }

        public virtual void Error(object sender, LogMessage message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Error(sender, message.ToString(), "");
            }
        }

        public virtual void Fatal(object sender, LogMessage message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Fatal(sender, message.ToString(), "");
            }
        }


        public virtual void Debug(object sender, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Debug(sender, message, "");
            }
        }

        public virtual void Info(object sender, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Info(sender, message, "");
            }
        }

        public virtual void Warn(object sender, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Warn(sender, message, "");
            }
        }

        public virtual void Error(object sender, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Error(sender, message, "");
            }
        }

        public virtual void Fatal(object sender, string message)
        {
            foreach (ILogger logger in loggers)
            {
                logger.Fatal(sender, message, "");
            }
        }


    }

    public struct LogMessage
    {
        #region Property Data
        private object data;
        public object Data
        {
            get => this.data;
            set => this.data = value;
        }
        #endregion

        #region Property values
        private object[] values;
        public object[] Values
        {
            get => this.values;
            set => this.values = value;
        }
        #endregion
        public LogMessage(object data, params object[] values)
        {
            this.data = data;
            this.values = values;
        }

        public override string ToString() => string.Format(data.ToString(), values);
    }
}