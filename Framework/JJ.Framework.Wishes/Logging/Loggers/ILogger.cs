using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public interface ILogger
    {
        bool WillLog(string category);
        void Log(string message);
        void Log(string category, string message);
        void SetCategories(params string[] categories);
        void SetCategories(ICollection<string> categories);
    }
}
