namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    internal class DerivedClassAccessorLegacy_UsingExpressions : DerivedClassAccessorLegacyBase
    {
        public DerivedClassAccessorLegacy_UsingExpressions(DerivedClassLegacy obj)
            : base(obj) { }

        public override int MemberToHide
        {
            get => _accessor.GetPropertyValue(() => MemberToHide);
            set => _accessor.SetPropertyValue(() => MemberToHide, value);
        }

        public override int Base_MemberToHide
        {
            get => _baseAccessor.GetPropertyValue(() => MemberToHide);
            set => _baseAccessor.SetPropertyValue(() => MemberToHide, value);
        }
    }
}