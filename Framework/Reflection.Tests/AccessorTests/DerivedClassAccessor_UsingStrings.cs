namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	internal class DerivedClassAccessor_UsingStrings : DerivedClassAccessorBase
	{
		public DerivedClassAccessor_UsingStrings(DerivedClass obj)
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
