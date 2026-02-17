namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;
    
    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Example()
    {
        AreEqual("Hi!",  Coalesce(" ", Null, "Hi!", spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch1()
    {
        NoNullRet(Empty, Coalesce(Null,        Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Null,        Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Null,        Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Null,        Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch2()
    {
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch3()
    {
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch4()
    {
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch5()
    {
        NoNullRet(Empty, Coalesce(Empty,       Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Empty,       Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Empty,       Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch6()
    {
        NoNullRet(Empty, Coalesce(Space,       Null,        Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Null,        Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Null,        Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Empty,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Empty,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Empty,       Text,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Space,       Null,        spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Empty, Coalesce(Space,       Space,       Empty,       spaceMatters: false));
        NoNullRet(Space, Coalesce(Space,       Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Space,       Text,        Text,        spaceMatters: false));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInBack_Batch7()
    {
        NoNullRet(Text,  Coalesce(Text,        Null,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Null,        Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Space,       Text,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        Null,        spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyEmpty,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullySpace,  spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyFilled, spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        Empty,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        Space,       spaceMatters: false));
        NoNullRet(Text,  Coalesce(Text,        Text,        Text,        spaceMatters: false));
    }
}