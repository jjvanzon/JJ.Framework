namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_Arity3_ThingToString
{
    static StringBuilder  Obj            => TestHelper.NoNullObj  ;
    static StringBuilder? Null           => TestHelper.NullObj    ;
    static string         EmptyText      => TestHelper.NoNullEmpty;
    static string         Space          => TestHelper.NoNullSpace;
    static string         Text           => TestHelper.NoNullText ;
    static string?        NullyEmptyText => TestHelper.NullyEmpty ;

    [TestMethod]
    public void Coalesce_Arity3_ObjectsToString_Static()
    {
        NoNullRet(EmptyText,        Coalesce(Null,        Null,           NullText      ));
        NoNullRet(EmptyText,        Coalesce(Null,        Null,           EmptyText     ));
        NoNullRet(Space,            Coalesce(Null,        Null,           Space         ));
        NoNullRet(Text,             Coalesce(Null,        Null,           Text          ));
        NoNullRet(EmptyText,        Coalesce(Null,        Null,           NullyEmptyText));
        NoNullRet(Space,            Coalesce(Null,        Null,           NullySpace    ));
        NoNullRet(Text,             Coalesce(Null,        Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            Space         ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            Text          ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Null,        Obj,            NullyWithText ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    EmptyText     ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullyEmptyText));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,        NullyFilled,    NullyWithText ));
               
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         Obj,            NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,         NullyFilled,    NullyWithText ));

        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullText      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           EmptyText     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           Space         ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           Text          ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullyEmptyText));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullySpace    ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Null,           NullyWithText ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullText      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            EmptyText     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            Space         ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            Text          ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullyEmptyText));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullySpace    ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, Obj,            NullyWithText ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    EmptyText     ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullyEmptyText));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", Coalesce(NullyFilled, NullyFilled,    NullyWithText ));
    }

    [TestMethod]
    public void Coalesce_Arity3_ObjectsToString_Extensions()
    {
        NoNullRet(EmptyText,        Null       .Coalesce( Null,           NullText      ));
        NoNullRet(EmptyText,        Null       .Coalesce( Null,           EmptyText     ));
        NoNullRet(Space,            Null       .Coalesce( Null,           Space         ));
        NoNullRet(Text,             Null       .Coalesce( Null,           Text          ));
        NoNullRet(EmptyText,        Null       .Coalesce( Null,           NullyEmptyText));
        NoNullRet(Space,            Null       .Coalesce( Null,           NullySpace    ));
        NoNullRet(Text,             Null       .Coalesce( Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullText      ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            Space         ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            Text          ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Null       .Coalesce( Obj,            NullyWithText ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    EmptyText     ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullyEmptyText));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", Null       .Coalesce( NullyFilled,    NullyWithText ));
        
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           EmptyText     ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullyEmptyText));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( Obj,            NullyWithText ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    EmptyText     ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullyEmptyText));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{Obj}",         Obj        .Coalesce( NullyFilled,    NullyWithText ));
        
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           EmptyText     ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullyEmptyText));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Null,           NullyWithText ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            EmptyText     ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullyEmptyText));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( Obj,            NullyWithText ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    EmptyText     ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullyEmptyText));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", NullyFilled.Coalesce( NullyFilled,    NullyWithText ));
    }
}