namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Example()
    {
        AreEqual("Hi!", " ".Coalesce(null, "Hi!", spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch1()
    {
        NoNullRet(Empty, Null       .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Null       .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Null       .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Null       .Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch2()
    {
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, NullyEmpty .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch3()
    {
        NoNullRet(Empty, NullySpace .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, NullySpace .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch4()
    {
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch5()
    {
        NoNullRet(Empty, Empty      .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Empty      .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Empty      .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch6()
    {
        NoNullRet(Empty, Space      .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Space      .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Space      .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Space      .Coalesce(Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoExplicit_Batch7()
    {
        NoNullRet(Text,  Text       .Coalesce(Null,        Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Null,        Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Text       .Coalesce(Text,        Text,        spaceMatters: false));
    }
}