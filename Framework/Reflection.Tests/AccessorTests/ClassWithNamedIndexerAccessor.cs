namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class ClassWithNamedIndexerAccessor
    {
        private readonly Accessor _accessor;

        public ClassWithNamedIndexerAccessor(ClassWithNamedIndexer obj)
        {
            _accessor = new Accessor(obj);
        }

        public int this[int index]
        {
            get { return (int)_accessor.GetIndexerValue(index); }
            set { _accessor.SetIndexerValue(index, value); }
        }
    }
}
