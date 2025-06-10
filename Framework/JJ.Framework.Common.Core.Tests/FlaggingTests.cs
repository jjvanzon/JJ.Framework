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
    H = 128,
    I = 256
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
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsFalse(value.HasFlag(E));
        IsFalse(value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
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
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsTrue (value.HasFlag(E));
        IsTrue (value.HasFlag(F));
        IsTrue (value.HasFlag(G));
        IsTrue (value.HasFlag(H));
        
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
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsTrue (value.HasFlag(C));
        IsTrue (value.HasFlag(D));
        IsTrue (value.HasFlag(E));
        IsTrue (value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
        
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
        IsTrue (value.HasFlag(A));
        IsTrue (value.HasFlag(B));
        IsFalse(value.HasFlag(C));
        IsFalse(value.HasFlag(D));
        IsFalse(value.HasFlag(E));
        IsFalse(value.HasFlag(F));
        IsFalse(value.HasFlag(G));
        IsFalse(value.HasFlag(H));
    }
    
    [TestMethod]
    public void Flagging_Ints()
    {
    }
}