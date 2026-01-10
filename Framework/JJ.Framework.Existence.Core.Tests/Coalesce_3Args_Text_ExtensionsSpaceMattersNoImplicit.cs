namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Example()
    {
        AreEqual("Hi!", " ".Coalesce(null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch1()
    {
        NoNullRet(Empty, Null       .Coalesce(Null,        Null       ));
        NoNullRet(Empty, Null       .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(Null,        NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(Null,        Empty      ));
        NoNullRet(Space, Null       .Coalesce(Null,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(Null,        Text       ));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  Null       ));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Space, Null       .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  Null       .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  Null       .Coalesce(NullyFilled, Text       ));
        NoNullRet(Empty, Null       .Coalesce(Empty,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(Empty,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(Empty,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(Empty,       Text       ));
        NoNullRet(Empty, Null       .Coalesce(Space,       Null       ));
        NoNullRet(Empty, Null       .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Space, Null       .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(Space,       NullyFilled));
        NoNullRet(Empty, Null       .Coalesce(Space,       Empty      ));
        NoNullRet(Space, Null       .Coalesce(Space,       Space      ));
        NoNullRet(Text,  Null       .Coalesce(Space,       Text       ));
        NoNullRet(Text,  Null       .Coalesce(Text,        Null       ));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  Null       .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  Null       .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  Null       .Coalesce(Text,        Space      ));
        NoNullRet(Text,  Null       .Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch2()
    {
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Null,        NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(Null,        Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(Null,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Null,        Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(NullyFilled, Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Empty,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(Empty,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Empty,       Text       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       Null       ));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Space, NullyEmpty .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Space,       NullyFilled));
        NoNullRet(Empty, NullyEmpty .Coalesce(Space,       Empty      ));
        NoNullRet(Space, NullyEmpty .Coalesce(Space,       Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Space,       Text       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Null       ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Space      ));
        NoNullRet(Text,  NullyEmpty .Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch3()
    {
        NoNullRet(Empty, NullySpace .Coalesce(Null,        Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(Null,        NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(Null,        Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(Null,        Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(Null,        Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(NullyFilled, Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(Empty,       NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(Empty,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(Empty,       Text       ));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       Null       ));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Space, NullySpace .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(Space,       NullyFilled));
        NoNullRet(Empty, NullySpace .Coalesce(Space,       Empty      ));
        NoNullRet(Space, NullySpace .Coalesce(Space,       Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(Space,       Text       ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Null       ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Space      ));
        NoNullRet(Text,  NullySpace .Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch4()
    {
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Null,        Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(NullyFilled, Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Empty,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Space,       Text       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Null       ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Empty      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Space      ));
        NoNullRet(Text,  NullyFilled.Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch5()
    {
        NoNullRet(Empty, Empty      .Coalesce(Null,        Null       ));
        NoNullRet(Empty, Empty      .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(Null,        NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(Null,        Empty      ));
        NoNullRet(Space, Empty      .Coalesce(Null,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(Null,        Text       ));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  Null       ));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Space, Empty      .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  Empty      .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  Empty      .Coalesce(NullyFilled, Text       ));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(Empty,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(Empty,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(Empty,       Text       ));
        NoNullRet(Empty, Empty      .Coalesce(Space,       Null       ));
        NoNullRet(Empty, Empty      .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Space, Empty      .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(Space,       NullyFilled));
        NoNullRet(Empty, Empty      .Coalesce(Space,       Empty      ));
        NoNullRet(Space, Empty      .Coalesce(Space,       Space      ));
        NoNullRet(Text,  Empty      .Coalesce(Space,       Text       ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Null       ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Space      ));
        NoNullRet(Text,  Empty      .Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch6()
    {
        NoNullRet(Empty, Space      .Coalesce(Null,        Null       ));
        NoNullRet(Empty, Space      .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(Null,        NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(Null,        Empty      ));
        NoNullRet(Space, Space      .Coalesce(Null,        Space      ));
        NoNullRet(Text,  Space      .Coalesce(Null,        Text       ));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  Space      .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  Null       ));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Space, Space      .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  Space      .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  Space      .Coalesce(NullyFilled, Text       ));
        NoNullRet(Empty, Space      .Coalesce(Empty,       Null       ));
        NoNullRet(Empty, Space      .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(Empty,       NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(Empty,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  Space      .Coalesce(Empty,       Text       ));
        NoNullRet(Empty, Space      .Coalesce(Space,       Null       ));
        NoNullRet(Empty, Space      .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Space, Space      .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(Space,       NullyFilled));
        NoNullRet(Empty, Space      .Coalesce(Space,       Empty      ));
        NoNullRet(Space, Space      .Coalesce(Space,       Space      ));
        NoNullRet(Text,  Space      .Coalesce(Space,       Text       ));
        NoNullRet(Text,  Space      .Coalesce(Text,        Null       ));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  Space      .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  Space      .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  Space      .Coalesce(Text,        Space      ));
        NoNullRet(Text,  Space      .Coalesce(Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_ExtensionsSpaceMattersNoImplicit_Batch7()
    {
        NoNullRet(Text,  Text       .Coalesce(Null,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(Null,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(Null,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(Null,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(Null,        Text       ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(NullyEmpty,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Null       ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Empty      ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Space      ));
        NoNullRet(Text,  Text       .Coalesce(NullySpace,  Text       ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Null       ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Empty      ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Space      ));
        NoNullRet(Text,  Text       .Coalesce(NullyFilled, Text       ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(Empty,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(Space,       Null       ));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(Space,       NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(Space,       Empty      ));
        NoNullRet(Text,  Text       .Coalesce(Space,       Space      ));
        NoNullRet(Text,  Text       .Coalesce(Space,       Text       ));
        NoNullRet(Text,  Text       .Coalesce(Text,        Null       ));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullyEmpty ));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullySpace ));
        NoNullRet(Text,  Text       .Coalesce(Text,        NullyFilled));
        NoNullRet(Text,  Text       .Coalesce(Text,        Empty      ));
        NoNullRet(Text,  Text       .Coalesce(Text,        Space      ));
        NoNullRet(Text,  Text       .Coalesce(Text,        Text       ));
    }
}