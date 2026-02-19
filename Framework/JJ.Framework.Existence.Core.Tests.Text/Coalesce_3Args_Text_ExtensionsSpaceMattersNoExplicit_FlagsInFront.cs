namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Example()
    {
        AreEqual("Hi!", " ".Coalesce(spaceMatters: false, Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  Space      .Coalesce(spaceMatters: false, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Null,        Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyEmpty,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullySpace,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, NullyFilled, Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Empty,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Space,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(spaceMatters: false, Text,        Text       ));
    }
}