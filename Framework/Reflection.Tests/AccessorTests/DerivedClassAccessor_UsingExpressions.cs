namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	internal class DerivedClassAccessor_UsingExpressions : DerivedClassAccessorBase
	{
		public DerivedClassAccessor_UsingExpressions(DerivedClass obj)
			: base(obj)
		{ }

		public override int MemberToHide
		{
			get { return _accessor.GetPropertyValue(() => MemberToHide); }
			set { _accessor.SetPropertyValue(() => MemberToHide, value); }
		}

		public override int Base_MemberToHide
		{
			get { return _baseAccessor.GetPropertyValue(() => MemberToHide); }
			set { _baseAccessor.SetPropertyValue(() => MemberToHide, value); }
		}
	}
}
