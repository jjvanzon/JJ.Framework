namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Example()
    {
        AreEqual(" ",    Coalesce(spaceMatters, " ", Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Null,        Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Null,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Null,        Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, NullyEmpty,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullyEmpty,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyEmpty,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch3()
    {
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Null,        Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullySpace,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  NullyFilled, Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Space,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, NullySpace,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, NullyFilled, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters, Empty,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Empty,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Empty,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch6()
    {
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Null,        Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullySpace,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       NullyFilled, Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Space,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters, Space,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesMagicBool_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters, Text,        Text,        Text       ));
    }
}