namespace JJ.Framework.Existence.Core.SBs.Tests;

[TestClass]
public class Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront: TestBase
{
    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet(                 NullSB       .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(                 NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(                 NullSB       .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullSB       .Coalesce(spaceMatters, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      NullSB       .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullSB       .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullSB       .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(                 NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      NullyEmptySB .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullyEmptySB .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullyEmptySB .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      NullySpaceSB .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     NullyFilledSB.Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters, NullSB,        NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(                 EmptySB      .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet($"{EmptySB}", $"{EmptySB      .Coalesce(spaceMatters, EmptySB,       NullSB       )}");
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   EmptySB,      EmptySB      .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      EmptySB      .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     EmptySB      .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   SpaceSB,      SpaceSB      .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }

    [TestMethod]
    public void Coalesce_3Args_SBs_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullSB,        FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyEmptySB,  FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullySpaceSB,  FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, NullyFilledSB, FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, EmptySB,       FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, SpaceSB,       FilledSB     ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      NullSB       ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      NullyEmptySB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      NullySpaceSB ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      NullyFilledSB));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      EmptySB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      SpaceSB      ));
        NoNullRet(   FilledSB,     FilledSB     .Coalesce(spaceMatters, FilledSB,      FilledSB     ));
    }
}