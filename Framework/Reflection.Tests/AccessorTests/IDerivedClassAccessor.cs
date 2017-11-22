namespace JJ.Framework.Reflection.Tests.AccessorTests
{
	public interface IDerivedClassAccessor
	{
		int MemberToHide { get; set; }
		int Base_MemberToHide { get; set; }
	}
}
