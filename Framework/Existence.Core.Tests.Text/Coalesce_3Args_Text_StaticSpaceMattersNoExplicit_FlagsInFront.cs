namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;
    
    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Example()
    {
        AreEqual("Hi!",  Coalesce(spaceMatters: false, " ", Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Empty,       Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Space,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Null,        Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Null,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Null,        Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Empty,       Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Space,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullyEmpty,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullyEmpty,  Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyEmpty,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch3()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Empty,       Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Space,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, NullySpace,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, NullySpace,  Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullySpace,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, NullyFilled, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Empty,       Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Space,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Empty,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Empty,       Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Empty,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch6()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Empty,       Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Space,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: false, Space,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: false, Space,       Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Space,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersNoExplicit_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: false, Text,        Text,        Text       ));
    }
}