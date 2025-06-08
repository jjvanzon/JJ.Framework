namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_3Args_ObjectsToText : TestBase
{
    static Dummy  Obj  = Mocks.NoNullObj;
    static Dummy? Null = Mocks.NullObj  ;

    [TestMethod]
    public void Coalesce_3Args_ObjectsToString_Static()
    {
        NoNullRet(Empty,            Coalesce(Null,        Null,           NullText  ));
        NoNullRet(Empty,            Coalesce(Null,        Null,           Empty     ));
        NoNullRet(Space,            Coalesce(Null,        Null,           Space     ));
        NoNullRet(Text,             Coalesce(Null,        Null,           Text      ));
        NoNullRet(Empty,            Coalesce(Null,        Null,           NullyEmpty));
        NoNullRet(Space,            Coalesce(Null,        Null,           NullySpace));
        NoNullRet(Text,             Coalesce(Null,        Null,           NullyText ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullText  ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            Empty     ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            Space     ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            Text      ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullyEmpty));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullySpace));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullyText ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullText  ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    Empty     ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    Space     ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    Text      ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullyEmpty));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullySpace));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullyText ));
               
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullText  ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           Empty     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           Space     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           Text      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullyEmpty));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullySpace));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullyText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullText  ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            Empty     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            Space     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            Text      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullyEmpty));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullySpace));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullyText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullText  ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    Empty     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    Space     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    Text      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullyEmpty));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullySpace));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullyText ));

        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullText  ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           Empty     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           Space     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           Text      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullyEmpty));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullySpace));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullyText ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullText  ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            Empty     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            Space     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            Text      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullyEmpty));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullySpace));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullyText ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullText  ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    Empty     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    Space     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    Text      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullyEmpty));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullySpace));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullyText ));
    }

    [TestMethod]
    public void Coalesce_3Args_ObjectsToString_Extensions()
    {
        NoNullRet(Empty,            Null       .Coalesce( Null,           NullText      ));
        NoNullRet(Empty,            Null       .Coalesce( Null,           Empty         ));
        NoNullRet(Space,            Null       .Coalesce( Null,           Space         ));
        NoNullRet(Text,             Null       .Coalesce( Null,           Text          ));
        NoNullRet(Empty,            Null       .Coalesce( Null,           NullyEmpty    ));
        NoNullRet(Space,            Null       .Coalesce( Null,           NullySpace    ));
        NoNullRet(Text,             Null       .Coalesce( Null,           NullyText     ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullText      ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            Empty         ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            Space         ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            Text          ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullyEmpty    ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullyText     ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    Empty         ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullyEmpty    ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullyText     ));
        
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           Empty         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullyEmpty    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullyText     ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            Empty         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullyEmpty    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullyText     ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    Empty         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullyEmpty    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullyText     ));
        
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           Empty         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullyEmpty    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullyText     ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            Empty         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullyEmpty    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullyText     ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    Empty         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullyEmpty    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullyText     ));
    }
}