using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;

namespace JJ.Framework.Wishes.Testing
{
    /// <inheritdoc cref="docs._casecollection" />
    public class CaseCollection<TCase> : IEnumerable<object[]>
        where TCase : ICase
    {
        // Storage Variables
        
        /// <inheritdoc cref="docs._casecollectionallowduplicates" />
        public bool AllowDuplicates { get; set; }
        
        private readonly IList<CaseCollection<TCase>> _subCollections = new List<CaseCollection<TCase>>();
        private readonly Dictionary<string, TCase> _caseDictionary = new Dictionary<string, TCase>();
        
        // Constructor (basic)
        
        public CaseCollection() { }
        public CaseCollection(bool allowDuplicates) => AllowDuplicates = allowDuplicates;

        // Constructors (single collection)

        public CaseCollection(params TCase[] theseCases) : this((ICollection<TCase>)theseCases) { }
        public CaseCollection(ICollection<TCase> theseCases) => AddToDictionary(theseCases);
        
        // Adding (multi-collections)
        
        public CaseCollection<TCase> AddCollection(params TCase[] subCases) => AddCollection(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> AddCollection(ICollection<TCase> subCases) => AddCollection(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> AddCollection(CaseCollection<TCase> subCollection)
        {
            if (subCollection == null) throw new NullException(() => subCollection);
            
            _subCollections.Add(subCollection);
            
            var subCases = subCollection.GetAll();
            AddToDictionary(subCases);
            
            return subCollection;
        }
        
        private void AddToDictionary(ICollection<TCase> newCases)
        {
            if (newCases == null) throw new NullException(() => newCases);
            if (newCases.Contains(default)) throw new Exception($"{nameof(newCases)} collection has empty elements.");

            foreach (TCase testCase in newCases)
            {
                string key = testCase.Key;

                if (!AllowDuplicates && _caseDictionary.ContainsKey(key))
                {
                    throw new Exception($"Duplicate key '{key}' found while adding {nameof(newCases)}.");
                }

                _caseDictionary[key] = testCase;
            }
        }
        
        // Get
        
        public TCase this[string descriptor] => Get(descriptor);
        
        public TCase Get(string descriptor)
        {
            if (_caseDictionary.TryGetValue(descriptor, out TCase testCase)) return testCase;
            throw new Exception($"Case not found: {descriptor}");
        }
                
        public ICollection<TCase> GetAll() => _caseDictionary.Values.ToArray();
        
        // Templating
        
        /// <inheritdoc cref="docs._casetemplate" />
        public CaseCollection<TCase> FromTemplate(TCase template, params TCase[] cases)
            => FromTemplate(template, (ICollection<TCase>)cases);
        
        /// <inheritdoc cref="docs._casetemplate" />
        public CaseCollection<TCase> FromTemplate(TCase template, ICollection<TCase> cases)
        {
            if (template == null) throw new NullException(() => template);
            if (cases == null) throw new NullException(() => cases);
            cases = template.FromTemplate(cases.Cast<ICase>().ToArray()).Cast<TCase>().ToArray();
            return AddCollection(cases);
        }
        
        // DynamicData
                        
        public IEnumerable<object[]> DynamicData => _caseDictionary.Values.Select(x => x.DynamicData).ToArray();
        
        public static implicit operator object[][](CaseCollection<TCase> caseCollection)
        {
            if (caseCollection == null) throw new NullException(() => caseCollection);
            return caseCollection.DynamicData.ToArray();
        }

        public IEnumerator<object[]> GetEnumerator() => DynamicData.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
