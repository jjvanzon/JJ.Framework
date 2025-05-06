namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal class ClassLegacy_NamedIndexer_Accessor
    {
        private readonly AccessorLegacy _accessor;

        public ClassLegacy_NamedIndexer_Accessor(ClassLegacy_NamedIndexer obj) => _accessor = new AccessorLegacy(obj);

        public int this[int index]
        {
            get => (int)_accessor.GetIndexerValue(index);
            set => _accessor.SetIndexerValue(index, value);
        }
    }
}