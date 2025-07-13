// ReSharper disable RedundantBaseConstructorCall

namespace JJ.Framework.Testing.Core
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public abstract class CaseBase<TMainProp> : CaseProp<TMainProp>, ICase
        where TMainProp : struct
    {
        // Properties

        /// <inheritdoc cref="_strict" />
        public bool Strict { get; set; } = true;
        public CaseProp<TMainProp> MainProp => this;
        ICaseProp ICase.MainProp => this;
        
        public IList<ICaseProp> Props
        {
            [Suppress("Trimmer", "IL2026", Justification = FieldType)]
            get => GetCasePropFields().Select(x => x.GetValue(this))
                                      .Cast<ICaseProp>()
                                      .Distinct()
                                      .ToArray();
        }

        [NoTrim(FieldType)]
        private IList<FieldInfo> GetCasePropFields()
            => GetType().GetFields(BINDING_FLAGS_ALL)
                        .Where(x => x.FieldType.HasInterfaceInHierarchy<ICaseProp>())
                        .ToArray();
        
        [NoTrim(FieldType)]
        private void AutoCreateProps() => GetCasePropFields().Where(x => x.GetValue(this) == null)
                                                             .ForEach(x => x.SetValue(this, CreateInstance(x.FieldType)));
        // Descriptions
        
        public string Name { get; set; } = "";
        public string Key => new CaseKeyBuilder(this).BuildKey();
        public override string ToString() => Key;
        public object[] DynamicData => [Key];

        public virtual IList<object> KeyElements { get; } = Empty<object>();
        private string DebuggerDisplay => DebuggerDisplay(this);

        // Templating

        // Instance
        
        /// <inheritdoc cref="_casetemplate" />
        public ICase[] FromTemplate(params ICase[] destCases) 
            => FromTemplate(this, destCases);
        
        /// <inheritdoc cref="_casetemplate" />
        public ICollection<ICase> FromTemplate(ICollection<ICase> destCases) 
            => FromTemplate(this, destCases);

        // Static
        
        /// <inheritdoc cref="_casetemplate" />
        public static ICase[] FromTemplate(ICase template, params ICase[] destCases) 
            => FromTemplate(template, (ICollection<ICase>)destCases).ToArray();

        /// <inheritdoc cref="_casetemplate" />
        public static ICollection<ICase> FromTemplate(ICase template, ICollection<ICase> destCases) 
        {
            if (template == null) throw new NullException(() => template);
            if (destCases == null) throw new NullException(() => destCases);
            if (destCases.Contains(null!)) throw new Exception($"{nameof(destCases)} contains nulls.");
            
            var sourceCase = template;
            
            foreach (var destCase in destCases)
            {
                // Basic
                destCase.Name = Coalesce(destCase.Name, template.Name);
                if (template.Strict == false)
                {
                    destCase.Strict = false; // Yield over "alleviation from strictness".
                }
                
                // Main Prop
                destCase.CloneFrom(sourceCase);
                
                // Props
                for (int j = 0; j < template.Props.Count; j++)
                {
                    var sourceProp = template.Props[j];
                    if (sourceProp != null)
                    {
                        ICaseProp destProp = destCase.Props[j];
                        destProp.CloneFrom(sourceProp);
                    }
                }
            }
            
            return destCases;
        }

        // Constructors

        [NoTrim(FieldType)] public CaseBase() : base() => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp value) : base(value) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp? value) : base(value) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp from, TMainProp to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp from, TMainProp? to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp? from, TMainProp to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp? from, TMainProp? to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp from, TMainProp to) values) : base(values) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp? from, TMainProp to) values) : base(values) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp from, TMainProp? to) values) : base(values) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp? from, TMainProp? to) values) : base(values) => Initialize();
        [NoTrim(FieldType)] public CaseBase(TMainProp from, (TMainProp? nully, TMainProp coalesced) to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp? nully, TMainProp coalesced) from, TMainProp to) : base(from, to) => Initialize();
        [NoTrim(FieldType)] public CaseBase((TMainProp? nully, TMainProp coalesced) from, (TMainProp? nully, TMainProp coalesced) to) : base(from, to) => Initialize();
        
        [NoTrim(FieldType)]
        private void Initialize() => AutoCreateProps();
    }
}
