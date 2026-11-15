#pragma warning disable IDE0200
// ReSharper disable InvokeAsExtensionMember

namespace JJ.Framework.Collections.Legacy.Tests;

using static StaticEnumerableEx;

[TestClass]
public class UnionTestsEx
{
    [TestMethod]
    public void Test_Union_Syntaxes_IncludingShortStatic()
    {
        var syntaxes = new Func<IEnumerable<int>, IEnumerable<int>, IEnumerable<int>>[]
        {
            (x, y) => x.Union(y),
            (x, y) => Union(x, y),
            (x, y) => Enumerable.Union(x, y),
            (x, y) => x.Union(y, EqualityComparer<int>.Default),
            (x, y) => Union(x, y, EqualityComparer<int>.Default),
            (x, y) => Enumerable.Union(x, y, EqualityComparer<int>.Default),
        };

        int[] coll1 = [ 1, 2, 3 ];
        IList<int> coll2 = [ 3, 4, 5, 6 ]; // Deliberate duplcate to be removed.

        foreach (var func in syntaxes)
        {
            int[] result =  func(coll1, coll2).ToArray();

            IsNotNull(coll1);
            AreEqual(3, coll1.Length);
            AreEqual(1, coll1[0]);
            AreEqual(2, coll1[1]);
            AreEqual(3, coll1[2]);

            IsNotNull(coll2);
            AreEqual(4, coll2.Count);
            AreEqual(3, coll2[0]);
            AreEqual(4, coll2[1]);
            AreEqual(5, coll2[2]);
            AreEqual(6, coll2[3]);

            IsNotNull(result);
            AreEqual(6, result.Length);
            AreEqual(1, result[0]);
            AreEqual(2, result[1]);
            AreEqual(3, result[2]);
            AreEqual(4, result[3]);
            AreEqual(5, result[4]);
            AreEqual(6, result[5]);
        }
    }
}