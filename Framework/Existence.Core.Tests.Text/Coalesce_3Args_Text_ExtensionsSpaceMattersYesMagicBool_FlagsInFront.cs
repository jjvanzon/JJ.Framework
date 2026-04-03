namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Example()
    {
        AreEqual(" ",   " ".Coalesce(spaceMatters, Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Null,        Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyEmpty,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullySpace,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, NullyFilled, Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Empty,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Space,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters, Text,        Text       ));
    }
}