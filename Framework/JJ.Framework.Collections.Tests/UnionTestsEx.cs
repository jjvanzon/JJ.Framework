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

            IsTrue(coll1 .SequenceEqual([ 1, 2, 3 ]));
            IsTrue(coll2 .SequenceEqual([ 3, 4, 5, 6 ]));
            IsTrue(result.SequenceEqual([ 1, 2, 3, 4, 5, 6 ]));
        }
    }
}