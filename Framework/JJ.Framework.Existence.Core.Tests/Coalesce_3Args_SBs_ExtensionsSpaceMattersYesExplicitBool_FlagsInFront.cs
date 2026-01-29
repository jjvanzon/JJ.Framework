namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront
{
    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet(                 NullSB       .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters: true, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(                 NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(                 NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters: true, FilledSB,      FilledSB     ));
    }
}