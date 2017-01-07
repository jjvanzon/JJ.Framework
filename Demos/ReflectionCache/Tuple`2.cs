namespace JJ.Demos.ReflectionCache
{
    /// <summary>
    /// A subsitute for Tuple&lt;T1, T2&gt; for use in .NET versions lower than 4.0.
    /// </summary>
    internal struct Tuple<T1, T2>
    {
        private T1 _item1;
        private T2 _item2;

        public T1 Item1 { get { return _item1; } }
        public T2 Item2 { get { return _item2; } }

        public Tuple(T1 item1, T2 item2)
        {
            _item1 = item1;
            _item2 = item2;
        }
    }
}
