namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack
{
    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch1()
    {
        NoNullRet(                 Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        NullSB,        NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullSB,        FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        NullyEmptySB,  NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(NullSB,        EmptySB,       NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullSB,        EmptySB,       NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullSB,        EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullSB,        EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullSB,        SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullSB,        FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch2()
    {
        NoNullRet(                 Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  NullSB,        NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullSB,        FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  NullyEmptySB,  NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(NullyEmptySB,  EmptySB,       NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(NullyEmptySB,  EmptySB,       NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(NullyEmptySB,  EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullyEmptySB,  SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyEmptySB,  FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch3()
    {
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullSB,        FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(NullySpaceSB,  FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch4()
    {
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullSB,        FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(NullyFilledSB, FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch5()
    {
        NoNullRet(                 Coalesce(EmptySB,       NullSB,        NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       NullSB,        NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullSB,        FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(EmptySB,       NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       NullyEmptySB,  NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(                 Coalesce(EmptySB,       EmptySB,       NullSB,        spaceMatters));
        NoNullRet($"{EmptySB}", $"{Coalesce(EmptySB,       EmptySB,       NullSB,        spaceMatters)}");
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   EmptySB,      Coalesce(EmptySB,       EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(EmptySB,       SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(EmptySB,       FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch6()
    {
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullSB,        FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   SpaceSB,      Coalesce(SpaceSB,       FilledSB,      FilledSB,      spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch7()
    {
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullSB,        FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyEmptySB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullySpaceSB,  FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      NullyFilledSB, FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      EmptySB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      SpaceSB,       FilledSB,      spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullSB,        spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullyEmptySB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullySpaceSB,  spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      NullyFilledSB, spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      EmptySB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      SpaceSB,       spaceMatters));
        NoNullRet(   FilledSB,     Coalesce(FilledSB,      FilledSB,      FilledSB,      spaceMatters));
    }
}