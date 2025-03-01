using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string category, string message);
        void SetCategories(params string[] categories);
        void SetCategories(ICollection<string> categories);
        void SetCategories(HashSet<string> categories);
    }
}
