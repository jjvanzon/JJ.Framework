﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using JJ.Framework.Common;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Reflection;
using static System.Activator;
using static System.Array;
using static JJ.Framework.Reflection.ReflectionHelper;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Testing.DebuggerDisplayFormatter;

namespace JJ.Framework.Wishes.Testing
{

    [DebuggerDisplay("{DebuggerDisplay}")]
    public abstract class CaseBase<TMainPropNully, TMainPropCoalesced> : CaseProp<TMainPropNully, TMainPropCoalesced>, ICase
        //where TMainProp : struct
    {
        // Properties

        /// <inheritdoc cref="docs._strict />
        public bool Strict { get; set; } = true;
        public CaseProp<TMainPropNully, TMainPropCoalesced> MainProp => this;
        ICaseProp ICase.MainProp => MainProp;

        public IList<ICaseProp> Props
            => GetCasePropFields().Select(x => x.GetValue(this))
                                  .Cast<ICaseProp>()
                                  .Distinct()
                                  .ToArray();
        
        private IList<FieldInfo> GetCasePropFields()
            => GetType().GetFields(BINDING_FLAGS_ALL)
                        .Where(x => x.FieldType.HasInterfaceRecursive<ICaseProp>())
                        .ToArray();
        
        private void AutoCreateProps() => GetCasePropFields().Where(x => x.GetValue(this) == null)
                                                             .ForEach(x => x.SetValue(this, CreateInstance(x.FieldType)));
        // Descriptions
        
        public string Name { get; set; }
        public string Key => new CaseKeyBuilder(this).BuildKey();
        public override string ToString() => Key;
        public object[] DynamicData => new object[] { Key };
        public virtual IList<object> KeyElements { get; } = Empty<object>();
        private string DebuggerDisplay => DebuggerDisplay(this);

        // Templating

        // Instance

        /// <inheritdoc cref="docs._casetemplate" />
        public ICase[] FromTemplate(params ICase[] destCases) 
            => FromTemplate(this, destCases);
        
        /// <inheritdoc cref="docs._casetemplate" />
        public ICollection<ICase> FromTemplate(ICollection<ICase> destCases) 
            => FromTemplate(this, destCases);

        // Static
        
        /// <inheritdoc cref="docs._casetemplate" />
        public static ICase[] FromTemplate(ICase template, params ICase[] destCases) 
            => FromTemplate(template, (ICollection<ICase>)destCases).ToArray();

        /// <inheritdoc cref="docs._casetemplate" />
        public static ICollection<ICase> FromTemplate(ICase template, ICollection<ICase> destCases) 
        {
            if (template == null) throw new NullException(() => template);
            if (destCases == null) throw new NullException(() => destCases);
            if (destCases.Contains(null)) throw new Exception($"{nameof(destCases)} contains nulls.");
            
            var sourceCase = template;
            
            foreach (var destCase in destCases)
            {
                // Basic
                destCase.Name = Coalesce(destCase.Name, template.Name);
                if (template.Strict == false)
                {
                    destCase.Strict = false; // Yield over alleviation from strictness.
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

        public CaseBase() => Initialize();
        public CaseBase(TMainPropCoalesced  value) : base(value) => Initialize();
        public CaseBase(TMainPropNully      value) : base(value) => Initialize();
        public CaseBase(TMainPropCoalesced  from , TMainPropCoalesced to) : base(from, to) => Initialize();
        public CaseBase(TMainPropCoalesced  from , TMainPropNully     to) : base(from, to) => Initialize();
        public CaseBase(TMainPropNully      from , TMainPropCoalesced to) : base(from, to) => Initialize();
        public CaseBase(TMainPropNully      from , TMainPropNully     to) : base(from, to) => Initialize();
        public CaseBase((TMainPropCoalesced from , TMainPropCoalesced to) values) : base(values) => Initialize();
        public CaseBase((TMainPropNully     from , TMainPropCoalesced to) values) : base(values) => Initialize();
        public CaseBase((TMainPropCoalesced from , TMainPropNully     to) values) : base(values) => Initialize();
        public CaseBase((TMainPropNully     from , TMainPropNully     to) values) : base(values) => Initialize();
        public CaseBase(TMainPropCoalesced  from , (TMainPropNully nully, TMainPropCoalesced coalesced)   to) : base(from, to) => Initialize();
        public CaseBase((TMainPropNully     nully, TMainPropCoalesced coalesced) from, TMainPropCoalesced to) : base(from, to) => Initialize();
        public CaseBase((TMainPropNully     nully, TMainPropCoalesced coalesced) from, (TMainPropNully nully, TMainPropCoalesced coalesced) to) : base(from, to) => Initialize();
        
        private void Initialize() => AutoCreateProps();
    }
}
