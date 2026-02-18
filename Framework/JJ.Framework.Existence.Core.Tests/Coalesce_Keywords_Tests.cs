// ReSharper disable ArrangeDefaultValueWhenTypeNotEvident
namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_Keywords_Tests
{
    // Random Cases
    
    [TestMethod]
    public void Coalesce_Keywords_RandomCases()
    {
        NoNullRet(1, default(int).Coalesce(NullNum, Nully0, Nully1, NoNull0));
        NoNullRet(1, default(int?).Coalesce(NullNum, Nully0, Nully1, NoNull0));
        NoNullRet(0, default(int).Coalesce(NullNum, NullNum, NullNum));
        NoNullRet(0, default(int?).Coalesce(NullNum, NullNum, NullNum));
    }    
    
    // 1 Arg

    [TestMethod]
    public void Coalesce_Keywords_1Arg_Text()
    {
        NoNullRet("", default(string) .Coalesce());
        NoNullRet("", default(string?).Coalesce());
        NoNullRet("", ((string?)null) .Coalesce());
        NoNullRet("", ((string)null!) .Coalesce());
        NoNullRet("", Coalesce(default(string)  ));
        NoNullRet("", Coalesce(default(string?) ));
        NoNullRet("", Coalesce((string?)null    ));
        NoNullRet("", Coalesce((string)null!    ));
    }

    [TestMethod]
    public void Coalesce_Keywords_1Arg_Vals()
    {

      //NullRet  (null, (int?)null             );
        NullRet  (0,    (int?)0                );
        NullRet  (1,    (int?)1                );
        NullRet  (2,    (int?)2                );
        NoNullRet(0,    ((int?)null).Coalesce());
        NoNullRet(0,    ((int?)0).Coalesce()   );
        NoNullRet(1,    ((int?)1).Coalesce()   );
        NoNullRet(2,    ((int?)2).Coalesce()   );
        NoNullRet(0,    Coalesce(((int?)null)) );
        NoNullRet(0,    Coalesce((int?)0)      );
        NoNullRet(1,    Coalesce((int?)1)      );
        NoNullRet(2,    Coalesce((int?)2)      );
        
        NoNullRet(0, default(int)           );
        NoNullRet(0, default(int).Coalesce());
        NoNullRet(0, Coalesce(default(int)) );
        NoNullRet(0, ((int)0.0).Coalesce()  );
        NoNullRet(0, Coalesce(((int)0.0))   );
    }

    [TestMethod]
    public void Coalesce_Keywords_1Arg_Obj()
    {
        NoNullRet(Coalesce((StringBuilder?)null));
        NoNullRet(((StringBuilder?)null).Coalesce());

        IsNull(default(StringBuilder?));
        NoNullRet(Coalesce(default(StringBuilder?)));
        NoNullRet(default(StringBuilder?).Coalesce());

        IsNull(default(StringBuilder));
        NoNullRet(Coalesce(default(StringBuilder)));
        NoNullRet(default(StringBuilder).Coalesce());
    }

    // 2 Args

    [TestMethod]
    public void Coalesce_Keywords_2Args_Text_Static()
    {
      //NoNullRet("", Coalesce(null,              null                              )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              (string )null!                    ));
      //NoNullRet("", Coalesce(null,              (string?)null                     ));
      //NoNullRet("", Coalesce(null,              default                           )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              default(string )                  ));
      //NoNullRet("", Coalesce(null,              default(string?)                  ));
      //NoNullRet("", Coalesce((string )null!,    null                              ));
        NoNullRet("", Coalesce((string )null!,    (string )null!                    ));
        NoNullRet("", Coalesce((string )null!,    (string?)null                     ));
      //NoNullRet("", Coalesce((string )null!,    default                           ));
        NoNullRet("", Coalesce((string )null!,    default(string )                  ));
        NoNullRet("", Coalesce((string )null!,    default(string?)                  ));
      //NoNullRet("", Coalesce((string?)null,     null                              ));
        NoNullRet("", Coalesce((string?)null,     (string )null!                    ));
        NoNullRet("", Coalesce((string?)null,     (string?)null                     ));
      //NoNullRet("", Coalesce((string?)null,     default                           ));
        NoNullRet("", Coalesce((string?)null,     default(string )                  ));
        NoNullRet("", Coalesce((string?)null,     default(string?)                  ));
      //NoNullRet("", Coalesce(default,           null                              )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default,           (string )null!                    ));
      //NoNullRet("", Coalesce(default,           (string?)null                     ));
      //NoNullRet("", Coalesce(default,           default                           )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default,           default(string )                  ));
      //NoNullRet("", Coalesce(default,           default(string?)                  ));
      //NoNullRet("", Coalesce(default(string ),  null                              ));
        NoNullRet("", Coalesce(default(string ),  (string )null!                    ));
        NoNullRet("", Coalesce(default(string ),  (string?)null                     ));
      //NoNullRet("", Coalesce(default(string ),  default                           ));
        NoNullRet("", Coalesce(default(string ),  default(string )                  ));
        NoNullRet("", Coalesce(default(string ),  default(string?)                  ));
      //NoNullRet("", Coalesce(default(string?),  null                              ));
        NoNullRet("", Coalesce(default(string?),  (string )null!                    ));
        NoNullRet("", Coalesce(default(string?),  (string?)null                     ));
      //NoNullRet("", Coalesce(default(string?),  default                           ));
        NoNullRet("", Coalesce(default(string?),  default(string )                  ));
        NoNullRet("", Coalesce(default(string?),  default(string?)                  ));
      //NoNullRet("", Coalesce(null,              null            , spaceMatters: false)); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              (string )null!  , spaceMatters: false));
      //NoNullRet("", Coalesce(null,              (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce(null,              default         , spaceMatters: false)); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              default(string ), spaceMatters: false));
      //NoNullRet("", Coalesce(null,              default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce((string )null!,    null            , spaceMatters: false));
        NoNullRet("", Coalesce((string )null!,    (string )null!  , spaceMatters: false));
        NoNullRet("", Coalesce((string )null!,    (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce((string )null!,    default         , spaceMatters: false));
        NoNullRet("", Coalesce((string )null!,    default(string ), spaceMatters: false));
        NoNullRet("", Coalesce((string )null!,    default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce((string?)null,     null            , spaceMatters: false));
        NoNullRet("", Coalesce((string?)null,     (string )null!  , spaceMatters: false));
        NoNullRet("", Coalesce((string?)null,     (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce((string?)null,     default         , spaceMatters: false));
        NoNullRet("", Coalesce((string?)null,     default(string ), spaceMatters: false));
        NoNullRet("", Coalesce((string?)null,     default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce(default,           null            , spaceMatters: false)); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default,           (string )null!  , spaceMatters: false));
      //NoNullRet("", Coalesce(default,           (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce(default,           default         , spaceMatters: false)); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default,           default(string ), spaceMatters: false));
      //NoNullRet("", Coalesce(default,           default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce(default(string ),  null            , spaceMatters: false));
        NoNullRet("", Coalesce(default(string ),  (string )null!  , spaceMatters: false));
        NoNullRet("", Coalesce(default(string ),  (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce(default(string ),  default         , spaceMatters: false));
        NoNullRet("", Coalesce(default(string ),  default(string ), spaceMatters: false));
        NoNullRet("", Coalesce(default(string ),  default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce(default(string?),  null            , spaceMatters: false));
        NoNullRet("", Coalesce(default(string?),  (string )null!  , spaceMatters: false));
        NoNullRet("", Coalesce(default(string?),  (string?)null   , spaceMatters: false));
      //NoNullRet("", Coalesce(default(string?),  default         , spaceMatters: false));
        NoNullRet("", Coalesce(default(string?),  default(string ), spaceMatters: false));
        NoNullRet("", Coalesce(default(string?),  default(string?), spaceMatters: false));
      //NoNullRet("", Coalesce(null,              null            , spaceMatters: true )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              (string )null!  , spaceMatters: true ));
      //NoNullRet("", Coalesce(null,              (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce(null,              default         , spaceMatters: true )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(null,              default(string ), spaceMatters: true ));
      //NoNullRet("", Coalesce(null,              default(string?), spaceMatters: true ));
      //NoNullRet("", Coalesce((string )null!,    null            , spaceMatters: true ));
        NoNullRet("", Coalesce((string )null!,    (string )null!  , spaceMatters: true ));
        NoNullRet("", Coalesce((string )null!,    (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce((string )null!,    default         , spaceMatters: true ));
        NoNullRet("", Coalesce((string )null!,    default(string ), spaceMatters: true ));
        NoNullRet("", Coalesce((string )null!,    default(string?), spaceMatters: true ));
      //NoNullRet("", Coalesce((string?)null,     null            , spaceMatters: true ));
        NoNullRet("", Coalesce((string?)null,     (string )null!  , spaceMatters: true ));
        NoNullRet("", Coalesce((string?)null,     (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce((string?)null,     default         , spaceMatters: true ));
        NoNullRet("", Coalesce((string?)null,     default(string ), spaceMatters: true ));
        NoNullRet("", Coalesce((string?)null,     default(string?), spaceMatters: true ));
      //NoNullRet("", Coalesce(default         ,  null            , spaceMatters: true )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default         ,  (string )null!  , spaceMatters: true ));
      //NoNullRet("", Coalesce(default         ,  (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce(default         ,  default         , spaceMatters: true )); // Compiles, unsupported, ambiguous.
      //NoNullRet("", Coalesce(default         ,  default(string ), spaceMatters: true ));
      //NoNullRet("", Coalesce(default         ,  default(string?), spaceMatters: true ));
      //NoNullRet("", Coalesce(default(string ),  null            , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string ),  (string )null!  , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string ),  (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce(default(string ),  default         , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string ),  default(string ), spaceMatters: true ));
        NoNullRet("", Coalesce(default(string ),  default(string?), spaceMatters: true ));
      //NoNullRet("", Coalesce(default(string?),  null            , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string?),  (string )null!  , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string?),  (string?)null   , spaceMatters: true ));
      //NoNullRet("", Coalesce(default(string?),  default         , spaceMatters: true ));
        NoNullRet("", Coalesce(default(string?),  default(string ), spaceMatters: true ));
        NoNullRet("", Coalesce(default(string?),  default(string?), spaceMatters: true ));
    }

    [TestMethod]
    public void Coalesce_Keywords_2Args_Text_Extensions()
    {
      //Computer says no
      //NoNullRet("", null            .Coalesce(  null                              )); 
      //NoNullRet("", null            .Coalesce(  (string )null!                    ));
      //NoNullRet("", null            .Coalesce(  (string?)null                     ));
      //NoNullRet("", null            .Coalesce(  default                           ));
      //NoNullRet("", null            .Coalesce(  default(string )                  ));
      //NoNullRet("", null            .Coalesce(  default(string?)                  ));
      //NoNullRet("", ((string )null!).Coalesce(  null                              ));
        NoNullRet("", ((string )null!).Coalesce(  (string )null!                    ));
        NoNullRet("", ((string )null!).Coalesce(  (string?)null                     ));
      //NoNullRet("", ((string )null!).Coalesce(  default                           ));
        NoNullRet("", ((string )null!).Coalesce(  default(string )                  ));
        NoNullRet("", ((string )null!).Coalesce(  default(string?)                  ));
      //NoNullRet("", ((string?)null ).Coalesce(  null                              ));
        NoNullRet("", ((string?)null ).Coalesce(  (string )null!                    ));
        NoNullRet("", ((string?)null ).Coalesce(  (string?)null                     ));
      //NoNullRet("", ((string?)null ).Coalesce(  default                           ));
        NoNullRet("", ((string?)null ).Coalesce(  default(string )                  ));
        NoNullRet("", ((string?)null ).Coalesce(  default(string?)                  ));
      //Computer says no
      //NoNullRet("", default         .Coalesce(  null                              ));
      //NoNullRet("", default         .Coalesce(  (string )null!                    ));
      //NoNullRet("", default         .Coalesce(  (string?)null                     ));
      //NoNullRet("", default         .Coalesce(  default                           ));
      //NoNullRet("", default         .Coalesce(  default(string )                  ));
      //NoNullRet("", default         .Coalesce(  default(string?)                  ));
      //NoNullRet("", default(string ).Coalesce(  null                              ));
        NoNullRet("", default(string ).Coalesce(  (string )null!                    ));
        NoNullRet("", default(string ).Coalesce(  (string?)null                     ));
      //NoNullRet("", default(string ).Coalesce(  default                           ));
        NoNullRet("", default(string ).Coalesce(  default(string )                  ));
        NoNullRet("", default(string ).Coalesce(  default(string?)                  ));
      //NoNullRet("", default(string?).Coalesce(  null                              ));
        NoNullRet("", default(string?).Coalesce(  (string )null!                    ));
        NoNullRet("", default(string?).Coalesce(  (string?)null                     ));
      //NoNullRet("", default(string?).Coalesce(  default                           ));
        NoNullRet("", default(string?).Coalesce(  default(string )                  ));
        NoNullRet("", default(string?).Coalesce(  default(string?)                  ));
      //Computer says no
      //NoNullRet("", null            .Coalesce(  null            , spaceMatters: false));
      //NoNullRet("", null            .Coalesce(  (string )null!  , spaceMatters: false));
      //NoNullRet("", null            .Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", null            .Coalesce(  default         , spaceMatters: false));
      //NoNullRet("", null            .Coalesce(  default(string ), spaceMatters: false));
      //NoNullRet("", null            .Coalesce(  default(string?), spaceMatters: false));
      //NoNullRet("", ((string )null!).Coalesce(  null            , spaceMatters: false));
        NoNullRet("", ((string )null!).Coalesce(  (string )null!  , spaceMatters: false));
        NoNullRet("", ((string )null!).Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", ((string )null!).Coalesce(  default         , spaceMatters: false));
        NoNullRet("", ((string )null!).Coalesce(  default(string ), spaceMatters: false));
        NoNullRet("", ((string )null!).Coalesce(  default(string?), spaceMatters: false));
      //NoNullRet("", ((string?)null ).Coalesce(  null            , spaceMatters: false));
        NoNullRet("", ((string?)null ).Coalesce(  (string )null!  , spaceMatters: false));
        NoNullRet("", ((string?)null ).Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", ((string?)null ).Coalesce(  default         , spaceMatters: false));
        NoNullRet("", ((string?)null ).Coalesce(  default(string ), spaceMatters: false));
        NoNullRet("", ((string?)null ).Coalesce(  default(string?), spaceMatters: false));
      //Computer says no
      //NoNullRet("", default         .Coalesce(  null            , spaceMatters: false));
      //NoNullRet("", default         .Coalesce(  (string )null!  , spaceMatters: false));
      //NoNullRet("", default         .Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", default         .Coalesce(  default         , spaceMatters: false));
      //NoNullRet("", default         .Coalesce(  default(string ), spaceMatters: false));
      //NoNullRet("", default         .Coalesce(  default(string?), spaceMatters: false));
      //NoNullRet("", default(string ).Coalesce(  null            , spaceMatters: false));
        NoNullRet("", default(string ).Coalesce(  (string )null!  , spaceMatters: false));
        NoNullRet("", default(string ).Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", default(string ).Coalesce(  default         , spaceMatters: false));
        NoNullRet("", default(string ).Coalesce(  default(string ), spaceMatters: false));
        NoNullRet("", default(string ).Coalesce(  default(string?), spaceMatters: false));
      //NoNullRet("", default(string?).Coalesce(  null            , spaceMatters: false));
        NoNullRet("", default(string?).Coalesce(  (string )null!  , spaceMatters: false));
        NoNullRet("", default(string?).Coalesce(  (string?)null   , spaceMatters: false));
      //NoNullRet("", default(string?).Coalesce(  default         , spaceMatters: false));
        NoNullRet("", default(string?).Coalesce(  default(string ), spaceMatters: false));
        NoNullRet("", default(string?).Coalesce(  default(string?), spaceMatters: false));
      //Computer says no
      //NoNullRet("", null            .Coalesce(  null            , spaceMatters: true ));
      //NoNullRet("", null            .Coalesce(  (string )null!  , spaceMatters: true ));
      //NoNullRet("", null            .Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", null            .Coalesce(  default         , spaceMatters: true ));
      //NoNullRet("", null            .Coalesce(  default(string ), spaceMatters: true ));
      //NoNullRet("", null            .Coalesce(  default(string?), spaceMatters: true ));
      //NoNullRet("", ((string )null!).Coalesce(  null            , spaceMatters: true ));
        NoNullRet("", ((string )null!).Coalesce(  (string )null!  , spaceMatters: true ));
        NoNullRet("", ((string )null!).Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", ((string )null!).Coalesce(  default         , spaceMatters: true ));
        NoNullRet("", ((string )null!).Coalesce(  default(string ), spaceMatters: true ));
        NoNullRet("", ((string )null!).Coalesce(  default(string?), spaceMatters: true ));
      //NoNullRet("", ((string?)null ).Coalesce(  null            , spaceMatters: true ));
        NoNullRet("", ((string?)null ).Coalesce(  (string )null!  , spaceMatters: true ));
        NoNullRet("", ((string?)null ).Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", ((string?)null ).Coalesce(  default         , spaceMatters: true ));
        NoNullRet("", ((string?)null ).Coalesce(  default(string ), spaceMatters: true ));
        NoNullRet("", ((string?)null ).Coalesce(  default(string?), spaceMatters: true ));
      //Computer says no
      //NoNullRet("", default         .Coalesce(  null            , spaceMatters: true ));
      //NoNullRet("", default         .Coalesce(  (string )null!  , spaceMatters: true ));
      //NoNullRet("", default         .Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", default         .Coalesce(  default         , spaceMatters: true ));
      //NoNullRet("", default         .Coalesce(  default(string ), spaceMatters: true ));
      //NoNullRet("", default         .Coalesce(  default(string?), spaceMatters: true ));
      //NoNullRet("", default(string ).Coalesce(  null            , spaceMatters: true ));
        NoNullRet("", default(string ).Coalesce(  (string )null!  , spaceMatters: true ));
        NoNullRet("", default(string ).Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", default(string ).Coalesce(  default         , spaceMatters: true ));
        NoNullRet("", default(string ).Coalesce(  default(string ), spaceMatters: true ));
        NoNullRet("", default(string ).Coalesce(  default(string?), spaceMatters: true ));
      //NoNullRet("", default(string?).Coalesce(  null            , spaceMatters: true ));
        NoNullRet("", default(string?).Coalesce(  (string )null!  , spaceMatters: true ));
        NoNullRet("", default(string?).Coalesce(  (string?)null   , spaceMatters: true ));
      //NoNullRet("", default(string?).Coalesce(  default         , spaceMatters: true ));
        NoNullRet("", default(string?).Coalesce(  default(string ), spaceMatters: true ));
        NoNullRet("", default(string?).Coalesce(  default(string?), spaceMatters: true ));
    }

    [TestMethod]
    public void Coalesce_2Args_ObjectToText_Keywords()
    {
      //NoNullRet("",       Coalesce(NullObj,        null            )); // Doesn't resolve to string
        NoNullRet("",       Coalesce(NullObj,        (string )null!  ));
        NoNullRet("",       Coalesce(NullObj,        (string?)null   ));
      //NoNullRet("",       Coalesce(NullObj,        default         )); // Doesn't resolve to string
        NoNullRet("",       Coalesce(NullObj,        default(string )));
        NoNullRet("",       Coalesce(NullObj,        default(string?)));
      //NoNullRet("",       NullObj.Coalesce(        null            )); // Doesn't resolve to string
        NoNullRet("",       NullObj.Coalesce(        (string )null!  ));
        NoNullRet("",       NullObj.Coalesce(        (string?)null   ));
      //NoNullRet("",       NullObj.Coalesce(        default         )); // Doesn't resolve to string
        NoNullRet("",       NullObj.Coalesce(        default(string )));
        NoNullRet("",       NullObj.Coalesce(        default(string?)));
      //NoNullRet("Filled", Coalesce(NullyFilledObj, null            )); // Doesn't resolve to string
        NoNullRet("Filled", Coalesce(NullyFilledObj, (string )null!  ));
        NoNullRet("Filled", Coalesce(NullyFilledObj, (string?)null   ));
      //NoNullRet("Filled", Coalesce(NullyFilledObj, default         )); // Doesn't resolve to string
        NoNullRet("Filled", Coalesce(NullyFilledObj, default(string )));
        NoNullRet("Filled", Coalesce(NullyFilledObj, default(string?)));
      //NoNullRet("Filled", NullyFilledObj.Coalesce( null            )); // Doesn't resolve to string
        NoNullRet("Filled", NullyFilledObj.Coalesce( (string )null!  ));
        NoNullRet("Filled", NullyFilledObj.Coalesce( (string?)null   ));
      //NoNullRet("Filled", NullyFilledObj.Coalesce( default         )); // Doesn't resolve to string
        NoNullRet("Filled", NullyFilledObj.Coalesce( default(string )));
        NoNullRet("Filled", NullyFilledObj.Coalesce( default(string?)));
      //NoNullRet("NoNull", Coalesce(NoNullObj,      null            )); // Doesn't resolve to string
        NoNullRet("NoNull", Coalesce(NoNullObj,      (string )null!  ));
        NoNullRet("NoNull", Coalesce(NoNullObj,      (string?)null   ));
      //NoNullRet("NoNull", Coalesce(NoNullObj,      default         )); // Doesn't resolve to string
        NoNullRet("NoNull", Coalesce(NoNullObj,      default(string )));
        NoNullRet("NoNull", Coalesce(NoNullObj,      default(string?)));
      //NoNullRet("NoNull", NoNullObj.Coalesce(      null            )); // Doesn't resolve to string
        NoNullRet("NoNull", NoNullObj.Coalesce(      (string )null!  ));
        NoNullRet("NoNull", NoNullObj.Coalesce(      (string?)null   ));
      //NoNullRet("NoNull", NoNullObj.Coalesce(      default         )); // Doesn't resolve to string
        NoNullRet("NoNull", NoNullObj.Coalesce(      default(string )));
        NoNullRet("NoNull", NoNullObj.Coalesce(      default(string?)));
    }
    
    
}