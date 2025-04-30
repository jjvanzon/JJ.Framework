namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal abstract class DerivedClassAccessorLegacyBase : IDerivedClassAccessorLegacy
    {
        protected readonly AccessorLegacy _accessor;
        protected readonly AccessorLegacy _baseAccessor;

        public DerivedClassAccessorLegacyBase(DerivedClassLegacy obj)
        {
            _accessor = new AccessorLegacy(obj);
            _baseAccessor = new AccessorLegacy(obj, typeof(ClassLegacy));
        }

        public abstract int MemberToHide { get; set; }
        public abstract int Base_MemberToHide { get; set; }
    }
}
