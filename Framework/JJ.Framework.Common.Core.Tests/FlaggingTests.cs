using static JJ.Framework.Common.Core.Tests.FlagTestEnum;

namespace JJ.Framework.Common.Core.Tests;
    
[Flags]
enum FlagTestEnum
{
    None = 0,
    A = 1,
    B = 2,
    C = 4,
    D = 8,
    E = 16,
    F = 32,
    G = 64,
    H = 128
}

[TestClass]
public class FlaggingTests
{
    [TestMethod]
    public void Flagging_Enums()
    {
        // Init
        FlagTestEnum value = A | B;
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsFalse(value.HasFlag(C));
        IsFalse(value.HasFlag(D));
        IsFalse(value.HasFlag(E));
        IsFalse(value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
        // Extension Method
        value = value.SetFlag(C);
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsFalse(value.HasFlag(D));
        IsFalse(value.HasFlag(E));
        IsFalse(value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));

        // Static Call
        value = SetFlag(value, D);
        IsTrue (HasFlag(value, A));
        IsTrue (HasFlag(value, B));
        IsTrue (HasFlag(value, C));
        IsTrue (HasFlag(value, D));
        IsFalse(HasFlag(value, E));
        IsFalse(HasFlag(value, F));
        IsFalse(HasFlag(value, G));
        IsFalse(HasFlag(value, H));
        
        // Params
        value = value.SetFlags(E, F);
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsTrue (value.HasFlag(E));
        IsTrue (value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
        value = SetFlags(value, G, H);
        IsTrue (HasFlag(value, A));
        IsTrue (HasFlag(value, B));
        IsTrue (HasFlag(value, C));
        IsTrue (HasFlag(value, D));
        IsTrue (HasFlag(value, E));
        IsTrue (HasFlag(value, F));
        IsTrue (HasFlag(value, G));
        IsTrue (HasFlag(value, H));
        
        // Clearing Flags
        value = value.ClearFlag(H);
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsTrue (value.HasFlag(E));
        IsTrue (value.HasFlag(F));
        IsTrue (value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
        value = ClearFlag(value, G);
        IsTrue (HasFlag(value, A));
        IsTrue (HasFlag(value, B));
        IsTrue (HasFlag(value, C));
        IsTrue (HasFlag(value, D));
        IsTrue (HasFlag(value, E));
        IsTrue (HasFlag(value, F));
        IsFalse(HasFlag(value, G));
        IsFalse(HasFlag(value, H));
        
        value = value.ClearFlags(F, E);
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsFalse(value.HasFlag(E));
        IsFalse(value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
        value = ClearFlags(value, D, C);
        IsTrue (HasFlag(value, A));
        IsTrue (HasFlag(value, B));
        IsFalse(HasFlag(value, C));
        IsFalse(HasFlag(value, D));
        IsFalse(HasFlag(value, E));
        IsFalse(HasFlag(value, F));
        IsFalse(HasFlag(value, G));
        IsFalse(HasFlag(value, H));

        // Correspondence between .NET and JJ.Framework.
        {
            bool hasFlagStatic = HasFlag(value, A | B);
            bool hasFlagInstance = value.HasFlag(A | B);
            IsTrue(hasFlagStatic);
            IsTrue(hasFlagInstance);
        }
        {
            bool hasFlagStatic = HasFlag(value, A | B | C);
            bool hasFlagInstance = value.HasFlag(A | B | C);
            IsFalse(hasFlagStatic);
            IsFalse(hasFlagInstance);
        }
    }
    
    [TestMethod]
    public void Flagging_Ints()
    {
        // Init
        int value = 1 | 2;
        IsTrue (HasFlag(value,   1));
        IsTrue (HasFlag(value,   2));
        IsFalse(HasFlag(value,   4));
        IsFalse(HasFlag(value,   8));
        IsFalse(HasFlag(value,  16));
        IsFalse(HasFlag(value,  32));
        IsFalse(HasFlag(value,  64));
        IsFalse(HasFlag(value, 128));

        // Extension Method
        value = value.SetFlag(4);
        IsTrue (value.HasFlag(   1));
        IsTrue (value.HasFlag(   2));
        IsTrue (value.HasFlag(   4));
        IsFalse(value.HasFlag(   8));
        IsFalse(value.HasFlag(  16));
        IsFalse(value.HasFlag(  32));
        IsFalse(value.HasFlag(  64));
        IsFalse(value.HasFlag( 128));

        // Static Call
        value = SetFlag(value, 8);
        IsTrue (HasFlag(value,   1));
        IsTrue (HasFlag(value,   2));
        IsTrue (HasFlag(value,   4));
        IsTrue (HasFlag(value,   8));
        IsFalse(HasFlag(value,  16));
        IsFalse(HasFlag(value,  32));
        IsFalse(HasFlag(value,  64));
        IsFalse(HasFlag(value, 128));

        // Params
        value = value.SetFlags(16, 32);
        IsTrue (value.HasFlag(   1));
        IsTrue (value.HasFlag(   2));
        IsTrue (value.HasFlag(   4));
        IsTrue (value.HasFlag(   8));
        IsTrue (value.HasFlag(  16));
        IsTrue (value.HasFlag(  32));
        IsFalse(value.HasFlag(  64));
        IsFalse(value.HasFlag( 128));

        value = SetFlags(value, 64, 128);
        IsTrue (HasFlag(value,   1));
        IsTrue (HasFlag(value,   2));
        IsTrue (HasFlag(value,   4));
        IsTrue (HasFlag(value,   8));
        IsTrue (HasFlag(value,  16));
        IsTrue (HasFlag(value,  32));
        IsTrue (HasFlag(value,  64));
        IsTrue (HasFlag(value, 128));

        // Clearing Flags
        value = value.ClearFlag(128);
        IsTrue (value.HasFlag(   1));
        IsTrue (value.HasFlag(   2));
        IsTrue (value.HasFlag(   4));
        IsTrue (value.HasFlag(   8));
        IsTrue (value.HasFlag(  16));
        IsTrue (value.HasFlag(  32));
        IsTrue (value.HasFlag(  64));
        IsFalse(value.HasFlag( 128));

        value = ClearFlag(value, 64);
        IsTrue (HasFlag(value,   1));
        IsTrue (HasFlag(value,   2));
        IsTrue (HasFlag(value,   4));
        IsTrue (HasFlag(value,   8));
        IsTrue (HasFlag(value,  16));
        IsTrue (HasFlag(value,  32));
        IsFalse(HasFlag(value,  64));
        IsFalse(HasFlag(value, 128));

        value = value.ClearFlags(32, 16);
        IsTrue (value.HasFlag(   1));
        IsTrue (value.HasFlag(   2));
        IsTrue (value.HasFlag(   4));
        IsTrue (value.HasFlag(   8));
        IsFalse(value.HasFlag(  16));
        IsFalse(value.HasFlag(  32));
        IsFalse(value.HasFlag(  64));
        IsFalse(value.HasFlag( 128));

        value = ClearFlags(value, 8, 4);
        IsTrue (HasFlag(value,   1));
        IsTrue (HasFlag(value,   2));
        IsFalse(HasFlag(value,   4));
        IsFalse(HasFlag(value,   8));
        IsFalse(HasFlag(value,  16));
        IsFalse(HasFlag(value,  32));
        IsFalse(HasFlag(value,  64));
        IsFalse(HasFlag(value, 128));
    }
}