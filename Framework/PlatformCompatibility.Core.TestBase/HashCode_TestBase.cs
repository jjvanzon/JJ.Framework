namespace JJ.Framework.PlatformCompatibility.Core.TestBase;

public class HashCode_TestBase
{
    public void Test_HashCode_PlatformStub()
    {
        int hashCode1 =  HashCode.Combine(1);
        int hashCode2 =  HashCode.Combine(1, 2l);
        int hashCode3 =  HashCode.Combine(1, 2l, 3f);
        int hashCode4 =  HashCode.Combine(1, 2l, 3f, 4d);
        int hashCode5 =  HashCode.Combine(1, 2l, 3f, 4d, 5m);
        int hashCode6 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6");
        int hashCode7 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7);
        int hashCode8 =  HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7, FromMinutes(8));
        WriteLine(TextOf(HashCode.Combine(1)) + " = " + hashCode1);
        WriteLine(TextOf(HashCode.Combine(1, 2l)) + " = " + hashCode2);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f)) + " = " + hashCode3);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d)) + " = " + hashCode4);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m)) + " = " + hashCode5);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6")) + " = " + hashCode6);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7)) + " = " + hashCode7);
        WriteLine(TextOf(HashCode.Combine(1, 2l, 3f, 4d, 5m, "6", (char)7, FromMinutes(8))) + " = " + hashCode8);
        IsTrue(hashCode1 != 0);
        IsTrue(hashCode2 != 0);
        IsTrue(hashCode3 != 0);
        IsTrue(hashCode4 != 0);
        IsTrue(hashCode5 != 0);
        IsTrue(hashCode6 != 0);
        IsTrue(hashCode7 != 0);
        IsTrue(hashCode8 != 0);
    }
}