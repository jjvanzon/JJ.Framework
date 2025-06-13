
namespace JJ.Framework.Testing.Core
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class CaseProp<T> : ICaseProp where T : struct
    {
        // Properties
        
        /// <inheritdoc cref="docs._from" />
        public NullyPair<T> From   { get; set; } = new NullyPair<T>();
        /// <inheritdoc cref="docs._from" />
        public NullyPair<T> Init   { get => From; set => From = value; }
        /// <inheritdoc cref="docs._from" />
        public NullyPair<T> Source { get => From; set => From = value; }
        
        /// <inheritdoc cref="docs._to" />
        public NullyPair<T> To    { get; set; } = new NullyPair<T>();
        /// <inheritdoc cref="docs._to" />
        public NullyPair<T> Dest  { get => To; set => To = value; }
        /// <inheritdoc cref="docs._to" />
        public NullyPair<T> Value { get => To; set => To = value; }
        /// <inheritdoc cref="docs._to" />
        public NullyPair<T> Val { get => To; set => To = value; }

        public T? Nully
        {
            get => To.Nully;
            set => From.Nully = To.Nully = value;
        }
        
        public T Coalesced
        {
            get => To.Coalesced;
            set => From.Coalesced = To.Coalesced = value;
        }
                    
        public bool Changed => From != To;

        // Conversion Operators

        public static implicit operator T (CaseProp<T> prop) => prop.To;
        public static implicit operator T?(CaseProp<T> prop) => prop.To;
        public static implicit operator CaseProp<T>(T  value) => new CaseProp<T>(value);
        public static implicit operator CaseProp<T>(T? value) => new CaseProp<T>(value);
        public static implicit operator CaseProp<T>((T  from, T  to) values) => new CaseProp<T>(values);
        public static implicit operator CaseProp<T>((T? from, T  to) values) => new CaseProp<T>(values);
        public static implicit operator CaseProp<T>((T  from, T? to) values) => new CaseProp<T>(values);
        public static implicit operator CaseProp<T>((T? from, T? to) values) => new CaseProp<T>(values);
        public static implicit operator CaseProp<T>((T from, (T? nully, T coalesced) to) x) => new CaseProp<T>(x.from, x.to);
        public static implicit operator CaseProp<T>(((T? nully, T coalesced) from, T to) x) =>  new CaseProp<T>(x.from, x.to);
        public static implicit operator CaseProp<T>(((T? nully, T coalesced) from, (T? nully, T coalesced) to) x) => new CaseProp<T>(x.from, x.to);
        
        // Constructors
        
        public CaseProp() { }
        public CaseProp( T  value      ) { From = value     ; To = value   ; }
        public CaseProp( T? value      ) { From = value     ; To = value   ; }
        public CaseProp( T  from, T  to) { From       = from; To =       to; }
        public CaseProp( T? from, T  to) { From.Nully = from; To       = to; }
        public CaseProp( T  from, T? to) { From       = from; To.Nully = to; }
        public CaseProp( T? from, T? to) { From.Nully = from; To.Nully = to; }
        public CaseProp((T  from, T  to) values) { From = values.from; To = values.to; }
        public CaseProp((T? from, T  to) values) { From = values.from; To = values.to; }
        public CaseProp((T  from, T? to) values) { From = values.from; To = values.to; }
        public CaseProp((T? from, T? to) values) { From = values.from; To = values.to; }
        public CaseProp( T  from, (T? nully, T coalesced) to) { From = from; To = to; }
        public CaseProp((T? nully, T coalesced) from, T to) { To = to; From = from; }
        public CaseProp((T? nully, T coalesced) from, (T? nully, T coalesced) to) { To = to; From = from; }

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
                if (from.IsNully() && to.IsNully()) return "";
                
                // All Equal
                if (from.Is(to)) return from;
                
                // No Change
                if (Equals(From.Nully, To.Nully) && Equals(From.Coalesced, To.Coalesced))
                {
                    return $"{Nully}?{Coalesced}";
                }
                
                // Mutation
                return $"{from} => {to}";
            }
        }

        // Templating
        
        private enum NullyLevel
        {
            Undefined,
            NullVal,
            Zero,
            Filled
        }
        
        private NullyLevel GetNullyLevel(T? value)
        {
            if (Equals(value, default(T?)))
            {
                return NullyLevel.NullVal;
            }
            if (Equals(value, default(T)))
            {
                return NullyLevel.Zero;
            }
            return NullyLevel.Filled;
        }
        
        private NullyLevel GetNullyLevel(T value)
        {
            if (Equals(value, default(T)))
            {
                return NullyLevel.Zero;
            }
            return NullyLevel.Filled;
        }
    
        public void CloneFrom(ICaseProp obj)
        {
            var template = (CaseProp<T>)obj;

            if (template == null) throw new NullException(() => template);

            // Favor specifically specified values over template values,
            // even though that gives 2 competing meanings to Nully values:
            // either not filled in in the test case or use default value in the API.

            // Coalesce now does a hard coalesce from null int to 0.
            //From.Nully = Coalesce(From.Nully, template.From.Nully);
            //To.Nully = Coalesce(To.Nully, template.To.Nully);
            //From.Coalesced = Coalesce(From.Coalesced, template.From.Coalesced);
            //To.Coalesced = Coalesce(To.Coalesced, template.To.Coalesced);

            // Replaced with explicit fallback instead.
            //if (!From.Nully    .FilledIn()) From.Nully     = template.From.Nully    ;
            //if (!To  .Nully    .FilledIn()) To  .Nully     = template.To  .Nully    ;
            if (!From.Coalesced.FilledIn()) From.Coalesced = template.From.Coalesced;
            if (!To  .Coalesced.FilledIn()) To  .Coalesced = template.To  .Coalesced;

            //  Patch-up for overwriting null with 0 even though both nully.
            {
                NullyLevel sourceLevel = GetNullyLevel(template.From.Nully);
                NullyLevel destLevel = GetNullyLevel(From.Nully);
                if (sourceLevel > destLevel)
                {
                    From.Nully = Coalesce(From.Nully, template.From.Nully);
                }
            }
            {
                NullyLevel sourceLevel = GetNullyLevel(template.To.Nully);
                NullyLevel destLevel = GetNullyLevel(To.Nully);
                if (sourceLevel > destLevel)
                {
                    To.Nully = Coalesce(To.Nully, template.To.Nully);
                }
            }
        }
    }
}
