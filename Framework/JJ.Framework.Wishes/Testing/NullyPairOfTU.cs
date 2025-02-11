using JJ.Framework.Wishes.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using static JJ.Framework.Wishes.Testing.DebuggerDisplayFormatter;

namespace JJ.Framework.Wishes.Testing
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class NullyPair<TNully, TCoalesced> : IEquatable<NullyPair<TNully, TCoalesced>>
        //where TCoalesced : struct 
    {
        // Properties
        
        public TNully     Nully     { get; set; }
        public TCoalesced Coalesced { get; set; }
        
        // Conversion Operators
        
        public static implicit operator TNully(NullyPair<TNully, TCoalesced> pair)  => pair.Nully;
        public static implicit operator TCoalesced (NullyPair<TNully, TCoalesced> pair)  => pair.Coalesced;
        public static implicit operator NullyPair<TNully, TCoalesced>(TNully value) => new NullyPair<TNully, TCoalesced> { Nully = value };
        public static implicit operator NullyPair<TNully, TCoalesced>(TCoalesced  value) => new NullyPair<TNully, TCoalesced> { /*Nully = value,*/ Coalesced = value };
        public static implicit operator NullyPair<TNully, TCoalesced>((TNully nully, TCoalesced coalesced) x) => new NullyPair<TNully, TCoalesced> { Nully = x.nully, Coalesced = x.coalesced };
        
        // Equals
        
        public static bool operator ==(NullyPair<TNully, TCoalesced> a, NullyPair<TNully, TCoalesced> b) => Equalish(a, b);
        public static bool operator !=(NullyPair<TNully, TCoalesced> a, NullyPair<TNully, TCoalesced> b) => !Equalish(a, b);
        public override bool Equals(object other) => Equalish(other, this);
        public bool Equals(NullyPair<TNully, TCoalesced> other) => Equalish(other, this);
        
        private static bool Equalish(object inputA, object inputB)
        {
            if (inputA == null && inputB == null) return true;
            if (ReferenceEquals(inputA, inputB)) return true;

            // Treat null and zeroed as equal.
            var autoA = inputA ?? new NullyPair<TNully, TCoalesced>();
            var autoB = inputB ?? new NullyPair<TNully, TCoalesced>();

            if (autoA is NullyPair<TNully, TCoalesced> castedA && 
                autoB is NullyPair<TNully, TCoalesced> castedB)
            {
                return EqualityComparer<TCoalesced>.Default.Equals(castedA.Coalesced, castedB.Coalesced) && 
                       EqualityComparer<TNully>.Default.Equals(castedA.Nully, castedB.Nully);
                       //Nullable.Equals(castedA.Nully, castedB.Nully); 
            }
            
            return false;
        }
        
        // Descriptions
        
        string DebuggerDisplay => DebuggerDisplay(this);
        
        public override string ToString() => Descriptor;
        
        public string Descriptor
        {
            get
            {
                if (!FilledInWishes.Has(Nully) && !FilledInWishes.Has(Coalesced)) return "";
                if (Equals(Nully, Coalesced)) return $"{Nully}";
                if (FilledInWishes.Has(Nully) && !FilledInWishes.Has(Coalesced)) return $"{Nully}";
                return $"({Nully},{Coalesced})";
            }
        }
    }
}
