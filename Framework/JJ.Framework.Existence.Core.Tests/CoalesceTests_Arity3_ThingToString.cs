namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class CoalesceTests_Arity3_ThingToString
{
    private static readonly StringBuilder  Obj            = TestHelper.NoNullObj  ;
    private static readonly StringBuilder? Null           = TestHelper.NullObj    ;
    private static readonly string         EmptyText      = TestHelper.NoNullEmpty;
    private static readonly string         Space          = TestHelper.NoNullSpace;
    private static readonly string         Text           = TestHelper.NoNullText ;
    private static readonly string?        NullyEmptyText = TestHelper.NullyEmpty ;

    [TestMethod]
    public void Coalesce_Arity3_ObjectsToString_Static()
    {
        NoNullRet(EmptyText,        Coalesce(Null,         Null,           NullText      ));
        NoNullRet(EmptyText,        Coalesce(Null,         Null,           EmptyText     ));
        NoNullRet(Space,            Coalesce(Null,         Null,           Space         ));
        NoNullRet(Text,             Coalesce(Null,         Null,           Text          ));
        NoNullRet(EmptyText,        Coalesce(Null,         Null,           NullyEmptyText));
        NoNullRet(Space,            Coalesce(Null,         Null,           NullySpace    ));
        NoNullRet(Text,             Coalesce(Null,         Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            Space         ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            Text          ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Null,         Obj,            NullyWithText ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    NullText      ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    EmptyText     ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    Space         ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    Text          ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    NullyEmptyText));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    NullySpace    ));
        NoNullRet($"{NullyFilled}", Coalesce(Null,         NullyFilled,    NullyWithText ));
               
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Null,           NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          Obj,            NullyWithText ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    NullText      ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    EmptyText     ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    Space         ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    Text          ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    NullyEmptyText));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    NullySpace    ));
        NoNullRet($"{Obj}",         Coalesce(Obj,          NullyFilled,    NullyWithText ));

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
}