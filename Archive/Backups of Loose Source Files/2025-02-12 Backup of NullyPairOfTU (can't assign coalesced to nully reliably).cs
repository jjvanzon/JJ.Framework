using JJ.Framework.Wishes.Common;
using JJ.Framework.Wishes.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using static JJ.Framework.Wishes.Testing.DebuggerDisplayFormatter;

namespace JJ.Framework.Wishes.Testing
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class NullyPair<TNully, TCoalesced> : IEquatable<NullyPair<TNully, TCoalesced>>
        //where TCoalesced : struct 
    {
        // Properties
        
        private TNully _nully;
        public TNully Nully { get => _nully; set => _nully = value; }
        
        private TCoalesced _coalesced;
        public TCoalesced Coalesced { get => _coalesced; set => _coalesced = value; }
        
        // Conversion Operators
        
        public static implicit operator TNully(NullyPair<TNully, TCoalesced>      pair)  => pair.Nully;
        public static implicit operator TCoalesced (NullyPair<TNully, TCoalesced> pair)  => pair.Coalesced;
        public static implicit operator NullyPair<TNully, TCoalesced>(TNully      value) => new NullyPair<TNully, TCoalesced> { Nully = value };
        public static implicit operator NullyPair<TNully, TCoalesced>(TCoalesced  value)
        {
            var nullyPair = new NullyPair<TNully, TCoalesced>();
            //TryAssignNully(value, ref nullyPair._nully);
            
            nullyPair.Nully = TryConvertToNully(value);
            nullyPair.Coalesced = value;
            return nullyPair;
        }
        
        public static implicit operator NullyPair<TNully, TCoalesced>((TNully nully, TCoalesced coalesced) x) => new NullyPair<TNully, TCoalesced> { Nully = x.nully, Coalesced = x.coalesced };
        
        private static TNully TryConvertToNully(TCoalesced coalesced)
        {
            object nully = Activator.CreateInstance<TNully>();
            ConvertTupleUnsafe(coalesced, nully);
            return (TNully)nully;
        }
        
        //private static void TryAssignNully(TCoalesced coalesced, ref TNully nully)
        //{
        //    if (coalesced is TNully baseObject) nully = baseObject;

        //    if (ConvertTupleUnsafe(coalesced, destObject);
            
        //    //return (TNully)Convert.ChangeType(coalesced, typeof(TNully));
        //    //return (TNully)(object)coalesced;
        //    //throw new InvalidCastException($"Cannot assign {typeof(TCoalesced)} to {typeof(TNully)}");
        //}
        
        
        //private static bool ConvertTupleUnsafe(TCoalesced sourceObject, ref TNully destObject)
        private static bool ConvertTupleUnsafe(TCoalesced sourceObject, object destObject)
        {
            //try
            {
                if (sourceObject == null) return false;
                if (destObject == null) return false;

                Type sourceType = sourceObject.GetType();
                Type destType = destObject.GetType();

                if (!sourceType.IsGenericType) return false;
                if (!destType.IsGenericType) return false;

                int i = 1;

                FieldInfo sourceField = sourceType.GetField("Item" + i);
                FieldInfo destField = destType.GetField("Item" + i);

                while (sourceField != null && destField != null)
                {
                    object sourceValue = sourceField.GetValue(sourceObject);
                    object destValue = Convert.ChangeType(sourceValue, destField.FieldType);
                    
                    destField.SetValue(destObject, destValue);
                    i++;

                    sourceField = sourceType.GetField("Item" + i);
                    destField = destType.GetField("Item" + i);
                }

                return true;
            }
            //catch
            //{
            //    return false;
            //}
        }


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
                       (EqualityComparer<TNully>.Default.Equals(castedA.Nully, castedB.Nully) ||
                        Nullable.Equals(castedA.Nully, castedB.Nully)); 
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
