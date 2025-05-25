// ReSharper disable RedundantEmptyObjectOrCollectionInitializer

using System.Collections.Immutable;
// ReSharper disable CollectionNeverUpdated.Local

namespace JJ.Framework.Existence.Core.Tests;

[TestClass]
public class FilledInTests
{
    // Should check:
    // - [x] int
    // - [x] int?
    // - [x] string
    // - [x] string?
    // - [ ] Enum
    // - [ ] Enum?
    // - [ ] double
    // - [ ] bool
    // - [ ] Reference Types (StringBuilder)
    // - [ ] Nullable reference types (StringBuilder?)
    // - [ ] Coalescing from collection to collection
    // - [x] Collection types
    // - [x] Trim tolerance
    // - [ ] Coalesce arities
    // - [x] Static variant
    // - [x] Extension variant
    
    string? _nullText         = null;
    string? _nullableEmpty    = "";
    string? _nullableSpace    = " ";
    string? _nullableWithText = "Hi";
    string  _nonNullEmpty     = "";
    string  _nonNullSpace     = " ";
    string  _nonNullText      = "Hello";
    
    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(_nullableWithText));
        IsTrue(Has(_nonNullText));
        IsTrue(FilledIn(_nullableWithText));
        IsTrue(FilledIn(_nonNullText));
        IsTrue(_nullableWithText.FilledIn());
        IsTrue(_nonNullText.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(_nullText));
        IsFalse(Has(_nullableEmpty));
        IsFalse(Has(_nullableSpace));
        IsFalse(Has(_nonNullEmpty));
        IsFalse(Has(_nonNullSpace));
        IsFalse(FilledIn(_nullText));
        IsFalse(FilledIn(_nullableEmpty));
        IsFalse(FilledIn(_nullableSpace));
        IsFalse(FilledIn(_nonNullEmpty));
        IsFalse(FilledIn(_nonNullSpace));
        IsFalse(_nullText.FilledIn());
        IsFalse(_nullableEmpty.FilledIn());
        IsFalse(_nullableSpace.FilledIn());
        IsFalse(_nonNullEmpty.FilledIn());
        IsFalse(_nonNullSpace.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(_nullableWithText));
        IsFalse(IsNully(_nonNullText));
        IsFalse(_nullableWithText.IsNully());
        IsFalse(_nonNullText.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(IsNully(_nullText));
        IsTrue(IsNully(_nullableEmpty));
        IsTrue(IsNully(_nullableSpace));
        IsTrue(IsNully(_nonNullEmpty));
        IsTrue(IsNully(_nonNullSpace));
        IsTrue(_nullText.IsNully());
        IsTrue(_nullableEmpty.IsNully());
        IsTrue(_nullableSpace.IsNully());
        IsTrue(_nonNullEmpty.IsNully());
        IsTrue(_nonNullSpace.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Text_TrimSpace()
    {
        IsFalse(_nullableSpace.IsNully(trimSpace: false));
        IsFalse(_nullableSpace.IsNully(false));
        IsFalse(_nonNullSpace.IsNully(trimSpace: false));
        IsFalse(_nonNullSpace.IsNully(false));
        IsFalse(IsNully(_nullableSpace, trimSpace: false));
        IsFalse(IsNully(_nullableSpace, false));
        IsFalse(IsNully(_nonNullSpace, trimSpace: false));
        IsFalse(IsNully(_nonNullSpace, false));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(_nullableSpace, trimSpace: false));
        IsTrue(Has(_nullableSpace, false));
        IsTrue(Has(_nonNullSpace, trimSpace: false));
        IsTrue(Has(_nonNullSpace, false));
        IsTrue(_nullableSpace.FilledIn(trimSpace: false));
        IsTrue(_nullableSpace.FilledIn(false));
        IsTrue(_nonNullSpace.FilledIn(trimSpace: false));
        IsTrue(_nonNullSpace.FilledIn(false));
        IsTrue(FilledIn(_nullableSpace, trimSpace: false));
        IsTrue(FilledIn(_nullableSpace, false));
        IsTrue(FilledIn(_nonNullSpace, trimSpace: false));
        IsTrue(FilledIn(_nonNullSpace, false));
    }

    int? _nullInt    = null;
    int  _nonNull0   = 0;
    int  _nonNull1   = 1;
    int? _nullable0  = 0;
    int? _nullable1  = 1;
    
    [TestMethod]
    public void FilledIn_Int_True()
    {
        IsTrue(Has(_nonNull1));
        IsTrue(Has(_nullable1));
        IsTrue(_nonNull1.FilledIn());
        IsTrue(_nullable1.FilledIn());
        IsTrue(FilledIn(_nonNull1));
        IsTrue(FilledIn(_nullable1));
    }
    
    [TestMethod]
    public void FilledIn_Int_False()
    {
        IsFalse(Has(_nullInt));
        IsFalse(Has(_nonNull0));
        IsFalse(Has(_nullable0));
        IsFalse(_nullInt.FilledIn());
        IsFalse(_nonNull0.FilledIn());
        IsFalse(_nullable0.FilledIn());
        IsFalse(FilledIn(_nullInt));
        IsFalse(FilledIn(_nonNull0));
        IsFalse(FilledIn(_nullable0));
    }
        
    [TestMethod]
    public void IsNully_Int_False()
    {
        IsFalse(_nonNull1.IsNully());
        IsFalse(_nullable1.IsNully());
        IsFalse(IsNully(_nonNull1));
        IsFalse(IsNully(_nullable1));
    }
    
    [TestMethod]
    public void IsNully_Int_True()
    {
        IsTrue(_nullInt.IsNully());
        IsTrue(_nonNull0.IsNully());
        IsTrue(_nullable0.IsNully());
        IsTrue(IsNully(_nullInt));
        IsTrue(IsNully(_nonNull0));
        IsTrue(IsNully(_nullable0));
    }

    StringBuilder? _nullObject     = null;
    StringBuilder  _nonNullObject  = new();
    StringBuilder? _nullableFilled = new();
    
    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(Has(_nonNullObject));
        IsTrue(Has(_nullableFilled));
        IsTrue(FilledIn(_nonNullObject));
        IsTrue(FilledIn(_nullableFilled));
        IsTrue(_nonNullObject.FilledIn());
        IsTrue(_nullableFilled.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(Has(_nullObject));
        IsFalse(FilledIn(_nullObject));
        IsFalse(_nullObject.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(_nonNullObject));
        IsFalse(IsNully(_nullableFilled));
        IsFalse(_nonNullObject.IsNully());
        IsFalse(_nullableFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(_nullObject));
        IsTrue(_nullObject.IsNully());
    }
    
    private int[]?                    _emptyArray                 = [ ];
    private List               <int>? _emptyList                  = [ ];
    private HashSet            <int>? _emptyHashSet               = [ ];
    private IList              <int>? _emptyIList                 = [ ];
    private ISet               <int>? _emptyISet = new HashSet<int> { };
    private ICollection        <int>? _emptyICollection           = [ ];
    private IReadOnlyList      <int>? _emptyIReadOnlyList         = [ ];
    private IReadOnlyCollection<int>? _emptyIReadOnlyCollection   = [ ];
    private IEnumerable        <int>? _emptyIEnumerable           = [ ];
    
    private int[]?                    _array                 = [ 1, 2, 3 ];
    private List               <int>? _list                  = [ 1, 2, 3 ];
    private HashSet            <int>? _hashSet               = [ 1, 2, 3 ];
    private IList              <int>? _iList                 = [ 1, 2, 3 ];
    private ISet               <int>? _iSet = new HashSet<int> { 1, 2, 3 };
    private ICollection        <int>? _iCollection           = [ 1, 2, 3 ];
    private IReadOnlyList      <int>? _iReadOnlyList         = [ 1, 2, 3 ];
    private IReadOnlyCollection<int>? _iReadOnlyCollection   = [ 1, 2, 3 ];
    private IEnumerable        <int>? _iEnumerable           = [ 1, 2, 3 ];
    
    [TestMethod]
    public void FilledIn_Collections_True()
    {
        IsTrue(Has(_array));
        IsTrue(Has(_list));
        IsTrue(Has(_hashSet));
        IsTrue(Has(_iList));
        IsTrue(Has(_iSet));
        IsTrue(Has(_iCollection));
        IsTrue(Has(_iReadOnlyList));
        IsTrue(Has(_iReadOnlyCollection));
        IsTrue(Has(_iEnumerable));
        IsTrue(_array.FilledIn());
        IsTrue(_list.FilledIn());
        IsTrue(_hashSet.FilledIn());
        IsTrue(_iList.FilledIn());
        IsTrue(_iSet.FilledIn());
        IsTrue(_iCollection.FilledIn());
        IsTrue(_iReadOnlyList.FilledIn());
        IsTrue(_iReadOnlyCollection.FilledIn());
        IsTrue(_iEnumerable.FilledIn());
        IsTrue(FilledIn(_array));
        IsTrue(FilledIn(_list));
        IsTrue(FilledIn(_hashSet));
        IsTrue(FilledIn(_iList));
        IsTrue(FilledIn(_iSet));
        IsTrue(FilledIn(_iCollection));
        IsTrue(FilledIn(_iReadOnlyList));
        IsTrue(FilledIn(_iReadOnlyCollection));
        IsTrue(FilledIn(_iEnumerable));
    }
        
    [TestMethod]
    public void FilledIn_Collections_False()
    {
        IsFalse(Has(_emptyArray));
        IsFalse(Has(_emptyList));
        IsFalse(Has(_emptyHashSet));
        IsFalse(Has(_emptyIList));
        IsFalse(Has(_emptyISet));
        IsFalse(Has(_emptyICollection));
        IsFalse(Has(_emptyIReadOnlyList));
        IsFalse(Has(_emptyIReadOnlyCollection));
        IsFalse(Has(_emptyIEnumerable));
        IsFalse(_emptyArray.FilledIn());
        IsFalse(_emptyList.FilledIn());
        IsFalse(_emptyHashSet.FilledIn());
        IsFalse(_emptyIList.FilledIn());
        IsFalse(_emptyISet.FilledIn());
        IsFalse(_emptyICollection.FilledIn());
        IsFalse(_emptyIReadOnlyList.FilledIn());
        IsFalse(_emptyIReadOnlyCollection.FilledIn());
        IsFalse(_emptyIEnumerable.FilledIn());
        IsFalse(FilledIn(_emptyArray));
        IsFalse(FilledIn(_emptyList));
        IsFalse(FilledIn(_emptyHashSet));
        IsFalse(FilledIn(_emptyIList));
        IsFalse(FilledIn(_emptyISet));
        IsFalse(FilledIn(_emptyICollection));
        IsFalse(FilledIn(_emptyIReadOnlyList));
        IsFalse(FilledIn(_emptyIReadOnlyCollection));
        IsFalse(FilledIn(_emptyIEnumerable));
    }
    
    [TestMethod]
    public void IsNully_Collections_False()
    {
        IsFalse(_array.IsNully());
        IsFalse(_list.IsNully());
        IsFalse(_hashSet.IsNully());
        IsFalse(_iList.IsNully());
        IsFalse(_iSet.IsNully());
        IsFalse(_iCollection.IsNully());
        IsFalse(_iReadOnlyList.IsNully());
        IsFalse(_iReadOnlyCollection.IsNully());
        IsFalse(_iEnumerable.IsNully());
        IsFalse(IsNully(_array));
        IsFalse(IsNully(_list));
        IsFalse(IsNully(_hashSet));
        IsFalse(IsNully(_iList));
        IsFalse(IsNully(_iSet));
        IsFalse(IsNully(_iCollection));
        IsFalse(IsNully(_iReadOnlyList));
        IsFalse(IsNully(_iReadOnlyCollection));
        IsFalse(IsNully(_iEnumerable));
    }
    
    [TestMethod]
    public void IsNully_Collections_True()
    {
        IsTrue(_emptyArray.IsNully());
        IsTrue(_emptyList.IsNully());
        IsTrue(_emptyHashSet.IsNully());
        IsTrue(_emptyIList.IsNully());
        IsTrue(_emptyISet.IsNully());
        IsTrue(_emptyICollection.IsNully());
        IsTrue(_emptyIReadOnlyList.IsNully());
        IsTrue(_emptyIReadOnlyCollection.IsNully());
        IsTrue(_emptyIEnumerable.IsNully());
        IsTrue(IsNully(_emptyArray));
        IsTrue(IsNully(_emptyList));
        IsTrue(IsNully(_emptyHashSet));
        IsTrue(IsNully(_emptyIList));
        IsTrue(IsNully(_emptyISet));
        IsTrue(IsNully(_emptyICollection));
        IsTrue(IsNully(_emptyIReadOnlyList));
        IsTrue(IsNully(_emptyIReadOnlyCollection));
        IsTrue(IsNully(_emptyIEnumerable));
    }
    
    [TestMethod]
    public void FilledIn_MethodResolution_Object_Over_GenericInterface_Regression()
    {
        // ImmutableArray<T> works out even with fallback to plain T - default(T) apparently is an empty collection (because it is a struct?)
        {
            var filled = new ImmutableArray<int> [ 1, 2, 3 ];
            IsTrue(FilledIn(filled));

            var empty = new ImmutableArray<int>();
            IsFalse(FilledIn(empty));
            
        }
        
        // Interface IList<T> is supported:
        {
            IList<int> filled = ImmutableList.Create(1, 2, 3);
            IsTrue(FilledIn(filled));

            IList<int> empty = ImmutableList.Create<int>();
            IsFalse(FilledIn(empty));
        }
        
        // ImmutableList is a class => non-supported collection type - failed.
        {
            ImmutableList<int> filled = ImmutableList.Create(1, 2, 3);
            IsTrue(FilledIn(filled));

            ImmutableList<int> empty = ImmutableList.Create<int>();
            //ThrowsException(() => IsFalse(FilledIn(empty)));
            IsFalse(FilledIn(empty)); // Fixed!
        }
    }
}
