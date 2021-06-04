namespace JJ.Framework.Reflection.Tests.AccessorTests
{
    internal class Class_NamedIndexer_Accessor
    {
        private readonly Accessor _accessor;

        public Class_NamedIndexer_Accessor(Class_NamedIndexer obj) => _accessor = new Accessor(obj);

        public int this[int index]
        {
            get => (int)_accessor.GetIndexerValue(index);
            set => _accessor.SetIndexerValue(index, value);
        }
    }
}