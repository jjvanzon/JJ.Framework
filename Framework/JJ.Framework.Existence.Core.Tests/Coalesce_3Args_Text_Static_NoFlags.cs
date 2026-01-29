namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_Text_Static_NoFlags : TestBase
{
    const string? Null = NullText;
    const string? NullyFilled = NullyFilledText;
    
    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Example()
    {
        AreEqual("Hi!",  Coalesce(" ", Null, "Hi!"));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch1()
    {
        NoNullRet(Empty, Coalesce(Null,        Null,        Null       ));
        NoNullRet(Empty, Coalesce(Null,        Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(Null,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(Null,        Null,        Empty      ));
        NoNullRet(Space, Coalesce(Null,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(Null,        Null,        Text       ));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(Null,        NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(Null,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(Null,        NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(Null,        NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(Null,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(Null,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(Null,        NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Null       ));
        NoNullRet(Empty, Coalesce(Null,        Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Null,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(Null,        Empty,       Empty      ));
        NoNullRet(Space, Coalesce(Null,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(Null,        Empty,       Text       ));
        NoNullRet(Empty, Coalesce(Null,        Space,       Null       ));
        NoNullRet(Empty, Coalesce(Null,        Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Null,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(Null,        Space,       Empty      ));
        NoNullRet(Space, Coalesce(Null,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(Null,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(Null,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(Null,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(Null,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(Null,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(Null,        Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch2()
    {
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(NullyEmpty,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(NullyEmpty,  NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Empty,       Text       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       Null       ));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(NullyEmpty,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(NullyEmpty,  Space,       Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(NullyEmpty,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch3()
    {
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        Null       ));
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(NullySpace,  Null,        Empty      ));
        NoNullRet(Space, Coalesce(NullySpace,  Null,        Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  Null,        Text       ));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(NullySpace,  NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(NullySpace,  NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(NullySpace,  NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(NullySpace,  NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       Null       ));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(NullySpace,  Empty,       Empty      ));
        NoNullRet(Space, Coalesce(NullySpace,  Empty,       Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  Empty,       Text       ));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       Null       ));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(NullySpace,  Space,       Empty      ));
        NoNullRet(Space, Coalesce(NullySpace,  Space,       Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  Space,       Text       ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Null       ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Empty      ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Space      ));
        NoNullRet(Text,  Coalesce(NullySpace,  Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch4()
    {
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Null,        Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Empty,       Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Space,       Text       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Null       ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Empty      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Space      ));
        NoNullRet(Text,  Coalesce(NullyFilled, Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch5()
    {
        NoNullRet(Empty, Coalesce(Empty,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(Empty,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(Empty,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(Empty,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(Empty,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(Empty,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(Empty,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(Empty,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(Empty,       NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(Empty,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(Empty,       NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(Empty,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(Empty,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Empty,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(Empty,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(Empty,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(Empty,       Empty,       Text       ));
        NoNullRet(Empty, Coalesce(Empty,       Space,       Null       ));
        NoNullRet(Empty, Coalesce(Empty,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Empty,       Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(Empty,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(Empty,       Space,       Space      ));
        NoNullRet(Text,  Coalesce(Empty,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(Empty,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch6()
    {
        NoNullRet(Empty, Coalesce(Space,       Null,        Null       ));
        NoNullRet(Empty, Coalesce(Space,       Null,        NullyEmpty ));
        NoNullRet(Space, Coalesce(Space,       Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       Null,        NullyFilled));
        NoNullRet(Empty, Coalesce(Space,       Null,        Empty      ));
        NoNullRet(Space, Coalesce(Space,       Null,        Space      ));
        NoNullRet(Text,  Coalesce(Space,       Null,        Text       ));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  Null       ));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       NullyEmpty,  NullyFilled));
        NoNullRet(Empty, Coalesce(Space,       NullyEmpty,  Empty      ));
        NoNullRet(Space, Coalesce(Space,       NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(Space,       NullyEmpty,  Text       ));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  Null       ));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  NullyEmpty ));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       NullySpace,  NullyFilled));
        NoNullRet(Empty, Coalesce(Space,       NullySpace,  Empty      ));
        NoNullRet(Space, Coalesce(Space,       NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(Space,       NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(Space,       NullyFilled, Text       ));
        NoNullRet(Empty, Coalesce(Space,       Empty,       Null       ));
        NoNullRet(Empty, Coalesce(Space,       Empty,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Space,       Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       Empty,       NullyFilled));
        NoNullRet(Empty, Coalesce(Space,       Empty,       Empty      ));
        NoNullRet(Space, Coalesce(Space,       Empty,       Space      ));
        NoNullRet(Text,  Coalesce(Space,       Empty,       Text       ));
        NoNullRet(Empty, Coalesce(Space,       Space,       Null       ));
        NoNullRet(Empty, Coalesce(Space,       Space,       NullyEmpty ));
        NoNullRet(Space, Coalesce(Space,       Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       Space,       NullyFilled));
        NoNullRet(Empty, Coalesce(Space,       Space,       Empty      ));
        NoNullRet(Space, Coalesce(Space,       Space,       Space      ));
        NoNullRet(Text,  Coalesce(Space,       Space,       Text       ));
        NoNullRet(Text,  Coalesce(Space,       Text,        Null       ));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(Space,       Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(Space,       Text,        Empty      ));
        NoNullRet(Text,  Coalesce(Space,       Text,        Space      ));
        NoNullRet(Text,  Coalesce(Space,       Text,        Text       ));
    }

    [TestMethod]
    public void Coalesce_3Args_Text_Static_NoFlags_Batch7()
    {
        NoNullRet(Text,  Coalesce(Text,        Null,        Null       ));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        Null,        NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        Null,        Empty      ));
        NoNullRet(Text,  Coalesce(Text,        Null,        Space      ));
        NoNullRet(Text,  Coalesce(Text,        Null,        Text       ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Null       ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Empty      ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Space      ));
        NoNullRet(Text,  Coalesce(Text,        NullyEmpty,  Text       ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Null       ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Empty      ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Space      ));
        NoNullRet(Text,  Coalesce(Text,        NullySpace,  Text       ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Null       ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Empty      ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Space      ));
        NoNullRet(Text,  Coalesce(Text,        NullyFilled, Text       ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Null       ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Empty      ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Space      ));
        NoNullRet(Text,  Coalesce(Text,        Empty,       Text       ));
        NoNullRet(Text,  Coalesce(Text,        Space,       Null       ));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        Space,       NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        Space,       Empty      ));
        NoNullRet(Text,  Coalesce(Text,        Space,       Space      ));
        NoNullRet(Text,  Coalesce(Text,        Space,       Text       ));
        NoNullRet(Text,  Coalesce(Text,        Text,        Null       ));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyEmpty ));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullySpace ));
        NoNullRet(Text,  Coalesce(Text,        Text,        NullyFilled));
        NoNullRet(Text,  Coalesce(Text,        Text,        Empty      ));
        NoNullRet(Text,  Coalesce(Text,        Text,        Space      ));
        NoNullRet(Text,  Coalesce(Text,        Text,        Text       ));
    }
}