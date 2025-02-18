using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;

namespace JJ.Framework.Wishes.Testing
{
    /// <inheritdoc cref="docs._casecollection" />
    public class CaseCollection<TCase> : IEnumerable<object[]>
        where TCase : ICase
    {
        // Storage Variables
        
        public bool AllowDuplicates { get; set; }
        
        private readonly IList<TCase> _theseCases = new List<TCase>();
        private readonly IList<CaseCollection<TCase>> _subCaseCollections = new List<CaseCollection<TCase>>();
        private readonly Dictionary<string, TCase> _dictionary = new Dictionary<string, TCase>();
        
        // Constructor (basic)
        
        public CaseCollection() { }
        public CaseCollection(bool allowDuplicates) => AllowDuplicates = allowDuplicates;

        // Constructors (single collection)

        public CaseCollection(params TCase[] theseCases) : this((ICollection<TCase>)theseCases) { }
        public CaseCollection(ICollection<TCase> theseCases) => Initialize(theseCases);
        
        // Adding (multi-collections)
        
        public CaseCollection<TCase> Add(params TCase[] subCases) => Add(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> Add(ICollection<TCase> subCases) => Add(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> Add(CaseCollection<TCase> subCaseCollection)
        {
            if (subCaseCollection == null) throw new NullException(() => subCaseCollection);
            
            _subCaseCollections.Add(subCaseCollection);
            
            var cases = subCaseCollection.GetAll();
            
            Initialize(cases);
            
            return subCaseCollection;
        }
        
        private void Initialize(ICollection<TCase> cases)
        {
            Assert(cases);
            
            AddToList(cases);
            
            AddToDictionary(cases);
        }
        
        private static void Assert(ICollection<TCase> cases)
        {
            if (cases == null) throw new NullException(() => cases);
            if (cases.Contains(default)) throw new Exception($"{nameof(cases)} collection has empty elements.");
        }
        
        private void AddToList(ICollection<TCase> cases)
        {
            _theseCases.AddRange(cases);
        }
        
        private void AddToDictionary(ICollection<TCase> cases)
        {
            foreach (TCase testCase in cases)
            {
                string key = testCase.Key;
                
                if (AllowDuplicates)
                {
                    // Allow duplicates to pass by, for practical reasons when managing multiple CaseCollections as one.
                    _dictionary[key] = testCase;
                }
                else
                {
                    if (_dictionary.ContainsKey(key))
                    {
                        throw new Exception($"Duplicate key '{key}' found while adding to {nameof(cases)} collection.");
                    }
                    _dictionary.Add(key, testCase);
                }
            }
        }
        
        // Get
        
        public TCase this[string descriptor] => Get(descriptor);
        
        public TCase Get(string descriptor)
        {
            if (_dictionary.TryGetValue(descriptor, out TCase testCase)) return testCase;
            throw new Exception($"Case not found: {descriptor}");
        }
                
        public ICollection<TCase> GetAll() => _theseCases;
        
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
            return Add(cases);
        }
        
        // DynamicData
                        
        public IEnumerable<object[]> DynamicData => _theseCases.Select(x => x.DynamicData).ToArray();
        
        public static implicit operator object[][](CaseCollection<TCase> caseCollection)
        {
            if (caseCollection == null) throw new NullException(() => caseCollection);
            return caseCollection.DynamicData.ToArray();
        }

        public IEnumerator<object[]> GetEnumerator() => DynamicData.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
