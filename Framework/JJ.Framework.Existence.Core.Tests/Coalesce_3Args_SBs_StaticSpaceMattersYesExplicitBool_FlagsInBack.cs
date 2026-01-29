namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack
{
    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch1()
    {
        NoNullRet(                 Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(NullSB,        EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        EmptySB,       NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch2()
    {
        NoNullRet(                 Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(NullyEmptySB,  EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  EmptySB,       NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch3()
    {
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch4()
    {
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch5()
    {
        NoNullRet(                 Coalesce(EmptySB,       NullSB,        NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       NullSB,        NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(EmptySB,       NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       NullyEmptySB,  NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(                 Coalesce(EmptySB,       EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       EmptySB,       NullSB,        spaceMatters: true)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch6()
    {
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      FilledSB,      spaceMatters: true));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInBack_Batch7()
    {
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       FilledSB,      spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullSB,        spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullyEmptySB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullySpaceSB,  spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullyFilledSB, spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      EmptySB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      SpaceSB,       spaceMatters: true));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      FilledSB,      spaceMatters: true));
    }
}