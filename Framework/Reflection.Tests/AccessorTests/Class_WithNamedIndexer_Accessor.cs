namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class Class_WithNamedIndexer_Accessor
    {
        private readonly Accessor _accessor;

        public Class_WithNamedIndexer_Accessor(Class_WithNamedIndexer obj) => _accessor = new Accessor(obj);

        public int this[int index]
        {
            get => (int)_accessor.GetIndexerValue(index);
            set => _accessor.SetIndexerValue(index, value);
        }
    }
}