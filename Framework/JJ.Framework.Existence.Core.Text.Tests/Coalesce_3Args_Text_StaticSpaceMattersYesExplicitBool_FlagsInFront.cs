namespace JJ.Framework.Existence.Core.Text.Tests;

[TestClass]
public class Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Example()
    {
        AreEqual(" ",    Coalesce(spaceMatters: true, " ", Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch1()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Null,        Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Null,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Null,        Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch2()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, NullyEmpty,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullyEmpty,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyEmpty,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch3()
    {
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Null,        Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullySpace,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  NullyFilled, Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Space,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, NullySpace,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch4()
    {
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, NullyFilled, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch5()
    {
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(spaceMatters: true, Empty,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Empty,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Empty,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch6()
    {
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Null,        Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyEmpty,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullySpace,  Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       NullyFilled, Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Empty,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Space,       Text       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        Null       ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        NullyEmpty ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        NullySpace ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        NullyFilled));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        Empty      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        Space      ));
        NoNullRet(Space, Coalesce(spaceMatters: true, Space,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_StaticSpaceMattersYesExplicitBool_FlagsInFront_Batch7()
    {
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Null,        Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Empty,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(spaceMatters: true, Text,        Text,        Text       ));
    }
}