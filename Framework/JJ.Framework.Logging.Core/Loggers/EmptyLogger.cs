using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// ReSharper disable UnusedParameter.Global

namespace JJ.Framework.Logging.Core.Loggers
{
    internal class EmptyLogger : ILogger
    {
        public bool WillLog(string category) => false;
        public void Log(string message) { }
        public void Log(string category, string message) { }
        public void LogRaw(string message) { }
        public void LogRaw(string category, string message) { }
        public IList<string> GetCategories() => new List<string>();
        public void SetCategories(params string[] categories) { }
        public void SetCategories(ICollection<string> categories) { }
        public void AddCategories(params string[] categories) { }
        public void AddCategories(ICollection<string> categories) { }
        public void RemoveCategories(params string[] categories){ }
        public void RemoveCategories(ICollection<string> categories){ }
        public void ClearCategories(){ }
        public string Format { get => ""; set { } }
    }
}
