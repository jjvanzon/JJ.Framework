using System.Collections;

namespace JJ.Framework.Testing.Core
{
    /// <inheritdoc cref="_casecollection" />
    public class CaseCollection<TCase> : IEnumerable<object[]>
        where TCase : ICase
    {
        // Storage Collection

        private readonly Dictionary<string, TCase> _caseDictionary = new();

        // Properties
        
        public bool AllowDuplicates { get; set; }
        private bool IsRoot => Root == null;
        private CaseCollection<TCase>? Root { get; set; }

        // Constructor (basic)
        
        public CaseCollection() { }

        // Constructors (single collection)

        public CaseCollection(params TCase[] initialCases) : this((ICollection<TCase>)initialCases) { }
        public CaseCollection(IEnumerable<TCase> initialCases) => AddToDictionary(initialCases);
        
        // Adding (multi-collections)
        
        public CaseCollection<TCase> Add(params TCase[] subCases) => Add(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> Add(IEnumerable<TCase> subCases) => Add(new CaseCollection<TCase>(subCases));
        public CaseCollection<TCase> Add(CaseCollection<TCase> subCollection)
        {
            if (subCollection == null) throw new NullException(() => subCollection);

            subCollection.Root = this;
            
            var items = subCollection.GetAll();

            AddToDictionary(items);
            Root?.AddToDictionary(items);

            if (IsRoot)
            {
                return subCollection;
            }
            else
            {
                return this;
            }
        }
        
        private void AddToDictionary(IEnumerable<TCase> newCases)
        {
            if (newCases == null) throw new NullException(() => newCases);

            foreach (TCase newCase in newCases)
            {
                if (Equals(newCase, default)) throw new Exception($"{nameof(newCases)} collection has empty elements.");

                string key = newCase.Key;
                if (!AllowDuplicates && _caseDictionary.ContainsKey(key))
                {
                    throw new Exception($"Duplicate key '{key}' found while adding Cases.");
                }

                _caseDictionary[key] = newCase;
            }
        }
        
        // Get
        
        public TCase this[string key] => Get(key);
        
        public TCase Get(string key)
        {
            if (_caseDictionary.TryGetValue(key, out TCase? testCase)) return testCase;
            throw new Exception($"Case not found: {key}");
        }
                
        public ICollection<TCase> GetAll() => _caseDictionary.Values.ToArray();
        
        // Templating
        
        /// <inheritdoc cref="_casetemplate" />
        public CaseCollection<TCase> FromTemplate(TCase template, params TCase[] cases)
            => FromTemplate(template, (ICollection<TCase>)cases);
        
        /// <inheritdoc cref="_casetemplate" />
        public CaseCollection<TCase> FromTemplate(TCase template, ICollection<TCase> cases)
        {
            if (template == null) throw new NullException(() => template);
            if (cases == null) throw new NullException(() => cases);
            cases = template.FromTemplate(cases.Cast<ICase>().ToArray()).Cast<TCase>().ToArray();
            return Add(cases);
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
