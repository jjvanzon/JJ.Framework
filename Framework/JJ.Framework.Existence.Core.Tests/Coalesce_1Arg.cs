namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class Coalesce_1Arg
{
    static string  Empty     = NoNullEmpty;
    static string  Space     = NoNullSpace;
    static string  Text      = NoNullText;
    static string? NullyText = NullyWithText;

    // Text
    
    [TestMethod]
    public void Coalesce_1Arg_Text_Literals()
    {
        NoNullRet(""   , ""      .Coalesce());
        NoNullRet("   ", "   "   .Coalesce());
        NoNullRet("Hi" , "Hi"    .Coalesce());
        NoNullRet(""   , Coalesce(NullText ));
        NoNullRet(""   , Coalesce(""       ));
        NoNullRet("   ", Coalesce("   "    ));
        NoNullRet("Hi" , Coalesce("Hi"     ));
    }

    [TestMethod]
    public void Coalesce_1Arg_Text_Vars()
    {
        NoNullRet(Empty, NullText  .Coalesce());
        NoNullRet(Empty, Empty     .Coalesce());
        NoNullRet(Empty, NullyEmpty.Coalesce());
        NoNullRet(Space, Space     .Coalesce());
        NoNullRet(Space, NullySpace.Coalesce());
        NoNullRet(Text,  Text      .Coalesce());
        NoNullRet(Text,  NullyText .Coalesce());
        NoNullRet(Empty, Coalesce(NullText   ));
        NoNullRet(Empty, Coalesce(Empty      ));
        NoNullRet(Empty, Coalesce(NullyEmpty ));
        NoNullRet(Space, Coalesce(Space      ));
        NoNullRet(Space, Coalesce(NullySpace ));
        NoNullRet(Text,  Coalesce(Text       ));
        NoNullRet(Text,  Coalesce(NullyText  ));
    }

    [TestMethod]
    public void Coalesce_1Arg_Text_Keywords()
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
    
    // Values
         
    [TestMethod]
    public void Coalesce_1Arg_Vals_Literals()
    {
        NoNullRet(0, 0.Coalesce());
        NoNullRet(0, Coalesce(0) );
        NoNullRet(1, 1.Coalesce());
        NoNullRet(1, Coalesce(1) );
        NoNullRet(2, 2.Coalesce());
        NoNullRet(2, Coalesce(2) );
    }

    [TestMethod]
    public void Coalesce_1Arg_Vals_Nully_Vars()
    {
        NullRet  (null,    NullNum           );
        NullRet  (0,       Nully0            );
        NullRet  (1,       Nully1            );
        NullRet  (2,       Nully2            );
        NoNullRet(0,       NoNull0           );
        NoNullRet(1,       NoNull1           );
        NoNullRet(2,       NoNull2           );

        NoNullRet(NoNull0, NullNum.Coalesce());
        NoNullRet(NoNull0, Coalesce(NullNum) );
        NullRet  (NoNull0, Nully0            );
        NoNullRet(NoNull0, Nully0.Coalesce() );
        NoNullRet(NoNull0, Coalesce(Nully0)  );
        NullRet  (NoNull1, Nully1            );
        NoNullRet(NoNull1, Nully1.Coalesce() );
        NoNullRet(NoNull1, Coalesce(Nully1)  );
        NullRet  (NoNull2, Nully2            );
        NoNullRet(NoNull2, Nully2.Coalesce() );
        NoNullRet(NoNull2, Coalesce(Nully2)  );
    }
        
    [TestMethod]
    public void Coalesce_1Arg_Vals_NoNull_Vars()
    {
        NoNullRet(0, NoNull0           );
        NoNullRet(0, NoNull0.Coalesce());
        NoNullRet(0, Coalesce(NoNull0) );
        NoNullRet(3, NoNull3           );
        NoNullRet(3, NoNull3.Coalesce());
        NoNullRet(3, Coalesce(NoNull3) );
    }

    [TestMethod]
    public void Coalesce_1Arg_Vals_Nully_Keywords()
    {
        NullRet  (null, (int?)null             );
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
    }
    
    [TestMethod]
    public void Coalesce_1Arg_Vals_NoNull_Keywords()
    {
        NoNullRet(0, default(int)           );
        NoNullRet(0, default(int).Coalesce());
        NoNullRet(0, Coalesce(default(int)) );
        NoNullRet(0, ((int)0.0).Coalesce()  );
        NoNullRet(0, Coalesce(((int)0.0))   );
    }
   
    // Objects

    [TestMethod]
    public void Coalesce_1Arg_Obj_Vars()
    {
        NoNullRet(NoNullObj);
        NoNullRet(Coalesce(NoNullObj));
        NoNullRet(NoNullObj.Coalesce());
        
        IsNull(NullObj);
        NoNullRet(Coalesce(NullObj));
        NoNullRet(NullObj.Coalesce());

        NotNull(NullyFilled);
        NoNullRet(Coalesce(NullyFilled));
        NoNullRet(NullyFilled.Coalesce());
    }

    [TestMethod]
    public void Coalesce_1Arg_Obj_Keywords()
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
}