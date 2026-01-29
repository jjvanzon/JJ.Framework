namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront
{
    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet(                 Coalesce(spaceMatters, NullSB,        NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullSB,        NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, NullSB,        EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullSB,        EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullSB,        EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullSB,        SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullSB,        FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet(                 Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullyEmptySB,  SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyEmptySB,  FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, NullySpaceSB,  FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, NullyFilledSB, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet(                 Coalesce(spaceMatters, EmptySB,       NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, EmptySB,       NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters, EmptySB,       EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters, EmptySB,       EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters, EmptySB,       EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, EmptySB,       SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, EmptySB,       FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters, SpaceSB,       FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters, FilledSB,      FilledSB,      FilledSB     ));
    }
}