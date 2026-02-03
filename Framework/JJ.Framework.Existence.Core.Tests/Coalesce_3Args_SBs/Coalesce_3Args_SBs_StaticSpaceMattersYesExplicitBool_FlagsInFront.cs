namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront
{
    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet(                 Coalesce(spaceMatters: true, NullSB,        NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullSB,        NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullSB,        EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullSB,        SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullSB,        FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet(                 Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, NullyFilledSB, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet(                 Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullSB,        FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB, FilledSB     ));
        NoNullRet(                 Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      Coalesce(spaceMatters: true, EmptySB,       EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, EmptySB,       SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, EmptySB,       FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      Coalesce(spaceMatters: true, SpaceSB,       FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     Coalesce(spaceMatters: true, FilledSB,      FilledSB,      FilledSB     ));
    }
}