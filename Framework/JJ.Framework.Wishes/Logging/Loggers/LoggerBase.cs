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
        
        private HashSet<string> _categories;

        protected LoggerBase() 
            : this(_emptyCategories) { }
        
        protected LoggerBase(ICollection<string> categories) 
            : this(new HashSet<string>(categories)) { }

        protected LoggerBase(HashSet<string> categories) 
            => _categories = Has(categories) ? categories : _emptyCategories;

        public abstract void Log(string message);
        
        public void Log(string category, string message)
        {
            if (HasCategory(category))
            {
                Log(message);
        }
        }
        
        protected bool HasCategory(string category) => _categories == _emptyCategories || _categories.Contains(category);
        
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
        
        public void SetCategories(HashSet<string> categories)
        {
            _categories = Has(categories) ? categories : _emptyCategories;
        }
    }
}
