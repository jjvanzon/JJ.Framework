using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    internal class EmptyLogger : ILogger
    {
        public bool WillLog(string category) => false;
        public void Log(string message) { }
        public void Log(string category, string message) { }
        public void SetCategories(params string[] categories) { }
        public void SetCategories(ICollection<string> categories) { }
        public void AddCategories(params string[] categories) { }
        public void AddCategories(ICollection<string> categories) { }
        public void RemoveCategories(params string[] categories){ }
        public void RemoveCategories(ICollection<string> categories){ }
        public void ClearCategories(){ }
    }
}
