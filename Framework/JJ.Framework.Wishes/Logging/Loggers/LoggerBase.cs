using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.Logging.Config;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        private static readonly HashSet<string> _emptyCategories = new HashSet<string>();
        
        private readonly HashSet<string> _categories;

        protected LoggerBase() 
            : this(_emptyCategories) { }
        
        protected LoggerBase(ICollection<string> categories) 
            : this(new HashSet<string>(categories)) { }

        protected LoggerBase(HashSet<string> categories) 
            => _categories = Has(categories) ? categories : _emptyCategories;

        public abstract void Log(string message);
        
        public void Log(string category, string message)
        {
            if (HasCategory(category)) Log(message);
        }
        
        protected bool HasCategory(string category)
        {
            //if (_categories.Count == 0)
            if (_categories == _emptyCategories)
            {
                return true;
            }
            
            return _categories.Contains(category);
        }
    }
}
