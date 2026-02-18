namespace JJ.Framework.Existence.Core.Collections.Tests;

[TestClass]
public class Has_Collection_Misc : TestBase
{
    [TestMethod]
    public void Has_Collection_ImmutableArrayAdditionalStatesOfEmptiness()
    {
        IsFalse(FilledIn(ImmutableArrayWithDefault));
        IsFalse(FilledIn(ImmutableArrayWithDefaultNullable));
        IsFalse(FilledIn(ImmutableArrayWithNew));  
        IsFalse(FilledIn(ImmutableArrayWithNewNullable));
    }
    
    [TestMethod]
    public void Has_Collection_SpanStatesOfEmptiness()
    {
        Span<int> filledSpan = [ 1, 2, 3 ];
        Span<int> emptySpan = [ ];
        Span<int> defaultSpan = default;
        ReadOnlySpan<int> filledReadOnlySpan = [ 1, 2, 3 ];
        ReadOnlySpan<int> emptyReadOnlySpan = [ ];
        ReadOnlySpan<int> defaultReadOnlySpan = default;
        {
            IsTrue(Has(filledSpan));
            IsTrue(Has(filledReadOnlySpan));
            IsTrue(FilledIn(filledSpan));
            IsTrue(FilledIn(filledReadOnlySpan));
            IsTrue(filledSpan.FilledIn());
            IsTrue(filledReadOnlySpan.FilledIn());
        }
        {
            IsFalse(Has(emptySpan));
            IsFalse(Has(emptyReadOnlySpan));
            IsFalse(FilledIn(emptySpan));
            IsFalse(FilledIn(emptyReadOnlySpan));
            IsFalse(emptySpan.FilledIn());
            IsFalse(emptyReadOnlySpan.FilledIn());
        }
        {
            IsFalse(Has(defaultSpan));
            IsFalse(Has(defaultReadOnlySpan));
            IsFalse(FilledIn(defaultSpan));
            IsFalse(FilledIn(defaultReadOnlySpan));
            IsFalse(defaultSpan.FilledIn());
            IsFalse(defaultReadOnlySpan.FilledIn());
        }
        {
            IsFalse(IsNully(filledSpan));
            IsFalse(IsNully(filledReadOnlySpan));
            IsFalse(filledSpan.IsNully());
            IsFalse(filledReadOnlySpan.IsNully());
        }
        {
            IsTrue(IsNully(emptySpan));
            IsTrue(IsNully(emptyReadOnlySpan));
            IsTrue(emptySpan.IsNully());
            IsTrue(emptyReadOnlySpan.IsNully());
        }
        {
            IsTrue(IsNully(defaultSpan));
            IsTrue(IsNully(defaultReadOnlySpan));
            IsTrue(defaultSpan.IsNully());
            IsTrue(defaultReadOnlySpan.IsNully());
        }
    }
}