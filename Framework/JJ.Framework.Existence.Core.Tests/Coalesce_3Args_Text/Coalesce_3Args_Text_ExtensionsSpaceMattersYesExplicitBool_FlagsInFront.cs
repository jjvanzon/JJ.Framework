namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Example()
    {
        AreEqual(" ",   " ".Coalesce(spaceMatters: true, Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: true, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Null,        Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyEmpty,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullySpace,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, NullyFilled, Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Empty,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Space,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: true, Text,        Text       ));
    }
}