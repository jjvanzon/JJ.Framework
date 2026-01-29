namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Example()
    {
        AreEqual(" ",    Coalesce(" ", Null, "Hi!", spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch1()
    {
        NoNullRet(Empty, Coalesce(Null,        Null,        Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Null,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Null,        NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        Null,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Null,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Null,        Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Empty,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Empty,       NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Empty,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Empty,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Null,        Space,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Null,        Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch2()
    {
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch3()
    {
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  NullyFilled, Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        Null,        spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        Space,       spaceMatters));
        NoNullRet(Space, Coalesce(NullySpace,  Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch4()
    {
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch5()
    {
        NoNullRet(Empty, Coalesce(Empty,       Null,        Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Null,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Null,        NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       Null,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Null,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Null,        Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Text,        spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Null,        spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Empty,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       NullyFilled, spaceMatters));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Empty,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Empty,       Space,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch6()
    {
        NoNullRet(Space, Coalesce(Space,       Null,        Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Null,        Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       NullyFilled, Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Empty,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Space,       Text,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        Null,        spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        NullySpace,  spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        NullyFilled, spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        Empty,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        Space,       spaceMatters));
        NoNullRet(Space, Coalesce(Space,       Text,        Text,        spaceMatters));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInBack_Batch7()
    {
        NoNullRet(Text,  Coalesce(Text,        Null,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Null,        Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Space,       Text,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        Null,        spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyEmpty,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullySpace,  spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyFilled, spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        Empty,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        Space,       spaceMatters));
        NoNullRet(Text,  Coalesce(Text,        Text,        Text,        spaceMatters));
    }
}