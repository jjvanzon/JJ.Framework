using Microsoft.VisualStudio.TestTools.UnitTesting;
// ReSharper disable ConvertToConstant.Local

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class CollectionExtensionsCoreTests
{
    [TestMethod]
    public void CollectionExtensions_ForEach_Core_Test()
    {
        List<int> list = new List<int> { 1, 2, 3 };
        IEnumerable<int> enumerable = list;

        int sum1 = 0;
        list.ForEach(x => sum1 += x);

        int sum2 = 0;
        enumerable.ForEach(x => sum2 += x);
        
        AreEqual(6, () => sum1);
        AreEqual(6, () => sum2);
    }

    [TestMethod]
    public void CollectionExtensions_ForEach_Exceptions_Core_Test()
    {
        {
            IEnumerable<int> enumerable = null;
            ThrowsExceptionContaining(() => enumerable.ForEach(x => x++), "Cannot be null", "enumerable");
        }
        {
            IEnumerable<int> enumerable = [ 1, 2, 3 ];
            ThrowsExceptionContaining(() => enumerable.ForEach(null), "Cannot be null", "action");
        }
    }

    [TestMethod]
    public void CollectionExtensions_Except_WithSingleItem_Core_Test()
    {
        int[] input = [ 1, 2, 3 ];
        {
            int[] expected = [ 2, 3 ];
            int[] actual = input.Except(1).ToArray();
            AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 3 ];
            int[] actual = input.Except(2).ToArray();
            AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except(3).ToArray();
            AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void CollectionExtensions_Except_WithDistinctFlag_Core_Test()
    {
        int[] input = [ 1, 2, 2, 3 ];
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except([ 3 ]).ToArray();
            AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except([ 3 ], distinct: true).ToArray();
            AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2, 2 ];
            int[] actual = input.Except([ 3 ], distinct: false).ToArray();
            AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void CollectionExtensions_Except_WithSingleItem_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int item = 1;
        ThrowsExceptionContaining(() => nullColl.Except(item).ToArray(), "enumerable", "cannot be null");
    }

    [TestMethod]
    public void CollectionExtensions_Except_WithDistinctFlag_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int[] coll = [ 1, 2, 3 ];
        ThrowsExceptionContaining(() => nullColl.Except(coll, distinct: false).ToArray(), "source", "cannot be null");
        ThrowsExceptionContaining(() => coll.Except(nullColl, distinct: false).ToArray(), "input", "cannot be null");
    }
    
    [TestMethod]
    public void CollectionExtensions_Union_WithSingleItem_Core_Test()
    {
        int[] input = { 1, 2, 3 };
        {
            int[] expected = { 1, 2, 3, 4 };
            int[] actual   = input.Union(4).ToArray();
            AreEqual(expected, actual);
        }
        {
            int[] expected = { 4, 1, 2, 3 };
            int[] actual   = 4.Union(input).ToArray();
            AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void CollectionExtensions_Union_WithSingleItem_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int item = 1;
        ThrowsExceptionContaining(() => nullColl.Union(item).ToArray(), "first", "cannot be null");
        ThrowsExceptionContaining(() => item.Union(nullColl).ToArray(), "second", "cannot be null");
    }
}