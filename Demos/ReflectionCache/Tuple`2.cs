namespace JJ.Demos.ReflectionCache
{
    /// <summary>
    /// A subsitute for Tuple&lt;T1, T2&gt; for use in .NET versions lower than 4.0.
    /// </summary>
    internal struct Tuple<T1, T2>
    {
        public T1 Item1 { get; }
        public T2 Item2 { get; }

        public Tuple(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
}