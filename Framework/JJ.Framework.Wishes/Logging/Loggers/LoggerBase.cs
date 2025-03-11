using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.docs;
using JJ.Framework.Wishes.Collections;
using JJ.Framework.Wishes.Common;
using JJ.Framework.Wishes.Text;
using static System.Environment;
using static System.StringComparer;
using static JJ.Framework.Wishes.Common.FilledInWishes;

namespace JJ.Framework.Wishes.Logging.Loggers
{
    public abstract class LoggerBase : ILogger
    {
        private readonly HashSet<string> _categories = new HashSet<string>(OrdinalIgnoreCase);
        
        /// <inheritdoc cref="_loggerexcludedcategories" />
        private readonly HashSet<string> _excludedCategories = new HashSet<string>(OrdinalIgnoreCase);
        
        // NOTE: All the threading, locking and flushing helped
        // Test Explorer in Visual Studio 2022
        // avoid mangling blank lines, for the most part.
        
        private readonly object _logLock = new object();
        private bool _blankLinePending;
        
        protected abstract void WriteLine(string message);
        
        public void Log(string message) => Log("", message);
        public void Log(string category, string message)
        {
            if (!WillLog(category)) 
            {
                return;
            }

            bool hasMessage = Has(message);
            bool startsWithBlankLine = message.StartsWithBlankLine();
            bool endsWithBlankLine = message.EndsWithBlankLine();
            
            lock (_logLock)
            {
                if (!hasMessage)
                {
                    _blankLinePending = true;
                    return;
                }
                
                if (_blankLinePending)
                {
                    if (!startsWithBlankLine)
                    {
                        message = NewLine + message;
                    }
                }
                
                _blankLinePending = endsWithBlankLine;
                
                WriteLine(message.TrimEnd());
            }
        }
        
        public bool WillLog(string category)
        {
            // 1) Empty category => log
            // 2) If category is excluded => no
            // 3) If category list empty => log all
            // 4) Else check if it's in _categories => yes/no

            if (category.IsNully())
            {
                return true;
            }

            bool categoryIsExcluded = _excludedCategories.Contains(category);
            if (categoryIsExcluded)
            {
                return false;
            }
            
            bool noCategoryFilter = _categories.Count == 0;
            if (noCategoryFilter)
            {
                return true;
            }
            
            bool categoryIsListed = _categories.Contains(category);
            return categoryIsListed;
        }
        
        public IList<string> GetCategories() => _categories.Except(_excludedCategories).ToList();
        
        public void SetCategories(params string[] categories) => SetCategories((ICollection<string>)categories);
        public void SetCategories(ICollection<string> categories)
        {
            if (categories == null) throw new NullException(() => categories);
            _categories.Clear();
            _categories.AddRange(categories);
            _excludedCategories.Clear();
        }
        
        public void AddCategories(params string[] categories) => AddCategories((ICollection<string>)categories);
        public void AddCategories(ICollection<string> categories)
        {
            if (categories == null) throw new NullException(() => categories);
            _categories        .AddRange   (categories);
            _excludedCategories.RemoveRange(categories);
        }
        
        public void RemoveCategories(params string[] categories) => RemoveCategories((ICollection<string>)categories);
        public void RemoveCategories(ICollection<string> categories)
        {
            if (categories == null) throw new NullException(() => categories);
            _categories        .RemoveRange(categories);
            _excludedCategories.AddRange   (categories);
        }
        
        public void ClearCategories()
        {
            _categories        .Clear();
            _excludedCategories.Clear();
        }
    }
}
