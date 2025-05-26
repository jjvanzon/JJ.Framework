using System.Collections.Immutable;
using System.Globalization;
using static System.Globalization.CultureInfo;

// ReSharper disable RedundantEmptyObjectOrCollectionInitializer
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
    // - [x] Reference Types (StringBuilder)
    // - [x] Nullable reference types (StringBuilder?)
    // - [x] ~ Coalescing from collection to collection
    // - [x] Collection types
    // - [x] Trim tolerance
    // - [x] Static variant
    // - [x] Extension variant
    // - [ ] Enum
    // - [ ] Enum?
    // - [ ] double
    // - [ ] bool
    // - [ ] .. Coalesce arities
    
    string?        NullText       = null;
    string?        NullyEmpty     = "";
    string?        NullySpace     = " ";
    string?        NullyWithText  = "Hi";
    string         NonNullEmpty   = "";
    string         NonNullSpace   = " ";
    string         NonNullText    = "Hello";
    int?           NullNum        = null;
    int?           Nully0         = 0;
    int?           Nully1         = 1;
    int?           Nully2         = 2;
    int?           Nully3         = 3;
    int?           Nully4         = 4;
    int            NonNull0       = 0;
    int            NonNull1       = 1;
    int            NonNull2       = 2;
    int            NonNull3       = 3;
    int            NonNull4       = 4;
    StringBuilder? NullObject     = null;
    StringBuilder  NonNullObject  = new();
    StringBuilder? NullableFilled = new();

    [TestMethod]
    public void FilledIn_Text_True()
    {
        IsTrue(Has(NullyWithText));
        IsTrue(Has(NonNullText));
        IsTrue(FilledIn(NullyWithText));
        IsTrue(FilledIn(NonNullText));
        IsTrue(NullyWithText.FilledIn());
        IsTrue(NonNullText.FilledIn());
    }

    [TestMethod]
    public void FilledIn_Text_False()
    {
        IsFalse(Has(NullText));
        IsFalse(Has(NullyEmpty));
        IsFalse(Has(NullySpace));
        IsFalse(Has(NonNullEmpty));
        IsFalse(Has(NonNullSpace));
        IsFalse(FilledIn(NullText));
        IsFalse(FilledIn(NullyEmpty));
        IsFalse(FilledIn(NullySpace));
        IsFalse(FilledIn(NonNullEmpty));
        IsFalse(FilledIn(NonNullSpace));
        IsFalse(NullText.FilledIn());
        IsFalse(NullyEmpty.FilledIn());
        IsFalse(NullySpace.FilledIn());
        IsFalse(NonNullEmpty.FilledIn());
        IsFalse(NonNullSpace.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Text_False()
    {
        IsFalse(IsNully(NullyWithText));
        IsFalse(IsNully(NonNullText));
        IsFalse(NullyWithText.IsNully());
        IsFalse(NonNullText.IsNully());
    }

    [TestMethod] 
    public void IsNully_Text_True()
    {
        IsTrue(IsNully(NullText));
        IsTrue(IsNully(NullyEmpty));
        IsTrue(IsNully(NullySpace));
        IsTrue(IsNully(NonNullEmpty));
        IsTrue(IsNully(NonNullSpace));
        IsTrue(NullText.IsNully());
        IsTrue(NullyEmpty.IsNully());
        IsTrue(NullySpace.IsNully());
        IsTrue(NonNullEmpty.IsNully());
        IsTrue(NonNullSpace.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Text_TrimSpace()
    {
        IsFalse(NullySpace.IsNully(trimSpace: false));
        IsFalse(NullySpace.IsNully(false));
        IsFalse(NonNullSpace.IsNully(trimSpace: false));
        IsFalse(NonNullSpace.IsNully(false));
        IsFalse(IsNully(NullySpace, trimSpace: false));
        IsFalse(IsNully(NullySpace, false));
        IsFalse(IsNully(NonNullSpace, trimSpace: false));
        IsFalse(IsNully(NonNullSpace, false));
    }
        
    [TestMethod]
    public void FilledIn_Text_TrimSpace()
    {
        IsTrue(Has(NullySpace, trimSpace: false));
        IsTrue(Has(NullySpace, false));
        IsTrue(Has(NonNullSpace, trimSpace: false));
        IsTrue(Has(NonNullSpace, false));
        IsTrue(NullySpace.FilledIn(trimSpace: false));
        IsTrue(NullySpace.FilledIn(false));
        IsTrue(NonNullSpace.FilledIn(trimSpace: false));
        IsTrue(NonNullSpace.FilledIn(false));
        IsTrue(FilledIn(NullySpace, trimSpace: false));
        IsTrue(FilledIn(NullySpace, false));
        IsTrue(FilledIn(NonNullSpace, trimSpace: false));
        IsTrue(FilledIn(NonNullSpace, false));
    }
    
    [TestMethod]
    public void FilledIn_Int_True()
    {
        IsTrue(Has(NonNull1));
        IsTrue(Has(Nully1));
        IsTrue(NonNull1.FilledIn());
        IsTrue(Nully1.FilledIn());
        IsTrue(FilledIn(NonNull1));
        IsTrue(FilledIn(Nully1));
    }
    
    [TestMethod]
    public void FilledIn_Int_False()
    {
        IsFalse(Has(NullNum));
        IsFalse(Has(NonNull0));
        IsFalse(Has(Nully0));
        IsFalse(NullNum.FilledIn());
        IsFalse(NonNull0.FilledIn());
        IsFalse(Nully0.FilledIn());
        IsFalse(FilledIn(NullNum));
        IsFalse(FilledIn(NonNull0));
        IsFalse(FilledIn(Nully0));
    }
        
    [TestMethod]
    public void IsNully_Int_False()
    {
        IsFalse(NonNull1.IsNully());
        IsFalse(Nully1.IsNully());
        IsFalse(IsNully(NonNull1));
        IsFalse(IsNully(Nully1));
    }
    
    [TestMethod]
    public void IsNully_Int_True()
    {
        IsTrue(NullNum.IsNully());
        IsTrue(NonNull0.IsNully());
        IsTrue(Nully0.IsNully());
        IsTrue(IsNully(NullNum));
        IsTrue(IsNully(NonNull0));
        IsTrue(IsNully(Nully0));
    }
    
    [TestMethod]
    public void FilledIn_Object_True()
    {
        IsTrue(Has(NonNullObject));
        IsTrue(Has(NullableFilled));
        IsTrue(FilledIn(NonNullObject));
        IsTrue(FilledIn(NullableFilled));
        IsTrue(NonNullObject.FilledIn());
        IsTrue(NullableFilled.FilledIn());
    }
    
    [TestMethod]
    public void FilledIn_Object_False()
    {
        IsFalse(Has(NullObject));
        IsFalse(FilledIn(NullObject));
        IsFalse(NullObject.FilledIn());
    }
    
    [TestMethod]
    public void IsNully_Object_False()
    {
        IsFalse(IsNully(NonNullObject));
        IsFalse(IsNully(NullableFilled));
        IsFalse(NonNullObject.IsNully());
        IsFalse(NullableFilled.IsNully());
    }
    
    [TestMethod]
    public void IsNully_Object_True()
    {
        IsTrue(IsNully(NullObject));
        IsTrue(NullObject.IsNully());
    }
    
    private int[]?                    FilledArray                      = [ 1, 2, 3 ];
    private List               <int>  FilledList                       = [ 1, 2, 3 ];
    private HashSet            <int>  FilledHashSet                    = [ 1, 2, 3 ];
    private IList              <int>  FilledIList                      = [ 1, 2, 3 ];
    private ISet               <int>  FilledISet      = new HashSet<int> { 1, 2, 3 };
    private ICollection        <int>  FilledICollection                = [ 1, 2, 3 ];
    private IReadOnlyList      <int>  FilledIReadOnlyList              = [ 1, 2, 3 ];
    private IReadOnlyCollection<int>  FilledIReadOnlyCollection        = [ 1, 2, 3 ];
    private IEnumerable        <int>  FilledIEnumerable                = [ 1, 2, 3 ];
    
    private int[]?                    NullyFilledArray                 = [ 1, 2, 3 ];
    private List               <int>? NullyFilledList                  = [ 1, 2, 3 ];
    private HashSet            <int>? NullyFilledHashSet               = [ 1, 2, 3 ];
    private IList              <int>? NullyFilledIList                 = [ 1, 2, 3 ];
    private ISet               <int>? NullyFilledISet = new HashSet<int> { 1, 2, 3 };
    private ICollection        <int>? NullyFilledICollection           = [ 1, 2, 3 ];
    private IReadOnlyList      <int>? NullyFilledIReadOnlyList         = [ 1, 2, 3 ];
    private IReadOnlyCollection<int>? NullyFilledIReadOnlyCollection   = [ 1, 2, 3 ];
    private IEnumerable        <int>? NullyFilledIEnumerable           = [ 1, 2, 3 ];
    
    private int[]                     EmptyArray                       = [ ];
    private List               <int>  EmptyList                        = [ ];
    private HashSet            <int>  EmptyHashSet                     = [ ];
    private IList              <int>  EmptyIList                       = [ ];
    private ISet               <int>  EmptyISet       = new HashSet<int> { };
    private ICollection        <int>  EmptyICollection                 = [ ];
    private IReadOnlyList      <int>  EmptyIReadOnlyList               = [ ];
    private IReadOnlyCollection<int>  EmptyIReadOnlyCollection         = [ ];
    private IEnumerable        <int>  EmptyIEnumerable                 = [ ];
    
    private int[]?                    NullableEmptyArray                  = [ ];
    private List               <int>? NullableEmptyList                   = [ ];
    private HashSet            <int>? NullableEmptyHashSet                = [ ];
    private IList              <int>? NullableEmptyIList                  = [ ];
    private ISet               <int>? NullableEmptyISet  = new HashSet<int> { };
    private ICollection        <int>? NullableEmptyICollection            = [ ];
    private IReadOnlyList      <int>? NullableEmptyIReadOnlyList          = [ ];
    private IReadOnlyCollection<int>? NullableEmptyIReadOnlyCollection    = [ ];
    private IEnumerable        <int>? NullableEmptyIEnumerable            = [ ];
    
    private int[]?                    NullArray                        = null;
    private List               <int>? NullList                         = null;
    private HashSet            <int>? NullHashSet                      = null;
    private IList              <int>? NullIList                        = null;
    private ISet               <int>? NullISet                         = null;
    private ICollection        <int>? NullICollection                  = null;
    private IReadOnlyList      <int>? NullIReadOnlyList                = null;
    private IReadOnlyCollection<int>? NullIReadOnlyCollection          = null;
    private IEnumerable        <int>? NullIEnumerable                  = null;
    
    [TestMethod]
    public void FilledIn_Collections_True()
    {
        {
            IsTrue(Has(FilledArray));
            IsTrue(Has(FilledList));
            IsTrue(Has(FilledHashSet));
            IsTrue(Has(FilledIList));
            IsTrue(Has(FilledISet));
            IsTrue(Has(FilledICollection));
            IsTrue(Has(FilledIReadOnlyList));
            IsTrue(Has(FilledIReadOnlyCollection));
            IsTrue(Has(FilledIEnumerable));
            IsTrue(FilledArray.FilledIn());
            IsTrue(FilledList.FilledIn());
            IsTrue(FilledHashSet.FilledIn());
            IsTrue(FilledIList.FilledIn());
            IsTrue(FilledISet.FilledIn());
            IsTrue(FilledICollection.FilledIn());
            IsTrue(FilledIReadOnlyList.FilledIn());
            IsTrue(FilledIReadOnlyCollection.FilledIn());
            IsTrue(FilledIEnumerable.FilledIn());
            IsTrue(FilledIn(FilledArray));
            IsTrue(FilledIn(FilledList));
            IsTrue(FilledIn(FilledHashSet));
            IsTrue(FilledIn(FilledIList));
            IsTrue(FilledIn(FilledISet));
            IsTrue(FilledIn(FilledICollection));
            IsTrue(FilledIn(FilledIReadOnlyList));
            IsTrue(FilledIn(FilledIReadOnlyCollection));
            IsTrue(FilledIn(FilledIEnumerable));
        }
        {
            IsTrue(Has(NullyFilledArray));
            IsTrue(Has(NullyFilledList));
            IsTrue(Has(NullyFilledHashSet));
            IsTrue(Has(NullyFilledIList));
            IsTrue(Has(NullyFilledISet));
            IsTrue(Has(NullyFilledICollection));
            IsTrue(Has(NullyFilledIReadOnlyList));
            IsTrue(Has(NullyFilledIReadOnlyCollection));
            IsTrue(Has(NullyFilledIEnumerable));
            IsTrue(NullyFilledArray.FilledIn());
            IsTrue(NullyFilledList.FilledIn());
            IsTrue(NullyFilledHashSet.FilledIn());
            IsTrue(NullyFilledIList.FilledIn());
            IsTrue(NullyFilledISet.FilledIn());
            IsTrue(NullyFilledICollection.FilledIn());
            IsTrue(NullyFilledIReadOnlyList.FilledIn());
            IsTrue(NullyFilledIReadOnlyCollection.FilledIn());
            IsTrue(NullyFilledIEnumerable.FilledIn());
            IsTrue(FilledIn(NullyFilledArray));
            IsTrue(FilledIn(NullyFilledList));
            IsTrue(FilledIn(NullyFilledHashSet));
            IsTrue(FilledIn(NullyFilledIList));
            IsTrue(FilledIn(NullyFilledISet));
            IsTrue(FilledIn(NullyFilledICollection));
            IsTrue(FilledIn(NullyFilledIReadOnlyList));
            IsTrue(FilledIn(NullyFilledIReadOnlyCollection));
            IsTrue(FilledIn(NullyFilledIEnumerable));
        }
    }
        
    [TestMethod]
    public void FilledIn_Collections_False()
    {
        {
            IsFalse(Has(EmptyArray));
            IsFalse(Has(EmptyList));
            IsFalse(Has(EmptyHashSet));
            IsFalse(Has(EmptyIList));
            IsFalse(Has(EmptyISet));
            IsFalse(Has(EmptyICollection));
            IsFalse(Has(EmptyIReadOnlyList));
            IsFalse(Has(EmptyIReadOnlyCollection));
            IsFalse(Has(EmptyIEnumerable));
            IsFalse(EmptyArray.FilledIn());
            IsFalse(EmptyList.FilledIn());
            IsFalse(EmptyHashSet.FilledIn());
            IsFalse(EmptyIList.FilledIn());
            IsFalse(EmptyISet.FilledIn());
            IsFalse(EmptyICollection.FilledIn());
            IsFalse(EmptyIReadOnlyList.FilledIn());
            IsFalse(EmptyIReadOnlyCollection.FilledIn());
            IsFalse(EmptyIEnumerable.FilledIn());
            IsFalse(FilledIn(EmptyArray));
            IsFalse(FilledIn(EmptyList));
            IsFalse(FilledIn(EmptyHashSet));
            IsFalse(FilledIn(EmptyIList));
            IsFalse(FilledIn(EmptyISet));
            IsFalse(FilledIn(EmptyICollection));
            IsFalse(FilledIn(EmptyIReadOnlyList));
            IsFalse(FilledIn(EmptyIReadOnlyCollection));
            IsFalse(FilledIn(EmptyIEnumerable));
        }
        {
            IsFalse(Has(NullableEmptyArray));
            IsFalse(Has(NullableEmptyList));
            IsFalse(Has(NullableEmptyHashSet));
            IsFalse(Has(NullableEmptyIList));
            IsFalse(Has(NullableEmptyISet));
            IsFalse(Has(NullableEmptyICollection));
            IsFalse(Has(NullableEmptyIReadOnlyList));
            IsFalse(Has(NullableEmptyIReadOnlyCollection));
            IsFalse(Has(NullableEmptyIEnumerable));
            IsFalse(NullableEmptyArray.FilledIn());
            IsFalse(NullableEmptyList.FilledIn());
            IsFalse(NullableEmptyHashSet.FilledIn());
            IsFalse(NullableEmptyIList.FilledIn());
            IsFalse(NullableEmptyISet.FilledIn());
            IsFalse(NullableEmptyICollection.FilledIn());
            IsFalse(NullableEmptyIReadOnlyList.FilledIn());
            IsFalse(NullableEmptyIReadOnlyCollection.FilledIn());
            IsFalse(NullableEmptyIEnumerable.FilledIn());
            IsFalse(FilledIn(NullableEmptyArray));
            IsFalse(FilledIn(NullableEmptyList));
            IsFalse(FilledIn(NullableEmptyHashSet));
            IsFalse(FilledIn(NullableEmptyIList));
            IsFalse(FilledIn(NullableEmptyISet));
            IsFalse(FilledIn(NullableEmptyICollection));
            IsFalse(FilledIn(NullableEmptyIReadOnlyList));
            IsFalse(FilledIn(NullableEmptyIReadOnlyCollection));
            IsFalse(FilledIn(NullableEmptyIEnumerable));
        }
        {
            IsFalse(Has(NullArray));
            IsFalse(Has(NullList));
            IsFalse(Has(NullHashSet));
            IsFalse(Has(NullIList));
            IsFalse(Has(NullISet));
            IsFalse(Has(NullICollection));
            IsFalse(Has(NullIReadOnlyList));
            IsFalse(Has(NullIReadOnlyCollection));
            IsFalse(Has(NullIEnumerable));
            IsFalse(NullArray.FilledIn());
            IsFalse(NullList.FilledIn());
            IsFalse(NullHashSet.FilledIn());
            IsFalse(NullIList.FilledIn());
            IsFalse(NullISet.FilledIn());
            IsFalse(NullICollection.FilledIn());
            IsFalse(NullIReadOnlyList.FilledIn());
            IsFalse(NullIReadOnlyCollection.FilledIn());
            IsFalse(NullIEnumerable.FilledIn());
            IsFalse(FilledIn(NullArray));
            IsFalse(FilledIn(NullList));
            IsFalse(FilledIn(NullHashSet));
            IsFalse(FilledIn(NullIList));
            IsFalse(FilledIn(NullISet));
            IsFalse(FilledIn(NullICollection));
            IsFalse(FilledIn(NullIReadOnlyList));
            IsFalse(FilledIn(NullIReadOnlyCollection));
            IsFalse(FilledIn(NullIEnumerable));
        }
    }
    
    [TestMethod]
    public void IsNully_Collections_False()
    {
        {
            IsFalse(FilledArray.IsNully());
            IsFalse(FilledList.IsNully());
            IsFalse(FilledHashSet.IsNully());
            IsFalse(FilledIList.IsNully());
            IsFalse(FilledISet.IsNully());
            IsFalse(FilledICollection.IsNully());
            IsFalse(FilledIReadOnlyList.IsNully());
            IsFalse(FilledIReadOnlyCollection.IsNully());
            IsFalse(FilledIEnumerable.IsNully());
            IsFalse(IsNully(FilledArray));
            IsFalse(IsNully(FilledList));
            IsFalse(IsNully(FilledHashSet));
            IsFalse(IsNully(FilledIList));
            IsFalse(IsNully(FilledISet));
            IsFalse(IsNully(FilledICollection));
            IsFalse(IsNully(FilledIReadOnlyList));
            IsFalse(IsNully(FilledIReadOnlyCollection));
            IsFalse(IsNully(FilledIEnumerable));
        }
        {
            IsFalse(NullyFilledArray.IsNully());
            IsFalse(NullyFilledList.IsNully());
            IsFalse(NullyFilledHashSet.IsNully());
            IsFalse(NullyFilledIList.IsNully());
            IsFalse(NullyFilledISet.IsNully());
            IsFalse(NullyFilledICollection.IsNully());
            IsFalse(NullyFilledIReadOnlyList.IsNully());
            IsFalse(NullyFilledIReadOnlyCollection.IsNully());
            IsFalse(NullyFilledIEnumerable.IsNully());
            IsFalse(IsNully(NullyFilledArray));
            IsFalse(IsNully(NullyFilledList));
            IsFalse(IsNully(NullyFilledHashSet));
            IsFalse(IsNully(NullyFilledIList));
            IsFalse(IsNully(NullyFilledISet));
            IsFalse(IsNully(NullyFilledICollection));
            IsFalse(IsNully(NullyFilledIReadOnlyList));
            IsFalse(IsNully(NullyFilledIReadOnlyCollection));
            IsFalse(IsNully(NullyFilledIEnumerable));
        }
    }
    
    [TestMethod]
    public void IsNully_Collections_True()
    {
        {
            IsTrue(EmptyArray.IsNully());
            IsTrue(EmptyList.IsNully());
            IsTrue(EmptyHashSet.IsNully());
            IsTrue(EmptyIList.IsNully());
            IsTrue(EmptyISet.IsNully());
            IsTrue(EmptyICollection.IsNully());
            IsTrue(EmptyIReadOnlyList.IsNully());
            IsTrue(EmptyIReadOnlyCollection.IsNully());
            IsTrue(EmptyIEnumerable.IsNully());
            IsTrue(IsNully(EmptyArray));
            IsTrue(IsNully(EmptyList));
            IsTrue(IsNully(EmptyHashSet));
            IsTrue(IsNully(EmptyIList));
            IsTrue(IsNully(EmptyISet));
            IsTrue(IsNully(EmptyICollection));
            IsTrue(IsNully(EmptyIReadOnlyList));
            IsTrue(IsNully(EmptyIReadOnlyCollection));
            IsTrue(IsNully(EmptyIEnumerable));
        }
        {
            IsTrue(NullableEmptyArray.IsNully());
            IsTrue(NullableEmptyList.IsNully());
            IsTrue(NullableEmptyHashSet.IsNully());
            IsTrue(NullableEmptyIList.IsNully());
            IsTrue(NullableEmptyISet.IsNully());
            IsTrue(NullableEmptyICollection.IsNully());
            IsTrue(NullableEmptyIReadOnlyList.IsNully());
            IsTrue(NullableEmptyIReadOnlyCollection.IsNully());
            IsTrue(NullableEmptyIEnumerable.IsNully());
            IsTrue(IsNully(NullableEmptyArray));
            IsTrue(IsNully(NullableEmptyList));
            IsTrue(IsNully(NullableEmptyHashSet));
            IsTrue(IsNully(NullableEmptyIList));
            IsTrue(IsNully(NullableEmptyISet));
            IsTrue(IsNully(NullableEmptyICollection));
            IsTrue(IsNully(NullableEmptyIReadOnlyList));
            IsTrue(IsNully(NullableEmptyIReadOnlyCollection));
            IsTrue(IsNully(NullableEmptyIEnumerable));
        }
        {
            IsTrue(NullArray.IsNully());
            IsTrue(NullList.IsNully());
            IsTrue(NullHashSet.IsNully());
            IsTrue(NullIList.IsNully());
            IsTrue(NullISet.IsNully());
            IsTrue(NullICollection.IsNully());
            IsTrue(NullIReadOnlyList.IsNully());
            IsTrue(NullIReadOnlyCollection.IsNully());
            IsTrue(NullIEnumerable.IsNully());
            IsTrue(IsNully(NullArray));
            IsTrue(IsNully(NullList));
            IsTrue(IsNully(NullHashSet));
            IsTrue(IsNully(NullIList));
            IsTrue(IsNully(NullISet));
            IsTrue(IsNully(NullICollection));
            IsTrue(IsNully(NullIReadOnlyList));
            IsTrue(IsNully(NullIReadOnlyCollection));
            IsTrue(IsNully(NullIEnumerable));
        }
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
    
    [TestMethod]
    public void Test_String_Is()
    {
        // NullOrWhiteSpace
        IsTrue(Is(null,   null  ));
        IsTrue(Is(" " ,   null  ));
        IsTrue(   " " .Is(null  ));
        IsTrue(Is(""  ,   " "   ));
        IsTrue(   ""  .Is(" "   ));
        IsTrue(Is(""  ,   "  \t"));
        IsTrue(   ""  .Is("  \t"));
        
        // Ignore Case
        IsTrue(Is("test",   "test"));
        IsTrue(Is("test",   "test", ignoreCase: true));
        IsTrue(   "test".Is("test"));
        IsTrue(   "test".Is("test", ignoreCase: true));
        IsTrue(Is("test",   "TEST"));
        IsTrue(Is("test",   "TEST", ignoreCase: true));
        IsTrue(   "test".Is("TEST"));
        IsTrue(   "test".Is("TEST", ignoreCase: true));
        IsTrue(Is("TEST",   "test"));
        IsTrue(Is("TEST",   "test", ignoreCase: true));
        IsTrue(   "TEST".Is("test"));
        IsTrue(   "TEST".Is("test", ignoreCase: true));
        
        // Bunch of white space and case mismatch
        IsTrue(Is("test",   "\r\n \t TEST  \n"));
        IsTrue(Is("test",   "\r\n \t TEST  \n", ignoreCase: true));
        IsTrue(   "test".Is("\r\n \t TEST  \n"));
        IsTrue(   "test".Is("\r\n \t TEST  \n", ignoreCase: true));
        IsTrue(Is("\r\n \t TEST  \n",   "test"));
        IsTrue(Is("\r\n \t TEST  \n",   "test", ignoreCase: true));
        IsTrue(   "\r\n \t TEST  \n".Is("test"));
        IsTrue(   "\r\n \t TEST  \n".Is("test", ignoreCase: true));
        
        // Excess white space
        string a = "I am a STRING .  ";
        string b = "   i am a string    . \t";
        IsTrue(a.Is(b));
        IsTrue(a.Is(b,  ignoreCase: true));
        IsTrue(Is(a, b));
        IsTrue(Is(a, b, ignoreCase: true));
        
        // Case sensitive
        IsFalse("TEST".Is("test", ignoreCase: false));
        IsFalse(Is("test", "Test", ignoreCase: false));

        // Negative match
        IsFalse("Plant".Is("Animal"));
        IsFalse(Is("Animal", "Plant"));

        // Diacritics
        string c = "   i ÂM ã string   . \t";
        IsTrue(a.Is(c));
        IsTrue(c.Is(a));
        IsTrue(Is(a, c));
        IsTrue(Is(c, a));
    }
    
    [TestMethod]
    public void In_Strings()
    {
        // Main Use
        IsTrue (In("GREEN" ,                        "Red", "Green", "Blue"                     ));
        IsTrue (   "GREEN" .In(                     "Red", "Green", "Blue"                     ));
        
        // Collection Expressions
        IsTrue (In("GREEN" ,                      [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "GREEN" .In(                   [ "Red", "Green", "Blue" ]                   ));
        
        // Ignore Case (default behavior)
        IsTrue (In("GREEN" ,   ignoreCase: true,    "Red", "Green", "Blue"                     ));
        IsTrue (   "GREEN" .In(ignoreCase: true,    "Red", "Green", "Blue"                     ));
        IsTrue (In("GREEN" ,   ignoreCase: true,  [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "GREEN" .In(ignoreCase: true,  [ "Red", "Green", "Blue" ]                   ));
        IsTrue (In("GREEN" ,                      [ "Red", "Green", "Blue" ], ignoreCase: true ));
        IsTrue (   "GREEN" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: true ));
        
        // Match case
        IsFalse(In("GREEN" ,   ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsFalse(   "GREEN" .In(ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsFalse(In("GREEN" ,   ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsFalse(   "GREEN" .In(ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsFalse(In("GREEN" ,                      [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsFalse(   "GREEN" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsTrue (In("Green" ,   ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsTrue (   "Green" .In(ignoreCase: false,   "Red", "Green", "Blue"                     ));
        IsTrue (In("Green" ,   ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsTrue (   "Green" .In(ignoreCase: false, [ "Red", "Green", "Blue" ]                   ));
        IsTrue (In("Green" ,                      [ "Red", "Green", "Blue" ], ignoreCase: false));
        IsTrue (   "Green" .In(                   [ "Red", "Green", "Blue" ], ignoreCase: false));
        
        // Negative match
        IsFalse(In("Yellow",                        "Red", "Green", "Blue"                     ));
        IsFalse(   "Yellow".In(                     "Red", "Green", "Blue"                     ));
        IsFalse(In("Yellow",                      [ "Red", "Green", "Blue" ]                   ));
        IsFalse(   "Yellow".In(                   [ "Red", "Green", "Blue" ]                   ));
        
        // TODO: Test nulls
    }
    
    [TestMethod]
    public void In_Objects()
    {
        StringBuilder a = new();
        StringBuilder b = new();
        StringBuilder c = new();
        StringBuilder d = new();
        
        IsTrue (a.In(     a, b, c  ));
        IsTrue (b.In(     a, b, c  ));
        IsTrue (a.In(   [ a, b, c ]));
        IsTrue (b.In(   [ a, b, c ]));
        IsTrue (  In(a,   a, b, c  ));
        IsTrue (  In(b,   a, b, c  ));
        IsTrue (  In(a, [ a, b, c ]));
        IsTrue (  In(b, [ a, b, c ]));

        IsFalse(d.In(     a, b, c  ));
        IsFalse(d.In(   [ a, b, c ]));
        IsFalse(  In(d,   a, b, c  ));
        IsFalse(  In(d, [ a, b, c ]));
    }

    
    [TestMethod]
    public void In_Structs()
    {
        IsTrue (1.In(     1, 2, 3  ));
        IsTrue (2.In(     1, 2, 3  ));
        IsTrue (1.In(   [ 1, 2, 3 ]));
        IsTrue (2.In(   [ 1, 2, 3 ]));
        IsTrue (  In(1,   1, 2, 3  ));
        IsTrue (  In(2,   1, 2, 3  ));
        IsTrue (  In(1, [ 1, 2, 3 ]));
        IsTrue (  In(2, [ 1, 2, 3 ]));

        IsFalse(4.In(     1, 2, 3  ));
        IsFalse(4.In(   [ 1, 2, 3 ]));
        IsFalse(  In(4,   1, 2, 3  ));
        IsFalse(  In(4, [ 1, 2, 3 ]));
    }
    
    [TestMethod]
    public void In_Nully()
    {
        {
            StringBuilder a = new();
            StringBuilder b = new();
            object? _null = null;

            IsTrue (a    .In(a, b, _null));
            IsTrue (b    .In(a, b, _null));
            IsTrue (_null.In(a, b, _null));
            IsFalse(_null.In(a, b       ));
        }
        {
            int?[]? nullColl = null;
            int?[] emptyColl = [ ];
            
            IsTrue (      1.In(      1,      2,      3, NullNum));
            IsTrue (      2.In(      1,      2,      3, NullNum));
            IsTrue (      3.In(      1,      2,      3, NullNum));
            IsTrue ( Nully1.In(      1,      2,      3         ));
            IsTrue ( Nully2.In(      1,      2,      3         ));
            IsTrue ( Nully3.In(      1,      2,      3         ));
            IsTrue ( Nully1.In(      1,      2, Nully3         ));
            IsTrue ( Nully2.In(      1,      2, Nully3         ));
            IsTrue ( Nully3.In(      1,      2, Nully3         ));
            IsTrue (      1.In(      1,      2, Nully3         ));
            IsTrue (      2.In(      1,      2, Nully3         ));
            IsTrue (      3.In(      1,      2, Nully3         ));
            IsTrue (      1.In( Nully1, Nully2, Nully3         ));
            IsTrue (      2.In( Nully1, Nully2, Nully3         ));
            IsTrue (      3.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully1.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully2.In( Nully1, Nully2, Nully3         ));
            IsTrue ( Nully3.In( Nully1, Nully2, Nully3         ));
            IsTrue (NullNum.In(      1,      2,      3, NullNum));
            IsTrue (NullNum.In(      1,      2, Nully3, NullNum));
            IsTrue (NullNum.In( Nully1, Nully2, Nully3, NullNum));
            IsTrue (In(      1,      1,      2,      3, NullNum));
            IsTrue (In(      2,      1,      2,      3, NullNum));
            IsTrue (In(      3,      1,      2,      3, NullNum));
            IsTrue (In( Nully1,      1,      2,      3         ));
            IsTrue (In( Nully2,      1,      2,      3         ));
            IsTrue (In( Nully3,      1,      2,      3         ));
            IsTrue (In( Nully1,      1,      2, Nully3         ));
            IsTrue (In( Nully2,      1,      2, Nully3         ));
            IsTrue (In( Nully3,      1,      2, Nully3         ));
            IsTrue (In(      1,      1,      2, Nully3         ));
            IsTrue (In(      2,      1,      2, Nully3         ));
            IsTrue (In(      3,      1,      2, Nully3         ));
            IsTrue (In(      1, Nully1, Nully2, Nully3         ));
            IsTrue (In(      2, Nully1, Nully2, Nully3         ));
            IsTrue (In(      3, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully1, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully2, Nully1, Nully2, Nully3         ));
            IsTrue (In( Nully3, Nully1, Nully2, Nully3         ));
            IsTrue (In(NullNum,      1,      2,      3, NullNum));
            IsTrue (In(NullNum,      1,      2, Nully3, NullNum));
            IsTrue (In(NullNum, Nully1, Nully2, Nully3, NullNum));
            
            // Negative matches
            IsFalse(      4.In(      1,      2,      3, NullNum));
            IsFalse(      4.In(      1,      2, Nully3         ));
            IsFalse(      4.In( Nully1, Nully2, Nully3         ));
            IsFalse( Nully4.In(      1,      2,      3         ));
            IsFalse( Nully4.In(      1,      2, Nully3         ));
            IsFalse( Nully4.In( Nully1, Nully2, Nully3         ));
            IsFalse(NullNum.In(      1,      2,      3         ));
            IsFalse(NullNum.In(      1,      2, Nully3         ));
            IsFalse(NullNum.In( Nully1, Nully2, Nully3         ));
            IsFalse(In(     4,       1,      2,      3, NullNum));
            IsFalse(In(Nully4,       1,      2,      3         ));
            IsFalse(In(Nully4,       1,      2, Nully3         ));
            IsFalse(In(     4,       1,      2, Nully3         ));
            IsFalse(In(     4,  Nully1, Nully2, Nully3         ));
            IsFalse(In(Nully4,  Nully1, Nully2, Nully3         ));
            IsFalse(In(NullNum,      1,      2,      3         ));
            IsFalse(In(NullNum,      1,      2, Nully3         ));
            IsFalse(In(NullNum, Nully1, Nully2, Nully3         ));
            
            // Staring into the abyss
            IsFalse(   Nully1.In(nullColl));
            IsFalse(        1.In(NullNum  ));
            IsFalse(        1.In(nullColl));
            IsFalse(In(Nully1,   nullColl));
            IsFalse(In(     1,   NullNum  ));
            IsFalse(In(     1,   nullColl));
            
            // Very much null and empty
            IsTrue (   NullNum.In(NullNum   ));
            IsTrue (In(NullNum,   NullNum   ));
            IsFalse(   NullNum.In(emptyColl));
            IsFalse(In(NullNum,   emptyColl));
            IsFalse(   NullNum.In(nullColl ));
            IsFalse(In(NullNum,   nullColl ));
        }
    }
    
    /// <summary>
    /// <para>
    /// Gives you the <c>Type</c> the compiler thought this <c>value</c> was,
    /// before any automatic conversions or boxing.
    /// This allows us to differentiate between <c>int?</c> and <c>int</c>.
    /// </para>
    /// <para>
    /// For: <c>int? x = 1</c><br/>
    /// This: <c>x.GetType()</c> gives back <c>typeof(int)</c><br/>
    /// This: <c>CompileTimeType(x)</c> still gives back <c>typeof(int?)</c>
    /// </para>
    /// <para>
    /// That way we can inspect the nullability of our returned type,
    /// while the runtime was already so kind to remove the nullable wrapper for us.
    /// </para>
    /// </summary>
    static Type CompileTimeType<T>(T value) => typeof(T);

    [TestMethod]
    public void Plain_Coalesce()
    {
        {
            
            AreEqual(""   , NullText.Coalesce());
            AreEqual(""   , ""      .Coalesce());
            AreEqual("   ", "   "   .Coalesce());
            AreEqual("Hi" , "Hi"    .Coalesce());
            AreEqual(""   , Coalesce(NullText ));
            AreEqual(""   , Coalesce(""       ));
            AreEqual("   ", Coalesce("   "    ));
            AreEqual("Hi" , Coalesce("Hi"     ));
        }
        {
            AreEqual(0,            NullNum.Coalesce());
            AreEqual(0,            Coalesce(NullNum));
            AreEqual(typeof(int?), CompileTimeType(NullNum));
            AreEqual(typeof(int),  CompileTimeType(NullNum.Coalesce()));
            AreEqual(typeof(int),  CompileTimeType(Coalesce(NullNum)));
            
            AreEqual(0,            Nully0);
            AreEqual(0,            Nully0.Coalesce());
            AreEqual(0,            Coalesce(Nully0));
            AreEqual(typeof(int?), CompileTimeType(Nully0));
            AreEqual(typeof(int),  CompileTimeType(Nully0.Coalesce()));
            AreEqual(typeof(int),  CompileTimeType(Coalesce(Nully0)));
            
            AreEqual(1,            Nully1);
            AreEqual(1,            Nully1.Coalesce());
            AreEqual(1,            Coalesce(Nully1));
            AreEqual(typeof(int?), CompileTimeType(Nully1));
            AreEqual(typeof(int),  CompileTimeType(Nully1.Coalesce()));
            AreEqual(typeof(int),  CompileTimeType(Coalesce(Nully1)));
        }
        {
            int nonNull = 1;
            AreEqual(1,           nonNull);
            AreEqual(1,           nonNull.Coalesce());
            AreEqual(1,           Coalesce(nonNull));
            AreEqual(typeof(int), CompileTimeType(nonNull));
            AreEqual(typeof(int), CompileTimeType(nonNull.Coalesce()));
            AreEqual(typeof(int), CompileTimeType(Coalesce(nonNull)));
        }
        {
            NotNull(NonNullObject);
            NotNull(Coalesce(NonNullObject));
            NotNull(NonNullObject.Coalesce());
            
            IsNull (NullObject);
            NotNull(Coalesce(NullObject));
            NotNull(NullObject.Coalesce());
        }
        {
            List<string>? coll = null;
            List<string> result = Coalesce(coll);
            IsNull(coll);
            NotNull(result);
        }
    }
    
    [TestMethod]
    public void Coalesce_SingleFallback()
    {
        // Single Fallback String to String
        {
            AreEqual("",         Coalesce(NullText,  NullText ));
            AreEqual("Fallback", Coalesce(NullText, "Fallback"));
            AreEqual("Fallback", Coalesce("",       "Fallback"));
            AreEqual("Fallback", Coalesce("   ",    "Fallback"));
            AreEqual("Fallback", Coalesce(NullText, "Fallback", trimSpace: true ));
            AreEqual("Fallback", Coalesce("",       "Fallback", trimSpace: true ));
            AreEqual("Fallback", Coalesce("   ",    "Fallback", trimSpace: true ));
            AreEqual("Fallback", Coalesce(NullText, "Fallback", trimSpace: false));
            AreEqual("Fallback", Coalesce("",       "Fallback", trimSpace: false));
            AreEqual("   ",      Coalesce("   ",    "Fallback", trimSpace: false));
            
            AreEqual("",         NullText.Coalesce( NullText ));
            AreEqual("Fallback", NullText.Coalesce("Fallback"));
            AreEqual("Fallback", ""      .Coalesce("Fallback"));
            AreEqual("Fallback", "   "   .Coalesce("Fallback"));
            AreEqual("Fallback", NullText.Coalesce("Fallback", trimSpace: true ));
            AreEqual("Fallback", ""      .Coalesce("Fallback", trimSpace: true ));
            AreEqual("Fallback", "   "   .Coalesce("Fallback", trimSpace: true ));
            AreEqual("Fallback", NullText.Coalesce("Fallback", trimSpace: false));
            AreEqual("Fallback", ""      .Coalesce("Fallback", trimSpace: false));
            AreEqual("   ",      "   "   .Coalesce("Fallback", trimSpace: false));
        }
        // Single Fallback Object to String
        {
            CultureInfo? nullCulture = null;
            CultureInfo  culture = GetCultureInfo("nl-NL");
            AreEqual("nl-NL", Coalesce(culture,     "None"));
            AreEqual("None" , Coalesce(nullCulture, "None"));
            AreEqual(""     , Coalesce(nullCulture,  null ));
            AreEqual("nl-NL", culture    .Coalesce( "None"));
            AreEqual("None" , nullCulture.Coalesce( "None"));
            AreEqual(""     , nullCulture.Coalesce(  null ));
        }
        // Single Fallback Structs to String
        // With T
        {
            AreEqual("",           Coalesce(0,  NullText ));
            AreEqual("",           Coalesce(0,  NullText ));
            AreEqual("peekaboo",   Coalesce(0, "peekaboo"));
            AreEqual("",         0.Coalesce(    NullText ));
            AreEqual("peekaboo", 0.Coalesce(   "peekaboo"));
            AreEqual("1",        1.Coalesce(    NullText ));
            AreEqual("1",        1.Coalesce(   "peekaboo"));
        }
        // With T?
        {
            AreEqual("",    Coalesce(NullNum,  NullText));
            AreEqual("boo", Coalesce(NullNum, "boo"    ));
            AreEqual("",    Coalesce(Nully0,   NullText));
            AreEqual("boo", Coalesce(Nully0,  "boo"    ));
            AreEqual("1",   Coalesce(Nully1,   NullText));
            AreEqual("1",   Coalesce(Nully1,  "boo"    ));
            AreEqual("",    NullNum.Coalesce(  NullText));
            AreEqual("boo", NullNum.Coalesce( "boo"    ));
            AreEqual("",    Nully0 .Coalesce(  NullText));
            AreEqual("boo", Nully0 .Coalesce( "boo"    ));
            AreEqual("1",   Nully1 .Coalesce(  NullText));
            AreEqual("1",   Nully1 .Coalesce( "boo"    ));
        }
        // Single Fallback for Structs
        {
            // TODO: Does not compile
            //AreEqual(0, Coalesce( NullNum, null   ));
            //AreEqual(0, Coalesce(  Nully0, null   ));
            //AreEqual(1, Coalesce(  Nully1, null   ));
            //int? Nully2 = 2;
            // TODO: Doesn't compile without casting null.
            //AreEqual(2, Coalesce(  Nully2, null   ));
            //AreEqual(0, Coalesce(    null, null   ));
            //AreEqual(0, Coalesce(       0, null   ));
            //AreEqual(1, Coalesce(       1, null   ));
            //AreEqual(2, Coalesce(       2, null   ));
            AreEqual(0, Coalesce(    null, NullNum));
            AreEqual(0, Coalesce( NullNum, NullNum));
            AreEqual(0, Coalesce(  Nully0, NullNum));
            AreEqual(1, Coalesce(  Nully1, NullNum));
            AreEqual(2, Coalesce(  Nully2, NullNum));
            AreEqual(0, Coalesce(       0, NullNum));
            AreEqual(1, Coalesce(       1, NullNum));
            AreEqual(2, Coalesce(       2, NullNum));
            AreEqual(0, Coalesce(    null,  Nully0));
            AreEqual(0, Coalesce( NullNum,  Nully0));
            AreEqual(0, Coalesce(  Nully0,  Nully0));
            AreEqual(1, Coalesce(  Nully1,  Nully0));
            AreEqual(2, Coalesce(  Nully2,  Nully0));
            AreEqual(0, Coalesce(       0,  Nully0));
            AreEqual(1, Coalesce(       1,  Nully0));
            AreEqual(2, Coalesce(       2,  Nully0));
            AreEqual(1, Coalesce(    null,  Nully1));
            AreEqual(1, Coalesce( NullNum,  Nully1));
            AreEqual(1, Coalesce(  Nully0,  Nully1));
            AreEqual(1, Coalesce(  Nully1,  Nully1));
            AreEqual(2, Coalesce(  Nully2,  Nully1));
            AreEqual(1, Coalesce(       0,  Nully1));
            AreEqual(1, Coalesce(       1,  Nully1));
            AreEqual(2, Coalesce(       2,  Nully1));
            AreEqual(2, Coalesce(    null,  Nully2));
            AreEqual(2, Coalesce( NullNum,  Nully2));
            AreEqual(2, Coalesce(  Nully0,  Nully2));
            AreEqual(1, Coalesce(  Nully1,  Nully2));
            AreEqual(2, Coalesce(  Nully2,  Nully2));
            AreEqual(2, Coalesce(       0,  Nully2));
            AreEqual(1, Coalesce(       1,  Nully2));
            AreEqual(2, Coalesce(       2,  Nully2));
            AreEqual(0, Coalesce(    null,       0));
            AreEqual(0, Coalesce( NullNum,       0));
            AreEqual(0, Coalesce(  Nully0,       0));
            AreEqual(1, Coalesce(  Nully1,       0));
            AreEqual(2, Coalesce(  Nully2,       0));
            AreEqual(0, Coalesce(       0,       0));
            AreEqual(1, Coalesce(       1,       0));
            AreEqual(2, Coalesce(       2,       0));
            AreEqual(1, Coalesce(    null,       1));
            AreEqual(1, Coalesce( NullNum,       1));
            AreEqual(1, Coalesce(  Nully0,       1));
            AreEqual(1, Coalesce(  Nully1,       1));
            AreEqual(2, Coalesce(  Nully2,       1));
            AreEqual(1, Coalesce(       0,       1));
            AreEqual(1, Coalesce(       1,       1));
            AreEqual(2, Coalesce(       2,       1));
            AreEqual(2, Coalesce(    null,       2));
            AreEqual(2, Coalesce( NullNum,       2));
            AreEqual(2, Coalesce(  Nully0,       2));
            AreEqual(1, Coalesce(  Nully1,       2));
            AreEqual(2, Coalesce(  Nully2,       2));
            AreEqual(2, Coalesce(       0,       2));
            AreEqual(1, Coalesce(       1,       2));
            AreEqual(2, Coalesce(       2,       2));
            // TODO: Does not Compile
            //AreEqual(0,  NullNum.Coalesce( null   ));
            //AreEqual(0,   Nully0.Coalesce( null   ));
            //AreEqual(1,   Nully1.Coalesce( null   ));
            //AreEqual(2,   Nully2.Coalesce( null   ));
            //AreEqual(0,        0.Coalesce( null   ));
            //AreEqual(1,        1.Coalesce( null   ));
            //AreEqual(2,        2.Coalesce( null   ));
            //AreEqual(0,     null.Coalesce( NullNum)); // TODO: Does not Compile
            AreEqual(0,  NullNum.Coalesce( NullNum));
            AreEqual(0,   Nully0.Coalesce( NullNum));
            AreEqual(1,   Nully1.Coalesce( NullNum));
            AreEqual(2,   Nully2.Coalesce( NullNum));
            AreEqual(0,        0.Coalesce( NullNum));
            AreEqual(1,        1.Coalesce( NullNum));
            AreEqual(2,        2.Coalesce( NullNum));
            //AreEqual(0,     null.Coalesce(  Nully0)); // TODO: Does not Compile
            AreEqual(0,  NullNum.Coalesce(  Nully0));
            AreEqual(0,   Nully0.Coalesce(  Nully0));
            AreEqual(1,   Nully1.Coalesce(  Nully0));
            AreEqual(2,   Nully2.Coalesce(  Nully0));
            AreEqual(0,        0.Coalesce(  Nully0));
            AreEqual(1,        1.Coalesce(  Nully0));
            AreEqual(2,        2.Coalesce(  Nully0));
            //AreEqual(1,     null.Coalesce(  Nully1)); // TODO: Does not Compile
            AreEqual(1,  NullNum.Coalesce(  Nully1));
            AreEqual(1,   Nully0.Coalesce(  Nully1));
            AreEqual(1,   Nully1.Coalesce(  Nully1));
            AreEqual(2,   Nully2.Coalesce(  Nully1));
            AreEqual(1,        0.Coalesce(  Nully1));
            AreEqual(1,        1.Coalesce(  Nully1));
            AreEqual(2,        2.Coalesce(  Nully1));
            //AreEqual(2,     null.Coalesce(  Nully2)); // TODO: Does not Compile
            AreEqual(2,  NullNum.Coalesce(  Nully2));
            AreEqual(2,   Nully0.Coalesce(  Nully2));
            AreEqual(1,   Nully1.Coalesce(  Nully2));
            AreEqual(2,   Nully2.Coalesce(  Nully2));
            AreEqual(2,        0.Coalesce(  Nully2));
            AreEqual(1,        1.Coalesce(  Nully2));
            AreEqual(2,        2.Coalesce(  Nully2));
            //AreEqual(0,     null.Coalesce(       0)); // TODO: Does not Compile
            AreEqual(0,  NullNum.Coalesce(       0));
            AreEqual(0,   Nully0.Coalesce(       0));
            AreEqual(1,   Nully1.Coalesce(       0));
            AreEqual(2,   Nully2.Coalesce(       0));
            AreEqual(0,        0.Coalesce(       0));
            AreEqual(1,        1.Coalesce(       0));
            AreEqual(2,        2.Coalesce(       0));
            //AreEqual(1,     null.Coalesce(       1)); // TODO: Does not Compile
            AreEqual(1,  NullNum.Coalesce(       1));
            AreEqual(1,   Nully0.Coalesce(       1));
            AreEqual(1,   Nully1.Coalesce(       1));
            AreEqual(2,   Nully2.Coalesce(       1));
            AreEqual(1,        0.Coalesce(       1));
            AreEqual(1,        1.Coalesce(       1));
            AreEqual(2,        2.Coalesce(       1));
            //AreEqual(2,     null.Coalesce(       2)); // TODO: Does not Compile
            AreEqual(2,  NullNum.Coalesce(       2));
            AreEqual(2,   Nully0.Coalesce(       2));
            AreEqual(1,   Nully1.Coalesce(       2));
            AreEqual(2,   Nully2.Coalesce(       2));
            AreEqual(2,        0.Coalesce(       2));
            AreEqual(1,        1.Coalesce(       2));
            AreEqual(2,        2.Coalesce(       2));
            
        }
        // Single Fallback for Objects.
        {
            NotNull (                Coalesce(null,           null      ));
            NotNull (                Coalesce(NullObject,     null      ));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  null      ));
            AreEqual(NullableFilled, Coalesce(NullableFilled, null      ));
            NotNull (                Coalesce(null,           NullObject));
            NotNull (                Coalesce(NullObject,     NullObject));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NullObject));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NullObject));
            AreEqual(NonNullObject,  Coalesce(null,           NonNullObject));
            AreEqual(NonNullObject,  Coalesce(NullObject,     NonNullObject));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NonNullObject));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NonNullObject));
            AreEqual(NullableFilled, Coalesce(null,           NullableFilled));
            AreEqual(NullableFilled, Coalesce(NullObject,     NullableFilled));
            AreEqual(NonNullObject,  Coalesce(NonNullObject,  NullableFilled));
            AreEqual(NullableFilled, Coalesce(NullableFilled, NullableFilled));

            //NotNull (                null          .Coalesce(null      ));
            NotNull (                NullObject    .Coalesce(null      ));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(null      ));
            AreEqual(NullableFilled, NullableFilled.Coalesce(null      ));
            //NotNull (                null          .Coalesce(NullObject));
            NotNull (                NullObject    .Coalesce(NullObject));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NullObject));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NullObject));
            //AreEqual(NonNullObject,  null          .Coalesce(NonNullObject));
            AreEqual(NonNullObject,  NullObject    .Coalesce(NonNullObject));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NonNullObject));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NonNullObject));
            //AreEqual(NullableFilled, null          .Coalesce(NullableFilled));
            AreEqual(NullableFilled, NullObject    .Coalesce(NullableFilled));
            AreEqual(NonNullObject,  NonNullObject .Coalesce(NullableFilled));
            AreEqual(NullableFilled, NullableFilled.Coalesce(NullableFilled));
            
            // TODO: Check return types. After extending Testing.Core's helpers.
            //IsOfType<StringBuilder>(() => Coalesce(null,           NullObject));
        }
        
        // TODO: Add more tests that use the literal null. > Not a disaster if it doesn't work / compile.
        // TODO: Check for non-null return type. Also in the other tests.
        // TODO: Use more fields instead of local variables for better overview.
        // TODO: More tests
    }
}
