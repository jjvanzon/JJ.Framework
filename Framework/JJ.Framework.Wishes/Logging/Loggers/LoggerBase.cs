using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Wishes.Collections;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        private static readonly HashSet<string> _emptyCategories = new HashSet<string>();
        
        private HashSet<string> _categories = _emptyCategories;
        
        public abstract void Log(string message);
        
        public void Log(string category, string message)
        {
            if (CategoryIsMatch(category))
            {
                Log(message);
            }
        }
        
        private bool CategoryIsMatch(string category)
        {
            if (!Has(category))
            {
                return true;
            }
            
            if (_categories.Count == 0)
            {
                return true;
            }

            bool categoryIsListed = _categories.Contains(category, ignoreCase: true);
            return categoryIsListed;
        }
        
        public void SetCategories(params string[] categories)
        {
            if (!Has(categories))
            {
                _categories = _emptyCategories;
            }

            _categories = new HashSet<string>(categories);
        }
        
        public void SetCategories(ICollection<string> categories)
        {
            switch (categories)
            {
                case null: 
                    _categories = _emptyCategories; break;
                
                case var _ when categories.Count == 0:
                    _categories = _emptyCategories; break;
                    
                case HashSet<string> hashSet: 
                    _categories = hashSet; break;
                
                default: 
                    _categories = new HashSet<string>(categories); break;
            }
        }
    }
}
