// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
#pragma warning disable CS0660, CS0661 // Equals without GetHashCode
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()

namespace JJ.Framework.Testing.Core
{
    #pragma warning disable CS0611
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class NullyPair<T> : IEquatable<NullyPair<T>> where T : struct 
    {
        // Properties
        public T? Nully     { get; set; }
        public T  Coalesced { get; set; }
        
        // Conversion Operators
        
        public static implicit operator T?(NullyPair<T> pair)  => pair?.Nully ?? default(T?);
        public static implicit operator T (NullyPair<T> pair)  => pair?.Coalesced ?? default(T);
        public static implicit operator NullyPair<T>(T? value) => new() { Nully = value };
        public static implicit operator NullyPair<T>(T  value) => new() { Nully = value, Coalesced = value };
        public static implicit operator NullyPair<T>((T? nully, T coalesced) x) => new() { Nully = x.nully, Coalesced = x.coalesced };
        
        // Equals
        
        public static bool operator ==(NullyPair<T>? a, NullyPair<T>? b) => Equalish(a, b);
        public static bool operator !=(NullyPair<T>? a, NullyPair<T>? b) => !Equalish(a, b);
        public override bool Equals(object? other) => Equalish(other, this);
        public bool Equals(NullyPair<T>? other) => Equalish(other, this);
        
        private static bool Equalish(object? inputA, object? inputB)
        {
            if (inputA == null && inputB == null) return true;
            if (ReferenceEquals(inputA, inputB)) return true;

            // Treat null and zeroed as equal.
            var autoA = inputA ?? new NullyPair<T>();
            var autoB = inputB ?? new NullyPair<T>();

            if (autoA is NullyPair<T> castedA && 
                autoB is NullyPair<T> castedB)
            {
                return EqualityComparer<T>.Default.Equals(castedA.Coalesced, castedB.Coalesced) && 
                       Nullable.Equals(castedA.Nully, castedB.Nully); 
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
                if (!Has(Nully) && !Has(Coalesced)) return "";
                if (Equals(Nully, Coalesced)) return $"{Nully}";
                if (Has(Nully) && !Has(Coalesced)) return $"{Nully}";
                return $"{Nully}?{Coalesced}";
            }
        }
    }
}