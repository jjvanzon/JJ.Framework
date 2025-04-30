namespace JJ.Framework.Reflection.Core.Tests.AccessorLegacyTests
{
    public interface IDerivedClassAccessorLegacy
    {
        int MemberToHide { get; set; }
        int Base_MemberToHide { get; set; }
    }
}
