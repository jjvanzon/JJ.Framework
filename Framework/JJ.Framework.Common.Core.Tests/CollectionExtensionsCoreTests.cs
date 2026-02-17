// ReSharper disable ConvertToConstant.Local
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable PropertyCanBeMadeInitOnly.Local
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace JJ.Framework.Common.Core.Tests;

[TestClass]
public class CollectionExtensionsCoreTests
{
    // Struct instead of class for sequence equals to work with value comparisons.
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal readonly struct Item(int number, int? nully) 
    {
        public int Number { get; } = number;
        public int? Nully { get; } = nully;
        
        string DebuggerDisplay => GetDebuggerDisplay(this); // ncrunch: no coverage
    }
    
    private class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName  { get; set; } = "";
        public int    Age       { get; set; }
    }

    [TestMethod]
    public void ForEach_Core_Test()
    {
        List<int> list = [ 1, 2, 3 ];
        IEnumerable<int> enumerable = list;

        int sum1 = 0;
        list.ForEach(x => sum1 += x);

        int sum2 = 0;
        enumerable.ForEach(x => sum2 += x);
        
        AreEqual(6, sum1);
        AreEqual(6, sum2);
    }

    [TestMethod]
    public void ForEach_Exceptions_Core_Test()
    {
        {
            IEnumerable<int>? enumerable = null;
            ThrowsExceptionContaining(() => enumerable.ForEach(x => x++), "enumerable", "cannot be null");
        }
        {
            IEnumerable<int> enumerable = [ 1, 2, 3 ];
            ThrowsExceptionContaining(() => enumerable.ForEach(null), "action", "cannot be null");
        }
    }

    [TestMethod]
    public void Except_WithSingleItem_Core_Test()
    {
        int[] input = [ 1, 2, 3 ];
        {
            int[] expected = [ 2, 3 ];
            int[] actual = input.Except(1).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 3 ];
            int[] actual = input.Except(2).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except(3).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void Except_WithDistinctFlag_Core_Test()
    {
        int[] input = [ 1, 2, 2, 3 ];
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except([ 3 ]).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2 ];
            int[] actual = input.Except([ 3 ], distinct: true).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            int[] expected = [ 1, 2, 2 ];
            int[] actual = input.Except([ 3 ], distinct: false).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void Except_WithSingleItem_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int item = 1;
        ThrowsExceptionContaining(() => nullColl.Except(item).ToArray(), "enumerable", "cannot be null");
    }

    [TestMethod]
    public void Except_WithDistinctFlag_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int[] coll = [ 1, 2, 3 ];
        ThrowsExceptionContaining(() => nullColl.Except(coll, distinct: false).ToArray(), "source", "cannot be null");
        ThrowsExceptionContaining(() => coll.Except(nullColl, distinct: false).ToArray(), "input", "cannot be null");
    }
    
    [TestMethod]
    public void Union_WithSingleItem_Core_Test()
    {
        int[] input = [ 1, 2, 3 ];
        {
            int[] expected = [ 1, 2, 3, 4 ];
            int[] actual   = input.Union(4).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            int[] expected = [ 4, 1, 2, 3 ];
            int[] actual   = 4.Union(input).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void Union_WithSingleItem_NullExceptions_Core_Test()
    {
        int[]? nullColl = null;
        int item = 1;
        ThrowsExceptionContaining(() => nullColl.Union(item).ToArray(), "first" , "cannot be null");
        ThrowsExceptionContaining(() => item.Union(nullColl).ToArray(), "second", "cannot be null");
    }
    
    [TestMethod]
    public void Distinct_WithMultipleKeyDelegates_Core_Test()
    {
        {
            var input    = new[] { (a:1, b:2), (a:1, b:2), (a:3, b:4) };
            var expected = new[] { (a:1, b:2),             (a:3, b:4) };
            var actual   = input.Distinct(x => x.a, x => x.b).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
        {
            var input    = new[] { (a:1, b:2), (a:1, b:3), (a:1, b:4) };
            var expected = new[] { (a:1, b:2)                         };
            var actual   = input.Distinct(x => x.a).ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
    
    [TestMethod]
    public void Distinct_WithMultipleKeyDelegates_NullExceptions_Core_Test()
    {
        Item[] collection = [ new(1,2), new(1,3), new(3,4), new(3,null) ];
        Item[]? nullCollection = null;
         
        Func<Item, int>[]? nullDelegateCollection = null;
        Func<Item, int>? nullDelegate = null;
        
        ThrowsExceptionContaining(() => nullCollection.Distinct(x => x.Number     ).ToArray(), "enumerable", "cannot be null");
        ThrowsExceptionContaining(() => collection.Distinct(nullDelegateCollection).ToArray(), "keys", "cannot be null");
        ThrowsExceptionContaining(() => collection.Distinct(nullDelegate          ).ToArray(), "keys", "contains nulls");
    }
    
    [TestMethod]
    public void Distinct_WithMultipleKeyDelegates_NullKeyValues_Core_Test()
    {
        // But null key values are fine.
        Item[] input    = [ new(1,null), new(1,2), new(3,4), new(3,null) ];
        Item[] expected = [ new(1,null), new(1,2), new(3,4) ];
        Item[] actual   = input.Distinct(x => x.Nully).ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Distinct_ByAnonymousKey_Core_Test()
    {
        // Arrange
        var people = new Person[]
        {
            new() { FirstName = "Alice",   LastName = "Smith", Age = 30 },
            new() { FirstName = "Bob",     LastName = "Smith", Age = 30 },
            new() { FirstName = "Charlie", LastName = "Jones", Age = 25 },
            new() { FirstName = "Dana",    LastName = "Smith", Age = 30 },
            new() { FirstName = "Eve",     LastName = "Jones", Age = 25 }  
        };

        // Act
        var result = people
            .Distinct(x => new { x.LastName, x.Age })
            .ToArray();

        // Assert
        AreEqual(2, result.Length);
        IsTrue(result.Any(x => x.LastName == "Smith" && x.Age == 30));
        IsTrue(result.Any(x => x.LastName == "Jones" && x.Age == 25));
    }
    
    [TestMethod]
    public void AsEnumerable_Core_Test()
    {
        int input = 1;
        IEnumerable<int> enumerable = input.AsEnumerable();
        int[] array = enumerable.ToArray();
        int[] expected = [ 1 ];
        CollectionAssert.AreEqual(expected, array);
    }
    
    [TestMethod]
    public void AddRange_Core_Test()
    {
        IList<int> list  = [ 1, 2, 3 ];
        IList<int> list2 = [ 3, 4, 5 ];
        list.AddRange(list2);
        int[] expected = [ 1, 2, 3, 3, 4, 5 ];
        int[] actual = list.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void AddRange_NullExceptions_Core_Test()
    {
        IList<int>? nullList = null;
        IList<int> list = [ 1, 2, 3 ];
        ThrowsExceptionContaining(() => nullList.AddRange(list), "collection", "cannot be null");
        ThrowsExceptionContaining(() => list.AddRange(nullList), "items", "cannot be null");
    }
    
    [TestMethod]
    public void Add_WithParams_Core_Test()
    {
        IList<int> list = [ 1, 2, 3 ];
        list.Add(3, 4, 5);
        int[] expected = [ 1, 2, 3, 3, 4, 5 ];
        int[] actual = list.ToArray();
        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Add_WithParams_NullExceptions_Core_Test()
    {
        IList<int>? nullList = null;
        ThrowsExceptionContaining(() => nullList.Add(1, 2, 3), "collection", "cannot be null");
    }
}