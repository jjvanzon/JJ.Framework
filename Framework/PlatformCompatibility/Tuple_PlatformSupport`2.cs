namespace JJ.Framework.PlatformCompatibility
{
    // TODO: Is the original Tuple type faster as a dictionary key?

    /// <summary>
    /// Net4 substitute
    /// </summary>
    public struct Tuple_PlatformSupport<T1, T2>
    {
        private T1 _item1;
        private T2 _item2;

        public T1 Item1 { get { return _item1; }}
        public T2 Item2 { get { return _item2; }}

        /// <summary>
        /// Net4 substitute
        /// </summary>
        public Tuple_PlatformSupport(T1 item1, T2 item2)
        {
            _item1 = item1;
            _item2 = item2;
        }
    }
}

