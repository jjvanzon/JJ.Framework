using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using JJ.Framework.Reflection;
using JJ.Framework.Wishes.Common;
using static JJ.Framework.Wishes.Common.FilledInWishes;
using static JJ.Framework.Wishes.Testing.DebuggerDisplayFormatter;

namespace JJ.Framework.Wishes.Testing
{

    [DebuggerDisplay("{DebuggerDisplay}")]
    public class CaseProp<TNully, TCoalesced> : ICaseProp //where TCoalesced : struct
    {
        // Properties
        
        /// <inheritdoc cref="docs._from" />
        public NullyPair<TNully, TCoalesced> From   { get; set; } = new NullyPair<TNully, TCoalesced>();
        /// <inheritdoc cref="docs._from" />
        public NullyPair<TNully, TCoalesced> Init   { get => From; set => From = value; }
        /// <inheritdoc cref="docs._from" />
        public NullyPair<TNully, TCoalesced> Source { get => From; set => From = value; }
        
        /// <inheritdoc cref="docs._to" />
        public NullyPair<TNully, TCoalesced> To     { get; set; } = new NullyPair<TNully, TCoalesced>();
        /// <inheritdoc cref="docs._to" />
        public NullyPair<TNully, TCoalesced> Dest   { get => To; set => To = value; }
        /// <inheritdoc cref="docs._to" />
        public NullyPair<TNully, TCoalesced> Value  { get => To; set => To = value; }
        /// <inheritdoc cref="docs._to" />
        public NullyPair<TNully, TCoalesced> Val    { get => To; set => To = value; }

        public TNully Nully
        {
            get => To.Nully;
            set => From.Nully = To.Nully = value;
        }
        
        public TCoalesced Coalesced
        {
            get => To.Coalesced;
            set => From.Coalesced = To.Coalesced = value;
        }
                    
        public bool Changed => From != To;

        // Conversion Operators

        public static implicit operator TCoalesced (CaseProp<TNully, TCoalesced> prop) => prop.To;
        public static implicit operator TNully(CaseProp<TNully, TCoalesced> prop) => prop.To;
        public static implicit operator CaseProp<TNully, TCoalesced>(TCoalesced  value) => new CaseProp<TNully, TCoalesced>(value);
        public static implicit operator CaseProp<TNully, TCoalesced>(TNully value) => new CaseProp<TNully, TCoalesced>(value);
        public static implicit operator CaseProp<TNully, TCoalesced>((TCoalesced  from, TCoalesced  to) values) => new CaseProp<TNully, TCoalesced>(values);
        public static implicit operator CaseProp<TNully, TCoalesced>((TNully from, TCoalesced  to) values) => new CaseProp<TNully, TCoalesced>(values);
        public static implicit operator CaseProp<TNully, TCoalesced>((TCoalesced  from, TNully to) values) => new CaseProp<TNully, TCoalesced>(values);
        public static implicit operator CaseProp<TNully, TCoalesced>((TNully from, TNully to) values) => new CaseProp<TNully, TCoalesced>(values);
        public static implicit operator CaseProp<TNully, TCoalesced>((TCoalesced from, (TNully nully, TCoalesced coalesced) to) x) => new CaseProp<TNully, TCoalesced>(x.from, x.to);
        public static implicit operator CaseProp<TNully, TCoalesced>(((TNully nully, TCoalesced coalesced) from, TCoalesced to) x) =>  new CaseProp<TNully, TCoalesced>(x.from, x.to);
        public static implicit operator CaseProp<TNully, TCoalesced>(((TNully nully, TCoalesced coalesced) from, (TNully nully, TCoalesced coalesced) to) x) => new CaseProp<TNully, TCoalesced>(x.from, x.to);
        
        // Constructors
        
        public CaseProp() { }
        public CaseProp( TCoalesced  value) { From = value; To = value; }
        public CaseProp( TNully value     ) { From = value; To = value; }
        public CaseProp( TCoalesced from,  TCoalesced to) { From       = from; To       = to; }
        public CaseProp( TNully     from,  TCoalesced to) { From.Nully = from; To       = to; }
        public CaseProp( TCoalesced from,  TNully     to) { From       = from; To.Nully = to; }
        public CaseProp( TNully     from,  TNully     to) { From.Nully = from; To.Nully = to; }
        public CaseProp((TCoalesced from,  TCoalesced to) values) { From = values.from; To = values.to; }
        public CaseProp((TNully     from,  TCoalesced to) values) { From = values.from; To = values.to; }
        public CaseProp((TCoalesced from,  TNully     to) values) { From = values.from; To = values.to; }
        public CaseProp((TNully     from,  TNully     to) values) { From = values.from; To = values.to; }
        public CaseProp( TCoalesced from, (TNully nully, TCoalesced coalesced) to) { From = from; To   = to;   }
        public CaseProp((TNully nully, TCoalesced coalesced) from, TCoalesced  to) { To   = to  ; From = from; }
        public CaseProp((TNully nully, TCoalesced coalesced) from, (TNully nully, TCoalesced coalesced) to) { To = to; From = from; }

        // Descriptions
        
        string DebuggerDisplay => DebuggerDisplay(this);
        public override string ToString() => Descriptor;

        public string Descriptor
        {
            get
            {
                string from = $"{From}";
                string to = $"{To}";
                
                // None Filled In
                if (from.IsNully() && to.IsNully()) return default;
                
                // All Equal
                if (from.Is(to)) return from;
                
                // No Change
                if (Equals(From.Nully, To.Nully) && Equals(From.Coalesced, To.Coalesced))
                {
                    return $"({Nully},{Coalesced})";
                }
                
                // Mutation
                return $"{from} => {to}";
            }
        }

        // Templating
    
        public void CloneFrom(ICaseProp obj)
        {
            var template = (CaseProp<TNully, TCoalesced>)obj;

            if (template == null) throw new NullException(() => template);
            
            // Favor specifically specified values over template values,
            // even though that gives 2 competing meanings to Nully values:
            // either not filled in in the test case or use default value in the API.
            
            From.Nully     = Coalesce(From.Nully,     template.From.Nully);
            From.Coalesced = Coalesce(From.Coalesced, template.From.Coalesced);
            To.Nully       = Coalesce(To.Nully,       template.To.Nully);
            To.Coalesced   = Coalesce(To.Coalesced,   template.To.Coalesced);
        }
    }
}
