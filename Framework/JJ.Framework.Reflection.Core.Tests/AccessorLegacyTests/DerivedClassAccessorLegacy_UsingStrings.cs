namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal class DerivedClassAccessorLegacy_UsingStrings : DerivedClassAccessorLegacyBase
    {
        public DerivedClassAccessorLegacy_UsingStrings(DerivedClassLegacy obj)
            : base(obj)
        { }

        public override int MemberToHide
        {
            get => (int)_accessor.GetPropertyValue("MemberToHide");
            set => _accessor.SetPropertyValue("MemberToHide", value);
        }

        public override int Base_MemberToHide
        {
            get => (int)_baseAccessor.GetPropertyValue("MemberToHide");
            set => _baseAccessor.SetPropertyValue("MemberToHide", value);
        }
    }
}
